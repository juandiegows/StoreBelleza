using StoreBelleza.Controller;
using StoreBelleza.Data;
using StoreBelleza.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace StoreBelleza.ViewModels
{
    public class ProductModel : INotifyPropertyChanged
    {

        public ObservableCollection<Product> collectionProduct { get; set; }
        public List<Product> productsCard { get; set; }
        public int Count
        {
            get
            {
                if (productsCard == null)
                {
                    return 0;
                }
                return productsCard.Sum(x=> x.Count);
            }
        }
        public double Price
        {
            get
            {
                if (productsCard == null)
                {
                    return 0;
                }
                return productsCard.Sum(x => x.Price * x.Count);
            }
        }
        public bool Add(Product product_, int count)
        {
            Product productItem = collectionProduct.Where(x => x.Id == product_.Id).FirstOrDefault();
            if (productItem == null)
            {
                return false;
            }
            if (productItem.Count - count < 0)
            {
                return false;
            }

            productItem.Count -= count;
            if (productsCard.Count(x => x.Id == product_.Id) == 0)
            {
              
                productsCard.Add(new Product
                {
                    Count = count,
                    Description = product_.Description,
                    Price = product_.Price,
                    Name = product_.Name,
                    Id = product_.Id 
                });
                NotifyPropertyChanged();
            }
            else
            {
                Product productSelect = productsCard.Where(x => x.Id == product_.Id).First();
                productSelect.Count += count;
                NotifyPropertyChanged("collectionProduct");
            }
            return true;
        }
        public ProductModel(SQLiteHelper db)
        {
            productsCard = new List<Product>();
            Get(db);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
   
        public void Get(SQLiteHelper db)
        {
            collectionProduct = new ObservableCollection<Product>(new ProductController(db).Get());
        }
    }
}
