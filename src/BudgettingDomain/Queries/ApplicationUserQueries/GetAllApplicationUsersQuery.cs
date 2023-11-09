using BudgettingDomain.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budgetting.Domain.Queries.ApplicationUserQueries
{
    public class GetAllApplicationUsersQuery : IRequest<List<Models.ApplicationUser>>
    {
    }
}
