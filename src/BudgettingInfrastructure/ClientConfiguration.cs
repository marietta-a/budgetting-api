using IdentityServer4;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityServer
{
    public class ClientConfiguration
    {
        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
               ClientWithClientCredentialGrantType,
               //InteractiveClient
            };
        }

        public static Client ClientWithClientCredentialGrantType
        {
            get
            {
                return new Client
                {
                    ClientId = "mvc",
                    //ClientId = "service.client",
                    ClientSecrets = { new Secret("secret".Sha256()) },

                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    AllowedScopes = { "api", "api1", "api2.read_only" }
                };
            }
        }
        // For interactive applications
        public static Client InteractiveClient
        {
            get
            {
                return new Client
                {
                    //ClientId = "webclient",
                    ClientId = "mvc",

                    AllowedGrantTypes = GrantTypes.Code,
                    AllowOfflineAccess = true,
                    ClientSecrets = { new Secret("secret".Sha256()) },

                    RedirectUris = { "http://localhost:21402/signin-oidc" },
                    PostLogoutRedirectUris = { "http://localhost:21402/" },
                    FrontChannelLogoutUri = "http://localhost:21402/signout-oidc",

                    //RedirectUris = { "http://localhost:4200/#/login" },
                    //PostLogoutRedirectUris = { "http://localhost:4200/#/login" },
                    //FrontChannelLogoutUri = "http://localhost:4200/#/register",

                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,

                        "api",
                        "api1",
                        "api2.read_only"
                    },
                };
            }
        }

    }
}
