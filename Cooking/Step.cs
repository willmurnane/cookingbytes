using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingBytes.Cooking
{
    public class Step
    {
        public Step(string description, Tool tool = null, params Food[] inputs)
        {
            Description = description;
            Tool = tool;
            Inputs = inputs;
        }
        public string Description { get; protected set; }
        public Tool Tool { get; protected set; }
        public ICollection<Food> Inputs { get; protected set; }
    }
    public class FoodProducingStep : Step, Food
    {
        public FoodProducingStep(string description, Tool tool = null, params Food[] inputs)
            : base(description, tool, inputs)
        { }
    }
}
