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

        public void Validate(CreateTransactionCommand command)
        {
            _command = command ?? throw new ArgumentNullException(nameof(command));
            ValidateProperties();
        }

        private void ValidateProperties()
        {
            ValidateTransaction();
        }

        private void ValidateTransaction()
        {
            if (_command.Transaction == default)
            {
                throw new MissingRequiredPropertyException(
                    nameof(Transaction),
                    nameof(CreateTransactionCommand));
            }
            _transactionValidator.Validate(_command.Transaction);
        }
    }
}
