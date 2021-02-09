using System;
using System.Collections.Generic;

namespace DinnerRoulette.XamarinForms.Models
{
    public class ExtendedIngredients
    {
        public int Id { get; set; }
        public string Aisle { get; set; }
        public string Image { get; set; }
        public string Consistency { get; set; }
        public string Name { get; set; }
        public string Original { get; set; }
        public string OriginalString { get; set; }
        public string OriginalName { get; set; }
        public double Amount { get; set; }
        public string Unit { get; set; }
        public List<string> Meta { get; set; }
        public List<string> MedaInformation { get; set; }
        public Measures Measures { get; set; }

    }
}