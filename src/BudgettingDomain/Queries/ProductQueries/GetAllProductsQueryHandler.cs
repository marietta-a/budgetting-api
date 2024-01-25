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
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, List<Product>>
    {
        private IProductService service;
        public GetAllProductsQueryHandler(IProductService service)
        {
            this.service = service;
        }


        async Task<List<Product>> IRequestHandler<GetAllProductsQuery, List<Product>>.Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await service.GetItems().Result.ToListAsync(cancellationToken);
                return result;
            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}
