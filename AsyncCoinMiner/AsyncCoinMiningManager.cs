using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncCoinMiner
{
    public class AsyncCoinMiningManager
    {
        public void RunPrimesinParallel()
        {
            var primeTasks = new Task<string>[2];
            var watch = new Stopwatch();
            Console.WriteLine($"Primary Thread ID: {Thread.CurrentThread.ManagedThreadId}");
            watch.Start();

            Console.WriteLine($"Start of first prime calculation");
            primeTasks[0] = Task.Run(() => MineAsyncCoinsWithPrimes(3));
            Console.WriteLine($"Working on some other task on thread {Thread.CurrentThread.ManagedThreadId} while the calculating code runs.");
            primeTasks[1] = Task.Run(()=>MineAsyncCoinsWithPrimes(4));
            Console.WriteLine($"And another task on thread {Thread.CurrentThread.ManagedThreadId} while the mining code runs.");
            Task.WaitAll(primeTasks);
            foreach (var task in primeTasks)
            {
                Console.WriteLine(task.Result);
            }
            Console.WriteLine($"Total Time: Elapsed Seconds: {(float)watch.ElapsedMilliseconds / 1000}");

        }
        public void RunPrimesSynchronously()
        {
            var watch = new Stopwatch();
            watch.Start();

            Console.WriteLine($"Start of first prime calculation");
            var result = MineAsyncCoinsWithPrimes(3);
            Console.WriteLine($"Split Time: Elapsed Seconds: {(float)watch.ElapsedMilliseconds / 1000}");
            Console.WriteLine(result);

            Console.WriteLine($"Start of second prime calculation");
            result = MineAsyncCoinsWithPrimes(4);
            watch.Stop();
            Console.WriteLine($"Total Time: Elapsed Seconds: {(float)watch.ElapsedMilliseconds / 1000}");
            Console.WriteLine(result);
        }
        public string MineAsyncCoinsWithPrimes(int howMany)
        {
            double allPrimes = 0;
            for (int x = 2; x < howMany * 50000; x++)
            {
                int primeCounter = 0;
                for (int y = 1; y < x; y++)
                {
                    if (x % y == 0)
                    {
                        primeCounter++;
                    }

                    if (primeCounter == 2) break;
                }
                if (primeCounter != 2)
                {
                    // Console.Write($"{x}, ");
                    allPrimes++;
                }

                primeCounter = 0;
            }
            Console.WriteLine($"Finished Calculations on Worker Thread ID: {Thread.CurrentThread.ManagedThreadId}.");
            var infoString = $"Found {allPrimes} Primes up to {howMany*50000}";
            return infoString;
        }
    }
}