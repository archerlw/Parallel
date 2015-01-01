using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("main thread id: '{0}'.", Thread.CurrentThread.ManagedThreadId);

            Console.WriteLine("use parallel.invoke to run tasks.");            
            Parallel.Invoke(
                () =>
                {
                    Console.WriteLine("thread id: '{0}'.", Thread.CurrentThread.ManagedThreadId);
                    Thread.Sleep(3000);
                },
                () =>
                {
                    Console.WriteLine("thread id: '{0}'.", Thread.CurrentThread.ManagedThreadId);
                    Thread.Sleep(1000);
                });


            Console.WriteLine("create a task object to run tasks.");
            Task t1 = new Task(
                () =>
                {
                    Console.WriteLine("thread id: '{0}'.", Thread.CurrentThread.ManagedThreadId);
                    Thread.Sleep(1000);
                });
            t1.Start();
            t1.Wait();


            Console.WriteLine("use the run method of task class.");
            Task t2 = Task.Run(
                () => 
                {
                    Console.WriteLine("thread id: '{0}'.", Thread.CurrentThread.ManagedThreadId);
                    Thread.Sleep(1000);
                });
            t2.Wait();


            Console.WriteLine("use the task factory.");
            Task t3 = Task.Factory.StartNew(
               () =>
               {
                   Console.WriteLine("thread id: '{0}'.", Thread.CurrentThread.ManagedThreadId);
                   Thread.Sleep(1000);
               });
            t3.Wait();

            Console.ReadKey();

        }
    }
}
