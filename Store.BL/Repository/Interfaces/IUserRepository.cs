﻿using Store.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Store.BL.Repository.Interfaces
{
    public interface IUserRepository<T> where T : class
    {
        Task<ClaimsIdentity> AuthenticateAsync(string login, string password);
    }
}
