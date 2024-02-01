using Budgetting.Domain.Models;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budgetting.Services
{
    public interface IProductService : IServiceBase<Product>
    {
        Task<List<LookupTableData>> GetProductStatuses();
        //Task<List<Product>> GetDetailedProducts();
    }
}
