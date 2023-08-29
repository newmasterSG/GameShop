﻿using IdentityModel.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.IdentityServices
{
    public interface ITokenService
    {
        Task<TokenResponse> GetToken(string scope);
    }
}
