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
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, Category>
    {
        private ICategoryService service;
        public DeleteCategoryCommandHandler(ICategoryService service)
        {
            this.service = service;
        }

        public async Task<Category> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var record = new Category
                {
                    Id = request?.Id,
                    Name = request?.Name,
                    ParentCategoryId = request?.ParentCategoryId
                };

                var result = await service.DeleteItem(record);

                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
