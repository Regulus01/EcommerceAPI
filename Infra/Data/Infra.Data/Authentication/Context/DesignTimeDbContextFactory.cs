using System.Threading.Channels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Infra.Data.Authentication.Context;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AuthenticationContext>
{
    public AuthenticationContext CreateDbContext(string[] args)
    {
        var fileName = Path.Combine(Directory.GetCurrentDirectory(), "Config", "appsettings.json");

        var configuration = new ConfigurationBuilder().AddJsonFile(fileName).Build();
        var connectionString = configuration.GetConnectionString("App");
        
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Utilizando conexão -> " + connectionString);
        Console.ForegroundColor = ConsoleColor.White;

        var optionsBuilder = new DbContextOptionsBuilder<AuthenticationContext>();
        optionsBuilder.UseNpgsql(connectionString);

        return new AuthenticationContext(optionsBuilder.Options);
    }
}