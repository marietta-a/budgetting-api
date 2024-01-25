using Budgetting.Domain.Models;
using Budgetting.Domain.Queries.ProductQueries;
using BudgettingDomain.Commands.ProductCommands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BudgettingCore.Controllers
{
    [Route("api/[controller]/[action]")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<Product> logger;
        private readonly IMediator mediator;

        public ProductController(ILogger<Product> logger, IMediator mediator)
        {
            this.mediator = mediator;
            this.logger = logger;
        }

        [HttpPost(Name = "CreateProduct")]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductCommand command)
        {
            try
            {
                var record = mediator.Send(command);
                return Ok(record);
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        [HttpGet(Name = "GetAllProducts")]
        public async Task<IActionResult> GetALlProducts()
        {
            try
            {
                var query = new GetAllProductsQuery();
                var Products = mediator.Send(query);

                return Ok(Products);
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        
    }
}
