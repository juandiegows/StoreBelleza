using StoreBelleza.Data;
using StoreBelleza.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreBelleza.Controller
{
    public class ProductController: IController<Product>
    {
        private SQLiteHelper SQLite;
        public ProductController(SQLiteHelper db)
        {
            SQLite = db;
        }

        public int Delete(Product model)
        {
           return SQLite.Delete(model);
        }

        public List<Product> Get()
        {
            return SQLite.Table<Product>().ToList();
        }

        public  Product Get(int ID)
        {
            return ( Get()).FirstOrDefault(x => x.Id == ID);
        }

        public int Insert(Product model)
        {
            return SQLite.Insert(model);
        }

        public int nInsert(Product model)
        {
            throw new NotImplementedException();
        }

        public int Update(Product model)
        {
           return SQLite.Update(model);
        }

      
    }
}
