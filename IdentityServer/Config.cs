﻿// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4.Models;
using System.Collections.Generic;

namespace IdentityServer
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources => IdentityResourceConfiguration.GetIdentityResources();

        public static IEnumerable<ApiScope> ApiScopes => IdentityResourceConfiguration.GetApiScopes();
        public static IEnumerable<Client> Clients => ClientConfiguration.GetClients();
    }
}