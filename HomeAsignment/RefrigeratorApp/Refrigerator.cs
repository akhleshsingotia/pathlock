using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefrigeratorApp
{
    public class Refrigerator
    {
        private List<Product> products;

        public Refrigerator()
        {
            products = new List<Product>();
        }

        public void InsertProduct(string name, double quantity, DateTime expirationDate)
        {
            var product = new Product
            {
                Name = name,
                Quantity = quantity,
                ExpirationDate = expirationDate
            };

            products.Add(product);
            Console.WriteLine($"Product '{name}' inserted into the refrigerator.");
        }

        public void ConsumeProduct(string name, double quantity)
        {
            var product = GetProductByName(name);
            if (product != null)
            {
                if (quantity <= product.Quantity)
                {
                    product.Quantity -= quantity;
                    Console.WriteLine($"Consumed {quantity} units of product '{name}'.");
                }
                else
                {
                    Console.WriteLine($"Not enough quantity of product '{name}' in the refrigerator.");
                }
            }
            else
            {
                Console.WriteLine($"Product '{name}' not found in the refrigerator.");
            }
        }

        public void ShowCurrentStatus()
        {
            Console.WriteLine("Current status of the refrigerator:");
            foreach (var product in products)
            {
                Console.WriteLine($"Product: {product.Name}, Quantity: {product.Quantity}, Expiration Date: {product.ExpirationDate}");
            }
        }

        public void CheckExpiry()
        {
            Console.WriteLine("Checking for expired products:");

            foreach (var product in products)
            {
                if (product.ExpirationDate <= DateTime.Now)
                {
                    Console.WriteLine($"Product '{product.Name}' has expired. Please remove it from the refrigerator.");
                    products.Remove(product);
                }
            }
        }
        public void CreateShoppingList()
        {
            Console.WriteLine("Creating a shopping list based on past shopping and actual consumption:");

            Dictionary<string, double> shoppingList = new Dictionary<string, double>();
            foreach (var product in products)
            {
                if (product.Quantity <= 2)
                {
                    if (!shoppingList.ContainsKey(product.Name))
                    {
                        shoppingList.Add(product.Name, 5); // Suggested quantity to buy
                    }
                }
            }

            Console.WriteLine("Shopping List:");
            foreach (var item in shoppingList)
            {
                Console.WriteLine($"Product: {item.Key}, Quantity to Buy: {item.Value}");
            }
        }

        private Product GetProductByName(string name)
        {
            return products.Find(p => p.Name == name);
        }
    }
}
