using Budgetting.Domain.Models;
using Budgetting.Services;
using BudgettingPersistence;
using Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budgetting.Repository
{
    public class PaymentService : ServiceBase<Payment>, IPaymentService
    {
        public PaymentService(IBudgettingContext _ctx) : base(_ctx)
        {
        }

        public override async Task<Payment> GetItem(Payment item)
        {
            return await Context.Payments.FindAsync(item.EntityKeys);
        }
    }
}
