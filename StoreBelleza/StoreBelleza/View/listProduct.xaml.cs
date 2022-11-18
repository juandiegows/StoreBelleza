using StoreBelleza.Controller;
using StoreBelleza.Data;
using StoreBelleza.Model;
using StoreBelleza.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
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
        ProductModel model;
        public listProduct()
        {

            InitializeComponent();
            BindingContext = model = new ProductModel(App.SQLiteHelper);
            

        }

        private async void btnBuy_Clicked(object sender, EventArgs e)
        {
            if (model.Count == 0)
            {
                await DisplayAlert("error", "first add products to shopping cart", "Ok");
                return;
            }
            if ((await DisplayAlert("Question", "are you sure, you want to buy?", "yes", "no")))
            {
                string NIC = await DisplayPromptAsync("Question 1", "What's your NIC?", keyboard: Keyboard.Numeric);
                if (NIC ==  null)
                {
                    await DisplayAlert("error", "the NIC field is required", "Ok");
                    return;
                }
                string direction = await DisplayPromptAsync("Question 2", "What's your Direction home?");
                if (direction == null)
                {
                    await DisplayAlert("error", "the direction field is required", "Ok");
                    return;
                }
                ProductController productController = new ProductController(App.SQLiteHelper);
                foreach (var prod in model.collectionProduct.Where(x=> model.productsCard.Count(d=> d.Id == x.Id)> 0))
                {
                    productController.Update(prod);
                }
                await DisplayAlert("Success", "has been saved successfully", "Ok");
            }
        }

        private async void btnAddCart_Clicked(object sender, EventArgs e)
        {
            await AddCart(sender);

        }

        private async Task AddCart(object sender)
        {
            var product = (sender as Xamarin.Forms.View).BindingContext as Product;
            string countString = await DisplayPromptAsync("Question 1", "how many products do you want (" + product.Name + ")?", keyboard: Keyboard.Numeric);
            int.TryParse(countString, out int count);
            if (count == 0)
            {
                return;
            }

            if (model.Add(product, count))
            {
                BindingContext = null;
                BindingContext = model;
                await DisplayAlert("Success", "successfully added to cart the product " + product.Name, "Ok");
            }
            else
            {
                await DisplayAlert("error", "Can't add to cart,check that the quantity does not exceed the limit in inventory (" + product.Name + ")", "Ok");
            }
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await AddCart(sender);

        }
    }
}