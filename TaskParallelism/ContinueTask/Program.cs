using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ContinueTask
{
    class Program
    {
        static void Main(string[] args)
        {
            ContinueWith();
            ContinueWhenAll();
            ContinueWhenAny();

            Console.ReadKey();
        }

        private static void ContinueWith()
        {
            Task<int> getData = Task.Factory.StartNew(
                () =>
                {
                    Thread.Sleep(1000);
                    Console.WriteLine("thread 1 id: '{0}'.", Thread.CurrentThread.ManagedThreadId);
                    return 1;
                });
            Task<int> processData = getData.ContinueWith(
                t =>
                {
                    Thread.Sleep(1000);
                    Console.WriteLine("thread 2 id: '{0}'.", Thread.CurrentThread.ManagedThreadId);
                    return t.Result + 1;
                });
            Task<string> displayData = processData.ContinueWith(
                t =>
                {
                    Thread.Sleep(1000);
                    Console.WriteLine("thread 3 id: '{0}'.", Thread.CurrentThread.ManagedThreadId);
                    return string.Format("result is {0}", t.Result);
                });

            Console.WriteLine(displayData.Result);
        }

        private static void ContinueWhenAll()
        {
            Task<int>[] tasks =
            {
                Task<int>.Factory.StartNew(
                ()=>
                {
                    Thread.Sleep(1000);
                    Console.WriteLine("thread id: '{0}'.", Thread.CurrentThread.ManagedThreadId);
                    return 1;
                }),
                Task<int>.Factory.StartNew(
                ()=>
                {
                    Thread.Sleep(3000);
                    Console.WriteLine("thread id: '{0}'.", Thread.CurrentThread.ManagedThreadId);
                    return 2;
                }),
                Task<int>.Factory.StartNew(
                ()=>
                {
                    Thread.Sleep(2000);
                    Console.WriteLine("thread id: '{0}'.", Thread.CurrentThread.ManagedThreadId);
                    return 3;
                })
            };

            Task task = Task.Factory.ContinueWhenAll(tasks, 
                ts => 
                {
                    Console.WriteLine("continue when all tasks.");
                }); 
            task.Wait();
        }

        private static void ContinueWhenAny()
        {
            Task<int>[] tasks =
            {
                Task<int>.Factory.StartNew(
                ()=>
                {
                    Thread.Sleep(1000);
                    Console.WriteLine("thread id: '{0}'.", Thread.CurrentThread.ManagedThreadId);
                    return 1;
                }),
                Task<int>.Factory.StartNew(
                ()=>
                {
                    Thread.Sleep(3000);
                    Console.WriteLine("thread id: '{0}'.", Thread.CurrentThread.ManagedThreadId);
                    return 2;
                }),
                Task<int>.Factory.StartNew(
                ()=>
                {
                    Thread.Sleep(2000);
                    Console.WriteLine("thread id: '{0}'.", Thread.CurrentThread.ManagedThreadId);                    
                    return 3;
                })
            };

            Task task = Task.Factory.ContinueWhenAny(tasks, 
                ts =>
                {
                    Console.WriteLine("continue when any tasks.");
                });
            task.Wait();
        }
    }
}
