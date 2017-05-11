using Store.Api.Mappers;
using Store.Api.Models;
using Store.BL.UnityOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Store.Api.Controllers
{
    [RoutePrefix("api/Paypal")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class PaypalController : DefaultController
    {
        private ProductMapper _productMapper;

        public PaypalController(IUnityOfWork unityOfWork, ProductMapper productMapper)
            : base(unityOfWork)
        {
            _productMapper = productMapper;
        }

        [Route("PaymentWithPaypal")]
        [HttpPost]
        public async Task<IHttpActionResult> PaymentWithPaypal(PaymentPaypalJsonModel paymentPaypalJsonModel)
        {
            var product = await  _unityOfWork.Products.GetAsync(paymentPaypalJsonModel.ProductId);

            PaypalRest.PaymentWithPaypal.Paypal(paymentPaypalJsonModel.Url, product);

            return Ok("Success");
        }
    }
}
