using Ledger.Entities.Exceptions;
using Ledger.Entities.Transactions;
using Ledger.Services.Implementations.Common.Validations;
using Ledger.Services.Transactions.Commands;

namespace Ledger.Services.Implementations.Transactions.Commands.Validators
{
    public class CreateTransactionCommandValidator :
        ICommandValidator<CreateTransactionCommand>
    {
        private readonly IEntityValidator<Transaction> _transactionValidator;
        private CreateTransactionCommand _command;

        public CreateTransactionCommandValidator(IEntityValidator<Transaction> transactionValidator)
        {
            _transactionValidator = transactionValidator;
        }

        public async Task ValidateAsync(CreateTransactionCommand command)
        {
            _command = command ?? throw new ArgumentNullException(nameof(command));
            await ValidatePropertiesAsync();
        }

        private async Task ValidatePropertiesAsync()
        {
            await ValidateTransactionAsync();
        }

        private async Task ValidateTransactionAsync()
        {
            if (_command.Transaction == default)
            {
                throw new MissingRequiredPropertyException(
                    nameof(Transaction),
                    nameof(CreateTransactionCommand));
            }
            await _transactionValidator.ValidateAsync(_command.Transaction);
        }
    }
}
