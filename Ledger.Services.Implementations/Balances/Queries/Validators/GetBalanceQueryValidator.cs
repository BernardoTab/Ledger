using Ledger.Services.Balances.Queries;
using Ledger.Services.Implementations.Common.Validations;

namespace Ledger.Services.Implementations.Balances.Queries.Validators
{
    public class GetBalanceQueryValidator :
        IQueryValidator<GetBalanceQuery, decimal>
    {
        private GetBalanceQuery _query;

        public void Validate(GetBalanceQuery query)
        {
            _query = query ?? throw new ArgumentNullException(nameof(query));
        }
    }
}
