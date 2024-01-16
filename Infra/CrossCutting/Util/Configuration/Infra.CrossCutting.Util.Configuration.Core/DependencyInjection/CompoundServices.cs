using System.Data.Common;
using Application.Authorization.AppService;
using Application.AutoMapper;
using Application.Interface;
using Domain.Authentication.Commands;
using Domain.Authentication.Configuration;
using Domain.Authentication.Interface;
using Infra.CrossCutting.Util.Notifications.Handler;
using Infra.CrossCutting.Util.Notifications.Implementation;
using Infra.CrossCutting.Util.Notifications.Interface;
using Infra.Data.Authentication.Context;
using Infra.Data.Authentication.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;

namespace Infra.CrossCutting.Util.Configuration.Core.DependencyInjection;

public class CompoundServices
{
    public static void Register(IServiceCollection serviceProvider)
    {
        RepositoryDependence(serviceProvider);
    }
     private static void RepositoryDependence(IServiceCollection serviceProvider)
    {
        //DBConnection
        var configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("Config/appsettings.json") // Obtem o appsettings da pasta de configuracao
            .Build(); 

        DbConnection dbConnection = new NpgsqlConnection(configuration.GetConnectionString("app"));
        //Para adicionar mais contextos é necessário repetir o addDbContext
    
        serviceProvider.AddDbContext<AuthenticationContext>(opt =>
        {
            opt.UseNpgsql(dbConnection, assembly =>
                assembly.MigrationsAssembly(typeof(AuthenticationContext).Assembly.FullName));
        });
    

        //Token service
        serviceProvider.AddTransient<TokenService>();
        
        //Auto mapper
        var mapper = AutoMapperConfig.RegisterMaps().CreateMapper();
        serviceProvider.AddSingleton(mapper);
        serviceProvider.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        //Inversao de dependencia
        //Notification pattern
        serviceProvider.AddScoped<INotificationHandler<Notifications.Model.Notifications>, NotifyHandler>();
        serviceProvider.AddScoped<INotify, Notify>();
        serviceProvider.AddScoped<IUsuarioRepository, UsuarioRepository>();
        
        //Authorization
        serviceProvider.AddScoped<IAuthorizationAppService, AuthorizationAppService>();
        
        //Mediatr
        serviceProvider.AddMediatR(config =>
        {
            config.RegisterServicesFromAssemblies(typeof(CadastrarUsuarioCommand).Assembly);
        });
        
    }
}