using BethanyPieShop.InventoryManagement.Domain.Orders;
using BethanyPieShop.InventoryManagement.Domain.Products;

namespace BethanyPieShop.InventoryManagement.Domain.DesignExamples;

public class OrderDesignComparison
{
    public class AnemicOrder
    {
        public List<OrderLine> Lines { get; set; } = [];
    }

    public class RichOrder
    {
        private readonly List<OrderLine> _lines = [];

        public IReadOnlyCollection<OrderLine> Lines => _lines;

        public void AddProduct(Product product, int quantity)
        {
            ArgumentNullException.ThrowIfNull(product);

            if (quantity <= 0)
            {
                throw new ArgumentException("Quantity must be greater than zero.", nameof(quantity));
            }

            _lines.Add(new OrderLine
            {
                Product = product,
                Quantity = quantity
            });
        }

        public decimal CalculateTotal()
        {
            return _lines.Sum(line => line.Product.UnitPrice * line.Quantity);
        }
    }
}