using BethanyPieShop.InventoryManagement.Domain.Customers;
using BethanyPieShop.InventoryManagement.Domain.Orders;
using BethanyPieShop.InventoryManagement.Domain.Pricing;
using BethanyPieShop.InventoryManagement.Domain.Products;

Console.WriteLine("Business request: model a first checkout flow for Bethany's Pie Shop.");
Console.WriteLine("Scenario: a customer places a shipping order with two different pies.");
Console.WriteLine();

var cherryPie = new Product
{
    ProductCode = "PIE-CH-001",
    Name = "Cherry Pie",
    UnitPrice = 14.50m,
    IsActive = true
};

var applePie = new Product
{
    ProductCode = "PIE-AP-001",
    Name = "Apple Pie",
    UnitPrice = 12.00m,
    IsActive = true
};

var customer = new Customer
{
    FirstName = "Beth",
    LastName = "Miller",
    Email = "beth@example.com"
};

var order = new Order
{
    Customer = customer,
    DeliveryMethod = "Shipping",
    ShippingAddress = "15 Oak Street, Seattle"
};

order.Lines.Add(new OrderLine { Product = cherryPie, Quantity = 1 });
order.Lines.Add(new OrderLine { Product = applePie, Quantity = 2 });

var pricingService = new OrderPricingService();

var subtotal = pricingService.CalculateSubtotal(order);
var shippingCost = pricingService.CalculateShippingCost(order);
var total = pricingService.CalculateTotal(order);

Console.WriteLine("Order summary:");
Console.WriteLine($"Customer: {order.Customer.FirstName} {order.Customer.LastName}");
Console.WriteLine($"Email: {order.Customer.Email}");
Console.WriteLine($"Delivery method: {order.DeliveryMethod}");
Console.WriteLine($"Shipping address: {order.ShippingAddress}");
Console.WriteLine("Items:");

foreach (var line in order.Lines)
{
    var lineTotal = line.Product.UnitPrice * line.Quantity;
    Console.WriteLine($"- {line.Quantity} x {line.Product.Name} ({line.Product.ProductCode}) = {lineTotal:C}");
}

Console.WriteLine($"Line count: {order.Lines.Count}");
Console.WriteLine($"Subtotal: {subtotal:C}");
Console.WriteLine($"Shipping: {shippingCost:C}");
Console.WriteLine($"Total: {total:C}");
Console.WriteLine();