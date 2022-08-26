using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GranbyChallenge
{
    public class ChristmasJob : JobTemplate
    {
        public override string Name => "Christmas Job";
        public override int DispatchTime { get; set; }
        public ChristmasJob(int dispatchTime)
        {
            DispatchTime = dispatchTime;
        }

        public override bool CheckStock()
        {
            // Get the instance of stock
            Stock stock = Stock.GetInstance();

            // Check that stock is available and return true if available or false if not available
            if (stock.XboxStockAmount > 0)
            {
                if (stock.BubblewrapStockAmount > 0)
                {
                    if (stock.CardboardboxStockAmount > 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public override bool ProcessOrder()
        {
            throw new NotImplementedException();
        }
    }
}
