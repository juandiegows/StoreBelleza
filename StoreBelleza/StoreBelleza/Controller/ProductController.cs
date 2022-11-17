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

        public Task<int> Delete(Product model)
        {
           return SQLite.DeleteAsync(model);
        }

        public Task<List<Product>> Get()
        {
            return SQLite.Table<Product>().ToListAsync();
        }

        public async Task<Product> Get(int ID)
        {
            return (await Get()).FirstOrDefault(x => x.Id == ID);
        }

        public Task<int> Insert(Product model)
        {
            return SQLite.InsertAsync(model);
        }

        public Task<int> Update(Product model)
        {
           return SQLite.UpdateAsync(model);
        }
    }
}
