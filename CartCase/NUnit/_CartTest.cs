using NUnit.Framework;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using CartCase.Entities;
using CartCase.Services;

[TestFixture]
public class CartServiceTests
{
    private Mock<Cart> _cartMock;
    private CartService _cartService;
    private Product _product1;
    private Product _product2;

    [SetUp]
    public void SetUp()
    {
        _cartMock = new Mock<Cart>();
        _cartService = new CartService();

        // Mocking some products
        _product1 = new Product { ProductId = 1, Price = 100.0m, Stock = 10, Store = new Store { StoreId = new Guid(), StoreName = "Store A" } };
        _product2 = new Product { ProductId = 2, Price = 50.0m, Stock = 5, Store = new Store { StoreId = new Guid(), StoreName = "Store A" } };
    }

    [Test]
    public void AddItemToCart_ShouldAddProductWhenStockIsAvailable()
    {
        // Arrange
        _cartMock.Setup(c => c.AddItem(It.IsAny<Product>(), It.IsAny<int>())).Returns(1);

        // Act
        var result = _cartService.AddItemToCart(_product1, 2);

        // Assert
        _cartMock.Verify(c => c.AddItem(_product1, 2), Times.Once);
        Assert.That(result, Is.EqualTo(1)); // Success return code
    }

    [Test]
    public void AddItemToCart_ShouldReturnNoStockWhenProductIsOutOfStock()
    {
        // Arrange
        _product1.Stock = 0;
        _cartMock.Setup(c => c.AddItem(It.IsAny<Product>(), It.IsAny<int>())).Returns(2);

        // Act
        var result = _cartService.AddItemToCart(_product1, 2);

        // Assert
        Assert.That(result, Is.EqualTo(2)); // No stock return code
    }

    [Test]
    public void RemoveCartLine_ShouldRemoveProductFromCart()
    {
        // Arrange
        _cartMock.Setup(c => c.RemoveLine(It.IsAny<Product>()));

        // Act
        _cartService.RemoveCartLine(_product1);

        // Assert
        _cartMock.Verify(c => c.RemoveLine(_product1), Times.Once);
    }

    [Test]
    public void ClearCart_ShouldClearAllProducts()
    {
        // Arrange
        _cartMock.Setup(c => c.ClearCart());

        // Act
        _cartService.ClearCart();

        // Assert
        _cartMock.Verify(c => c.ClearCart(), Times.Once);
    }

    [Test]
    public void GetAllProducts_ShouldReturnAllProductsInCart()
    {
        // Arrange
        var cartItems = new List<CartLine>
    {
        new CartLine { product = _product1, Quantity = 2 },
        new CartLine { product = _product2, Quantity = 3 }
    };

        _cartMock.Setup(c => c.getCartItems()).Returns(cartItems);

        // Act
        var result = _cartService.GetAllProducts().ToList();

        // Assert
        Assert.That(result, Does.Contain(_product1)); // Check if _product1 is in the result
        Assert.That(result, Does.Contain(_product2)); // Check if _product2 is in the result
    }

    [Test]
    public void GetCartTotal_ShouldReturnCorrectTotalValue()
    {
        // Arrange
        var cartItems = new List<CartLine>
        {
            new CartLine { product = _product1, Quantity = 2 },
            new CartLine { product = _product2, Quantity = 3 }
        };

        _cartMock.Setup(c => c.getCartItems()).Returns(cartItems);
        _cartMock.Setup(c => c.ComputeTotalValue()).Returns(_product1.Price * 2 + _product2.Price * 3);

        // Act
        var result = _cartService.GetCartTotal();

        // Assert
        Assert.That(result, Is.EqualTo(350.0m)); // Total should be 100*2 + 50*3 = 350
    }
}