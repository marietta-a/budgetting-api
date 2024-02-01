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
    public class ShipmentService : ServiceBase<Shipment>, IShipmentService
    {
        public ShipmentService(IBudgettingContext _ctx) : base(_ctx)
        {
        }

        public override async Task<Shipment> GetItem(Shipment item)
        {
            return await Context.Shipments.FindAsync(item.EntityKeys);
        }
    }
}
