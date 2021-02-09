using System.Runtime.Serialization;

namespace DinnerRoulette.XamarinForms
{
    public static class Constants
    {
        private const string APIKey = "d64e0b3cecbd4c21b48dffb302f18a63";
        public const string GetRandomMainDish = "https://api.spoonacular.com/recipes/random?apiKey=d64e0b3cecbd4c21b48dffb302f18a63&limitLicense=true&number=1&tags=dinner,main";
        public const string LocalFileName = "TheRecipe.txt";
        public const string GetFromLocal = "https://172.17.134.225:44335/api/Recipe";
    }
}
