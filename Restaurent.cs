using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memento_pattern_poc
{
    public class Restaurant
    {
        public string Name { get; private set; }
        public List<string> MenuItems { get; private set; }

        public Restaurant(string name, List<string> menuItems)
        {
            Name = name;
            MenuItems = menuItems;
        }
    }

}
