using Budgetting.Domain.Models;
using BudgettingCore.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BudgettingCore.Core
{
    public class ApiControllerBase: ControllerBase
    {
        public ApiControllerBase()
        {
        }

        protected ServerResult GetServerResult(object result, bool succeeded, object err = null)
        {
            return new ServerResult
            {
                Result = result,
                Succeeded = succeeded,
                Errors = err
            };
        }
    }
}
