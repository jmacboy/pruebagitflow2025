using Inventory.Domain.Items;
using Inventory.Domain.Transactions;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Inventory.Application
{
    public static class Extensions
    {
        public static IServiceCollection AddAplication(this IServiceCollection services) {
            services.AddMediatR(config =>
                config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly())
            );


            services.AddSingleton<ITransactionFactory, TransactionFactory>();
            services.AddSingleton<IItemFactory, ItemFactory>();



            return services;
        }

    }
}
