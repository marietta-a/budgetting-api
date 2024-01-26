using Budgetting.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgettingDomain.Queries.StaffQueries
{
    public interface CategoryInterface
    {
        Category FindById(Guid id);
        ICollection<Category> FindAll();
        ICollection<Category> FindByName();
    }
}
