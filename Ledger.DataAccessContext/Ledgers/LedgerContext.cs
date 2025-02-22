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

        public void CreateTransaction(Transaction transaction)
        {
            decimal transactionValue = transaction.Type == TransactionType.Withdrawal ?
                -transaction.Value :
                transaction.Value;
            _currentBalance += transactionValue;
            _transactions.Add(transaction);
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
