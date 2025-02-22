using Ledger.Entities.Transactions;

namespace Ledger.Services.Ledgers
{
    public interface ILedgerContext
    {
        decimal GetBalance();
        Transaction CreateTransaction(Transaction transaction);
        ICollection<Transaction> GetTransactionHistory();
    }
}
