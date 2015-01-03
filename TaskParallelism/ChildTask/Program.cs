using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ChildTask
{
    public class Program
    {
        static void Main(string[] args)
        {
            //DetachedChildren();
            AttachedChildren();
            Console.ReadKey();
        }

        //如果在任务中运行的用户代码创建一个新任务，且未指定 AttachedToParent 选项，则该新任务不采用任何特殊方式与父任务同步。
        static void DetachedChildren()
        {
            var outer = Task.Factory.StartNew(() =>
            {
                Console.WriteLine("Outer task beginning.");

                var child = Task.Factory.StartNew(() =>
                {
                    Thread.Sleep(2000);
                    Console.WriteLine("Detached task completed.");
                });

            });

            outer.Wait();
            Console.WriteLine("Outer task completed.");
        }

        //如果在一个任务中运行的用户代码创建任务时指定了 AttachedToParent 选项，则该新任务称为父任务的“附加子任务”。 因为父任务隐式地等待所有附加子任务完成，所以你可以使用 AttachedToParent 选项表示结构化的任务并行。
        static void AttachedChildren()
        {
            var outer = Task.Factory.StartNew(() =>
            {
                Console.WriteLine("Outer task beginning.");

                var child = Task.Factory.StartNew(() =>
                {
                    Thread.Sleep(2000);
                    Console.WriteLine("Detached task completed.");
                }, TaskCreationOptions.AttachedToParent);

            });

            outer.Wait();
            Console.WriteLine("Outer task completed.");
        }
    }
}
