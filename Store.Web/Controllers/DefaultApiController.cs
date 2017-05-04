using Store.BL.UnityOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Store.Web.Controllers
{
    public class DefaultApiController : ApiController
    {
        public IUnityOfWork _unityOfWork;

        public DefaultApiController(IUnityOfWork unityOfWork)
        {
            _unityOfWork = unityOfWork;
        }
    }
}
