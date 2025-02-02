using System;

public class Program
{
    public static void Main()
    {
        // Create Address objects
        Address address1 = new Address("123 Main St", "New York", "NY", "USA");
        Address address2 = new Address("456 Maple Ave", "Toronto", "ON", "Canada");

        // Create Customer objects
        Customer customer1 = new Customer("John John", address1);
        Customer customer2 = new Customer("Jane Jane", address2);

        // Create Product objects
        Product product1 = new Product("Laptop", 101, 800, 1);
        Product product2 = new Product("Headphones", 102, 50, 2);

        // Create Order objects
        Order order1 = new Order(customer1);
        order1.AddProduct(product1);
        order1.AddProduct(product2);

        Order order2 = new Order(customer2);
        order2.AddProduct(product1);

        // Display results for order1
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order1.CalculateTotalPrice()}");

        // Display results for order2
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order2.CalculateTotalPrice()}");
    }
}