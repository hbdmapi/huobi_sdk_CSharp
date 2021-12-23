using System;
using Huobi.SDK.Core.RequestBuilder;
using Xunit;

namespace Huobi.SDK.Core.Test.RequestBuilder
{
    public class PrivateUrlBuilderTest
    {
        [Fact]
        public void Build_NoRequestParameter_Success()
        {
            var builder = new PrivateUrlBuilder("abcdefg-hijklmn-opqrst-uvwxyz", "12345-67890-12345-67890", "api.huobi.pro");
            string result = builder.Build("GET", "/v1/account/accounts");

            string expected = @"https://api.huobi.pro/v1/account/accounts?AccessKeyId=abcdefg-hijklmn-opqrst-uvwxyz&SignatureMethod=HmacSHA256&SignatureVersion=2&Timestamp=2020-04-01T12%3A34%3A56&Signature=3IUZcEak4IIRrh7%2FidFrP2Jj77MaWGXR%2FoQbe9gL4%2BI%3D";
            Assert.Equal(expected, result);
        }
    }
}
