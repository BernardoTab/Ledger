using Ledger.Services.Balances.Queries;
using Ledger.Services.Implementations.Common.Validations;

namespace Ledger.Services.Implementations.Balances.Queries.Validators
{
    public class GetBalanceQueryValidator :
        IQueryValidator<GetBalanceQuery, decimal>
    {
        public async Task ValidateAsync(GetBalanceQuery query)
        {
            if (query == default)
            {
                throw new ArgumentNullException(nameof(query));
            }
            await Task.CompletedTask;
        }
    }
}
