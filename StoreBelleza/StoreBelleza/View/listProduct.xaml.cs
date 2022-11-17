using StoreBelleza.Controller;
using StoreBelleza.Data;
using StoreBelleza.Model;
using StoreBelleza.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StoreBelleza.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class listProduct : ContentPage
    {

        public ObservableCollection<Product> collectionProduct { get; set; }
        public  listProduct() 
        {

            InitializeComponent();
            Get();
            BindingContext = new ProductModel(App.SQLiteHelper);

       
        }
        public  void Get()
        {

            IEnumerable<Product> lista = App.SQLiteHelper.Table<Product>();
            collectionProduct = new ObservableCollection<Product>(lista);
        }
    }
}