using StoreBelleza.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace StoreBelleza
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
          
        }

        private void btnAdd_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new addProducts());
        }

        private void btnListProducts_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new listProduct());
        }
    }
}
