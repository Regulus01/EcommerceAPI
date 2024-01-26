using Infra.Data.Inventario.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Infra.Data.Produto.Context;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<InventarioContext>
{
    public InventarioContext CreateDbContext(string[] args)
    {
        var fileName = Path.Combine(Directory.GetCurrentDirectory(), "Config", "appsettings.json");

        var configuration = new ConfigurationBuilder().AddJsonFile(fileName).Build();
        var connectionString = configuration.GetConnectionString("App");
        
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Utilizando conexão -> " + connectionString);
        Console.ForegroundColor = ConsoleColor.White;

        var optionsBuilder = new DbContextOptionsBuilder<InventarioContext>();
        optionsBuilder.UseNpgsql(connectionString);

        return new InventarioContext(optionsBuilder.Options);
    }
}