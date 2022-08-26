using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GranbyChallenge
{
    public class Stock
    {
        static Stock instance;

        private int toyStockAmount;
        private int xboxStockAmount;
        private int bubblewrapStockAmount;
        private int cardboardboxStockAmount;

        protected Stock(int toyStockAmount, int xboxStockAmount, int bubblewrapStockAmount, int cardboardboxStockAmount)
        {
            this.toyStockAmount = toyStockAmount;
            this.xboxStockAmount = xboxStockAmount;
            this.bubblewrapStockAmount = bubblewrapStockAmount;
            this.cardboardboxStockAmount = cardboardboxStockAmount;
        }

        public static Stock GetInstance()
        {
            Random random = new();
            int[] stockAmounts =
            {
                random.Next(20, 40),
                random.Next(20, 60),
                random.Next(10, 57),
                random.Next(12, 28)
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
        }

        public int XboxStockAmount
        {
            get { return xboxStockAmount; }
        }

        public int BubblewrapStockAmount
        {
            get { return bubblewrapStockAmount; }
        }

        public int CardboardboxStockAmount
        {
            get { return cardboardboxStockAmount; }
        }
    }
}
