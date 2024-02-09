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
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Product>
    {
        private IProductService service;
        public UpdateProductCommandHandler(IProductService service)
        {
            this.service = service;
        }

        async Task<Product> IRequestHandler<UpdateProductCommand, Product>.Handle(UpdateProductCommand request, CancellationToken cancellationToken)
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
                    CreatedBy = request?.CreatedBy,
                    StatusCode = request?.StatusCode,
                    PromotionCode = request?.PromotionCode,
                    Size = request?.Size
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
