using Xunit;
using Microsoft.Extensions.Configuration;
using System;
using Newtonsoft.Json;
using Huobi.SDK.Core.CoinSwap.WS;
using Huobi.SDK.Core.CoinSwap.WS.Response.System;

namespace Huobi.SDK.Core.Test.CoinSwap
{
    public class WsSystemTest
    {
        static IConfigurationRoot config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

        [Fact]
        public void OrdersTest()
        {
            WSSystemClient client = new WSSystemClient();
            client.SubHeartBeat(delegate (SubHeartBeatResponse data)
            {
                Console.WriteLine(JsonConvert.SerializeObject(data));
            });
            System.Threading.Thread.Sleep(1000 * 60 * 1);
        }

    }
}
