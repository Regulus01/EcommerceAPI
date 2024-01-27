using System.Data;
using System.Data.Common;
using Application.AppService;
using Application.AutoMapper;
using Application.Interface;
using Application.Inventario.AppService;
using Application.Inventario.Interface;
using Domain.Authentication.Commands;
using Domain.Authentication.Interface;
using Domain.Authentication.Inventario.Commands;
using Domain.Authentication.Inventario.Interface;
using Infra.CrossCutting.Util.Notifications.Handler;
using Infra.CrossCutting.Util.Notifications.Implementation;
using Infra.CrossCutting.Util.Notifications.Interface;
using Infra.Data.Authentication.Context;
using Infra.Data.Authentication.Repository;
using Infra.Data.Inventario.Context;
using Infra.Data.Inventario.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;

namespace Infra.Data.DependencyInjection;

public class CompoundServices
{
    public static void Register(IServiceCollection serviceProvider)
    {
        RepositoryDependence(serviceProvider);
    }

    private static void RepositoryDependence(IServiceCollection serviceProvider)
    {
        BaseCompound.BaseCompoundDependence(serviceProvider);

        //DBConnection
        var configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("Config/appsettings.json") // Obtem o appsettings da pasta de configuracao
            .Build();

        DbConnection dbConnection = new NpgsqlConnection(configuration.GetConnectionString("app"));

        serviceProvider.AddTransient<IDbConnection>(db => new NpgsqlConnection(configuration.GetConnectionString("app")));
        
        //Para adicionar mais contextos é necessário repetir o addDbContext
        serviceProvider.AddDbContext<AuthenticationContext>(opt =>
        {
            opt.UseNpgsql(dbConnection, assembly =>
                assembly.MigrationsAssembly(typeof(AuthenticationContext).Assembly.FullName));
        });
        
        serviceProvider.AddDbContext<InventarioContext>(opt =>
        {
            opt.UseNpgsql(dbConnection, assembly =>
                assembly.MigrationsAssembly(typeof(InventarioContext).Assembly.FullName));
        });

        //Auto mapper
        var mapper = AutoMapperConfig.RegisterMaps().CreateMapper();
        serviceProvider.AddSingleton(mapper);
        serviceProvider.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        //Inversao de dependencia - Ioc
        //Notification pattern
        serviceProvider.AddScoped<INotificationHandler<CrossCutting.Util.Notifications.Model.Notifications>, NotifyHandler>();
        serviceProvider.AddScoped<INotify, Notify>();
        
        //Authetication
        serviceProvider.AddScoped<IUsuarioRepository, UsuarioRepository>();
        serviceProvider.AddScoped<IAuthorizationAppService, AuthorizationAppService>();
        
        //Inventario
        serviceProvider.AddScoped<IProdutoRepository, ProdutoRepository>();
        serviceProvider.AddScoped<IInventarioAppService, InventarioAppService>();
   

        //Mediatr
        serviceProvider.AddMediatR(config =>
        {
            //Authentication
            config.RegisterServicesFromAssemblies(typeof(CadastrarUsuarioCommand).Assembly);
            config.RegisterServicesFromAssemblies(typeof(LoginCommand).Assembly);
            
            //Inventario
            config.RegisterServicesFromAssemblies(typeof(CadastrarProdutoCommand).Assembly);
        });
    }
}