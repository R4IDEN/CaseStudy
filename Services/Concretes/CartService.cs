
using CartCase.Entities;
using CartCase.Models;
using Services.Contracts;

namespace CartCase.Services
{
    public class CartService : ICartService
    {
        private readonly SessionCart _cart;

        public int AddItemToCart(Product _product, int _quantity)
        {
            return _cart.AddItem(_product, _quantity);
        }

        public void ClearCart()
        {
            _cart.ClearCart();
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _cart.getCartItems().Select(cartLine => cartLine.product);
        }

        public decimal GetCartTotal()
        {
           return _cart.ComputeTotalValue();
        }

        public void RemoveCartLine(Product _product)
        {
            _cart.RemoveLine(_product);
        }
    }
}
