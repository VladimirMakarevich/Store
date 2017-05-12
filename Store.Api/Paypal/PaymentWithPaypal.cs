using PayPal.Api;
using Store.DAL.Entities;
using System;

namespace Store.Api.Paypal
{
    public class PaymentWithPaypal
    {
        public string Paypal(string redirectUrl, Product product)
        {
            try
            {
                APIContext apiContext = Configuration.GetAPIContext();

                var guid = Convert.ToString((new Random()).Next(100000));

                ExecPayment pay = new ExecPayment();

                var createdPayment = pay.CreatePayment(apiContext, redirectUrl + "guid=" + guid, product);

                var links = createdPayment.links.GetEnumerator();

                string paypalRedirectUrl = null;

                while (links.MoveNext())
                {
                    Links lnk = links.Current;

                    if (lnk.rel.ToLower().Trim().Equals("approval_url"))
                    {
                        paypalRedirectUrl = lnk.href;
                    }
                }

                return paypalRedirectUrl;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
