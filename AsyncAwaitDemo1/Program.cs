using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace AsyncAwaitDemo1
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Before writing to file");
            var filename = @"C:\Users\s9740\RiderProjects\AspNetCore\AsyncAwaitDemo1\test.txt";
            var sb = new StringBuilder();
            for (int i = 0; i < 1000; i++)
            {
                sb.AppendLine($"Hello {i}");
            }
            File.WriteAllTextAsync(filename, sb.ToString());
            Console.WriteLine("Before reading from file");
            var result = await File.ReadAllTextAsync(filename);
            Console.WriteLine(result);
        }
    }
}