using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GranbyChallenge.Jobs
{
    public class Stock
    {
        // Stock instance
        static Stock instance;

        // Stock amounts
        private int toyStockAmount;
        private int xboxStockAmount;
        private int bubblewrapStockAmount;
        private int cardboardboxStockAmount;

        /// <summary>
        /// Create a new instance of the stock class and assign the amount of stock for each item
        /// </summary>
        /// <param name="toyStockAmount">Amount of toy stock</param>
        /// <param name="xboxStockAmount">Amount of xbox stock</param>
        /// <param name="bubblewrapStockAmount">Amount of bubblewrap stock</param>
        /// <param name="cardboardboxStockAmount">Amount of cardboard stock</param>
        protected Stock(int toyStockAmount, int xboxStockAmount, int bubblewrapStockAmount, int cardboardboxStockAmount)
        {
            this.toyStockAmount = toyStockAmount;
            this.xboxStockAmount = xboxStockAmount;
            this.bubblewrapStockAmount = bubblewrapStockAmount;
            this.cardboardboxStockAmount = cardboardboxStockAmount;
        }
        /// <summary>
        /// Get the stock instance
        /// </summary>
        /// <returns>New stock or an instance of stock</returns>
        public static Stock GetInstance()
        {
            // Create a random number of stock for each item
            Random random = new();
            int[] stockAmounts =
            {
                random.Next(30, 40),
                random.Next(40, 60),
                random.Next(75, 100),
                random.Next(75, 100)
            };
            // Create a new stock class if the instance does not exist
            if (instance == null)
            {
                instance = new Stock(stockAmounts[0], stockAmounts[1], stockAmounts[2], stockAmounts[3]);
            }

            return instance;
        }

        /// <summary>
        /// Returns the amount of stock for each stock item
        /// </summary>
        /// <returns></returns>
        public int[] GetStockAmounts()
        {
            return new int[] { toyStockAmount, xboxStockAmount, bubblewrapStockAmount, cardboardboxStockAmount };
        }

        public int ToyStockAmount
        {
            get { return toyStockAmount; }
            set { toyStockAmount = value; }
        }

        public int XboxStockAmount
        {
            get { return xboxStockAmount; }
            set { xboxStockAmount = value; }
        }

        public int BubblewrapStockAmount
        {
            get { return bubblewrapStockAmount; }
            set { bubblewrapStockAmount = value; }
        }

        public int CardboardboxStockAmount
        {
            get { return cardboardboxStockAmount; }
            set { cardboardboxStockAmount = value; }
        }
    }
}
