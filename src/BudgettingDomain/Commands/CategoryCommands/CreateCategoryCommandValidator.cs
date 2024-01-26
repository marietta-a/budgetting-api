using BudgettingDomain.Commands.CategoryCommands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budgetting.Domain.Commands.CategoryCommands
{
    public class CreateCategoryCommandValidator: AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryCommandValidator() 
        {
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}
