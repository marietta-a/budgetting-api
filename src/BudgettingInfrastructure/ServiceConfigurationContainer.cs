using Budgetting.Domain.Models;
using Budgetting.Domain.Queries.ApplicationUserQueries;
using Budgetting.Implementations.Identity;
using Budgetting.Persistence;
using Budgetting.Repository;
using Budgetting.Services;
using BudgettingCore.Core;
using BudgettingDomain.Commands.ApplicationUserCommands;
using BudgettingPersistence;
using IdentityServer4;
using IdentityServer4.EntityFramework.Storage;
using IdentityServer4.Stores;
using MediatR;
using MediatR.Wrappers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using Services;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BudgettingInfrastructure
{
    public class ServiceConfigurationContainer
    {
        private static string originName => "AllowAngularOrigins";
        public static void SetConnectionString(IConfiguration configuration)
        {
            BudgettingContext.ConnectionString = configuration.GetConnectionString("BudgettingConn"); ;
            IdentityContext.ConnectionString = configuration.GetConnectionString("IdentityConnection"); ;
        }
        public static void EnsureDbCreation()
        {
            try
            {

                using (var db = new BudgettingContext())
                {
                    db.Database.EnsureCreated();
                }
                //using (var db = new IdentityContext())
                //{
                //    db.Database.EnsureCreated();
                //}
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
        }
        public static void RegisterConnections(IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<BudgettingContext>(options =>
            {
                options.UseSqlite(BudgettingContext.ConnectionString,
                    b => b.MigrationsAssembly(typeof(BudgettingContext).Assembly.FullName));
            });
            services.AddOperationalDbContext(options =>
            {
                options.ConfigureDbContext = db => db.UseSqlite(BudgettingContext.ConnectionString,
                    b => b.MigrationsAssembly(typeof(BudgettingContext).Assembly.FullName));
            });

            services.AddConfigurationDbContext(options =>
            {
                options.ConfigureDbContext = db => db.UseSqlite(BudgettingContext.ConnectionString,
                    b => b.MigrationsAssembly(typeof(BudgettingContext).Assembly.FullName));
            });
            services.AddDbContext<IdentityContext>(options =>
            {
                options.UseSqlite(IdentityContext.ConnectionString,
                    b => b.MigrationsAssembly(typeof(IdentityContext).Assembly.FullName));
            });
            services.AddOperationalDbContext(options =>
            {
                options.ConfigureDbContext = db => db.UseSqlite(IdentityContext.ConnectionString,
                    b => b.MigrationsAssembly(typeof(IdentityContext).Assembly.FullName));
            });

            services.AddConfigurationDbContext(options =>
            {
                options.ConfigureDbContext = db => db.UseSqlite(IdentityContext.ConnectionString,
                    b => b.MigrationsAssembly(typeof(IdentityContext).Assembly.FullName));
            });



        }
        public static void ConfigureServices(IServiceCollection services)
        {


            //services.AddAuthentication("Bearer")
            //    .AddJwtBearer("Bearer", options =>
            //    {
            //        options.Authority = "https://localhost:5001";

            //        options.TokenValidationParameters = new TokenValidationParameters
            //        {
            //            ValidateAudience = false
            //        };
            //    });
            //services.AddAuthorization(options =>
            //{
            //    options.AddPolicy("ApiScope", policy =>
            //    {
            //        policy.RequireAuthenticatedUser();
            //        policy.RequireClaim("scope", "api1");
            //    });

            //});

            //services.AddCors(options =>
            //{
            //    options.AddPolicy("CorsPolicy",
            //        builder => builder.AllowAnyOrigin()
            //            .AllowAnyMethod()
            //            .AllowAnyHeader());
            //            //.AllowCredentials());
            //});
            //services.AddSpaStaticFiles(configuration =>
            //{
            //    configuration.RootPath = "ClientApp/dist";
            //});

            services.AddAuthentication("Bearer").AddJwtBearer();
            services.AddAuthorization();

            services.AddCors( options =>
            {
                options.AddPolicy(name: originName,
                builder =>
                {
                    builder.WithOrigins(
                                        "http://localhost:4200"
                                        )
                                        .AllowAnyHeader()
                                        .AllowAnyMethod();
                });

            });
           

            services.AddControllers();
            services.AddMvc();
            AddMediatRServices(services);
            AddTransientServices(services);
            AddScopedServices(services);


            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.SignIn.RequireConfirmedEmail = true;
                // Password settings.
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;

                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                // User settings.
                options.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = false;

            }).AddEntityFrameworkStores<IdentityContext>()
              .AddDefaultTokenProviders();



            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
                options.LoginPath = "/Account/Login"; // Change this to your login page
                //options.AccessDeniedPath = "/Account/AccessDenied"; // Change this to your access denied page
                options.SlidingExpiration = true;
            });

            //IdentityResourceConfiguration.ConfigureIdentityServer(services);


            //IdentityModelEventSource.ShowPII = true;
            //services.AddAuthentication(options =>
            //{
            //    options.DefaultScheme = "Cookies";
            //    options.DefaultChallengeScheme = "oidc";
            //}).AddCookie("Cookies")
            //.AddOpenIdConnect("oidc", options =>
            //{
            //    options.SignInScheme = "Cookies";
            //    options.Authority = "https://localhost:5001";
            //    options.RequireHttpsMetadata = true;

            //    options.ClientId = "mvc";
            //    //options.ClientId = "webclient";
            //    options.ClientSecret = "secret";
            //    options.ResponseType = "code";

            //    options.SaveTokens = true;
            //    options.GetClaimsFromUserInfoEndpoint = true;

            //    options.Scope.Add(IdentityServerConstants.StandardScopes.OpenId);
            //    options.Scope.Add(IdentityServerConstants.StandardScopes.Profile);
            //    options.Scope.Add(IdentityServerConstants.StandardScopes.Email);
            //    options.Scope.Add("api");
            //    options.Scope.Add("read");
            //    options.Scope.Add("write");
            //    options.Scope.Add("delete");
            //    options.Scope.Add("manage");

            //});


        }

        private static void AddMediatRServices(IServiceCollection services)
        {
            var commandAssemblies = new[]
            {
                typeof(CreateApplicationUserCommand).Assembly,
                typeof(CreateApplicationUserCommandHandler).Assembly,
            };
            var queryAssemblies = new[]
            {
                typeof(GetAllApplicationUsersQuery).Assembly,
                typeof(GetAllApplicationUsersQueryHandler).Assembly,
            };
            services.AddMediatR(c => c.RegisterServicesFromAssemblies(commandAssemblies));
            services.AddMediatR(c => c.RegisterServicesFromAssemblies(queryAssemblies));
        }

        public static void Configure(IApplicationBuilder app)
        {

            //app.UseHttpsRedirection();
            //app.UseStaticFiles();

            //app.UseRouting();
            //app.UseAuthentication();
            //app.UseAuthorization();
            ////app.UseIdentityServer();

            ////app.UseEndpoints(endpoints =>
            ////{
            ////    endpoints.MapDefaultControllerRoute()
            ////        .RequireAuthorization();
            ////});
            //app.MapControllerRoute(name: "dafault", pattern: "{controller}/{action?}/{id?}");

            //app.MapControllers();

            app.UseCors(originName);
            app.UseHttpsRedirection();
            //app.UseSpaStaticFiles();
            //app.UseSpa(spa =>
            //{
            //    // To learn more about options for serving an Angular SPA from ASP.NET Core,
            //    // see https://go.microsoft.com/fwlink/?linkid=864501

            //    spa.Options.SourcePath = "ClientApp";

            //    //if (app.Environment.IsDevelopment())
            //    //{
            //    //    spa.UseAngularCliServer(npmScript: "start");
            //    //}
            //});
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();



            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllers()
            //        .RequireAuthorization("ApiScope");
            //});

        }

        private static void AddScopedServices(IServiceCollection services)
        {
            services.AddScoped<IBudgettingContext>(provider => provider.GetService<BudgettingContext>());
            services.AddScoped<IIdentityContext>(provider => provider.GetService<IdentityContext>());

        }

        private static void AddTransientServices(IServiceCollection services)
        {
            services.AddTransient<IApplicationUserService, ApplicationUserService>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<ICategoryService, CategoryService>();
        }

        public static async void MigrateDatabase(WebApplication app)
        {
            var scope = app.Services.CreateScope();
            {
                var identityContext = (IIdentityContext)scope.ServiceProvider.GetService(typeof(IIdentityContext));

                var userManager = scope.ServiceProvider.GetService<UserManager<ApplicationUser>>();
                var roleManager = scope.ServiceProvider.GetService<RoleManager<IdentityRole>>();

                await IdentityContextSeed.SeedAsync(identityContext, userManager, roleManager);
            }
        }
    }
}
