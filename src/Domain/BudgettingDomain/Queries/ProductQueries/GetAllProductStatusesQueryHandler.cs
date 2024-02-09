using BudgettingDomain.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Budgetting.Domain.Models;
using Services;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Budgetting.Services;

namespace Budgetting.Domain.Queries.ProductQueries
{
    public class GetAllProductStatusesQueryHandler : IRequestHandler<GetAllProductStatusesQuery, List<LookupTableData>>
    {
        private IProductService service;
        public GetAllProductStatusesQueryHandler(IProductService service)
        {
            this.service = service;
        }


        async Task<List<LookupTableData>> IRequestHandler<GetAllProductStatusesQuery, List<LookupTableData>>.Handle(GetAllProductStatusesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await service.GetProductStatuses();
                return result;
            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}
