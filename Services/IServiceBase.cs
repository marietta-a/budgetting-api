using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IServiceBase
    {

    }
    public interface IServiceBase<T> : IServiceBase where T : class
    {
        Task<T> GetItem(T item);
        Task<T> AddOrUpdateItem(T item);
    }
}
