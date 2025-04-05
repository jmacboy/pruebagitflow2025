using Inventory.Application;
using Inventory.Domain.Abstractions;
using Inventory.Domain.Items;
using Inventory.Domain.Transactions;
using Inventory.Domain.Users;
using Inventory.Infrastructure.DomainModel;
using Inventory.Infrastructure.Repositories;
using Inventory.Infrastructure.StoredModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMediatR(config =>
                config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly())
            );

        var connectionString = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<StoredDbContext>(context => 
                context.UseMySql(connectionString,
                    ServerVersion.AutoDetect(connectionString)));
        services.AddDbContext<DomainDbContext>(context =>
                context.UseMySql(connectionString,
                    ServerVersion.AutoDetect(connectionString)));

        services.AddScoped<IItemRepository, ItemRepository>();
        services.AddScoped<ITransactionRepository, TransactionRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddAplication();

        return services;
    }
}
