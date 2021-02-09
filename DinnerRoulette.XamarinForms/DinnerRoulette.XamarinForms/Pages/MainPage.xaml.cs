using DinnerRoulette.XamarinForms.ViewModels;
using System;
using Xamarin.Forms;

namespace DinnerRoulette.XamarinForms.Pages
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainPageViewModel();
        }
        async void Spin(Object sender, EventArgs e)
        {
            await imageSpin.RelRotateTo(3600,3000);
        }
        async void GoToShoppingList(Object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ShoppingListPage());
        }
        async void GoToDetails(Object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DetailPage());
        }
    }
}
