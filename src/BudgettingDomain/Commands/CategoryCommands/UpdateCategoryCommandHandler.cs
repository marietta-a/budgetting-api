using Budgetting.Domain.Models;
using Budgetting.Services;
using ExpressMapper.Extensions;
using MediatR;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgettingDomain.Commands.CategoryCommands
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, Category>
    {
        private ICategoryService service;
        public UpdateCategoryCommandHandler(ICategoryService service)
        {
            this.service = service;
        }

        async Task<Category> IRequestHandler<UpdateCategoryCommand, Category>.Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var record = new Category
                {
                    Id = request?.Id,
                    Name = request?.Name,
                    ParentCategoryId = request?.ParentCategoryId
                };

                var result = await service.AddOrUpdateItem(record);

                return result;
            }
            catch (Exception ex)
            { 
                throw;
            }
        }
    }
}
