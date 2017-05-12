using PayPal.Api;
using Store.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Api.Paypal
{
    public class ExecPayment
    {
        private Payment payment;

        public Payment ExecutePayment(APIContext apiContext, string payerId, string paymentId)
        {
            var paymentExecution = new PaymentExecution() { payer_id = payerId };
            payment = new Payment() { id = paymentId };

            return payment.Execute(apiContext, paymentExecution);
        }

        public Payment CreatePayment(APIContext apiContext, string redirectUrl, Product product)
        {
            var itemList = new ItemList()
            {
                items = new List<Item>()
            };

            itemList.items.Add(new Item()
            {
                name = product.Name,
                currency = "USD",
                price = product.Price.ToString(),
                quantity = "1",
                sku = "sku"
            });

            var payer = new Payer()
            {
                payment_method = "paypal"
            };

            var redirUrls = new RedirectUrls()
            {
                cancel_url = redirectUrl,
                return_url = redirectUrl
            };

            var details = new Details()
            {
                tax = "1",
                shipping = "1",
                subtotal = product.Price.ToString()
            };

            var amount = new Amount()
            {
                currency = "USD",
                total = "14",
                details = details
            };

            var transactionList = new List<Transaction>();

            transactionList.Add(new Transaction()
            {
                description = "Transaction description.",
                invoice_number = "your invoice number",
                amount = amount,
                item_list = itemList
            });

            payment = new Payment()
            {
                intent = "sale",
                payer = payer,
                transactions = transactionList,
                redirect_urls = redirUrls
            };

            return payment.Create(apiContext);
        }
    }
}
