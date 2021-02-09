using DinnerRoulette.XamarinForms.ViewModels;
using System;
using Xamarin.Forms;

namespace DinnerRoulette.XamarinForms.Pages
{
    public partial class DetailPage : ContentPage
    {
        public DetailPage()
        {
            InitializeComponent();
            BindingContext = new DetailPageViewModel();
        }

        async void Home(Object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }
    }
}