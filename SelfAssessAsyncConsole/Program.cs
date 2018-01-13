using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SelfAssessAsyncConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var miner = new CoinMining();
            var result = miner.QueryWebServiceAsync(5);
            Console.WriteLine(result.Result);
            Console.ReadLine();
        }
    }
}
