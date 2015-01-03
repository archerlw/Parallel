using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CancelTask
{
    class Program
    {
        static void Main(string[] args)
        {
            var tokenSource = new CancellationTokenSource();
            var token = tokenSource.Token;

            Task.Factory.StartNew(
               () =>
               {
                   if (Console.ReadKey().KeyChar == 'c')
                   {
                       tokenSource.Cancel();
                   }
               });


            Thread.Sleep(3000);

            Task t = Task.Factory.StartNew(
               () =>
               {
                   try
                   {

                       for (int i = 0; i < 1000; i++)
                       {
                           Thread.Sleep(200);
                           Console.WriteLine(i);

                           if (token.IsCancellationRequested)
                           {
                               token.ThrowIfCancellationRequested();
                           }
                       }

                   }
                   catch (Exception ex)
                   {
                       Console.WriteLine(ex.ToString());
                   }
               }, token);


            //如果在任务开始执行之前其 CancellationToken 标记为要取消，
            //或者任务通过引发具有相同 CancellationToken 的 OperationCanceledException 在已发信号的 CancellationToken 上确认取消请求时，
            //Task 将以“已取消”状态完成。
            if (t.IsCanceled)
            {
                Console.WriteLine("IsCanceled : " + t.IsCanceled);
            }
            else
            {
                t.Wait();
            }

            Console.ReadKey();
        }
    }
}
