using Ledger.Entities.Exceptions;
using Ledger.Entities.Transactions;
using Ledger.Services.Implementations.Common.Validations;

namespace Ledger.Services.Implementations.Transactions.EntityValidators
{
    public class TransactionValidator : IEntityValidator<Transaction>
    {
        private Transaction _transaction;

        public async Task ValidateAsync(Transaction transaction)
        {
            _transaction = transaction;
            ValidateProperties();
            await Task.CompletedTask;
        }

        private void ValidateProperties()
        {
            ValidateId();
            ValidateValue();
            ValidateType();
            ValidateCreatedDate();
        }

        private void ValidateId()
        {
            if (_transaction.Id == default)
            {
                throw new MissingRequiredPropertyException(
                    nameof(Transaction.Id),
                    nameof(Transaction));
            }
        }

        private void ValidateValue()
        {
            if (_transaction.Value <= 0)
            {
                throw new ValueNotSupportedException(
                    _transaction.Value,
                    nameof(Transaction.Value),
                    nameof(Transaction));
            }
        }

        private void ValidateType()
        {
            if (_transaction.Type == default)
            {
                throw new MissingRequiredPropertyException(
                    nameof(Transaction.Type),
                    nameof(Transaction));
            }
        }

        private void ValidateCreatedDate()
        {
            if (_transaction.CreatedDate == default)
            {
                throw new MissingRequiredPropertyException(
                    nameof(Transaction.CreatedDate),
                    nameof(Transaction));
            }
        }
    }
}
