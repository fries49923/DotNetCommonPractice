using System.Diagnostics;
using System.Reflection;

namespace MulticastDelegateGetInvocationListTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Action<string>? outputMessage = null;
            outputMessage += Console.WriteLine;
            outputMessage += OutputToFile;
            outputMessage += DebugWriteLine;

            //       Dim output1 As Action(Of string) = AddressOf Console.WriteLine
            //       Dim output2 As Action(Of string) = AddressOf OutputToFile
            //       Dim output3 As Action(Of string) = AddressOf MessageBox.Show
            //
            //       outputMessage = [Delegate].Combine( { output1, output2, output3 } )

            Console.WriteLine("Invocation list has {0} methods.",
                              outputMessage.GetInvocationList().Length);

            // Invoke delegates normally.
            outputMessage("Hello there!");
            Console.WriteLine("Press <Enter> to continue...");
            Console.ReadLine();

            // Invoke each delegate in the invocation list in reverse order.
            for (int ctr = outputMessage.GetInvocationList().Length - 1; ctr >= 0; ctr--)
            {
                var outputMsg = outputMessage.GetInvocationList()[ctr];
                outputMsg.DynamicInvoke("Greetings and salutations!");
            }
            Console.WriteLine("Press <Enter> to continue...");
            Console.ReadLine();

            // Invoke each delegate that doesn't write to a file.
            for (int ctr = 0; ctr < outputMessage.GetInvocationList().Length; ctr++)
            {
                var outputMsg = outputMessage.GetInvocationList()[ctr];
                if (!outputMsg.GetMethodInfo().Name.Contains("File"))
                    outputMsg.DynamicInvoke(new string[] { "Hi!" });
            }

            outputMessage("Cancel...");
            ClearEvent(ref outputMessage);

            if (outputMessage is null)
                Console.WriteLine("outputMessage is null");

            Console.ReadKey();
        }

        private static void OutputToFile(string s)
        {
            var sw = new StreamWriter(@".\output.txt");
            sw.WriteLine(s);
            sw.Close();
        }

        private static void DebugWriteLine(string s)
        {
            Debug.WriteLine(s);
        }

        private static void ClearEvent<T>(ref T? myEvent) where T : Delegate
        {
            if (myEvent is null)
            {
                return;
            }

            foreach (Delegate d in myEvent.GetInvocationList())
            {
                myEvent = (T?)Delegate.Remove(myEvent, d);
            }
        }

        // can't use
        private static void ClearEvent2(ref Delegate myEvent)
        {
            foreach (Delegate d in myEvent.GetInvocationList())
            {
                myEvent = Delegate.Remove(myEvent, d);
            }
        }
    }
}