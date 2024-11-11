using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memento_pattern_poc
{
    public class Cart
    {
        private List<string> _items = new List<string>();
        private string _currentRestaurant = null;
        private CartHistory _history = new CartHistory();

        public void AddItem(string restaurantName, string item)
        {
            if (_currentRestaurant != null && _currentRestaurant != restaurantName)
            {
                _history.Save(CreateMemento());
                _items.Clear();
            }

            _currentRestaurant = restaurantName;
            _items.Add(item);
            Console.WriteLine($"Added {item} from {restaurantName} to the cart.");
        }

        public void Undo()
        {
            CartMemento previousState = _history.Restore();
            if (previousState != null)
            {
                _items = new List<string>(previousState.Items);
                _currentRestaurant = previousState.RestaurantName;
                Console.WriteLine($"Restored cart to previous state with items from {previousState.RestaurantName}.");
            }
            else
            {
                Console.WriteLine("No previous state to restore.");
            }
        }

        private CartMemento CreateMemento()
        {
            return new CartMemento(_items, _currentRestaurant);
        }

        public void ShowCart()
        {
            Console.WriteLine("\n--- Cart Contents ---");
            if (_currentRestaurant == null)
            {
                Console.WriteLine("Cart is empty.");
            }
            else
            {
                Console.WriteLine($"Restaurant: {_currentRestaurant}");
                foreach (var item in _items)
                {
                    Console.WriteLine($"- {item}");
                }
            }
            Console.WriteLine("----------------------\n");
        }
    }

}
