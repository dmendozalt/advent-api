using Advent.Final.Entities.DTOs;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent.Final.Core.V1
{
    public class StripeCore
    {
        public StripeCore()
        {
            StripeConfiguration.ApiKey = "sk_test_51LLgOpHNoFBenqbdMnR7j1MfKUPJ9e1mnU6TQlSPHsw78Jj78zNhblpkBR1cmlkBnUN3egLwwcvVxBquTXA4AKOI00HTBT5Tmp";
        }

        public PaymentMethod CreatePaymentMethod(CardDto card,string idCustomer)
        {
            var options = new PaymentMethodCreateOptions
            {
                Type = "card",
                Card = new PaymentMethodCardOptions
                {
                    Number = card.Number,
                    ExpMonth = card.ExpMonth,
                    ExpYear = card.ExpYear,
                    Cvc = card.Cvv,
                },
            };
            var service = new PaymentMethodService();
            var result= service.Create(options);
            AttachPaymentMethodToCustomer(result.Id, idCustomer);
            return result;
        }

        public PaymentIntent PlacePayment(string methodToken, int amount,string customerToken, string currency="usd")
        {
            var options = new PaymentIntentCreateOptions
            {
                Amount = amount*100,
                Currency = currency,
                PaymentMethod = methodToken,
                Customer=customerToken,
                Confirm = true
            };
            var service = new PaymentIntentService();
            return service.Create(options);
        }

        public string CreateCustomer(string name, string email)
        {
            var options = new CustomerCreateOptions
            {
                Name = name,
                Email = email
            };
            var service = new CustomerService();
            return service.Create(options).Id;
        }

        private void AttachPaymentMethodToCustomer(string idPaymentMethod, string idCustomer)
        {
            var options = new PaymentMethodAttachOptions
            {
                Customer = idCustomer,
            };
            var service = new PaymentMethodService();
            service.Attach(idPaymentMethod,options);
        }

    }
}
