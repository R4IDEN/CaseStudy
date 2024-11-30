
using CartCase.Entities;
using NUnit.Framework;

namespace CartCase.NUnit
{
    [TestFixture]
    public class _CartTests
    {
        private Cart? _cart;
        private Product? _product1;
        private Product? _product2;

        [SetUp]
        public void SetUp()
        {
            _cart = new Cart();

            // Mocking Products
            _product1 = new Product { ProductId = 1, Price = 100.0m, Store = new Store { StoreId = 1, Name = "Store A" } };
            _product2 = new Product { ProductId = 2, Price = 50.0m, Store = new Store { StoreId = 1, Name = "Store A" } };
        }

        [Test]
        public void AddItem_ShouldAddNewProductToCart()
        {
            _cart.AddItem(_product1, 1);

            Assert.AreEqual(1, _cart.Lines.Count);
            Assert.AreEqual(1, _cart.Lines.First().Quantity);
            Assert.AreEqual(_product1, _cart.Lines.First().product);
        }

        [Test]
        public void AddItem_ShouldUpdateQuantityIfProductAlreadyInCart()
        {
            _cart.AddItem(_product1, 1);
            _cart.AddItem(_product1, 2);

            Assert.AreEqual(1, _cart.Lines.Count);
            Assert.AreEqual(3, _cart.Lines.First().Quantity); // Quantity should be updated to 3
        }

        [Test]
        public void RemoveLine_ShouldRemoveProductFromCart()
        {
            _cart.AddItem(_product1, 1);
            _cart.RemoveLine(_product1);

            Assert.AreEqual(0, _cart.Lines.Count); // Cart should be empty
        }

        [Test]
        public void ClearCart_ShouldClearAllLines()
        {
            _cart.AddItem(_product1, 1);
            _cart.AddItem(_product2, 2);

            _cart.ClearCart();

            Assert.AreEqual(0, _cart.Lines.Count); // All lines should be cleared
        }

        [Test]
        public void ComputeTotalValue_ShouldReturnCorrectTotal()
        {
            _cart.AddItem(_product1, 1);
            _cart.AddItem(_product2, 2);

            decimal expectedTotal = (_product1.Price * 1) + (_product2.Price * 2);
            decimal actualTotal = _cart.ComputeTotalValue();

            Assert.AreEqual(expectedTotal, actualTotal); // Total should be calculated correctly
        }
    }
}
