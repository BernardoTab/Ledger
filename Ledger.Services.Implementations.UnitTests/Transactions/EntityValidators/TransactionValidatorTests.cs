using Ledger.Entities.Transactions;
using Ledger.Services.Implementations.Transactions.EntityValidators;
using Ledger.Services.Implementations.UnitTests.Common;

namespace Ledger.Services.Implementations.UnitTests.Transactions.EntityValidators
{
    [TestClass]
    public class TransactionValidatorTests : EntityValidatorTests<TransactionValidator, Transaction>
    {
        protected override TransactionValidator CreateValidator()
        {
            return new TransactionValidator();
        }

        protected override Transaction CreateValidEntity()
        {
            return new Transaction
            {
                Value = 5,
                Type = TransactionType.Deposit,
                CreatedDate = DateTimeOffset.UtcNow,
            };
        }

        [TestMethod]
        [DataRow(0)]
        [DataRow(-5.9)]
        public async Task ValidateAsync_ValueIsEqualOrLessThanZero_ThrowsMissingRequiredPropertyException(double value)
        {
            Entity.Value = (decimal)value;

            Func<Task> testAction = async () => await EntityValidator.ValidateAsync(Entity);

            await Assert.That.ThrowsValueNotSupportedExceptionAsync(
                testAction,
                Entity.Value,
                nameof(Transaction),
                nameof(Transaction.Value));
        }

        [TestMethod]
        public async Task ValidateAsync_TypeIsDefault_ValueNotSupportedExceptionIsThrown()
        {
            Entity.Type = default;

            Func<Task> testAction = async () => await EntityValidator.ValidateAsync(Entity);

            await Assert.That.ThrowsMissingRequiredPropertyExceptionAsync(
                testAction,
                nameof(Transaction),
                nameof(Transaction.Type));
        }

        [TestMethod]
        public async Task ValidateAsync_CreatedDateIsDefault_ValueNotSupportedExceptionIsThrown()
        {
            Entity.CreatedDate = default;

            Func<Task> testAction = async () => await EntityValidator.ValidateAsync(Entity);

            await Assert.That.ThrowsMissingRequiredPropertyExceptionAsync(
                testAction,
                nameof(Transaction),
                nameof(Transaction.CreatedDate));
        }
    }
}
