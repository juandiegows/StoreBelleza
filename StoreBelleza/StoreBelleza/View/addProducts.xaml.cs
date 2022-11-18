using StoreBelleza.Controller;
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
    public partial class addProducts : ContentPage
    {
        public addProducts()
        {
            InitializeComponent();
            btnCancel.Clicked += BtnCancel_Clicked;

        }

        private async void BtnCancel_Clicked(object sender, EventArgs e)
        {
            if ((await DisplayAlert("Question", "are you sure, you want to exit?", "yes", "no")))
            {
                await Navigation.PopAsync();
            }

        }

        private async void btnAdd_Clicked(object sender, EventArgs e)
        {
            if (await IsValid())
            {
                if ((await DisplayAlert("Question", "are you sure, you want to save?", "yes", "no")))
                {
                    double.TryParse(txtPrice.Text, out double price);
                    int.TryParse(txtCount.Text, out int count);
                    int result =  new ProductController(App.SQLiteHelper).Insert(new Model.Product
                    {
                        Name = txtName.Text,
                        Description = txtDescription.Text,
                        Price = price,
                        Count = count,
                        Id = 0
                    });
                    if(result> 0)
                    {

                        await DisplayAlert("Success", "has been saved successfully", "Ok");
                        txtName.Text = "";
                        txtDescription.Text = "";
                        txtPrice.Text = "";
                        txtCount    .Text = "";
                    }else
                    {
                        await DisplayAlert("Error", "has not been saved", "Ok");
                    }
                }
            }
            else
            {
                await DisplayAlert("Alert", "check all fields before saving", "Ok");
            }

        }

        public async Task<bool> IsValid()
        {
            if (string.IsNullOrEmpty(txtName.Text))
            {
                return false;
            }
            if (string.IsNullOrEmpty(txtDescription.Text))
            {
                return false;
            }
            if (string.IsNullOrEmpty(txtPrice.Text))
            {
                return false;
            }
            if (string.IsNullOrEmpty(txtCount.Text))
            {
                return false;
            }
            int.TryParse(txtCount.Text, out int count);
            if (count <= 0)
            {
                await DisplayAlert("Alert", "the count field must be greater than zero", "Ok");
                return false;
            }

            double.TryParse(txtCount.Text, out double price);
            if (price <= 0)
            {
                await DisplayAlert("Alert", "the price field must be greater than zero", "Ok");
                return false;
            }
            return true;
        }
    }
}