using BudgettingDomain.Entities;
using BudgettingPersistence;
using IdentityServer4;
using IdentityServer4.Stores;
using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgettingInfrastructure
{
    public class ConfigureServiceContainer
    {
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
                using (var db = new IdentityContext())
                {
                    db.Database.EnsureCreated();
                }
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
            services.AddDbContext<IdentityContext>(options =>
            {
                options.UseSqlite(IdentityContext.ConnectionString,
                    b => b.MigrationsAssembly(typeof(IdentityContext).Assembly.FullName));
            });

        }
        public static void ConfigureServices(IServiceCollection services)
        {
            AddTransientServices(services);
            AddScopedServices(services);

            AddIdentityService(services);
        }

        private static void AddIdentityService(IServiceCollection services)
        {
            services.AddIdentityServer();
            services.AddAuthentication()
                    .AddOpenIdConnect("demoidsrv", "IdentityServer", options =>
                     {
                         options.SignInScheme = IdentityServerConstants.ExternalCookieAuthenticationScheme;
                         options.SignOutScheme = IdentityServerConstants.SignoutScheme;

                         options.Authority = "https://demo.identityserver.io/";
                         options.ClientId = "implicit";
                         options.ResponseType = "id_token";
                         options.SaveTokens = true;
                         options.CallbackPath = new PathString("/signin-idsrv");
                         options.SignedOutCallbackPath = new PathString("/signout-callback-idsrv");
                         options.RemoteSignOutPath = new PathString("/signout-idsrv");

                         options.TokenValidationParameters = new TokenValidationParameters
                         {
                             NameClaimType = "name",
                             RoleClaimType = "role"
                         };
                     });

            //services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            //{
            //    options.SignIn.RequireConfirmedAccount = false;
            //}).AddEntityFrameworkStores<IdentityContext>()
            //  .AddDefaultTokenProviders();
            //services.AddInMemoryCaching()
            //        .AddClientStore<InMemoryClientStore>()
            //        .AddResourceStore<InMemoryResourcesStore>()
            //        .AddDeveloperSigningCredential()
            //        .AddAspNetIdentity<ApplicationUser>();

        }
        private static void AddScopedServices(IServiceCollection services)
        {
            services.AddScoped<IBudgettingContext>(provider => provider.GetService<BudgettingContext>());
            services.AddScoped<IIdentityContext>(provider => provider.GetService<IdentityContext>());

        }

        private static void AddTransientServices(IServiceCollection services)
        {
        }
    }
}
