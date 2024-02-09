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
    public class GetDetailedCategoriesQueryHandler : IRequestHandler<GetDetailedCategoriesQuery, List<ParentCategories>>
    {
        private ICategoryService service;
        public GetDetailedCategoriesQueryHandler(ICategoryService service)
        {
            this.service = service;
        }


        async Task<List<ParentCategories>> IRequestHandler<GetDetailedCategoriesQuery, List<ParentCategories>>.Handle(GetDetailedCategoriesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await service.GetDetailedCategories();
                return result;
            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}
