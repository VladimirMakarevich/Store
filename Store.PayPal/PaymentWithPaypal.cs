using log4net.Repository.Hierarchy;
using PayPal.Api;
using Store.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.PaypalRest
{
    public static class PaymentWithPaypal
    {
        public static void Paypal(string redirectUrl, Product product)
        {
            APIContext apiContext = Configuration.GetAPIContext();

            try
            {
                var guid = Convert.ToString((new Random()).Next(100000));

                var createdPayment = ExecPayment.CreatePayment(apiContext, redirectUrl, product);

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

            }
            catch (Exception ex)
            {
                throw ex;
                //Logger.log("Error" + ex.Message);
            }
        }
    }
}
