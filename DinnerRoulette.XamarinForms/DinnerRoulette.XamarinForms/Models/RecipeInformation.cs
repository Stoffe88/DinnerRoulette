namespace DinnerRoulette.XamarinForms.Models
{
    public class RecipeInformation
    {
        public int ReadyInMinutes { get; set; }
        public int WeightWatcherSmartPoints { get; set; }
        public bool Vegetarian { get; set; }
        public bool Vegan { get; set; }
        public bool GlutenFree { get; set; }
        public bool DairyFree { get; set; }
        public string Diets { get; set; }
    }
}