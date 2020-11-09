# Huobi C# SDK

This is Huobi C# SDK, This is a lightweight .NET library, you can import it to your project.

The SDK API supports both RESTful and websocket to get/sub the market, account and order infomation.

## Table of Contents

- [Quick Start](#Quick-Start)

- [Usage](#Usage)

  - [Configuration](#Configuration)
  - [Folder structure](#Folder-Structure)
  - [Client](#Client)
  - [Response](#Response)
  
- [Request examples](#Request-examples)
  - [Market data](#Market-data)

- [Subscription examples](#Subscription-examples)
  - [Subscribe trade update](#Subscribe-trade-update)

  

## Quick Start

*The SDK is compiled by .NET Standard 2.1*, you can import the source code directly or build as dll lib.

The project **Huobi.SDK.Core** is a dll project as SDK API.
The project **Huobi.SDK.Core** is a unit test project and you can find usage of each API interface.

If you want to create your own application, you can follow below steps:

* Create a client (xxxClient/WSxxxClient) instance.
* Call the method of client instance.

```csharp
// RESTful api
AccountClient client = new AccountClient("AccessKey", "SecretKey");
var result = client.GetAccountAssetsAsync(contractCode).Result;

// websocker api
WSMarketClient client = new WSMarketClient();
client.SubKLine("BTC-USDT", "1min", delegate (SubKLineResponse data)
{
    Console.WriteLine(JsonConvert.SerializeObject(data));
});
```

## Usage

### Configuration

The client constructor must set AccessKey/SecretKey two value when you access private data. And it not need to set AccessKey/SecretKey value when you access public data such as market data.

You can create appsettings.json in your project for config AccessKey/SecretKey and other input data.

```json
{
  "Host": "api.hbdm.com",
  "AccessKey": "x-x-x-x",
  "SecretKey": "x-x-x-x",
  "AccountId": 10000000,
  "SubUid": 10000000
}
```

And use it as follow:
```csharp
IConfigurationRoot config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
string access_key = config["AccessKey"];
string secret_key = config["SecretKey"];
string host = config["Host"]
 ```

### Folder Structure

This is the folder and namespace structure of SDK source code and the description

- **Huobi.SDK.Core**: The SDK API project
  - **LinearSwap**: the linear swap api src inclue RESTful and API
  - **RequestBuilder**: Responsible to build the request with the signature
  - **Log**: The internal logger interface and implementations
  - **WSBase**: The websocket data model
- **Huobi.SDK.Core.Test**: The unit test project
  - **RequestBuilder**: The unit test for RequestBuilder
  - **xxxTest.cs**: The c# unit test file

You can find all demo in LinearSwapTest.cs to get/sub linear swap private/public data/

### Client

In this SDK, the client is the object to access the Huobi API.All the client are listed in below table. Each client is very small and simple.

| Access Type | Client | Privacy | Data Category  |
| ----------- | -------| ------- | ------------ |
| RESTful     | AccountClient | Private | account info |
|             | MarketClient | Public | market info |
|             | OrderClient | Private | about order |
|             | TransferClient | Private | transfer assets |
|             | TriggerOrderClient | Private | about trigger order |
| Websocket   | WSIndexClinet | Public | index infor |
|             | WSMarketClinet | Public | market info |
|             | WSNotifyClinet | Public/Private | market info/ account info |
|             |                |         |              |

#### Public vs. Private

There are two types of privacy that is correspondent with privacy of API:

**Public client**: It invokes public API to get public data (Common data and Market data), therefore you can create a new instance without applying an API Key.

```csharp
MarketClient client = new MarketClient();
var result = client.GetContractInfoAsync(“BTC-USDT”).Result;
```

**Private client**: It invokes private API to access private data, you need to follow the API document to apply an API Key first, and pass the API Key to the constructor.

```csharp
AccountClient client = new AccountClient("AccessKey", "SecretKey");
var result = client.GetAccountAssetsAsync(“BTC-USDT”).Result;
```

The API key is used for authentication. If the authentication cannot pass, the invoking of private interface will fail.

#### Rest vs. WebSocket

**Rest Client**: It invokes Rest API and get once-off response.

```csharp
AccountClient client = new AccountClient("AccessKey", "SecretKey");
var result = client.GetAccountAssetsAsync(“BTC-USDT”).Result;
```

You can refer to C# programming guide [Asynchronous programming with async and await](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/async/) to know more details.

**WebSocket Client**: It establishes WebSocket connection with server and data will be pushed from server actively. There are two types of method for WebSocket client:

- Request method: The method name starts with "Req", it will receive the once-off data after sending the request.
- Subscription: The method name starts with "Sub", it will receive update after sending the subscription.

```csharp
WSMarketClient client = new WSMarketClient();

// Reqxxx
client.ReqKLine("BTC-USDT", "1min", delegate (ReqKLineResponse data)
{
    Console.WriteLine(JsonConvert.SerializeObject(data));
}, 1604395758, 1604396758);

// Subxxx
client.SubKLine("BTC-USDT", "1min", delegate (SubKLineResponse data)
{
    Console.WriteLine(JsonConvert.SerializeObject(data));
});
```

#### Custom host

Each client constructor support an optional host parameter, by default it is "api.btcgateway.pro". If you need to use different host, you can specify the custom host. 

```csharp
AccountClient client = new AccountClient("AccessKey", "SecretKey", "Host");
var result = client.GetAccountAssetsAsync(“BTC-USDT”).Result;

WSMarketClient client = new WSMarketClient("Host");
```

### Response

In this SDK, the response is the object that define the data returned from API, which is deserialized from JSON string. It is the return type from each client method, you can declare the object use keyword *var* and don't need to specify the concrete type.

```csharp
AccountClient client = new AccountClient("AccessKey", "SecretKey");

// Use 'var' to declare a variable to hold the response
var result = client.GetAccountAssetsAsync(“BTC-USDT”).Result;
```

## Request Examples
### Market data
```csharp
MarketClient client = new MarketClient();
var result = client.GetContractInfoAsync(“BTC-USDT”).Result;
```

## Subscription Examples
### Subscribe trade update
```csharp
WSNotifyClient client = new WSNotifyClient("AccessKey", "SecretKey");
client.SubOrders(“BTC-USDT”, delegate (SubOrdersResponse data)
{
    Console.WriteLine(JsonConvert.SerializeObject(data));
});
System.Threading.Thread.Sleep(1000 * 30);
client.UnsubOrders(“BTC-USDT”);
System.Threading.Thread.Sleep(1000 * 5);
```