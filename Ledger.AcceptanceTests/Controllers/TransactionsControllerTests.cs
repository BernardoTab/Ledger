using Ledger.AcceptanceTests.Common;
using Ledger.DataTransferring.Transactions;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System.Text;

namespace Ledger.AcceptanceTests.Controllers
{
    [TestClass]
    public class TransactionsControllerTests
    {
        private static HttpClient _client;


        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            WebApplicationFactory<Program> factory = new WebApplicationFactory<Program>();
            _client = factory.CreateClient();
        }

        [ClassCleanup]
        public static void Cleanup()
        {
            _client.Dispose();
        }

        [TestMethod]
        public async Task CreateTransaction_NoResponse()
        {
            TransactionWriteDto expectedTransaction = new TransactionWriteDto
            {
                Value = 5,
                Type = TransactionTypeDto.Deposit
            };

            string endpointUri = "/api/transactions";
            string jsonPayload = JsonConvert.SerializeObject(expectedTransaction);
            HttpContent content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _client.PostAsync(endpointUri, content);

            Assert.IsTrue(response.IsSuccessStatusCode);
        }

        [TestMethod]
        public async Task GetTransactions_ReturnsSuccess()
        {
            TransactionWriteDto expectedTransaction = new TransactionWriteDto
            {
                Value = 5,
                Type = TransactionTypeDto.Deposit
            };
            string endpointUri = "/api/transactions";
            string jsonPayload = JsonConvert.SerializeObject(expectedTransaction);
            HttpContent content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _client.PostAsync(endpointUri, content);

            response = await _client.GetAsync(endpointUri);
            string responseBody = await response.Content.ReadAsStringAsync();
            ICollection<TransactionReadDto> transactionsFromResponse = JsonConvert.DeserializeObject<ICollection<TransactionReadDto>>(responseBody)!;

            Assert.IsTrue(response.IsSuccessStatusCode);
            Assert.AreEqual(1, transactionsFromResponse.Count);
            Assert.That.AreEqualExcludingProperties(expectedTransaction, transactionsFromResponse.Single());
        }
    }
}
