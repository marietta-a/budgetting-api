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

namespace Budgetting.Domain.Queries.CategoryQueries
{
    public class GetAllParentCategoriesQueryHandler : IRequestHandler<GetAllParentCategoriesQuery, List<LookupTableData>>
    {
        private ICategoryService service;
        public GetAllParentCategoriesQueryHandler(ICategoryService service)
        {
            this.service = service;
        }


        async Task<List<LookupTableData>> IRequestHandler<GetAllParentCategoriesQuery, List<LookupTableData>>.Handle(GetAllParentCategoriesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await service.GetParentCategories();
                return result;
            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}
