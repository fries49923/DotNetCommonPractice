using System.Threading.Tasks;

internal class Program
{
    static async Task Main(string[] args)
    {
        await Test01();

        Console.WriteLine("----------------------\n\n");

        await Test02();

        Console.ReadKey();
    }

    static async Task Test01()
    {
        var task = SomeOperationAsync();
        var task2 = SomeOperationAsync2();
        Console.WriteLine("Task Test01 Run.");
        await Task.WhenAny(task, task2);
        Console.WriteLine("Task after WhenAny.");
    }

    static async Task Test02()
    {
        int timeout = 1000;
        var task = SomeOperationAsync();
        Console.WriteLine("Task Test02 Run.");
        if (await Task.WhenAny(task, Task.Delay(timeout)) == task)
        {
            // task completed within timeout
            Console.WriteLine("Task completed within timeout.");
        }
        else
        {
            // timeout logic
            Console.WriteLine("Task timed out.");
        }

        //Task.WhenAny(task, Task.Delay(timeout)) 方法返回一個 Task，該 Task 在提供的任務中的任何一個完成時完成。
        //在這種情況下，我們提供了兩個任務：task 和 Task.Delay(timeout)。
        //如果 task 在超時時間內完成，則 Task.WhenAny(task, Task.Delay(timeout)) 將返回 task。
        //因此，我們可以通過比較返回的任務與 task 來確定操作是否在超時時間內完成。
        //如果返回的任務不是 task，則意味着超時時間已經過去，但操作仍未完成。
        //在這種情況下，我們可以執行超時邏輯。
    }

    static async Task SomeOperationAsync()
    {
        // Simulate a long running operation
        await Task.Delay(2000);
        Console.WriteLine("Task SomeOperationAsync finish.");
    }

    static async Task SomeOperationAsync2()
    {
        // Simulate a long running operation
        await Task.Delay(3000);
        Console.WriteLine("Task SomeOperationAsync2 finish.");
    }
}