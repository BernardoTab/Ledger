using Ledger.Entities.Common;

namespace Ledger.Entities.Transactions
{
    public class Transaction : Entity
    {
        public decimal Value { get; set; }
        public TransactionType Type { get; set; }
        public DateTimeOffset CreatedDate { get; set; }

        public Transaction()
        {
            CreatedDate = DateTimeOffset.Now;
        }
    }
}
