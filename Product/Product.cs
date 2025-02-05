namespace Product
{
    public class Product
    {
        public int ProdID { get; private set; }
        public string ProdName { get; private set; }
        public decimal ItemPrice { get; private set; }
        public int StockAmount { get; private set; }

        
        public Product(int prodID, string prodName, decimal itemPrice, int stockAmount)
        {
            if (prodID < 5 || prodID > 50000)
                throw new ArgumentOutOfRangeException(nameof(prodID), "Product ID must be between 5 and 50000.");
            if (itemPrice < 5m || itemPrice > 5000m)
                throw new ArgumentOutOfRangeException(nameof(itemPrice), "Item Price must be between $5 and $5000.");
            if (stockAmount < 5 || stockAmount > 500000)
                throw new ArgumentOutOfRangeException(nameof(stockAmount), "Stock Amount must be between 5 and 500000.");

            ProdID = prodID;
            ProdName = prodName;
            ItemPrice = itemPrice;
            StockAmount = stockAmount;
        }

       
        public void IncreaseStock(int amount)
        {
            if (amount < 0)
                throw new ArgumentException("Increase amount must be positive.", nameof(amount));
            StockAmount += amount;
        }

        public void DecreaseStock(int amount)
        {
            if (amount < 0)
                throw new ArgumentException("Decrease amount must be positive.", nameof(amount));
            if (amount > StockAmount)
                throw new InvalidOperationException("Decrease amount exceeds the current stock.");
            StockAmount -= amount;
        }
    }
}
