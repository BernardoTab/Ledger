using Ledger.Entities.Transactions;
using Ledger.Services.Implementations.Common.Validations;
using Ledger.Services.Transactions.Queries;

namespace Ledger.Services.Implementations.Transactions.Queries.Validators
{
    public class GetTransactionHistoryQueryValidator :
        IQueryValidator<GetTransactionHistoryQuery, ICollection<Transaction>>
    {
        private readonly GetTransactionHistoryQuery _query;

        public async Task ValidateAsync(GetTransactionHistoryQuery query)
        {
            if (query == default)
            {
                throw new ArgumentNullException(nameof(query));
            }
            await Task.CompletedTask;
        }
    }
}
