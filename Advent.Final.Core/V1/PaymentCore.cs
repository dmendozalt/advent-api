using Advent.Final.Contracts.Repository;
using Advent.Final.Core.Handlers;
using Advent.Final.Entities.Entities;
using Advent.Final.Entities.Utils;
using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent.Final.Core.V1
{
    public class PaymentCore
    {
        private readonly PaymentMethodCore _paymentMethodCore;
        private readonly StripeCore _stripe;

        public PaymentCore(IPaymentMethodRepository context, IMapper mapper, ILogger<PaymentMethod> logger)
        {
            _paymentMethodCore = new(context,mapper,logger);
            _stripe = new();
        }

        public async Task<ResponseService<List<PaymentMethod>>> GetAllMethods(int userId)
        {
            return await _paymentMethodCore.GetAllMethods(userId);
        }

        public async Task<string> PayBooking(int paymentMethodId,int total,string customerToken)
        {
            PaymentMethod paymentMethod = await _paymentMethodCore.GetById(paymentMethodId);
            var result = _stripe.PlacePayment(paymentMethod.Token, total,customerToken);
            return result.Id;
        }
    }
}
