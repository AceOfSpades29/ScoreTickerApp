using System;
using ScoreTickerApp.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ScoreTickerApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new ScoreTickerView();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
