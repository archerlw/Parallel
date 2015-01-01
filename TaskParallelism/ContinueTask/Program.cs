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
            Task<int> getData = Task.Factory.StartNew(
                () =>
                {
                    Thread.Sleep(1000);
                    Console.WriteLine("thread id: '{0}'.", Thread.CurrentThread.ManagedThreadId);
                    return 1;
                });
            Task<int> processData = getData.ContinueWith(
                t =>
                {
                    Thread.Sleep(1000);
                    Console.WriteLine("thread id: '{0}'.", Thread.CurrentThread.ManagedThreadId);
                    return t.Result + 1;
                });
            Task<string> displayData = processData.ContinueWith(
                t =>
                {
                    Thread.Sleep(1000);
                    Console.WriteLine("thread id: '{0}'.", Thread.CurrentThread.ManagedThreadId);
                    return string.Format("result is {0}", t.Result);
                });

            Console.WriteLine(displayData.Result);
            Console.ReadKey();
        }
    }
}
