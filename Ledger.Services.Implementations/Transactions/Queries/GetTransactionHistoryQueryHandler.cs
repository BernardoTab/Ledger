using Ledger.Entities.Transactions;
using Ledger.Services.Implementations.Common;
using Ledger.Services.Ledgers;
using Ledger.Services.Transactions.Queries;

namespace Ledger.Services.Implementations.Transactions.Queries
{
    public class GetTransactionHistoryQueryHandler :
        IQueryHandler<
            GetTransactionHistoryQuery,
            ICollection<Transaction>>
    {
        private readonly ILedgerContext _dataContext;

        public GetTransactionHistoryQueryHandler(ILedgerContext dataContext)
        {
            _dataContext = dataContext;
        }

        public ICollection<Transaction> Handle(GetTransactionHistoryQuery query)
        {
            return _dataContext.GetTransactionHistory();
        }
    }
}
