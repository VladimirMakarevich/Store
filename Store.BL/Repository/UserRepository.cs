using Store.BL.Repository.Interfaces;
using Store.DAL.Context;
using Store.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.BL.Repository
{
    public class UserRepository : IUserRepository<User>
    {
        private StoreContext _db;

        public UserRepository(StoreContext db)
        {
            _db = db;
        }
        public async Task<User> CheckUserAsync(User user)
        {
            return _db.Users.
        }
    }
}
