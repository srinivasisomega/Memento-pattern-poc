using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memento_pattern_poc
{
    public class Meal
    {
        public string Name { get; private set; }
        public List<string> Customizations { get; private set; }

        public Meal(string name, List<string> customizations)
        {
            Name = name;
            Customizations = customizations ?? new List<string>();
        }

        public override string ToString()
        {
            return $"{Name} with {string.Join(", ", Customizations)}";
        }
    }
}
