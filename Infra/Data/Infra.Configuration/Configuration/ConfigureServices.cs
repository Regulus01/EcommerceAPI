using System.Data;
using System.Data.Common;
using System.Reflection;
using System.Text;
using Amazon;
using Amazon.Runtime;
using Amazon.S3;
using Application.AppService;
using Application.Arquivos.AppService;
using Application.Arquivos.Interface;
using Application.AutoMapper;
using Application.Interface;
using Application.Inventario.AppService;
using Application.Inventario.Interface;
using Domain.Arquivos.Commands;
using Domain.Arquivos.Interfaces;
using Domain.Authentication.Commands;
using Domain.Authentication.Configuration;
using Domain.Entities.Roles;
using Domain.Interface;
using Domain.Inventario.Commands;
using Domain.Inventario.Interface;
using HttpAcessor;
using Infra.CrossCutting.Util.Notifications.Handler;
using Infra.CrossCutting.Util.Notifications.Implementation;
using Infra.CrossCutting.Util.Notifications.Interface;
using Infra.Data.Arquivos.Context;
using Infra.Data.Arquivos.Repository;
using Infra.Data.Authentication.Context;
using Infra.Data.Authentication.Repository;
using Infra.Data.Inventario.Context;
using Infra.Data.Inventario.Repository;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Npgsql;
using Notifications = Infra.CrossCutting.Util.Notifications.Model.Notifications;

namespace Infra.Configuration.Configuration;

public class ConfigureServices
{
    private static DbConnection? DbConnection { get; set; }
    private static IConfigurationRoot? ConfigurationRoot { get; set; }

    public static void Register(IServiceCollection serviceProvider)
    {
        RegisterDbConnection(serviceProvider);
        RegisterAwsServices(serviceProvider);
        RegisterDbContexts(serviceProvider);
        RegisterAutoMapper(serviceProvider);
        RegisterDependencyInjection(serviceProvider);
        ConfigureMediatR(serviceProvider);
        ConfigureJwt(serviceProvider);
        ConfigureSwagger(serviceProvider);
    }

    /// <summary>
    ///     Configura a conexão do banco de dados e registra os serviços relacionados no contêiner de IoC.
    /// </summary>
    /// <param name="serviceProvider">O contêiner de IoC utilizado para registrar serviços.</param>
    private static void RegisterDbConnection(IServiceCollection serviceProvider)
    {
        ConfigurationRoot = new ConfigurationBuilder()
                            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                            .AddJsonFile("Config/appsettings.json") // Obtem o appsettings da pasta de configuracao
                            .Build();

        var connectionString = ConfigurationRoot.GetConnectionString("app");
        
        DbConnection = new NpgsqlConnection(connectionString);
        
        serviceProvider.AddTransient<IDbConnection>(db => new NpgsqlConnection(connectionString));
    }

    /// <summary>
    ///     Configura a conexão com a AWS e registra os serviços relacionados no contêiner de IoC.
    /// </summary>
    /// <param name="serviceProvider">O contêiner de IoC utilizado para registrar serviços.</param>
    private static void RegisterAwsServices(IServiceCollection serviceProvider)
    {
        var awsConnectionString = ConfigurationRoot?.GetConnectionString("AwsS3")?.Split(";");
        
        var awsKey = awsConnectionString?[0].Split("key=")[1];
        var awsKeySecret = awsConnectionString?[1].Split("secret=")[1];
        
        var awsCredentials = new BasicAWSCredentials(awsKey, awsKeySecret);
        var config = new AmazonS3Config
        {
            RegionEndpoint = RegionEndpoint.USEast2
        };

        serviceProvider.AddScoped<IAmazonS3>(aws => new AmazonS3Client(awsCredentials, config));
    }
    
    /// <summary>
    ///     Configura os contexto da aplicação e registra os serviços relacionados no contêiner de IoC.
    /// </summary>
    /// <param name="serviceProvider">O contêiner de IoC utilizado para registrar serviços.</param>
    private static void RegisterDbContexts(IServiceCollection serviceProvider)
    {
        // Authentication
        serviceProvider.AddDbContext<AuthenticationContext>(opt =>
        {
            opt.UseNpgsql(DbConnection!, assembly =>
                assembly.MigrationsAssembly(typeof(AuthenticationContext).Assembly.FullName));
        });
        
        //Inventario
        serviceProvider.AddDbContext<InventarioContext>(opt =>
        {
            opt.UseNpgsql(DbConnection!, assembly =>
                assembly.MigrationsAssembly(typeof(InventarioContext).Assembly.FullName));
        });
        
        //Gerenciador de arquivos
        serviceProvider.AddDbContext<GerenciadorDeArquivosContext>(opt =>
        {
            opt.UseNpgsql(DbConnection!, assembly =>
                assembly.MigrationsAssembly(typeof(GerenciadorDeArquivosContext).Assembly.FullName));
        });
    }
    
