using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StoreBelleza.Controller
{
    public interface IController<T>
    {
        Task<int> Insert(T model);
        Task<List<T>> Get();
        Task<T> Get(int ID);
        Task<int> Update(T model);
        Task<int> Delete(T model);
    }
}
