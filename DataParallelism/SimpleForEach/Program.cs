using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleForEach
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            List<int> lst = new List<int>();
            for (int i = 1; i < 11; i++)
            {
                lst.Add(i);
            }

            Parallel.ForEach(lst, Process);

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