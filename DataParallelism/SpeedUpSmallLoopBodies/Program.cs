using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading.Tasks;

namespace SpeedUpSmallLoopBodies
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
            var source = Enumerable.Range(0, 100).ToArray();

            var rangePartitioner = Partitioner.Create(0, source.Length);

            Parallel.ForEach(rangePartitioner, range =>
            {
                for (int i = range.Item1; i < range.Item2; i++)
                {
                    Console.WriteLine(i);
                }
            });
        }
    }
}