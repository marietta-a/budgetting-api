using Budgetting.Domain.Models;
using Budgetting.Domain.Queries.CategoryQueries;
using Budgetting.Domain.Queries.ProductQueries;
using BudgettingDomain.Commands.CategoryCommands;
using BudgettingDomain.Commands.ProductCommands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BudgettingCore.Controllers
{
    [Route("api/[controller]/[action]")]
    public class CategoryController : ControllerBase
    {
        private readonly ILogger<Product> logger;
        private readonly IMediator mediator;

        public CategoryController(ILogger<Product> logger, IMediator mediator)
        {
            this.mediator = mediator;
            this.logger = logger;
        }

        [HttpPost(Name = "CreateCategory")]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryCommand command)
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

        [HttpPost(Name = "DeleteCategory")]
        public async Task<IActionResult> DeleteCategory([FromBody] DeleteCategoryCommand command)
        {
            try
            {
                var record = mediator.Send(command);
                return Ok(record);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost(Name = "UpdateCategory")]
        public async Task<IActionResult> UpdateCategory([FromBody] UpdateCategoryCommand command)
        {
            try
            {
                var record = mediator.Send(command);
                return Ok(record);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet(Name = "GetAllCategories")]
        public async Task<IActionResult> GetAllCategories()
        {
            try
            {
                var query = new GetAllCategoriesQuery();
                var Products = mediator.Send(query);

                return Ok(Products);
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        [HttpGet(Name = "GetAllParentCategories")]
        public async Task<IActionResult> GetAllParentCategories()
        {
            try
            {
                var query = new GetAllParentCategoriesQuery();
                var Products = mediator.Send(query);

                return Ok(Products);
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        [HttpGet(Name = "GetDetailedCategories")]
        public async Task<IActionResult> GetDetailedCategories()
        {
            try
            {
                var query = new GetDetailedCategoriesQuery();
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
