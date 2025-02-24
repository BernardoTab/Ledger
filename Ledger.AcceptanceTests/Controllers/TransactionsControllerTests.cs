using Ledger.DataTransferring.Transactions;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
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
        public async Task GetTransactions_ReturnsSuccess()
        {
            // Arrange
            TransactionWriteDto expectedTransaction = new TransactionWriteDto
            {
                Id = Guid.NewGuid(),
                Value = 5,
                Type = TransactionTypeDto.Deposit
            };
            string endpointUri = "/api/transactions";
            string jsonPayload = JsonConvert.SerializeObject(expectedTransaction);
            HttpContent content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _client.PostAsync(endpointUri, content);

            // Act
            response = await _client.GetAsync(endpointUri);
            string responseBody = await response.Content.ReadAsStringAsync();
            ICollection<TransactionReadDto> transactionsFromResponse = JsonConvert.DeserializeObject<ICollection<TransactionReadDto>>(responseBody)!;

            // Assert
            Assert.IsTrue(response.IsSuccessStatusCode);
            Assert.AreEqual(1, transactionsFromResponse.Count);
        }
    }
}
