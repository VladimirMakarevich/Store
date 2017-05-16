using Microsoft.AspNet.Identity;
using Store.BL.Repository.Interfaces;
using Store.DAL.Context;
using Store.DAL.Entities;
using Store.Identity;
using System.Threading.Tasks;

namespace Store.BL.Repository
{
    public class UserRepository : IUserRepository<User>
    {
        private StoreContext _db;
        private UserManager _userManager;
        public UserRepository(StoreContext db)
        {
            _db = db;
        }
        public UserRepository(StoreContext db, UserManager userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        public async Task CreateAsync(User user, string password)
        {
            user.UserName = user.Email;

            _db.Users.Add(user);
            await _db.SaveChangesAsync();
        }
    }
}
