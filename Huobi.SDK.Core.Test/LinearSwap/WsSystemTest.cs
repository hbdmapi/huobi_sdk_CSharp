using Xunit;
using Microsoft.Extensions.Configuration;
using System;
using Newtonsoft.Json;
using Huobi.SDK.Core.LinearSwap.WS;
using Huobi.SDK.Core.LinearSwap.WS.Response.System;

namespace Huobi.SDK.Core.Test.LinearSwap
{
    public class WsSystemTest
    {
        static IConfigurationRoot config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

        [Fact]
        public void HeartBeatTest()
        {
            bool has_data = false;
            WSSystemClient client = new WSSystemClient();
            client.SubHeartBeat(delegate (SubHeartBeatResponse data)
            {
                Console.WriteLine(JsonConvert.SerializeObject(data));
                has_data = true;
            });
            System.Threading.Thread.Sleep(1000);
            Assert.Equal(true, has_data);
            System.Threading.Thread.Sleep(1000 * 10);
        }

    }
}
