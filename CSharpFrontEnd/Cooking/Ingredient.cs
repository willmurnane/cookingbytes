using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingBytes.Cooking
{
    public class AbstractIngredient
    {
        public AbstractIngredient(string name)
        {
            Name = name;
        }
        public string Name { get; protected set; }
        public string Description { get; protected set; }

        public Ingredient Instantiate(Measurement howMuch)
        {
            return new Ingredient(this, howMuch);
        }
        public override string ToString()
        {
            return Name;
        }
    }
    public class Ingredient : Food
    {
        internal Ingredient(AbstractIngredient type, Measurement quantity)
        {
            Type = type;
            Quantity = quantity;
        }
        public AbstractIngredient Type { get; protected set; }
        public Measurement Quantity { get; protected set; }
    }
}
