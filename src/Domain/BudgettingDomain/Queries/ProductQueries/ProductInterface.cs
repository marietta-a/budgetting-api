using Budgetting.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgettingDomain.Queries.StaffQueries
{
    public interface ProductInterface
    {
        Product FindById(Guid id);
        ICollection<Product> FindAll();
        ICollection<Product> FindByName();
    }
}
