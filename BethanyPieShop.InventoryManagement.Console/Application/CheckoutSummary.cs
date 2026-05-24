namespace BethanyPieShop.InventoryManagement.Application;

public sealed record CheckoutSummary(
    string CustomerName,
    string DeliveryType,
    decimal Subtotal,
    decimal ShippingCost,
    decimal TotalBeforeDiscount,
    decimal TotalAfterDiscount
);
