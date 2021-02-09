using DinnerRoulette.XamarinForms.Models;
using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using Xamarin.Essentials;

namespace DinnerRoulette.XamarinForms.ViewModels
{
    public class DetailPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        RecipeDetails recipe = default;
        string localPath;
        string image;
        string title;
        string description;
        RecipeInformation recipeInformation = new RecipeInformation();
        ObservableCollection<Ingredient> ingredients = new ObservableCollection<Ingredient>();
        ObservableCollection<Instruction> instructions = new ObservableCollection<Instruction>();
        public DetailPageViewModel()
        {
            localPath = Path.Combine(FileSystem.CacheDirectory, Constants.LocalFileName);
            recipe = JsonConvert.DeserializeObject<RecipeDetails>(File.ReadAllText(LocalPath));

            image = recipe.ImageURL;
            title = recipe.Title;
            description = recipe.Description;
            recipeInformation = recipe.RecipeInformation;
            recipe.Ingredients.ForEach(i => ingredients.Add(i));
            recipe.InstructionSteps.ForEach(i => instructions.Add(i));
        }
     
        // Propterties
        public RecipeDetails Recipe
        {
            get => recipe;
            private set { SetProperty(ref recipe, value); }
        }
        public string LocalPath
        {
            get => localPath;
            private set { SetProperty(ref localPath, value); }
        }
        public string Image { get => image; private set { SetProperty(ref image, value); } }
        public string Title { get => title; private set { SetProperty(ref title, value); } }
        public string Description { get => description; private set { SetProperty(ref description, value); } }
        public RecipeInformation RecipeInformation { get => recipeInformation; private set { SetProperty(ref recipeInformation, value); } }
        public ObservableCollection<Ingredient> Ingredients { get => ingredients; private set { SetProperty(ref ingredients, value); } }
        public ObservableCollection<Instruction> Instructions { get => instructions; private set { SetProperty(ref instructions, value); } }
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
