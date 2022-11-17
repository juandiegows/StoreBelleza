using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StoreBelleza.Controller
{
    public interface IController<T>
    {
        int nInsert(T model);
        List<T> Get();
        T Get(int ID);
        int Update(T model);
        int Delete(T model);
    }
}
