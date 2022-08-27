using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GranbyChallenge
{
    public class ImplementationsTypes
    {
        /// <summary>
        /// Process jobs using the first in first out implementation
        /// </summary>
        public bool FirstInFirstOut(List<JobTemplate> jobs)
        {
            GetRequiredStock(jobs);
            foreach (var job in jobs)
            {
                bool isStockAvailable = job.CheckStock();
                if (isStockAvailable)
                {
                    job.ProcessOrder();
                    Console.WriteLine($"{job.Name} Order Processed");
                }
                else
                {
                    Console.WriteLine($"Stock is not available for {job.Name}");
                }
            }
            return true;
        }

        public bool InFull(List<JobTemplate> jobs)
        {
            GetRequiredStock(jobs);
            return true;
        }

        public bool OnTime(List<JobTemplate> jobs)
        {
            jobs.Sort();
            return true;
        }

        private static void GetRequiredStock(List<JobTemplate> jobs)
        {
            Stock stock = Stock.GetInstance();
            int[] stockAmounts = stock.GetStockAmounts();

            int toyStockNeeded = 0;
            int xboxStockNeeded = 0;
            int bubblewrapStockNeeded = 0;
            int cardboardboxStockNeeded = 0;

            for (int i = 0; i < jobs.Count; i++)
            {
                cardboardboxStockNeeded++;
                bubblewrapStockNeeded++;
                if (jobs[i] is BirthdayJob)
                {
                    toyStockNeeded++;
                }
                else
                {
                    xboxStockNeeded++;
                }
            }

            Console.WriteLine("Stock Required / Stock Available");
            Console.WriteLine($"Toys: {toyStockNeeded} / {stockAmounts[0]}");
            Console.WriteLine($"Xbox: {xboxStockNeeded} / {stockAmounts[1]}");
            Console.WriteLine($"Bubblewrap: {bubblewrapStockNeeded} / {stockAmounts[2]}");
            Console.WriteLine($"Cardboard Boxes: {cardboardboxStockNeeded} / {stockAmounts[3]}");
        }
    }
}
