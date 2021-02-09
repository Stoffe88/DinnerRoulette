using System.Collections.Generic;

namespace DinnerRoulette.XamarinForms.Models
{
    public class Instruction
    {
        public int Number { get; set; }
        public string Step { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public List<Equipment> Equipment { get; set; }
    }
}