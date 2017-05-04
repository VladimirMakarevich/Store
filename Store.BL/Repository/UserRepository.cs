using Microsoft.AspNet.Identity;
using Store.BL.Repository.Interfaces;
using Store.DAL.Context;
using Store.DAL.Entities;
using Store.DAL.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Store.BL.Repository
{
    public class UserRepository : IUserRepository<User>
    {
        private StoreContext _db;
        private UserManager _userManager;

        public UserRepository(StoreContext db, UserManager userManager)
        {
            _db = db;
            _userManager = userManager;
        }
        public async Task<ClaimsIdentity> AuthenticateAsync(string login, string password)
        {
            ClaimsIdentity claims = null;
            var user = await _userManager.FindAsync(login, password);

            if (user != null)
            {
                claims = await user.GenerateUserIdentityAsync(_userManager);
            }

            return claims;
        }

        public async Task<IdentityResult> CreateAsync(User user, string password)
        {
            return await _userManager.CreateAsync(user, password);
        }
    }
}
