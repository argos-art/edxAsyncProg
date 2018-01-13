using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace SelfAssessAsyncConsole
{
    class CoinMining
    {
        public async Task<string> QueryWebServiceAsync(int howMany)
        {
            var uri = new Uri($"https://asynccoinfunction.azurewebsites.net/api/asynccoin/{howMany}");
            // var client = new WebClient();
            // var result = client.DownloadStringTaskAsync(uri);
            // return result.Result;
            var client = new HttpClient();
            var result = client.GetStringAsync(uri);
            return result.Result;
        }
    }
}