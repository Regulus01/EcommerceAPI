using Infra.Data.Authentication.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Infra.Data.Produto.Context;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ProdutoContext>
{
    public ProdutoContext CreateDbContext(string[] args)
    {
        var fileName = Path.Combine(Directory.GetCurrentDirectory(), "Config", "appsettings.json");

        var configuration = new ConfigurationBuilder().AddJsonFile(fileName).Build();
        var connectionString = configuration.GetConnectionString("App");
        
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Utilizando conexão -> " + connectionString);
        Console.ForegroundColor = ConsoleColor.White;

        var optionsBuilder = new DbContextOptionsBuilder<ProdutoContext>();
        optionsBuilder.UseNpgsql(connectionString);

        return new ProdutoContext(optionsBuilder.Options);
    }
}