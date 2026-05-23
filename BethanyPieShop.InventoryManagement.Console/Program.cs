using BethanyPieShop.InventoryManagement.Domain.Customers;
using BethanyPieShop.InventoryManagement.Domain.Orders;
using BethanyPieShop.InventoryManagement.Domain.Products;

var customer = new Customer("Beth", "Johnson", "beth@example.com");
var cherryPie = new Product("CH001", "Cherry Pie", 15m);

var order = Order.CreateShippingOrder(customer, "Main Street 1");
order.AddProduct(cherryPie, 2);

Console.WriteLine("One-to-one composition example:");
Console.WriteLine($"Customer: {order.Customer.GetFullName()}");
Console.WriteLine($"Delivery method: {order.DeliveryDetails.DeliveryMethod}");
Console.WriteLine($"Shipping address: {order.DeliveryDetails.ShippingAddress}");
Console.WriteLine($"Shipping cost: {order.DeliveryDetails.CalculateShippingCost()}");
Console.WriteLine($"Order total: {order.CalculateTotal()}");
Console.WriteLine();

order.ChangeToPickup();

Console.WriteLine("After changing delivery through the order:");
Console.WriteLine($"Delivery method: {order.DeliveryDetails.DeliveryMethod}");
Console.WriteLine($"Shipping address: '{order.DeliveryDetails.ShippingAddress}'");
Console.WriteLine($"Order total: {order.CalculateTotal()}");