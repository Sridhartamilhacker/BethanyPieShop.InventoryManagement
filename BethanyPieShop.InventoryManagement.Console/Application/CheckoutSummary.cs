using BethanyPieShop.InventoryManagement.Domain.Values;

namespace BethanyPieShop.InventoryManagement.Application;

public sealed record CheckoutSummary(
    string CustomerName,
    string DeliveryType,
    Money Subtotal,
    Money ShippingCost,
    Money TotalBeforeDiscount,
    Money TotalAfterDiscount
);
