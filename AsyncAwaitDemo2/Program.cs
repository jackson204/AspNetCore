using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AsyncAwaitDemo2
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var result = await DownLoadAsync();
            Console.WriteLine("Completed");
        }

        private static async Task<int> DownLoadAsync()
        {
            var httpClient = new HttpClient();
            var result = await httpClient.GetStringAsync("https://www.google.com");
            return result.Length;
        }
    }
}