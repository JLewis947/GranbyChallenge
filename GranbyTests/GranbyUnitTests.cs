namespace GranbyTests
{
    public class GranbyUnitTests
    {
        List<JobTemplate> jobs = new List<JobTemplate>()
        {
            new BirthdayJob(24),
            new ChristmasJob(24),
            new BirthdayJob(48),
            new ChristmasJob(48)
        };

        ImplementationsTypes types = new ImplementationsTypes();

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
            BirthdayJob job = new BirthdayJob(24);
            // Check that stock is available for job
            Assert.True(job.CheckStock());
        }

        [Fact]
        public void CheckChristmasStockTest()
        {
            // Create new christmas job
            ChristmasJob job = new ChristmasJob(24);
            // Check that stock is available for job
            Assert.True(job.CheckStock());
        }

        [Fact]
        public void ProcessBirthdayJobTest()
        {
            // Create new birthday job
            BirthdayJob job = new BirthdayJob(48);
            // Check that order is processed
            Assert.True(job.ProcessOrder());
        }

        [Fact]
        public void ProcessChristmasJobTest()
        {
            // Create new christmas job
            ChristmasJob job = new ChristmasJob(48);
            // Check that order is processed
            Assert.True(job.ProcessOrder());
        }

        [Fact]
        public void GetStockAmountsTest()
        {
            Stock stock = Stock.GetInstance();
            int[] stockAmounts = stock.GetStockAmounts();
            Assert.True(stockAmounts[0] > 0);
            Assert.True(stockAmounts[1] > 0);
            Assert.True(stockAmounts[2] > 0);
            Assert.True(stockAmounts[3] > 0);
        }

        [Fact]
        public void TestFirstIn()
        {
            Assert.True(types.FirstInFirstOut(jobs));
        }

        [Fact]
        public void TestInFull()
        {
            Assert.True(types.InFull(jobs));
        }

        [Fact]
        public void TestOnTime()
        {
            Assert.True(types.OnTime(jobs));
        }
    }
}