using System.Collections.Generic;

namespace DinnerRoulette.XamarinForms.Models
{
    public class AnalyzedInstructions
    {
        public string Name { get; set; }

        public List<Instruction> Steps { get; set; }
    }
}