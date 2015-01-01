using System;
using System.Threading.Tasks;

namespace SimpleFor
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Parallel.For(1, 11, Process);

            Console.WriteLine("done");
            Console.ReadKey();
        }

        private static void Process(int i)
        {
            System.Threading.Thread.Sleep(500);
            Console.WriteLine(i);
        }
    }
}