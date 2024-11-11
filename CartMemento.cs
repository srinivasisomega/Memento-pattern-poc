using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memento_pattern_poc
{
    public class CartMemento
    {
        public List<string> Items { get; private set; }
        public string RestaurantName { get; private set; }

        public CartMemento(List<string> items, string restaurantName)
        {
            Items = new List<string>(items);
            RestaurantName = restaurantName;
        }
    }

}
