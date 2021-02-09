using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DinnerRoulette.XamarinForms.Models
{
    public class Recipe
    {
        // Can be Added to the RecipeInformation holder.
        public bool Vegetarian { get; set; }
        public bool Vegan { get; set; }
        public bool GlutenFree { get; set; }
        public bool DairyFree { get; set; }
        public List<string> Diets { get; set; }
        public int WeightWatcherSmartPoints { get; set; }
        public int ReadyInMinutes { get; set; }

        public bool VeryHealthy { get; set; }
        public bool Cheap { get; set; }
        public bool VeryPopular { get; set; }
        public bool Sustainable { get; set; }
        public string Gaps { get; set; }
        public bool LowFodmap { get; set; }
        public int AggregateLikes { get; set; }
        public double SpoonacularScore { get; set; }
        public double HealthScore { get; set; }
        public string CreditsText { get; set; }
        public string License { get; set; }
        public string SourceName { get; set; }
        public double PricePerServing { get; set; }
        public List<ExtendedIngredients> ExtendedIngredients { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        // Calculate amounts based on this....
        public int Servings { get; set; }
        public string SourceUrl { get; set; }
        // This is a URL to the image
        public string Image { get; set; }
        public string ImageType { get; set; }
        // Description
        public string Summary { get; set; }
        public List<string> Cuisines { get; set; }
        public List<string> DishTypes { get; set; }
        public string Instructions { get; set; }
        // Make this more accessable
        public List<AnalyzedInstructions> AnalyzedInstructions { get; set; }
        public int? OriginalId { get; set; }
        public string SpoonacularSourceUrl { get; set; }
        //public List<Ingredient> Ingredients { get; set; }
        //public List<Instruction> InstructionSteps { get; set; }
        public RecipeInformation RecipeInformation
        {
            get => RecipeInformation;
            private set
            {
                this.RecipeInformation.Vegetarian = this.Vegetarian;
                this.RecipeInformation.Vegan = this.Vegan;
                this.RecipeInformation.GlutenFree = this.GlutenFree;
                this.RecipeInformation.DairyFree = this.DairyFree;
                StringBuilder builder = new StringBuilder();

                for (int i = 0; i < this.Diets.Count; i++)
                {
                    builder.Append(this.Diets[i]);
                    if (i != this.Diets.Count) builder.Append(", ");
                }

                this.RecipeInformation.Diets = builder.ToString();
                this.RecipeInformation.WeightWatcherSmartPoints = this.WeightWatcherSmartPoints;
                this.RecipeInformation.ReadyInMinutes = this.ReadyInMinutes;
            }
        }

    }
}
