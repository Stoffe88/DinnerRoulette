using DinnerRoulette.XamarinForms.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace DinnerRoulette.XamarinForms.ViewModels
{
    public class ShoppingListViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        ObservableCollection<Ingredient> ingredients = new ObservableCollection<Ingredient>();
        RecipeDetails recipe = default;
        string localPath;

        public ShoppingListViewModel()
        {
            localPath = Path.Combine(FileSystem.CacheDirectory, Constants.LocalFileName);

            recipe = JsonConvert.DeserializeObject<RecipeDetails>(File.ReadAllText(localPath));

            recipe.Ingredients.ForEach(i => { ingredients.Add(i); });

            // UpdateIngredient this works as intended
            UpdateIngredientsCommand = new Command(() =>
            {
                List<Ingredient> updatedList = new List<Ingredient>();
                updatedList.AddRange(Ingredients);
                recipe.Ingredients = updatedList;
                File.WriteAllText(LocalPath, JsonConvert.SerializeObject(recipe));
            });
        }

        public ICommand UpdateIngredientsCommand { get; set; }

        // Propterties
        public RecipeDetails Recipe
        {
            get => recipe;
            private set { SetProperty(ref recipe, value); }
        }
        public ObservableCollection<Ingredient> Ingredients
        {
            get => ingredients;
            private set { SetProperty(ref ingredients, value); }
        }
        public string LocalPath
        {
            get => localPath;
            private set { SetProperty(ref localPath, value); }
        }

        // Property methods
        bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (Object.Equals(storage, value)) return false;

            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
