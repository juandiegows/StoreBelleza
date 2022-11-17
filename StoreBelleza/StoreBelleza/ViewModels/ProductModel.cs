using StoreBelleza.Controller;
using StoreBelleza.Data;
using StoreBelleza.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StoreBelleza.ViewModels
{
    public class ProductModel
    {
        public ObservableCollection<Product> collectionProduct { get; set; }
        public  ProductModel(SQLiteHelper db)
        {
            Get(db);
        }

        public  void Get(SQLiteHelper db)
        {
            collectionProduct = new ObservableCollection<Product>(  new ProductController(db).Get());
        }
    }
}
