using Ledger.Services.Common.Queries;

namespace Ledger.Services.Implementations.Common.Validations
{
    public interface IQueryValidator<TQuery, TResult>
        where TQuery : IQuery<TResult>
    {
        Task ValidateAsync(TQuery query);
    }
}
