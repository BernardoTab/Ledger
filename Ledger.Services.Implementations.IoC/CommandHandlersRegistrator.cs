using Ledger.Services.Implementations.Common;
using Ledger.Services.Implementations.Transactions.Commands;
using Microsoft.Extensions.DependencyInjection;

namespace Ledger.Services.Implementations.IoC
{
    public static class CommandHandlersRegistrator
    {
        public static void RegisterCommandHandlers(this IServiceCollection services)
        {
            services.Scan(scan => scan
                .FromAssemblyOf<CreateTransactionCommandHandler>()
                .AddClasses(classes => classes.AssignableToAny(typeof(ICommandHandler<>)))
                .AsImplementedInterfaces()
                .WithLifetime(ServiceLifetime.Transient));
        }
    }
}
