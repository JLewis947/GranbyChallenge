namespace GranbyTests
{
    public class GranbyUnitTests
    {
        [Fact]
        public void TestStockClass()
        {
            // Get the instance of the stock class
            Stock stock = Stock.GetInstance();

            // Get the stock amounts from the stock class
            int toyStockAmount = stock.ToyStockAmount;
            int xboxStockAmount = stock.XboxStockAmount;
            int bubblewrapStockAmount = stock.BubblewrapStockAmount;
            int cardboardboxStockAmount = stock.CardboardboxStockAmount;

            // Check the stock amounts are assigned to
            Assert.True(toyStockAmount > 0);
            Assert.True(xboxStockAmount > 0);
            Assert.True(bubblewrapStockAmount > 0);
            Assert.True(cardboardboxStockAmount > 0);
        }

        [Fact]
        public void CheckBirthdayStockTest()
        {
            // Create new birthday job
            BirthdayJob job = new BirthdayJob();
            // Check that stock is available for job
            Assert.True(job.CheckStock());
        }

        [Fact]
        public void CheckChristmasStockTest()
        {
            // Create new christmas job
            ChristmasJob job = new ChristmasJob();
            // Check that stock is available for job
            Assert.True(job.CheckStock());
        }
    }
}