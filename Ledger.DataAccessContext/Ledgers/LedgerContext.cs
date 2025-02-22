using Ledger.Entities.Exceptions;
using Ledger.Entities.Transactions;

namespace Ledger.Services.Ledgers
{
    public class LedgerContext : ILedgerContext
    {
        private decimal _currentBalance;
        private readonly List<Transaction> _transactions;

        public LedgerContext()
        {
            _currentBalance = 0;
            _transactions = [];
        }

        public Transaction CreateTransaction(Transaction transaction)
        {
            switch (transaction.Type)
            {
                case TransactionType.Withdrawal:
                    WithdrawMoney(transaction.Value);
                    break;
                case TransactionType.Deposit:
                    _currentBalance += transaction.Value;
                    break;
            }
            _transactions.Add(transaction);
            return transaction;
        }

        private void WithdrawMoney(decimal transactionValue)
        {
            if (_currentBalance < transactionValue)
            {
                throw new BalanceIsInsufficientForWithdrawalException(transactionValue, _currentBalance);
            }
            _currentBalance -= transactionValue;
        }

        public decimal GetBalance()
        {
            return _currentBalance;
        }

        public ICollection<Transaction> GetTransactionHistory()
        {
            return _transactions.OrderBy(t => t.CreatedDate).ToList();
        }
    }
}
