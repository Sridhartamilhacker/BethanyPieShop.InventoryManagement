using BethanyPieShop.InventoryManagement.Domain.Customers;
using BethanyPieShop.InventoryManagement.Domain.Orders;
using BethanyPieShop.InventoryManagement.Domain.Products;

var cherryPie = new Product
{
    Name = "Cherry Pie",
    ProductCode = "CH001"
};
cherryPie.ChangePrice(15m);

var blueberryPie = new Product
{
    Name = "Blueberry Pie",
    ProductCode = "BL001"
};
blueberryPie.ChangePrice(18m);

var customer = new Customer
{
    FirstName = "Beth",
    LastName = "Johnson"
};

var order = new Order
{
    Customer = customer,
    DeliveryMethod = DeliveryMethod.Shipping,
    ShippingAddress = "Main Street 1"
};

order.AddProduct(cherryPie, 2);
order.AddProduct(blueberryPie, 1);
order.AddProduct(cherryPie, 1);

Console.WriteLine($"Subtotal: {order.CalculateSubtotal():C}");
Console.WriteLine($"Shipping: {order.CalculateShippingCost():C}");
Console.WriteLine($"Total: {order.CalculateTotal():C}");

order.RemoveProduct("BL001");

Console.WriteLine($"Updated total: {order.CalculateTotal():C}");