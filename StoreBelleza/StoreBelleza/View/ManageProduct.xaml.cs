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
    public partial class ManageProduct : ContentPage
    {
        ProductModel model;
        public ManageProduct()
        {
            InitializeComponent();
            BindingContext = model = new ProductModel(App.SQLiteHelper);
        }
    }
}