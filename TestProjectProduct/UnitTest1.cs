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
            product = new Product.Product(100, "Test Product", 100, 50);
        }

        [Test]
        public void MinProdID()
        {
            product = new Product.Product(5, "Main Product", 100, 50);
            Assert.That(product.ProdID, Is.EqualTo(5));
        }

        [Test]
        public void MaxProdID()
        {
            product = new Product.Product(50000, "Main Product", 100, 50);
            Assert.That(product.ProdID, Is.EqualTo(50000));
        }

        [Test]
        public void WrongProdID()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Product.Product(0, "Wrong Product", 100, 50));
        }

        [Test]
        public void MinItemPrice()
        {
            product = new Product.Product(10, "Cheap Product", 5, 100);
            Assert.That(product.ItemPrice, Is.EqualTo(5m));
        }

        [Test]
        public void MaxItemPrice()
        {
            product = new Product.Product(10, "Expensive Product", 5000, 100);
            Assert.That(product.ItemPrice, Is.EqualTo(5000m));
        }

        [Test]
        public void WrongItemPrice()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Product.Product(10, "Wrong product price", -1, 100));
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
        public void WrongStockAmount()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Product.Product(10, "Wrong Stock Product", 100, -1));
        }

        [Test]
        public void IncreaseStock()
        {
            int mainStock = product.StockAmount;
            int increaseAmount = 5;
            product.IncreaseStock(increaseAmount);
            Assert.That(product.StockAmount, Is.EqualTo(mainStock + increaseAmount));
        }

        [Test]
        public void DecreaseStock()
        {
            product = new Product.Product(10, "Test Product", 100, 50);
            int mainStock = product.StockAmount;
            int decreaseAmount = 5;
            product.DecreaseStock(decreaseAmount);
            Assert.That(product.StockAmount, Is.EqualTo(mainStock - decreaseAmount));
        }

        [Test]
        public void DecreaseStockTooMuch()
        {
            product = new Product.Product(10, "Test Product", 100, 10);
            int aLotDecreaseAmount = 60;
            Assert.Throws<InvalidOperationException>(() => product.DecreaseStock(aLotDecreaseAmount));
        }
        [Test]
        public void IncreaseStockByOne()
        {
            int initialStock = product.StockAmount;
            product.IncreaseStock(1);
            Assert.That(product.StockAmount, Is.EqualTo(initialStock + 1));
        }

        [Test]
        public void DecreaseStockByOne()
        {
            product = new Product.Product(10, "Test Product", 100, 10);
            product.DecreaseStock(1);
            Assert.That(product.StockAmount, Is.EqualTo(9));
        }

        [Test]
        public void IncreaseStockToMaximum()
        {
            product = new Product.Product(10, "Max Stock Test Product", 100, 499999);
            product.IncreaseStock(1);
            Assert.That(product.StockAmount, Is.EqualTo(500000));  
        }

        [Test]
        public void DecreaseStockToZero()
        {
            product = new Product.Product(10, "Test Product", 100, 1);
            product.DecreaseStock(1);
            Assert.That(product.StockAmount, Is.EqualTo(0));
        }

        [Test]
        public void PriceAtExactMax()
        {
            product = new Product.Product(10, "Max exact price product", 5000, 100);
            Assert.That(product.ItemPrice, Is.EqualTo(5000));
        }

        [Test]
        public void PriceAtExactMin()
        {
            product = new Product.Product(10, "Min exact price product", 5, 100);
            Assert.That(product.ItemPrice, Is.EqualTo(5));
        }

    }
}

