using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GranbyChallenge.Jobs
{
    public class ChristmasJob : JobTemplate
    {
        public override string Name => "Christmas Job";
        public override int DispatchTime { get; set; }
        public override Stock WarehouseStock { get; set; }

        public ChristmasJob(int dispatchTime)
        {
            DispatchTime = dispatchTime;
            WarehouseStock = Stock.GetInstance();
        }

        /// <summary>
        /// Check stock is available for current job
        /// </summary>
        /// <returns>Return stock availability</returns>
        public override bool CheckStock()
        {
            // Check that stock is available and return true if available or false if not available
            if (WarehouseStock.XboxStockAmount > 0)
            {
                if (WarehouseStock.BubblewrapStockAmount > 0)
                {
                    if (WarehouseStock.CardboardboxStockAmount > 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Process job order
        /// </summary>
        /// <returns>Return completion status</returns>
        public override bool ProcessOrder()
        {
            try
            {
                WarehouseStock.BubblewrapStockAmount--;
                WarehouseStock.CardboardboxStockAmount--;
                WarehouseStock.XboxStockAmount--;
            }
            catch
            {
                Console.WriteLine("Stock change has failed");
                return false;
            }
            return true;
        }
    }
}
