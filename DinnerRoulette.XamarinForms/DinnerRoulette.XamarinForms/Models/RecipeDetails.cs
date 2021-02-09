using System.Collections.Generic;

namespace DinnerRoulette.XamarinForms.Models
{
    public class RecipeDetails
    {
        public string Title { get; set; }
        public string ImageURL { get; set; }
        public string Description { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public List<Instruction> InstructionSteps { get; set; }
        public RecipeInformation RecipeInformation { get; set; }

        public RecipeDetails() {}
    }
}
