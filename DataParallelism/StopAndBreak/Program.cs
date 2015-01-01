using System;
using System.Threading;
using System.Threading.Tasks;

namespace StopAndBreak
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Parallel.For(1, 21, Process);

            Console.WriteLine("done");
            Console.ReadKey();
        }

        private static void Process(int i, ParallelLoopState loopState)
        {
            Thread.Sleep(20);
            Console.WriteLine("{0} on Thread {1}", i, Thread.CurrentThread.ManagedThreadId);

            if (i == 3)
            {
                //loopState.Break();
                loopState.Stop();
            }
        }
    }
}