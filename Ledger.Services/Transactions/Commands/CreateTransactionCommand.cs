using Ledger.Entities.Transactions;
using Ledger.Services.Common.Commands;

namespace Ledger.Services.Transactions.Commands
{
    public class CreateTransactionCommand : ICommand
    {
        public Transaction Transaction { get; set; }
    }
}
