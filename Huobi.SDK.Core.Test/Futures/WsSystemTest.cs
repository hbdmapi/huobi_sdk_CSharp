using Xunit;
using Microsoft.Extensions.Configuration;
using System;
using Newtonsoft.Json;
using Huobi.SDK.Core.Futures.WS;
using Huobi.SDK.Core.Futures.WS.Response.System;

namespace Huobi.SDK.Core.Test.Futures
{
    public class WsSystemTest
    {
        static IConfigurationRoot config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

        [Fact]
        public void HeartBeatTest()
        {
            WSSystemClient client = new WSSystemClient();
            client.SubHeartBeat(delegate (SubHeartBeatResponse data)
            {
                Console.WriteLine(JsonConvert.SerializeObject(data));
            });
            System.Threading.Thread.Sleep(1000 * 60 * 10);
        }

    }
}
