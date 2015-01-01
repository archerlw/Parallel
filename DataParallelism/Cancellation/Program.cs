using System;
using System.Threading;
using System.Threading.Tasks;

namespace Cancellation
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

        public void Run()
        {
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            ParallelOptions parallelOptions = new ParallelOptions();
            parallelOptions.CancellationToken = cancellationTokenSource.Token;
            parallelOptions.MaxDegreeOfParallelism = Environment.ProcessorCount;

            Task.Factory.StartNew(
                () =>
                {
                    if (Console.ReadKey().KeyChar == 'c')
                    {
                        cancellationTokenSource.Cancel();
                    }
                }
                );

            try
            {
                Parallel.For(1, 1000, parallelOptions,
                i =>
                {
                    Thread.Sleep(20);
                    Console.WriteLine(i);
                    parallelOptions.CancellationToken.ThrowIfCancellationRequested();
                });
            }
            catch (OperationCanceledException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}