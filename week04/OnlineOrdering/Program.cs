using System;

class Program
{
    static void Main(string[] args)
    {
        // ----- First Order (USA Customer) -----
        Address address1 = new Address("123 Maple Street", "Springfield", "IL", "USA");
        Customer customer1 = new Customer("John Doe", address1);

        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Laptop", 101, 899.99m, 1));
        order1.AddProduct(new Product("Wireless Mouse", 102, 25.50m, 2));

        Console.WriteLine("===== Order 1 =====");
        Console.WriteLine("Packing Label:");
        Console.WriteLine(order1.GetPackingLabel());

        Console.WriteLine("Shipping Label:");
        Console.WriteLine(order1.GetShippingLabel());

        Console.WriteLine($"Total Cost: ${order1.GetTotalCost():F2}");
        Console.WriteLine();


        // ----- Second Order (International Customer) -----
        Address address2 = new Address("456 Elm Road", "London", "England", "United Kingdom");
        Customer customer2 = new Customer("Alice Smith", address2);

        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Camera", 201, 499.99m, 1));
        order2.AddProduct(new Product("Tripod", 202, 89.99m, 1));
        order2.AddProduct(new Product("Memory Card", 203, 19.99m, 2));

        Console.WriteLine("===== Order 2 =====");
        Console.WriteLine("Packing Label:");
        Console.WriteLine(order2.GetPackingLabel());

        Console.WriteLine("Shipping Label:");
        Console.WriteLine(order2.GetShippingLabel());

        Console.WriteLine($"Total Cost: ${order2.GetTotalCost():F2}");
    }
}
