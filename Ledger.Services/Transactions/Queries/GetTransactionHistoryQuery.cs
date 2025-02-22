using Ledger.Entities.Transactions;
using Ledger.Services.Common.Queries;

namespace Ledger.Services.Transactions.Queries
{
    public class GetTransactionHistoryQuery : IQuery<ICollection<Transaction>>
    {
    }
}
