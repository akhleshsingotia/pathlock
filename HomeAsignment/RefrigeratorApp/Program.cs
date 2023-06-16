using RefrigeratorApp;

public class Program
{
    public static void Main(string[] args)
    {
        Refrigerator refrigerator = new Refrigerator();

        // Stage 1: Insert products into the refrigerator
        refrigerator.InsertProduct("Milk", 2.5, DateTime.Now.AddDays(7));
        refrigerator.InsertProduct("Eggs", 12, DateTime.Now.AddDays(14));
        refrigerator.InsertProduct("Cheese", 0.5, DateTime.Now.AddDays(30));

        // Stage 2: Check for expired products
        refrigerator.CheckExpiry();

        // Stage 3: Create a shopping list
        refrigerator.CreateShoppingList();

        // Perform consumption
        refrigerator.ConsumeProduct("Milk", 0.5);

        // Show current status
        refrigerator.ShowCurrentStatus();

        Console.ReadLine();
    }
}
