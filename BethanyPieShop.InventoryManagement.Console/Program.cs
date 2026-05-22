using BethanyPieShop.InventoryManagement.Domain.Customers;
using BethanyPieShop.InventoryManagement.Domain.Orders;
using BethanyPieShop.InventoryManagement.Domain.Products;

var guestCustomer = new Customer("Sam", "Taylor");
var pickupOrder = new Order(guestCustomer, DeliveryMethod.PickUp);

Console.WriteLine("Overload example:");
Console.WriteLine($"Guest customer email fallback: {guestCustomer.Email}");
Console.WriteLine($"Pickup order delivery method: {pickupOrder.DeliveryMethod}");
Console.WriteLine("Observation: overloaded constructors can support different valid scenarios while delegating to one validation path.");
Console.WriteLine();

var customer = new Customer("Beth", "Johnson", "beth@example.com");
var cherryPie = new Product("CH001", "Cherry Pie", 15m);
var order = new Order(customer, DeliveryMethod.Shipping, "Main Street 1");

order.AddProduct(cherryPie, 2);
Console.WriteLine($"Shipping order total: {order.CalculateTotal():C}");