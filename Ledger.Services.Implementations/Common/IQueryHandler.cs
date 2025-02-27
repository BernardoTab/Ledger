﻿using Ledger.Services.Common.Queries;

namespace Ledger.Services.Implementations.Common
{
    public interface IQueryHandler<TQuery, TResult>
        where TQuery : IQuery<TResult>
    {
        Task<TResult> HandleAsync(TQuery query);
    }
}
