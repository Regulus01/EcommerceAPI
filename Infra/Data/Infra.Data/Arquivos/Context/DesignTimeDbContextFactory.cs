using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Infra.Data.Arquivos.Context;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<GerenciadorDeArquivosContext>
{
    public GerenciadorDeArquivosContext CreateDbContext(string[] args)
    {
        var fileName = Path.Combine(Directory.GetCurrentDirectory(), "Config", "appsettings.json");

        var configuration = new ConfigurationBuilder().AddJsonFile(fileName).Build();
        var connectionString = configuration.GetConnectionString("App");
        
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Utilizando conexão -> " + connectionString);
        Console.ForegroundColor = ConsoleColor.White;

        var optionsBuilder = new DbContextOptionsBuilder<GerenciadorDeArquivosContext>();
        optionsBuilder.UseNpgsql(connectionString);

        return new GerenciadorDeArquivosContext(optionsBuilder.Options);
    }
}