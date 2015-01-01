using System;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadLocalVariables
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Demo.Instance.Run();
            Console.ReadKey();
        }
    }

    internal class Demo
    {
        public static Demo Instance = new Demo();

        private int _sum = 0;

        public void Run()
        {
            Parallel.For<int>(1, 11, InitLocal, Process, Sum);

            Console.WriteLine("Sum: " + _sum);
        }

        private int InitLocal()
        {
            int local = 0;
            return local;
        }

        private int Process(int i, ParallelLoopState loopState, int local)
        {
            Thread.Sleep(20);
            Console.WriteLine(i);
            local += i;
            return local;
        }

        private void Sum(int local)
        {
            Console.WriteLine("{0} on Thread {1}", "local: " + local, Thread.CurrentThread.ManagedThreadId);
            _sum += local;
        }
    }
}