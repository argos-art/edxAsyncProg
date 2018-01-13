using System;
using System.Threading.Tasks;

namespace AsyncCoinConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var coinManager = new AsyncCoinManager();
            coinManager.AcquireAsyncCoinAsync();
            Console.WriteLine($"Some Main-Work at {DateTime.Now}");
            Console.ReadLine();
        }
    }
}
