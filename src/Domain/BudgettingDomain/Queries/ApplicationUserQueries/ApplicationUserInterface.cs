using Budgetting.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgettingDomain.Queries.StaffQueries
{
    public interface ApplicationUserInterface
    {
        ApplicationUser FindById(Guid id);
        ICollection<ApplicationUser> FindAll();
        ICollection<ApplicationUser> FindByName();
    }
}
