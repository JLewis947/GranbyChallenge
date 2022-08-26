using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GranbyChallenge
{
    public class Stock
    {
        private int toyStockAmount;
        private int xboxStockAmount;
        private int bubblewrapStockAmount;
        private int cardboardboxStockAmount;

        public Stock(int toyStockAmount, int xboxStockAmount, int bubblewrapStockAmount, int cardboardboxStockAmount)
        {
            this.toyStockAmount = toyStockAmount;
            this.xboxStockAmount = xboxStockAmount;
            this.bubblewrapStockAmount = bubblewrapStockAmount;
            this.cardboardboxStockAmount = cardboardboxStockAmount;
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
