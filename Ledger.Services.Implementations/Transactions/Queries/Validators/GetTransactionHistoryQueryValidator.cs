using Ledger.Entities.Transactions;
using Ledger.Services.Implementations.Common.Validations;
using Ledger.Services.Transactions.Queries;

namespace Ledger.Services.Implementations.Transactions.Queries.Validators
{
    public class GetTransactionHistoryQueryValidator :
        IQueryValidator<GetTransactionHistoryQuery, ICollection<Transaction>>
    {
        private GetTransactionHistoryQuery _query;

        public void Validate(GetTransactionHistoryQuery query)
        {
            _query = query ?? throw new ArgumentNullException(nameof(query));
        }
    }
}
