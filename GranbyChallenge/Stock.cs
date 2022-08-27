using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GranbyChallenge
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

        // Create a new instance of the stock class and assign the amount of stock for each item
        protected Stock(int toyStockAmount, int xboxStockAmount, int bubblewrapStockAmount, int cardboardboxStockAmount)
        {
            this.toyStockAmount = toyStockAmount;
            this.xboxStockAmount = xboxStockAmount;
            this.bubblewrapStockAmount = bubblewrapStockAmount;
            this.cardboardboxStockAmount = cardboardboxStockAmount;
        }

        // Get the instance of the stock class
        public static Stock GetInstance()
        {
            // Create a random number of stock for each item
            Random random = new();
            int[] stockAmounts =
            {
                random.Next(30, 40),
                random.Next(40, 60),
                random.Next(29, 57),
                random.Next(40, 100)
            };
            if(instance == null)
            {
                instance = new Stock(stockAmounts[0], stockAmounts[1], stockAmounts[2], stockAmounts[3]);
            }

            return instance;
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
