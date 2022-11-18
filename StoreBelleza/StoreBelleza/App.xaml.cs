using StoreBelleza.Data;
using StoreBelleza.View;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StoreBelleza
{
    public partial class App : Application
    {

        private static SQLiteHelper db;
        public App()
        {
            InitializeComponent();

          

        }

        public static SQLiteHelper SQLiteHelper
        {
            get
            {
                if (db is null)
                {
                    db = new SQLiteHelper(Constants.DatabasePath);
                }
                return db;
            }
        }
        protected override void OnStart()
        {
            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
