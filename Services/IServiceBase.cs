using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IServiceBase<T> where T : class
    {
        T GetItem(string key);
        T AddItem(T item);
        T EditItem(T item);
    }
}
