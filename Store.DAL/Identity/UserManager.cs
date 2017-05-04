using Microsoft.AspNet.Identity;
using Store.DAL.Entities;

namespace Store.DAL.Identity
{
    public class UserManager : UserManager<User>
    {
        public UserManager(IUserStore<User> userStore)
            :base(userStore)
        {

        }
    }
}
