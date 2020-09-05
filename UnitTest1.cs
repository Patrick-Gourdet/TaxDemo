using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Moq.Protected;

namespace TaxApi.Test
{
    [TestClass]
    public class TaxTexts
    {
        [TestMethod]
        public void HttpTaxRatesEnpointTest_RequestUsingZip_ResponceWithRates()
        {
            var handler = new Mock<HttpMessageHandler>(MockBehavior.Strict);
            handler.Protected().Setup<Task<HttpResponseMessage>>(
                    "SenAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>()).ReturnsAsync(
                    new HttpResponseMessage()
                    {
                        StatusCode = HttpStatusCode.OK,
                        Content = new StringContent("[{'endpoint':'rates','query':'90404-3370','apiName':'TaxJar','authorized':'8743b52063cd84097a65d1633f5c74f5'}]"),
                    })
                .Verifiable();
        }
        
        [TestMethod]
        public async Task UserRegistrationEndPoint_RegisterUser_Success201()
        {
            var userid = 111;
            var username = "Test";
            var password = "testing";
            var authLevel = 7;
            var Http = new HttpClient();
            var res =  await Http.GetAsync($"https://localhost:32770/register?UserId={userid}&Username={username}&Pasword={password}&AutheticationLevel={authLevel}");
            Assert.Equals(res.StatusCode, 201);

        }
        [TestMethod]
        public async Task UserSaveNewApiKeyToUser_RegisterUserToAPI_Success200()
        {
            var apiKey = "asdasdfg";
            var username = "Test";
            var password = "testing";
            var Http = new HttpClient();
            var res =  await Http.GetAsync($"https://localhost:32770/new-apikey/{apiKey}/newapi/{username}/{password}");
            Assert.Equals(res.StatusCode, 200);

        }
        [TestMethod]
        public async Task CalculateTax_RegisterUserToAPI_Success200()
        {
            var amount = 200.0m;
            var zip = "33304";
            var username = "Test";
            var password = "test123";
            var Http = new HttpClient();
            var res =  await Http.GetAsync($"https://localhost:32770/api/Calculations/taxjar/{amount}/{zip}/(username)/{password}?user={username}");
            Assert.Equals(res.StatusCode, 200);

        }
    }
}