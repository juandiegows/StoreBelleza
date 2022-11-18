using StoreBelleza.Controller;
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
    public partial class ManageProduct : ContentPage
    {
        ProductModel model;
        public ManageProduct()
        {
            InitializeComponent();
            BindingContext = model = new ProductModel(App.SQLiteHelper);
        }

        private async void btnDelete_Clicked(object sender, EventArgs e)
        {
            await Delete(sender);
        }

        private async Task Delete(object sender)
        {
            if ((await DisplayAlert("Question", "are you sure, you want to delete?", "yes", "no")))
            {
                Product product = (sender as Xamarin.Forms.View).BindingContext as Product;
                new ProductController(App.SQLiteHelper).Delete(product);
                model.collectionProduct.Remove(product);
                BindingContext = null;
                BindingContext = model;
            }
        }

        private async void btnSupply_Clicked(object sender, EventArgs e)
        {
            if ((await DisplayAlert("Question", "are you sure, you want to supply?", "yes", "no")))
            {
                string count = await DisplayPromptAsync("Question", "how many products you want to supply?", keyboard: Keyboard.Numeric);
                if (count == null)
                {
                    await DisplayAlert("error", "the  field is required", "Ok");
                    return;
                }
                int.TryParse(count, out int cant);
                Product product = (sender as Xamarin.Forms.View).BindingContext as Product;
                product.Count += cant;
                new ProductController(App.SQLiteHelper).Update(product);
                BindingContext = null;
                BindingContext = model;
            }
        }
    }
}