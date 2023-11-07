using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgettingDomain.Queries
{
    public interface IQueryHandler<in T, TResult>
    {
        ValueTask<TResult> Handle(T query, CancellationToken cancellationToken);
    }
}
