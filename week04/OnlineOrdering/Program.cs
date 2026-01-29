using System;

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address(
            "KN32 ST",
            "Kigali",
            "Nyarugenge",
            "Rwanda"
        );

        Customer customer1 = new Customer("Shema Darcy", address1);

        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Notebook", "R1001", 5.00, 4));
        order1.AddProduct(new Product("Backpack", "R1002", 45.00, 1));

        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order1.GetTotalPrice():F2}");
        Console.WriteLine("--------------------------------");

        Address address2 = new Address(
            "KG 11 Ave",
            "Kigali",
            "Gasabo",
            "Rwanda"
        );

        Customer customer2 = new Customer("Alice Uwimana", address2);

        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Phone", "R2001", 799.99, 1));
        order2.AddProduct(new Product("Headphones", "R2002", 150.00, 1));
        order2.AddProduct(new Product("Charger", "R2003", 20.00, 2));

        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order2.GetTotalPrice():F2}");
    }
}
