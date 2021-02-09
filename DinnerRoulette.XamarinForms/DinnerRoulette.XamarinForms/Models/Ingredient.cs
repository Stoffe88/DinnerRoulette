namespace DinnerRoulette.XamarinForms.Models
{
    public enum Unit
    {
        ml,
        cl,
        dl,
        liter,
        gram,
        kg,
        lb,
        oz,
        grain,
        tsp,
        tbsp,
        pinch,
        cup,
        pint,
        quart
    }
    public class Ingredient
    {
        public string Id { get; set; }
        public string RecipeId { get; set; }
        public string Title { get; set; }
        public string Amount { get; set; }
        public string Unit { get; set; }
        public bool Picked { get; set; }
    }
}