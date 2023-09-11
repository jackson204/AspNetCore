using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace AsyncAwaitDemo2
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var path = @"C:\Users\s9740\RiderProjects\AspNetCore\AsyncAwaitDemo2\test.txt";
            var result = await DownLoadHtmlAsync(path, "https://www.google.com");
            Console.WriteLine(result);
            Console.WriteLine("Download complete");
        }

        // private static async Task DownLoadHtmlAsync(string path, string url)
        // {
        //     using var httpClient = new HttpClient();
        //     var html = await httpClient.GetStringAsync(url);
        //     await File.WriteAllTextAsync(path, html);
        // }
        private static async Task<int> DownLoadHtmlAsync(string path, string url)
        {
            using var httpClient = new HttpClient();
            var html = await httpClient.GetStringAsync(url);
            await File.WriteAllTextAsync(path, html);
            return html.Length;
        }
    }
}