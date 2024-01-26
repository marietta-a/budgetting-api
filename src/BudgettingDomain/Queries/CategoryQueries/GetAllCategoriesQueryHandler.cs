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
    public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, List<Category>>
    {
        private ICategoryService service;
        public GetAllCategoriesQueryHandler(ICategoryService service)
        {
            this.service = service;
        }


        async Task<List<Category>> IRequestHandler<GetAllCategoriesQuery, List<Category>>.Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
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
