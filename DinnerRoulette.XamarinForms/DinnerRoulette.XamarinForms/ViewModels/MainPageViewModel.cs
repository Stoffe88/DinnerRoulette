using DinnerRoulette.XamarinForms.Helpers;
using DinnerRoulette.XamarinForms.Models;
using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.IO;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace DinnerRoulette.XamarinForms.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public ICommand GetRecipeCommand { get; private set; }
        RecipeDetails recipe = default;
        bool hasRecipe = false;
        string localPath;
        public event PropertyChangedEventHandler PropertyChanged;
        public RecipeDetails Recipe
        {
            get => recipe;
            private set { SetProperty(ref recipe, value); }
        }
        public bool HasRecipe
        {
            get => hasRecipe;
            private set { SetProperty(ref hasRecipe, value); } 
        }
        public string LocalPath 
        { 
            get => localPath;
            private set => localPath = value; 
        }
        public MainPageViewModel()
        {
            localPath = Path.Combine(FileSystem.CacheDirectory, Constants.LocalFileName);

            GetRecipeCommand = new Command(async () =>
            {
                Recipe = await GetRecipeAsync();
                File.WriteAllText(LocalPath, JsonConvert.SerializeObject(Recipe));
            });

            if (File.Exists(LocalPath)) Recipe = JsonConvert.DeserializeObject<RecipeDetails>(File.ReadAllText(LocalPath));
            else
            {
                GetRecipeCommand.Execute(null);
            }
        }
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
        private async Task<RecipeDetails> GetRecipeAsync()
        {
            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync(new Uri(Constants.GetRandomMainDish));
                
                if (response.IsSuccessStatusCode)
                {
                    RecipeList recipes = JsonConvert.DeserializeObject<RecipeList>(await response.Content.ReadAsStringAsync());
                    return RecipeHelper.ExtractRecipe(recipes.Recipes[0]);
                }
            }
            // Has a default recipe if unable to fetch a recipe.
            return RecipeHelper.Recipes[0];
        }
    }
}
