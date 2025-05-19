using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.ORM;
using Ambev.DeveloperEvaluation.ORM.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace Ambev.DeveloperEvaluation.IoC.ModuleInitializers;

public class InfrastructureModuleInitializer : IModuleInitializer
{
    public void Initialize(WebApplicationBuilder builder)
    {
        // Configuração do PostgreSQL
        builder.Services.AddDbContext<DefaultContext>(options =>
            options.UseNpgsql(
                builder.Configuration.GetConnectionString("PostgreSQL"),
                b => b.MigrationsAssembly("Ambev.DeveloperEvaluation.ORM")
            ));

        // Configuração do MongoDB
        builder.Services.AddSingleton<IMongoClient>(sp =>
            new MongoClient(builder.Configuration.GetConnectionString("MongoDB")));

        builder.Services.AddScoped<IMongoDatabase>(sp =>
            sp.GetRequiredService<IMongoClient>().GetDatabase("ambev_dev_eval"));

        // Repositórios
        builder.Services.AddScoped<DbContext>(provider => provider.GetRequiredService<DefaultContext>());
        builder.Services.AddScoped<IUserRepository, UserRepository>();

        // Foi implementado para qualquer repositório de vendas que for decidido usar (PostgreSQL ou MongoDB)
        // Para PostgreSQL:
        builder.Services.AddScoped<ISaleRepository, SaleRepository>();

        // Para MongoDB (descomente a linha abaixo e comente a acima):
        // builder.Services.AddScoped<ISaleRepository, MongoSaleRepository>();
    }
}