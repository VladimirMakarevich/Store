using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using Store.BL.UnityOfWork;
using Store.Api.Mappers;
using Store.Api.Models;
using System.Web.Http.Cors;

namespace Store.Api.Controllers
{
    [RoutePrefix("api/Account")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class AccountController : DefaultController
    {
        private UserMapper _userMapper;

        public AccountController(IUnityOfWork unityOfWork, UserMapper userMapper)
            : base(unityOfWork)
        {
            _userMapper = userMapper;
        }

        [AllowAnonymous]
        [Route("PostRegister")]
        [HttpPost]
        public async Task<IHttpActionResult> PostRegister([FromBody]RegistrationUser registrationUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = _userMapper.ToUser(registrationUser);

            await _unityOfWork.Users.CreateAsync(user, registrationUser.Password);

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