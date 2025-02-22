namespace Ledger.DataTransferring.Transactions
{
    public abstract class TransactionDto
    {
        public Guid Id { get; set; }
        public decimal Value { get; set; }
        public TransactionTypeDto Type { get; set; }

        protected TransactionDto()
        {
            Id = Guid.NewGuid();
        }
    }
}
