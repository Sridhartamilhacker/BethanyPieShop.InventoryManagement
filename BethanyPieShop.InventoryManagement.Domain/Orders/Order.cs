using BethanyPieShop.InventoryManagement.Domain.Customers;
using BethanyPieShop.InventoryManagement.Domain.Products;
using System.Collections.ObjectModel;

namespace BethanyPieShop.InventoryManagement.Domain.Orders;

public class Order
{
    private readonly List<OrderLine> _lines = [];

    public Customer Customer { get; }
    public DeliveryMethod DeliveryMethod { get; private set; }
    public string ShippingAddress { get; private set; }

    public IReadOnlyCollection<OrderLine> Lines => new ReadOnlyCollection<OrderLine>(_lines);

    private Order(Customer customer, DeliveryMethod deliveryMethod) :
        this(customer, deliveryMethod, string.Empty)
    {

    }
    private Order(Customer customer, DeliveryMethod deliveryMethod, string shippingAddress = "")
    {
        ArgumentNullException.ThrowIfNull(customer);

        if (deliveryMethod == DeliveryMethod.Shipping && string.IsNullOrWhiteSpace(shippingAddress))
        {
            throw new ArgumentException(
                "A shipping address is required when the delivery method is shipping.",
                nameof(shippingAddress));
        }

        Customer = customer;
        DeliveryMethod = deliveryMethod;
        ShippingAddress = shippingAddress;
    }

    public static Order CreatePickupOrder(Customer customer)
    {
        return new Order(customer, DeliveryMethod.PickUp, string.Empty);
    }

    public static Order CreateShippingOrder(Customer customer, string shippingAddress)
    {
        return new Order(customer, DeliveryMethod.Shipping, shippingAddress);
    }

    public void AddProduct(Product product, int quantity)
    {
        if (product is null)
        {
            throw new ArgumentNullException(nameof(product));
        }

        if (!product.IsActive)
        {
            throw new InvalidOperationException("Inactive products cannot be added to an order.");
        }

        if (quantity <= 0)
        {
            throw new ArgumentException("The quantity must be greater than zero.");
        }

        var existingLine = _lines.FirstOrDefault(l => l.Product.ProductCode == product.ProductCode);

        if (existingLine is not null)
        {
            existingLine.IncreaseQuantity(quantity);
            return;
        }

        _lines.Add(new OrderLine(product, quantity));
    }

    public void RemoveProduct(string productCode)
    {
        var lineToRemove = _lines.FirstOrDefault(l => l.Product.ProductCode == productCode);

        if (lineToRemove is not null)
        {
            _lines.Remove(lineToRemove);
        }
    }

    public void ChangeToShipping()
    {
        DeliveryMethod = DeliveryMethod.PickUp;
        ShippingAddress = string.Empty;
    }

    public void ChangeToShipping(string shippingAddress)
    {
        if (string.IsNullOrWhiteSpace(shippingAddress))
        {
            throw new ArgumentException("Shipping address cannot be empty.", nameof(shippingAddress));
        }
        DeliveryMethod = DeliveryMethod.Shipping;
        ShippingAddress = shippingAddress;
    }
    public decimal CalculateSubtotal()
    {
        return _lines.Sum(line => line.GetLineTotal());
    }
    public decimal CalculateShippingCost()
    {
        if (DeliveryMethod == DeliveryMethod.Shipping)
        {
            return 5m;
        }

        return 0m;
    }
    public decimal CalculateTotal()
    {
        return CalculateSubtotal() + CalculateShippingCost();
    }
}