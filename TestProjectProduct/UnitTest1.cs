using Product;
using NUnit.Compatibility;
using NUnit.Framework;

namespace TestProjectProduct
{
    [TestFixture]
    public class Tests
    {
        private Product.Product product;

        [SetUp]
        public void Setup()
        {
            product = new Product.Product(100, "Test Product", 100m, 50);
        }

        [Test]
        public void MinProdID()
        {
            product = new Product.Product(5, "Sample Product", 100, 50);
            Assert.That(product.ProdID, Is.EqualTo(5));
        }

        [Test]
        public void MaxProdID()
        {
            product = new Product.Product(50000, "Sample Product", 100, 50);
            Assert.That(product.ProdID, Is.EqualTo(50000));
        }

        [Test]
        public void InvalidProdID()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Product.Product(0, "Invalid Product", 100, 50));
        }

        [Test]
        public void MinItemPrice()
        {
            product = new Product.Product(10, "Cheap Product", 5m, 100);
            Assert.That(product.ItemPrice, Is.EqualTo(5m));
        }

        [Test]
        public void MaxItemPrice()
        {
            product = new Product.Product(10, "Expensive Product", 5000m, 100);
            Assert.That(product.ItemPrice, Is.EqualTo(5000m));
        }

        [Test]
        public void InvalidItemPrice()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Product.Product(10, "Invalid Price Product", -1m, 100));
        }

        [Test]
        public void MinStockAmount()
        {
            product = new Product.Product(10, "Low Stock Product", 100, 5);
            Assert.That(product.StockAmount, Is.EqualTo(5));
        }

        [Test]
        public void MaxStockAmount()
        {
            product = new Product.Product(10, "High Stock Product", 100, 500000);
            Assert.That(product.StockAmount, Is.EqualTo(500000));
        }

        [Test]
        public void InvalidStockAmount()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Product.Product(10, "Invalid Stock Product", 100, -1));
        }

        [Test]
        public void IncreaseStock()
        {
            int initialStock = product.StockAmount;
            int increaseAmount = 5;
            product.IncreaseStock(increaseAmount);
            Assert.That(product.StockAmount, Is.EqualTo(initialStock + increaseAmount));
        }

        [Test]
        public void DecreaseStock()
        {
            product = new Product.Product(10, "Test Product", 100, 50);
            int initialStock = product.StockAmount;
            int decreaseAmount = 5;
            product.DecreaseStock(decreaseAmount);
            Assert.That(product.StockAmount, Is.EqualTo(initialStock - decreaseAmount));
        }

        [Test]
        public void DecreaseStockTooMuch()
        {
            product = new Product.Product(10, "Test Product", 100, 10);
            int excessiveDecreaseAmount = 60;
            Assert.Throws<InvalidOperationException>(() => product.DecreaseStock(excessiveDecreaseAmount));
        }
    }
}

