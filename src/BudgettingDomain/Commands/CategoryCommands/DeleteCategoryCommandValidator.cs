using BudgettingDomain.Commands.CategoryCommands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budgetting.Domain.Commands.CategoryCommands
{
    public class DeleteCategoryCommandValidator: AbstractValidator<DeleteCategoryCommand>
    {
        public DeleteCategoryCommandValidator() 
        {
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}
