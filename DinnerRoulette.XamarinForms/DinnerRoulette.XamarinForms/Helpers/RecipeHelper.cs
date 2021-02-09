using DinnerRoulette.XamarinForms.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace DinnerRoulette.XamarinForms.Helpers
{
    public static class RecipeHelper
    {
        public static ObservableCollection<RecipeDetails> Recipes { get; set; }
        static RecipeHelper()
        {
            Recipes = new ObservableCollection<RecipeDetails>();

            Recipes.Add(new RecipeDetails
            {
                Title = "Eggplant Parmesan",
                Description = "If you want to add more <b>Mediterranean</b> recipes to your collection, Eggplant Parmesan might be a recipe you should try. This recipe serves 4 and costs $3.1 per serving. One serving contains <b>824 calories</b>, <b>29g of protein</b>, and <b>62g of fat</b>. This recipe from Foodista requires mozzarella cheese, parmesan cheese, bread crumbs, and tomato sauce. It works well as a main course. 8 people were impressed by this recipe. From preparation to the plate, this recipe takes approximately <b>approximately 45 minutes</b>. Taking all factors into account, this recipe <b>earns a spoonacular score of 64%</b>, which is solid. Similar recipes include <a href=\"https://spoonacular.com/recipes/crispy-baked-eggplant-fries-with-marinara-dipping-sauce-aka-eggplant-parmesan-fries-249194\">Crispy Baked Eggplant Fries with Marinara Dipping Sauce (akan Eggplant Parmesan Fries!)</a>, <a href=\"https://spoonacular.com/recipes/eggplant-parmesan-104085\">Eggplant Parmesan</a>, and <a href=\"https://spoonacular.com/recipes/eggplant-parmesan-103980\">Eggplant Parmesan</a>.",
                ImageURL = "https://spoonacular.com/recipeImages/642293-556x370.jpg",
                Ingredients = new List<Ingredient>
                {
                    new Ingredient
                    {
                        Title = "eggplant",
                        Amount = "1",
                        Unit = "large"
                    },
                    new Ingredient
                    {
                        Title = "egg",
                        Amount = "3",
                        Unit = ""
                    },
                    new Ingredient
                    {
                        Title = "bread crumbs",
                        Amount = "1",
                        Unit = "cup"
                    },
                    new Ingredient
                    {
                        Title = "olive oil",
                        Amount = "0.75",
                        Unit = "cup"
                    },
                    new Ingredient
                    {
                        Title = "parmesan cheese",
                        Amount = "0.5",
                        Unit = "cup"
                    },
                    new Ingredient
                    {
                        Title = "mozzarella cheese",
                        Amount = "0.5",
                        Unit = "pound"
                    },
                    new Ingredient
                    {
                        Title = "canned tomato sauce",
                        Amount = "24",
                        Unit = "oz"
                    },
                    new Ingredient
                    {
                        Title = "garlic",
                        Amount = "1",
                        Unit = "clove"
                    },
                    new Ingredient
                    {
                        Title = "yellow onion",
                        Amount = "2",
                        Unit = "medium"
                    },
                    new Ingredient
                    {
                        Title = "oregano",
                        Amount = "0.5",
                        Unit = "teaspoon"
                    }
                },
                InstructionSteps = new List<Instruction>
                {
                    new Instruction
                    {
                        Step = "Preheat oven to 350 degrees."
                    },
                    new Instruction
                    {
                        Step = "Slice eggplant into 1/4 inch thick rounds and salt for 30 minutes to remove water."
                    },
                    new Instruction
                    {
                        Step = "Saute onions and garlic in a tablespoon of oil."
                    },
                    new Instruction
                    {
                        Step = "Add tomatoes and oregano, simmer until sauce thickens slightly."
                    },
                    new Instruction
                    {
                        Step = "Dip each eggplant slice first into eggs, then into crumbs."
                    },
                    new Instruction
                    {
                        Step = "Saute in hot olive oil until golden brown on both sides."
                    },
                    new Instruction
                    {
                        Step = "Place a layer of browned slices in 2 quart casserole; sprinkle with some of Parmesan, oregano and mozzarella; then cover well with some of tomato sauce."
                    },
                    new Instruction
                    {
                        Step = "Repeat until all eggplant is used, topping last layer of sauce with several slices of mozzarella."
                    },
                    new Instruction
                    {
                        Step = "Bake until the sauce bubbles and the cheese is melted and browned, about 30 minutes."
                    },
                },
                RecipeInformation = new RecipeInformation
                {
                    DairyFree = false,
                    Diets = "",
                    ReadyInMinutes = 45,
                    GlutenFree = false,
                    Vegan = false,
                    Vegetarian = false,
                    WeightWatcherSmartPoints = 27
                }
            });
        }

        public static RecipeDetails ExtractRecipe(Recipe r)
        {
            var recipe = new RecipeDetails();
            recipe.Title = r.Title;
            recipe.Description = r.Summary;
            recipe.ImageURL = r.Image;
            recipe.Ingredients = r.ExtendedIngredients.Any() ? SimplyfyIngredients(r.ExtendedIngredients) : new List<Ingredient>();
            recipe.InstructionSteps = r.AnalyzedInstructions.Any() ? SimplyfyInstructions(r.AnalyzedInstructions) : new List<Instruction>();
            recipe.RecipeInformation = SimplyfyInformation(r);

            return recipe;
        }

        public static List<Instruction> SimplyfyInstructions(List<AnalyzedInstructions> analyzedInstructions)
        {
            List<Instruction> instructions = new List<Instruction>();
            analyzedInstructions[0].Steps.ForEach(i => instructions.Add(i));

            return instructions;
        }

        public static List<Ingredient> SimplyfyIngredients(List<ExtendedIngredients> extendedIngredients)
        {
            List<Ingredient> ingredients = new List<Ingredient>();
            extendedIngredients.ForEach(i =>
            {
                ingredients.Add(new Ingredient
                {
                    Title = i.Name,
                    Amount = i.Amount.ToString(),
                    Unit = i.Unit
                });
            });

            return ingredients;
        }

        public static RecipeInformation SimplyfyInformation(Recipe r)
        {
            RecipeInformation rv = new RecipeInformation();

            rv.DairyFree = r.DairyFree;
            rv.GlutenFree = r.GlutenFree;
            rv.Vegan = r.Vegan;
            rv.Vegetarian = r.Vegetarian;

            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < r.Diets.Count; i++)
            {
                builder.Append(r.Diets[i]);
                if (i != r.Diets.Count) builder.Append(", ");
            }

            rv.Diets = builder.ToString();

            rv.ReadyInMinutes = r.ReadyInMinutes;
            rv.WeightWatcherSmartPoints = r.WeightWatcherSmartPoints;

            return rv;
        }


    }
}
