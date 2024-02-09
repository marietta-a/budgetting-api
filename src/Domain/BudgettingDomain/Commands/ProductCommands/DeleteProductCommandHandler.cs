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

namespace BudgettingDomain.Commands.ProductCommands
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, Product>
    {
        private IProductService service;
        public DeleteProductCommandHandler(IProductService service)
        {
            this.service = service;
        }

        public async Task<Product> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = new Product
                {
                    Id = request?.Id,
                    Name = request?.Name,
                    ShortName = request?.ShortName,
                    DeliveryTimeSpan = request?.DeliveryTimeSpan,
                    Description = request?.Description,
                    Price = request.Price,
                    SKU = request?.SKU,
                    Stock = request.Stock,
                    ColorCode = request?.ColorCode,
                    ImageUrl = request?.ImageUrl,
                    CategoryId = request?.CategoryId,
                    CreatedDate = DateTime.Now,
                    CreatedBy = request?.CreatedBy
                };

                var result = await service.DeleteItem(user);

                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
