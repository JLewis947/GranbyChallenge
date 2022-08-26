namespace GranbyTests
{
    public class GranbyUnitTests
    {
        [Fact]
        public void TestStockClass()
        {
            // Create dummy stock amounts
            int[] stockAmounts = { 43, 26, 48, 92 };

            // Create new stock class with dummy stock amounts assigned to stock
            Stock stock = new Stock(stockAmounts[0], stockAmounts[1], stockAmounts[2], stockAmounts[3]);

            // Get the stock amounts from the stock class
            int toyStockAmount = stock.ToyStockAmount;
            int xboxStockAmount = stock.XboxStockAmount;
            int bubblewrapStockAmount = stock.BubblewrapStockAmount;
            int cardboardboxStockAmount = stock.CardboardboxStockAmount;

            // Check the stock amounts are equal to the dummy stock amounts
            Assert.Equal(toyStockAmount, stockAmounts[0]);
            Assert.Equal(xboxStockAmount, stockAmounts[1]);
            Assert.Equal(bubblewrapStockAmount, stockAmounts[2]);
            Assert.Equal(cardboardboxStockAmount, stockAmounts[3]);
        }
    }
}