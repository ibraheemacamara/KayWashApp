﻿using Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KayWashApp.Services
{
    public interface IAuthenticationService<T>
    {
        T Authenticate(string phone, string password);
    }
}
