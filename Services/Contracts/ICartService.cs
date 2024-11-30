using CartCase.Entities;

namespace Services.Contracts
{
    public interface ICartService
    {
        int AddItemToCart(Product _product, int _quantity);
        void RemoveCartLine(Product _product);
        void ClearCart();
        IEnumerable<Product> GetAllProducts();
        decimal GetCartTotal();
    }
}
