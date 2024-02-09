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
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Product>
    {
        private IProductService service;
        public CreateProductCommandHandler(IProductService service)
        {
            this.service = service;
        }

        async Task<Product> IRequestHandler<CreateProductCommand, Product>.Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = new Product
                {
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

                var result = await service.AddOrUpdateItem(user);

                return result;
            }
            catch (Exception ex)
            { 
                throw;
            }
        }
    }
}
