using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Infra.Data.Administracao.Context;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AdministracaoContext>
{
    public AdministracaoContext CreateDbContext(string[] args)
    {
        var fileName = Path.Combine(Directory.GetCurrentDirectory(), "Config", "appsettings.json");

        var configuration = new ConfigurationBuilder().AddJsonFile(fileName).Build();
        var connectionString = configuration.GetConnectionString("App");
        connectionString += Environment.GetEnvironmentVariable("DATABASE_SECRET");
        
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Utilizando conexão -> " + connectionString);
        Console.ForegroundColor = ConsoleColor.White;

        var optionsBuilder = new DbContextOptionsBuilder<AdministracaoContext>();
        optionsBuilder.UseNpgsql(connectionString);

        return new AdministracaoContext(optionsBuilder.Options);
    }
}