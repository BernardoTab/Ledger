using Ledger.Entities.Exceptions;
using Ledger.Entities.Transactions;
using Ledger.Services.Implementations.Common;
using Ledger.Services.Ledgers;
using Ledger.Services.Transactions.Commands;

namespace Ledger.Services.Implementations.Transactions.Commands
{
    public class CreateTransactionCommandHandler : ICommandHandler<CreateTransactionCommand>
    {
        private readonly ILedgerContext _dataContext;

        public CreateTransactionCommandHandler(ILedgerContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void Handle(CreateTransactionCommand command)
        {
            Transaction transaction = command.Transaction;
            ValidateTransactionEffectOnBalance(transaction);
            _dataContext.CreateTransaction(transaction);
        }

        private void ValidateTransactionEffectOnBalance(Transaction transaction)
        {
            if (transaction.Type == TransactionType.Withdrawal)
            {
                decimal balance = _dataContext.GetBalance();
                if (balance < transaction.Value)
                {
                    throw new BalanceIsInsufficientForWithdrawalException(transaction.Value, balance);
                }
            }
        }
    }
}
