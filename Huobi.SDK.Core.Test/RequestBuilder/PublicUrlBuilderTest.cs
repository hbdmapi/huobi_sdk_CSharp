using Huobi.SDK.Core;
using Huobi.SDK.Core.RequestBuilder;
using Xunit;

namespace Huobi.SDK.Core.Test.RequestBuilder
{
    public class PublicUrlBuilderTest
    {
        [Fact]
        public void Build_NoRequestParameter_Success()
        {
            var builder = new PublicUrlBuilder("api.huobi.pro");

            string result = builder.Build("/common/symbols");

            Assert.Equal("https://api.huobi.pro/common/symbols", result);
        }
    }
}
