using StoreBelleza.Model;
using StoreBelleza.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StoreBelleza.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class listProduct : ContentPage
    {
        public listProduct()
        {
            InitializeComponent();
            BindingContext = new ProductModel(App.SQLiteHelper);
        }
    }
}