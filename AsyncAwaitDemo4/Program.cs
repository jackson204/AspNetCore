using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwaitDemo4
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // Console.WriteLine("Hello World!");
            // var cancellationToken = new CancellationTokenSource();
            // cancellationToken.CancelAfter(1000);
            // CancellationToken cancellationTokenToken = cancellationToken.Token;
            // await Download2Async("https://www.google.com", 1, cancellationTokenToken);
            // await DownloadAsync("https://www.google.com" , 100);

            var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken1 = cancellationTokenSource.Token;
            cancellationToken1.Register(o =>
            {
                Console.WriteLine("Cancelled");
            }, null);
            UpdateMemberInfoLoopTask(cancellationToken1);
            Console.ReadLine();
            cancellationTokenSource.Cancel();
            Console.ReadLine();
        }

        private static void UpdateMemberInfoLoopTask(CancellationToken cancellationToken)
        {
            _ = Task.Run(() =>
            {
                while (true)
                {
                    cancellationToken.ThrowIfCancellationRequested();
                    Console.WriteLine("update aaa");
                    Thread.Sleep(1000);
                }
            });
        }

        private static async Task DownloadAsync(string url, int n)
        {
            using HttpClient client = new HttpClient();
            for (int i = 0; i < n; i++)
            {
                var result = await client.GetStringAsync(url);
                Console.WriteLine($"{DateTime.Now}:{result}");
            }
        }

        private static async Task Download2Async(string url, int n, CancellationToken cancellationToken)
        {
            using HttpClient client = new HttpClient();
            for (int i = 0; i < n; i++)
            {
                var result = await client.GetStringAsync(url, cancellationToken);
                Console.WriteLine($"{DateTime.Now}:{result}");
                if (cancellationToken.IsCancellationRequested)
                {
                    Console.WriteLine("Cancelled");
                    break;
                }
            }
        }
    }
}