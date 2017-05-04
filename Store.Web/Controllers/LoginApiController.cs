using Store.BL.UnityOfWork;
using Store.Web.Mappers;
using Store.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Store.Web.Controllers
{
    public class LoginApiController : DefaultApiController
    {
        private UserMapper _userMapper;

        public LoginApiController(IUnityOfWork unityOfWork, UserMapper userMapper)
            :base(unityOfWork)
        {
            _userMapper = userMapper;
        }

        public async Task<string> Post(UserLoginJsonModel userLoginJsonModel)
        {
            var claim = await _unityOfWork.Users.AuthenticateAsync(userLoginJsonModel.Login, userLoginJsonModel.Password);

            if (claim == null)
            {
                throw new NullReferenceException();
            }

        }
    }
}