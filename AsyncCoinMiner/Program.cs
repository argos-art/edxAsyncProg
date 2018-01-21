using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncCoinMiner
{
    class Program
    {
        static void Main(string[] args)
        {
            var miner = new AsyncCoinMiningManager();
            // miner.RunPrimesSynchronously();
            miner.RunPrimesinParallel();
            Console.ReadLine();
        }
    }
}
