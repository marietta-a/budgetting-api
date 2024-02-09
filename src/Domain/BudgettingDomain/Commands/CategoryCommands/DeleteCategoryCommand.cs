using Budgetting.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BudgettingDomain.Commands.CategoryCommands
{
    public class DeleteCategoryCommand: IRequest<Category>
    {
        public DeleteCategoryCommand()
        {

        }

        public DeleteCategoryCommand(string id, string name, string? parentCategoryId)
        {
            Id = id;
            Name = name;
            ParentCategoryId = parentCategoryId;
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string? ParentCategoryId { get; set; }

    }
}
