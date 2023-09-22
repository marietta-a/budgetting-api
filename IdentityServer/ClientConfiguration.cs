using IdentityServer4;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityServer
{
    public static class ClientConfiguration
    {
        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                ClientWithClientCredentialGrantType,
                InteractiveClient
            };
        }

        public static Client ClientWithClientCredentialGrantType
        {
            get
            {
                return new Client
                {
                    ClientId = "client",
                    ClientSecrets = { new Secret("secret".Sha256()) },

                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    // scopes that client has access to
                    AllowedScopes = { "api", "api1" }
                };
            }
        }
        // For interactive applications
        //RedirectUris = { "https://localhost:5002/signin-oidc" },
        //PostLogoutRedirectUris = { "https://localhost:5002/signout-callback-oidc" },
        public static Client InteractiveClient
        {
            get
            {
                return new Client
                {
                    ClientId = "spa",
                    //ClientId = "mvc",
                    ClientSecrets = { new Secret("secret".Sha256()) },

                    AllowedGrantTypes = GrantTypes.Code,

                    // where to redirect to after login
                    RedirectUris = { "http://localhost:4200/#/signin-oidc" },

                    // where to redirect to after logout
                    PostLogoutRedirectUris = { "http://localhost:4200/#/signout-callback-oidc" },

                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        IdentityServerConstants.StandardScopes.OfflineAccess,
                        "api"
                    }
                };
            }
        }

    }
}
