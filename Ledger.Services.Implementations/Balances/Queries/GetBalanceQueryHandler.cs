﻿using Ledger.Services.Balances.Queries;
using Ledger.Services.Implementations.Common;
using Ledger.Services.Ledgers;

namespace Ledger.Services.Implementations.Balances.Queries
{
    public class GetBalanceQueryHandler :
        IQueryHandler<GetBalanceQuery, decimal>
    {
        private readonly ILedgerContext _dataContext;

        public GetBalanceQueryHandler(ILedgerContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<decimal> HandleAsync(GetBalanceQuery query)
        {
            return await Task.FromResult<decimal>(_dataContext.GetBalance());
        }
    }
}
