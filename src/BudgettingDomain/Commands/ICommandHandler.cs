using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgettingDomain.Commands
{
    public interface ICommandHandler<in T>
    {
        ValueTask Handle(T command, CancellationToken cancellationToken);
    }
}
