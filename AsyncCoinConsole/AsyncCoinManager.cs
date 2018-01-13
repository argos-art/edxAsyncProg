using System;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncCoinConsole
{
    public class AsyncCoinManager
    {
        public async Task AcquireAsyncCoinAsync()
        {
            double y = 0;
            Console.WriteLine($"ACQUIRE: Call to long-running service at {DateTime.Now}");
            Task<string> resultTask = PretendToConnectToCoinServiceAsync();
            Console.WriteLine($"ACQUIRE: Return from long-running service. Starting some other work at {DateTime.Now}");
            for (int i = 0; i < 100000000; i++)
            {
                y = y + Math.Cos(i);
            }
            Console.WriteLine($"ACQUIRE: y = {y}. Finish some other Work at {DateTime.Now}");
            string result = await resultTask;
            Console.WriteLine($"ACQUIRE: Await Result from long-running service at {DateTime.Now}");
            Console.WriteLine($"result: {result}");
        }
        private async Task<string> PretendToConnectToCoinServiceAsync()
        {
            Console.WriteLine($"PRETEND: Long Running Task startet!");
            // Simulate a long-running network connection
            await Task.Delay(5000);
            Console.WriteLine($"PRETEND: Long Running Task Finished at {DateTime.Now}");
            return $"You've got 25 AsyncCoin!";

        }
    }
}