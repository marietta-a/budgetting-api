using BudgettingDomain.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Budgetting.Domain.Models;
using Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Budgetting.Domain.Queries.ApplicationUserQueries
{
    public class GetAllApplicationUsersQueryHandler : IRequestHandler<GetAllApplicationUsersQuery, List<ApplicationUser>>
    {
        private IApplicationUserService service;
        public GetAllApplicationUsersQueryHandler(IApplicationUserService service)
        {
            this.service = service;
        }


        async Task<List<ApplicationUser>> IRequestHandler<GetAllApplicationUsersQuery, List<ApplicationUser>>.Handle(GetAllApplicationUsersQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await service.GetItems().Result.ToListAsync(cancellationToken);
                return result;
            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}
