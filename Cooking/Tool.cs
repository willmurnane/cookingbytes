using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingBytes.Cooking
{
    public class Tool
    {
        public Tool(string name)
        {
            Name = name;
        }
        public string Name { get; protected set; }
    }
}
