using DinnerRoulette.XamarinForms.Models;
using DinnerRoulette.XamarinForms.ViewModels;
using System;
using System.Linq;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DinnerRoulette.XamarinForms.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ShoppingListPage : ContentPage
    {
        public ShoppingListPage()
        {
            InitializeComponent();
            BindingContext = new ShoppingListViewModel();
        }
        async void Home(Object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }

        void CollectionView_SelectionChanged(Object sender, SelectionChangedEventArgs e)
        {
            var ingredient = e.CurrentSelection.FirstOrDefault() as Ingredient;
            if (ingredient == null)
                return;
            else
                ingredient.Picked = !ingredient.Picked;

            ((CollectionView)sender).SelectedItem = null;
        }

        private void OnPickedChanged(object sender, CheckedChangedEventArgs e)
        {
            var cb = (CheckBox)sender;
            var item = (Ingredient)cb.BindingContext;
            if (item != null)
            {
                var vm = (ShoppingListViewModel)this.BindingContext;
                if(vm != null)
                {
                    vm.Recipe.Ingredients.Where(i => i.Title == item.Title).FirstOrDefault().Picked = item.Picked;
                    vm.UpdateIngredientsCommand.Execute(null);
                }
            }
        }
    }
}