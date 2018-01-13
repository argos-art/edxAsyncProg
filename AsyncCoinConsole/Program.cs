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
            var savedColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"MAIN: Continue Execution at {DateTime.Now}");
            Console.ForegroundColor = savedColor;
            Console.ReadLine();
        }
    }
}
