using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingBytes.Cooking
{
    public class Recipe
    {
        public Recipe(string title, params Step[] steps)
        {
            Title = title;
            Steps = steps;
        }
        public string Title { get; protected set; }
        public ICollection<Ingredient> Ingredients
        {
            get
            {
                List<Ingredient> ingredients = new List<Ingredient>();
                foreach (Step s in Steps)
                {
                    foreach (Food input in s.Inputs)
                    {
                        if (input is Ingredient)
                            ingredients.Add(input as Ingredient);
                    }
                }
                return ingredients;
            }
        }
        public ICollection<Tool> Tools;
        public Step[] Steps { get; protected set; }
    }
}
