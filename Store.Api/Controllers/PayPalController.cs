using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Store.Api.Controllers
{
    public class PaypalController : ApiController
    {
        public PaypalController()
        {

        }

        public IHttpActionResult PaymentWithPaypal(string payerId)
        {
            PaypalRest.PaymentWithPaypal.Paypal("ASD", "dad");

            return Ok("Success");
        }
    }
}