    /// <summary>
    ///     Configura o autoMapper e registra os serviços relacionados no contêiner de IoC.
    /// </summary>
    /// <param name="serviceProvider">O contêiner de IoC utilizado para registrar serviços.</param>
    private static void RegisterAutoMapper(IServiceCollection serviceProvider)
    {
        var mapper = AutoMapperConfig.RegisterMaps().CreateMapper();
        serviceProvider.AddSingleton(mapper);
        serviceProvider.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
    }
    
    /// <summary>
    /// Registra os serviços relacionados à injeção de dependência no contêiner de IoC.
    /// </summary>
    /// <param name="serviceProvider">O contêiner de IoC utilizado para registrar serviços.</param>
    private static void RegisterDependencyInjection(IServiceCollection serviceProvider)
    {
        //Notification pattern
        serviceProvider.AddScoped<INotificationHandler<Notifications>, NotifyHandler>();
        serviceProvider.AddScoped<INotify, Notify>();
        
        //Authentication
        serviceProvider.AddScoped<IUsuarioRepository, UsuarioRepository>();
        serviceProvider.AddScoped<IAuthorizationAppService, AuthorizationAppService>();
        serviceProvider.AddScoped<IAuthenticatedUser, AuthenticatedUser>();
        serviceProvider.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        
        //Inventario
        serviceProvider.AddScoped<IProdutoRepository, ProdutoRepository>();
        serviceProvider.AddScoped<IInventarioAppService, InventarioAppService>();
   
        //Gerenciador de arquivos
        serviceProvider.AddScoped<IGerenciadorDeArquivoAppService, GerenciadorDeArquivosAppService>();
        serviceProvider.AddScoped<IGerenciadorDeArquivosRepository, GerenciadorDeArquivosRepository>();
        
        //JWT - Token service 
        serviceProvider.AddTransient<TokenService>();
    }
    
    /// <summary>
    /// Registra a configuracao do MediatR à injeção de dependência no contêiner de IoC.
    /// </summary>
    /// <param name="serviceProvider">O contêiner de IoC utilizado para registrar serviços.</param>
    private static void ConfigureMediatR(IServiceCollection serviceProvider)
    {
        serviceProvider.AddMediatR(config =>
        {
            //Authentication
            config.RegisterServicesFromAssemblies(typeof(CadastrarUsuarioCommand).Assembly);
            config.RegisterServicesFromAssemblies(typeof(LoginCommand).Assembly);
            
            //Inventario
            config.RegisterServicesFromAssemblies(typeof(CadastrarProdutoCommand).Assembly);
            config.RegisterServicesFromAssemblies(typeof(CaminhoFotoCapaCommand).Assembly);
            
            //Gerenciador de arquivos
            config.RegisterServicesFromAssemblies(typeof(GerenciadorDeArquivosCommand).Assembly);
            config.RegisterServicesFromAssemblies(typeof(DeletarArquivoCommand).Assembly);
        });
    }
    
    /// <summary>
    /// Configura o token Jwt e registra a injeção de dependência no contêiner de IoC.
    /// </summary>
    /// <param name="serviceProvider">O contêiner de IoC utilizado para registrar serviços.</param>
    private static void ConfigureJwt(IServiceCollection serviceProvider)
    {
        // Jwt config
        var key = Encoding.ASCII.GetBytes(Domain.Authentication.Configuration.Configuration.JwtKey);
        serviceProvider.AddAuthentication(x =>
        {
            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(x =>
        {
            x.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                ValidateAudience = false,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false
            };
        });
        
        serviceProvider.AddAuthorizationBuilder()
                       .AddPolicy(RoleRegister.Admin.Nome, policy => policy.RequireRole(RoleRegister.Admin.Nome));
    }

    /// <summary>
    /// Configura o swagger da aplicação
    /// </summary>
    /// <param name="serviceCollection">O contêiner de IoC utilizado para registrar serviços.</param>
    private static void ConfigureSwagger(IServiceCollection serviceCollection)
    {
        serviceCollection.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "MarketPlaceAPI", Version = "v1" });

            var xmlFile = $"{Assembly.Load("Service").GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            c.IncludeXmlComments(xmlPath);

            var xmlFileApplication = $"{Assembly.Load("Application").GetName().Name}.xml";
            var xmlPathApplication = Path.Combine(AppContext.BaseDirectory, xmlFileApplication);
            c.IncludeXmlComments(xmlPathApplication);

            c.UseInlineDefinitionsForEnums();
            
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "JWT Authorization header using the Bearer scheme",
            });
            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    Array.Empty<string>()
                }
            });
        });
    }
}