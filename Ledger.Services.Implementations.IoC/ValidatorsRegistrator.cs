using Ledger.Services.Implementations.Common.Validations;
using Ledger.Services.Implementations.Transactions.Commands.Validators;
using Microsoft.Extensions.DependencyInjection;

namespace Ledger.Services.Implementations.IoC
{
    public static class ValidatorsRegistrator
    {
        public static void RegisterValidators(this IServiceCollection services)
        {
            services.Scan(scan => scan
                .FromAssemblyOf<CreateTransactionCommandValidator>()
                .AddClasses(classes => classes.AssignableToAny(
                    typeof(ICommandValidator<>),
                    typeof(IQueryValidator<,>),
                    typeof(IEntityValidator<>)))
                .AsImplementedInterfaces()
                .WithLifetime(ServiceLifetime.Transient));
        }
    }
}
