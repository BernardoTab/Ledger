using Ledger.Services.Common.Queries;

namespace Ledger.Services.Implementations.Common.Validations
{
    public class ValidatedQueryHandler<TQuery, TResult> : IQueryHandler<TQuery, TResult>
        where TQuery : IQuery<TResult>
    {
        private readonly IQueryValidator<TQuery, TResult> _queryValidator;
        private readonly IQueryHandler<TQuery, TResult> _queryHandler;

        public ValidatedQueryHandler(
            IQueryValidator<TQuery, TResult> queryValidator,
            IQueryHandler<TQuery, TResult> queryHandler)
        {
            _queryValidator = queryValidator;
            _queryHandler = queryHandler;
        }

        public TResult Handle(TQuery command)
        {
            _queryValidator.Validate(command);
            return _queryHandler.Handle(command);
        }
    }
}
