using BethanyPieShop.InventoryManagement.Domain.Customers;
using BethanyPieShop.InventoryManagement.Domain.Orders;
using BethanyPieShop.InventoryManagement.Domain.Products;

Console.WriteLine("Business request: prevent invalid objects at creation time.");
Console.WriteLine("Scenario: constructor-based creation should block weak objects from existing.");
Console.WriteLine();
try
{
    var testProduct = new Product("", "", 0m);
}
catch (Exception ex)
{
    Console.WriteLine($"Constructor guardrail (product): {ex.Message}");
}

try
{
    var tempCustomer = new Customer("Beth", "Johnson", "beth@example.com");
    var testOrder = new Order(tempCustomer, DeliveryMethod.Shipping);
}
catch (Exception ex)
{
    Console.WriteLine($"Constructor guardrail (order): {ex.Message}");
}

try
{
    var tempProduct = new Product("AP001", "Apple Pie", 12m);
    var testOrderLine = new OrderLine(tempProduct, 0);
}
catch (Exception ex)
{
    Console.WriteLine($"Constructor guardrail (order line): {ex.Message}");
}

Console.WriteLine();

var cherryPie = new Product("CH001", "Cherry Pie", 15m);
var blueberryPie = new Product("BL001", "Blueberry Pie", 18m);
var customer = new Customer("Beth", "Johnson", "beth@example.com");
var order = new Order(customer, DeliveryMethod.Shipping, "Main Street 1");

order.AddProduct(cherryPie, 2);
order.AddProduct(blueberryPie, 1);

Console.WriteLine($"Customer: {order.Customer.GetFullName()}");
Console.WriteLine($"Line count: {order.Lines.Count}");
Console.WriteLine($"Total: {order.CalculateTotal():C}");
