using System.Diagnostics;

namespace ConditionalAttributeTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("程式開始");

#if DEBUG
            Console.WriteLine("這段在 DEBUG 模式下才會被編譯進來");
#else
            Console.WriteLine("這段在 非 DEBUG 模式 (如 Release) 下才會被編譯進來");
#endif

            // 一定會執行
            LogMessage();

            // 只有在 DEBUG 模式下會執行
            LogMessageDebug();

            Console.WriteLine("程式結束");

            Console.ReadKey();
        }

        static void LogMessage()
        {
            Console.WriteLine("LogMessage() 不論模式都會執行");
        }

        [Conditional("DEBUG")]
        static void LogMessageDebug()
        {
            Console.WriteLine("LogMessageDebug() 只在 DEBUG 模式下會執行");
        }
    }
}
