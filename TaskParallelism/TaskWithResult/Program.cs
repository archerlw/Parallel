using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace TaskWithResult
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Task<int>[] tasks =
            {
                Task<int>.Factory.StartNew(
                (i)=>
                {
                    Console.WriteLine("thread id: '{0}'.", Thread.CurrentThread.ManagedThreadId);
                    Thread.Sleep(2000);
                    return 1 + (int) i;
                }, 6),
                Task<int>.Factory.StartNew(
                ()=>
                {
                    Console.WriteLine("thread id: '{0}'.", Thread.CurrentThread.ManagedThreadId);
                    Thread.Sleep(3000);
                    return 2;
                }),
                Task<int>.Factory.StartNew(
                ()=>
                {
                    Console.WriteLine("thread id: '{0}'.", Thread.CurrentThread.ManagedThreadId);
                    Thread.Sleep(2000);
                    return 3;
                })
            };

            int sum = tasks.Sum(t => t.Result);

            Console.WriteLine("sum is {0}", sum);
            Console.ReadKey();
        }
    }
}