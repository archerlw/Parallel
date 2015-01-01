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
                //Break 可用于通知循环当前迭代之后的其他迭代不需要运行。 例如，对于从 0 到 1000 并行迭代的 for 循环，如果从第 100 此迭代开始调用 Break，则低于 100 的所有迭代仍会运行，从 101 到 1000 的迭代则不必要。
                //loopState.Break();

                //Stop 可用于通知循环其他迭代不需要运行。
                loopState.Stop();
            }
        }
    }
}