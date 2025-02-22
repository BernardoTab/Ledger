using Ledger.Services.Implementations.Common;
using Ledger.Services.Implementations.Common.Validations;
using Ledger.Services.Implementations.Transactions.Queries;
using Microsoft.Extensions.DependencyInjection;

namespace Ledger.Services.Implementations.IoC
{
    public static class QueryHandlersRegistrator
    {
        public static void RegisterQueryHandlers(this IServiceCollection services)
        {
            services.Scan(scan => scan
                .FromAssemblyOf<GetTransactionHistoryQueryHandler>()
                .AddClasses(classes => classes.AssignableToAny(typeof(IQueryHandler<,>)))
                .AsImplementedInterfaces()
                .WithLifetime(ServiceLifetime.Transient));
            services.Decorate(typeof(IQueryHandler<,>), typeof(ValidatedQueryHandler<,>));
        }
    }
}
