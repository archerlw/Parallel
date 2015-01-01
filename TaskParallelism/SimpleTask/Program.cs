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
            
            
//TaskCreationOptions 参数值
//None  未指定任何选项时的默认值。 计划程序将使用其默认试探法来计划任务。
//PreferFairness    指定应当计划任务，以使越早创建的任务将更可能越早执行，而越晚创建的任务将更可能越晚执行。
//LongRunning   指定该任务表示长时间运行的运算。
//AttachedToParent  指定应将任务创建为当前任务（如果存在）的附加子级。 有关更多信息，请参见已附加和已分离的子任务。
//DenyChildAttach   指定如果内部任务指定 AttachedToParent 选项，则该任务不会成为附加的子任务。
//HideScheduler 指定通过调用特定任务内部的 TaskFactory.StartNew 或 Task<TResult>.ContinueWith 等方法创建的任务的任务计划程序是默认计划程序，而不是正在运行此任务的计划程序。
            
            Task t1 = new Task(
                () =>
                {
                    Console.WriteLine("thread id: '{0}'.", Thread.CurrentThread.ManagedThreadId);
                    Thread.Sleep(1000);
                }, TaskCreationOptions.LongRunning | TaskCreationOptions.PreferFairness);
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
