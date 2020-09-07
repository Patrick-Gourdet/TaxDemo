using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Auth.Business;
using Auth.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Moq.Protected;

namespace TaxApi.Test
{
    [TestClass]
    public class TaxTexts
    {
        private static Random rand3 = new Random((int) DateTime.Now.Ticks & 0x0000FFFF);
        private string userid = rand3.ToString();
        private string username = rand3.Next().ToString();
        private string password = rand3.Next().ToString();
        private string apiKey = rand3.Next().ToString();
        
        [TestMethod]
        public async Task Calculate_RequestUsingZip_ResponceWithRates()
        {
            ICalculate calc = new Calculate();
            var tateTest =  new RatesRate()
            {
                id = Guid.NewGuid(), rate = new SubRate()
                {
                    city = "", city_rate = "",
                    combined_rate = 0.02.ToString(),
                    combined_district_rate = "",
                    country = "US",
                    country_rate = "",
                    county = "",
                    county_rate = "",
                    freight_taxable = true,
                    id = Guid.NewGuid()
                }
            };
            
           var res = await calc.CalculatedTax(tateTest, 10.00m);
            Assert.IsNotNull(res);
            Assert.AreEqual(res.CalculatedAmount, 0.20m);
        }
        [TestMethod]
        public async Task UserRegistrationEndPoint_RegisterUser_Success201()
        {

            var authLevel = 7;
            var Http = new HttpClient();
            var res =  await Http.GetAsync($"https://localhost:32770/register?UserId={userid}&Username={username}&Pasword={password}&AutheticationLevel={authLevel}");
            Assert.Equals(res.StatusCode, 201);

        }
        [TestMethod]
        public async Task UserSaveNewApiKeyToUser_RegisterUserToAPI_Success200()
        {

            var Http = new HttpClient();
            var res =  await Http.GetAsync($"https://localhost:32770/new-apikey/{apiKey}/newapi/{username}/{password}");
            Assert.Equals(res.StatusCode, 200);

        }
        [TestMethod]
        public async Task CalculateTax_RegisterUserToAPI_Success200()
        {
            var amount = 200.0m;
            var zip = "33304";
            var Http = new HttpClient();
            var res =  await Http.GetAsync($"https://localhost:32770/api/Calculations/taxjar/{amount}/{zip}/(username)/{password}?user={username}");
            Assert.Equals(res.StatusCode, 200);

        }
    }
}