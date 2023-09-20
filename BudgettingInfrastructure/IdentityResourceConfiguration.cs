using IdentityServer4;
using IdentityServer4.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgettingInfrastructure
{
    public class IdentityResourceConfiguration
    {
        IServiceCollection Services;
        public IdentityResourceConfiguration(IServiceCollection srv)
        {
            Services = srv;
        }
        public IdentityResourceConfiguration()
        {
        }

        public static void ConfigureIdentityServer(IServiceCollection services)
        {
            var builder = services.AddIdentityServer(options =>
            {
                options.Events.RaiseErrorEvents = true;
                options.Events.RaiseInformationEvents = true;
                options.Events.RaiseFailureEvents = true;
                options.Events.RaiseSuccessEvents = true;
            });
            builder.AddInMemoryClients(ClientConfiguration.GetClients())
                    .AddInMemoryApiResources(GetApiResources())
                    .AddInMemoryApiScopes(GetApiScopes())
                    .AddInMemoryIdentityResources(GetIdentityResources())
                    .AddAspNetIdentity<IdentityUser>();
        }

        private static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResource(
                    name: "profile",
                    userClaims: new[] { "name", "email", "website" },
                    displayName: "Your profile data"
                    )
            };
        }

        private static IEnumerable<ApiScope> GetApiScopes()
        {
            return new List<ApiScope>
            {
                new ApiScope(name: "read",   displayName: "Read your data.", userClaims: new [] { "user_level" }),
                new ApiScope(name: "write",  displayName: "Write your data.", userClaims: new [] { "user_level" }),
                new ApiScope(name: "delete", displayName: "Delete your data.", userClaims: new [] { "user_level" })
            };
        }

        private static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource()
                {
                    Scopes = { "read", "write", "delete", "manage" }
                },
                new ApiResource("invoice", "Invoice API")
                {
                    Scopes = { "invoice.read", "invoice.pay", "manage" }
                },

                new ApiResource("customer", "Customer API")
                {
                    Scopes = { "customer.read", "customer.contact", "manage" }
                }
            };
        }
    }
}
