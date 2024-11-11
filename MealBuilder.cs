using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memento_pattern_poc
{
    public class MealBuilder
    {
        private string _name;
        private List<string> _customizations = new List<string>();

        public MealBuilder(string name)
        {
            _name = name;
        }

        public MealBuilder AddExtraCheese()
        {
            _customizations.Add("Extra Cheese");
            return this;
        }

        public MealBuilder AddExtraPepperoni()
        {
            _customizations.Add("Extra Pepperoni");
            return this;
        }

        public MealBuilder AddExtraSauce()
        {
            _customizations.Add("Extra Sauce");
            return this;
        }

        public Meal Build()
        {
            return new Meal(_name, _customizations);
        }
    }
}
