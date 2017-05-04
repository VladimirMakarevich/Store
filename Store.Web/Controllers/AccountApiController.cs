using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
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
    [AllowAnonymous]
    public class AccountApiController : DefaultApiController
    {
        private UserMapper _userMapper;

        public AccountApiController(IUnityOfWork unityOfWork, UserMapper userMapper)
            :base(unityOfWork)
        {
            _userMapper = userMapper;
        }

        [AllowAnonymous]
        public async Task<IHttpActionResult> Register(RegistrationJsonModel registrationJsonModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = _userMapper.ToUser(registrationJsonModel);

            var result = await _unityOfWork.Users.CreateAsync(user, registrationJsonModel.Password);

            if (!result.Succeeded)
            {
                return GetErrorResult(result);
            }

            return Ok();
        }

        public IHttpActionResult Logout()
        {
            Authentication.SignOut(CookieAuthenticationDefaults.AuthenticationType);
            return Ok();
        }

        private IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null)
            {
                return InternalServerError();
            }

            if (!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }

                if (ModelState.IsValid)
                {
                    return BadRequest();
                }

                return BadRequest(ModelState);
            }

            return null;
        }

        private IAuthenticationManager Authentication
        {
            get { return Request.GetOwinContext().Authentication; }
        }
    }
}