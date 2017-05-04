using Microsoft.AspNet.Identity;
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

        public async Task Post(UserLoginJsonModel userLoginJsonModel)
        {
            var claim = await _unityOfWork.Users.AuthenticateAsync(userLoginJsonModel.Login, userLoginJsonModel.Password);

            if (claim == null)
            {
                throw new NullReferenceException();
            }
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
                    // No ModelState errors are available to send, so just return an empty BadRequest.
                    return BadRequest();
                }

                return BadRequest(ModelState);
            }

            return null;
        }
    }
}