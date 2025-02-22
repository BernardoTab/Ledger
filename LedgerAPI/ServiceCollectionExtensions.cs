using Ledger.DataTransferring.Transactions.Mappings;
using Ledger.Services.Implementations.IoC;
using Ledger.Services.Ledgers;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Converters;

namespace Ledger
{
    public static class ServiceCollectionExtensions
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(TransactionDtoMap).Assembly);
            services.AddSingleton<ILedgerContext, LedgerContext>();
            services.RegisterCommandHandlers();
            services.RegisterQueryHandlers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Ledger",
                    Version = "v1",
                    Description = "Deposit or withdraw money!"
                });
            });
            services.AddControllers().AddNewtonsoftJson(options =>
            {
                // Apply StringEnumConverter globally
                options.SerializerSettings.Converters.Add(new StringEnumConverter());
            });
        }
    }
}
