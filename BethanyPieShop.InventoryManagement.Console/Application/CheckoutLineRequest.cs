namespace BethanyPieShop.InventoryManagement.Application;

public record CheckoutLineRequest(string ProductCode, int Quantity);