using System;
using System.Collections.Generic;
using Memento_pattern_poc;

public class Program
{
    public static void Main()
    {
        var restaurants = new List<Restaurant>
        {
            new Restaurant("Pizza Palace", new List<string> { "Pepperoni Pizza", "Margherita Pizza" }),
            new Restaurant("Burger Barn", new List<string> { "Cheeseburger", "Veggie Burger" }),
            new Restaurant("Taco Tower", new List<string> { "Beef Taco", "Chicken Taco" })
        };

        var cart = new Cart();
        string userChoice;

        while (true)
        {
            Console.WriteLine("\nOptions:");
            Console.WriteLine("1. Select Restaurant and Add Item to Cart with Customizations");
            Console.WriteLine("2. Show Cart");
            Console.WriteLine("3. Undo Last Action");
            Console.WriteLine("4. Exit");
            Console.Write("Choose an option: ");
            userChoice = Console.ReadLine();

            switch (userChoice)
            {
                case "1":
                    SelectRestaurantAndCustomizeItem(cart, restaurants);
                    break;

                case "2":
                    cart.ShowCart();
                    break;

                case "3":
                    cart.Undo();
                    break;

                case "4":
                    Console.WriteLine("Exiting the application. Goodbye!");
                    return;

                default:
                    Console.WriteLine("Invalid option, please try again.");
                    break;
            }
        }
    }

    private static void SelectRestaurantAndCustomizeItem(Cart cart, List<Restaurant> restaurants)
    {
        Console.WriteLine("\nSelect a Restaurant:");
        for (int i = 0; i < restaurants.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {restaurants[i].Name}");
        }
        Console.Write("Enter the restaurant number: ");
        if (int.TryParse(Console.ReadLine(), out int restaurantChoice) && restaurantChoice > 0 && restaurantChoice <= restaurants.Count)
        {
            var selectedRestaurant = restaurants[restaurantChoice - 1];
            Console.WriteLine($"\nYou selected {selectedRestaurant.Name}. Menu:");

            for (int j = 0; j < selectedRestaurant.MenuItems.Count; j++)
            {
                Console.WriteLine($"{j + 1}. {selectedRestaurant.MenuItems[j]}");
            }
            Console.Write("Enter the item number to add to the cart: ");
            if (int.TryParse(Console.ReadLine(), out int itemChoice) && itemChoice > 0 && itemChoice <= selectedRestaurant.MenuItems.Count)
            {
                string selectedItem = selectedRestaurant.MenuItems[itemChoice - 1];

                // Use the builder to customize the item
                var builder = new MealBuilder(selectedItem);
                Console.WriteLine("\nCustomizations available:");
                Console.WriteLine("1. Add Extra Cheese");
                Console.WriteLine("2. Add Extra Pepperoni");
                Console.WriteLine("3. Add Extra Sauce");
                Console.WriteLine("4. No customizations (build as-is)");

                while (true)
                {
                    Console.Write("Choose a customization option (or 4 to finish): ");
                    string customizationChoice = Console.ReadLine();
                    switch (customizationChoice)
                    {
                        case "1":
                            builder.AddExtraCheese();
                            break;
                        case "2":
                            builder.AddExtraPepperoni();
                            break;
                        case "3":
                            builder.AddExtraSauce();
                            break;
                        case "4":
                            var meal = builder.Build();
                            cart.AddItem(selectedRestaurant.Name, meal.ToString());
                            return;
                        default:
                            Console.WriteLine("Invalid option, please try again.");
                            break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Invalid item choice.");
            }
        }
        else
        {
            Console.WriteLine("Invalid restaurant choice.");
        }
    }
}
