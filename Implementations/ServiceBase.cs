using BudgettingPersistence;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementations
{
    public abstract class ServiceBase<T> where T : class, IServiceBase<T>
    {
        public IBudgettingContext Context { get; set; }
        public ServiceBase(IBudgettingContext _ctx) 
        { 
            Context = _ctx;
        }
    }
}
