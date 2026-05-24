using BethanyPieShop.InventoryManagement.Domain.Customers;
using BethanyPieShop.InventoryManagement.Domain.Orders;
using BethanyPieShop.InventoryManagement.Domain.Pricing;
using BethanyPieShop.InventoryManagement.Domain.Products;
using BethanyPieShop.InventoryManagement.Domain.Values;

namespace BethanyPieShop.InventoryManagement.Application;

public class CheckoutApplicationService
{
    private readonly IReadOnlyDictionary<string, Product> _catalog;

    public CheckoutApplicationService(IEnumerable<Product> catalog)
    {
        _catalog = catalog.ToDictionary(p => p.ProductCode, StringComparer.OrdinalIgnoreCase);
    }

    public CheckoutSummary CheckoutShipping(
        Customer customer,
        ShippingAddress shippingAddress ,
        IEnumerable<CheckoutLineRequest> lines,
        IDiscountPolicy? discountPolicy = null)
    {
        var order = Order.CreateShippingOrder(customer, shippingAddress);
        AddLines(order, lines);

        var totalBeforeDiscount = order.CalculateTotal();
        var totalAfterDiscount = discountPolicy is null
            ? totalBeforeDiscount
            : order.CalculateTotal(discountPolicy);

        return new CheckoutSummary(
            customer.GetFullName(),
            order.Delivery.DisplayName,
            order.CalculateSubtotal(),
            order.Delivery.CalculateShippingCost(),
            totalBeforeDiscount,
            totalAfterDiscount);
    }

    public CheckoutSummary CheckoutPickup(
        Customer customer,
        IEnumerable<CheckoutLineRequest> lines,
        IDiscountPolicy? discountPolicy = null)
    {
        var order = Order.CreatePickupOrder(customer);
        AddLines(order, lines);

        var totalBeforeDiscount = order.CalculateTotal();
        var totalAfterDiscount = discountPolicy is null
            ? totalBeforeDiscount
            : order.CalculateTotal(discountPolicy);

        return new CheckoutSummary(
            customer.GetFullName(),
            order.Delivery.DisplayName,
            order.CalculateSubtotal(),
            order.Delivery.CalculateShippingCost(),
            totalBeforeDiscount,
            totalAfterDiscount);
    }

    private void AddLines(Order order, IEnumerable<CheckoutLineRequest> lines)
    {
        foreach (var line in lines)
        {
            var product = ResolveProduct(line.ProductCode);
            order.AddProduct(product, line.Quantity);
        }
    }

    private Product ResolveProduct(string productCode)
    {
        if (_catalog.TryGetValue(productCode, out var product))
        {
            return product;
        }

        throw new InvalidOperationException($"Unknown product code: {productCode}");
    }
}