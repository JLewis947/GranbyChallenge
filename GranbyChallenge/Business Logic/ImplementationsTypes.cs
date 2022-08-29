using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GranbyChallenge.Jobs;

namespace GranbyChallenge
{
    public class ImplementationsTypes
    {
        static readonly Stock stock = Stock.GetInstance();

        /// <summary>
        /// Complete jobs on a first come first serve basis
        /// </summary>
        public bool FirstInFirstOut(List<JobTemplate> jobs)
        {
            // Get the required stock of the jobs
            GetRequiredStock(jobs);
            // Loop over the jobs and process each job
            foreach (var job in jobs)
            {
                bool isStockAvailable = job.CheckStock();
                ProcessJobOrder(job, isStockAvailable);
            }
            return true;
        }

        /// <summary>
        /// Processes inputted job order
        /// </summary>
        /// <param name="job">The job to complete</param>
        /// <param name="isStockAvailable">A check to ensure stock is available for the current job</param>
        private static void ProcessJobOrder(JobTemplate job, bool isStockAvailable)
        {
            // If stock is available for job then process the order
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

        /// <summary>
        /// Complete the maximum number of jobs possible
        /// </summary>
        /// <param name="jobs">The list of jobs to complete</param>
        public bool InFull(List<JobTemplate> jobs)
        {
            // Create list to hold completable jobs and the remaining jobs
            List<JobTemplate> completableJobs = new List<JobTemplate>();

            // Display the required stock for all of the jobs
            GetRequiredStock(jobs);

            // Create variables to display number of runs and to stop processing jobs
            bool stopLoop = false;
            int runNumber = 1;

            do
            {
                // Get the amount of stock for each stock item
                int toys = stock.ToyStockAmount;
                int xbox = stock.XboxStockAmount;
                int bubblewrap = stock.BubblewrapStockAmount;
                int boxes = stock.CardboardboxStockAmount;

                // Loop over jobs to complete
                foreach(var job in jobs)
                {
                    // Take away stock from bubblewrap and boxes
                    bubblewrap--;
                    boxes--;

                    // Check which job it is to process
                    if(job is BirthdayJob)
                    {
                        // Take away stock from toys
                        toys--;
                        
                        // If the stock for toys, bubblewrap and boxes is above or equal to 0 then add the job to completable jobs
                        if(toys >= 0 && bubblewrap >= 0 && boxes >= 0)
                        {
                            completableJobs.Add(job);
                        } else
                        {
                            // Add the stock back to the remaining stock and add the job to remaining jobs
                            toys++;
                            bubblewrap++;
                            boxes++;
                        }
                    } else if(job is ChristmasJob)
                    {
                        // Take away stock from xbox
                        xbox--;

                        // If the stock for toys, bubblewrap and boxes is above or equal to 0 then add the job to completable jobs
                        if (xbox >= 0 && bubblewrap >= 0 && boxes >= 0)
                        {
                            completableJobs.Add(job);
                        } else
                        {
                            // Add the stock back to the remaining stock and add the job to remaining jobs
                            xbox++;
                            bubblewrap++;
                            boxes++;
                        }
                    }
                }

                // Remove the completed jobs from the job list
                foreach (var job in completableJobs)
                {
                    jobs.Remove(job);
                }

                // Process the jobs if there are any to complete otherwise stop looking for jobs to complete
                if (completableJobs.Count != 0)
                {
                    foreach(var job in completableJobs)
                    {
                        ProcessJobOrder(job, job.CheckStock());
                    }
                    Console.WriteLine($"Run {runNumber} Jobs Completed: {completableJobs.Count}");
                    completableJobs.Clear();
                } else
                {
                    Console.WriteLine($"Number of remaining jobs is {jobs.Count}");
                    stopLoop = true;
                }
            } while (!stopLoop);
            return true;
        }

        /// <summary>
        /// Sort jobs by dispatch time and try to complete maximum number of jobs possible
        /// </summary>
        /// <param name="jobs">The list of jobs to complete</param>
        /// <returns></returns>
        public bool OnTime(List<JobTemplate> jobs)
        {
            // Create a list of 24 hour jobs and a list of 48 hour jobs
            List<JobTemplate> singleDayJobs = new List<JobTemplate>();
            List<JobTemplate> multiDayJobs = new List<JobTemplate>();

            // Sort jobs into their respective lists
            for(int i = 0; i < jobs.Count; i++)
            {
                if (jobs[i].DispatchTime == 24)
                {
                    singleDayJobs.Add(jobs[i]);
                } else
                {
                    multiDayJobs.Add(jobs[i]);
                }
            }

            // Process the maximum number of jobs for each list. 24 hour jobs are prioritised.
            InFull(singleDayJobs);
            InFull(multiDayJobs);
            return true;
        }

        /// <summary>
        /// Get the required stock for a list of jobs
        /// </summary>
        /// <param name="jobs">The list of jobs to check the required stock for</param>
        private static void GetRequiredStock(List<JobTemplate> jobs)
        {
            // Get the stock amounts
            int[] stockAmounts = stock.GetStockAmounts();

            // Create variables to hold stock amount needed for each stock item
            int toyStockNeeded = 0;
            int xboxStockNeeded = 0;
            int bubblewrapStockNeeded = 0;
            int cardboardboxStockNeeded = 0;

            // Calculate amount of total stock needed
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

            // Display stock required
            Console.WriteLine("Stock Required / Stock Available");
            Console.WriteLine($"Toys: {toyStockNeeded} / {stockAmounts[0]}");
            Console.WriteLine($"Xbox: {xboxStockNeeded} / {stockAmounts[1]}");
            Console.WriteLine($"Bubblewrap: {bubblewrapStockNeeded} / {stockAmounts[2]}");
            Console.WriteLine($"Cardboard Boxes: {cardboardboxStockNeeded} / {stockAmounts[3]}");

            // Display missing stock
            int missingToyStock = stockAmounts[0] - toyStockNeeded;
            int missingXboxStock = stockAmounts[1] - xboxStockNeeded;
            int missingBubblewrapStock = stockAmounts[2] - bubblewrapStockNeeded;
            int missingCardboardBoxStock = stockAmounts[3] - cardboardboxStockNeeded;

            if(missingToyStock < 0 || missingXboxStock < 0 || missingBubblewrapStock < 0 || missingCardboardBoxStock < 0)
            {
                Console.WriteLine("Missiing Stock");
            }

            if (missingToyStock < 0)
            {
                Console.WriteLine($"Toys: {missingToyStock * -1}");
            }
            if (missingXboxStock < 0)
            {
                Console.WriteLine($"Xbox: {missingXboxStock * -1}");
            }
            if (missingBubblewrapStock < 0)
            {
                Console.WriteLine($"Bubblewrap: {missingBubblewrapStock * -1}");
            }
            if (missingCardboardBoxStock < 0)
            {
                Console.WriteLine($"Cardboard Boxes: {missingCardboardBoxStock * -1}");
            }
        }
    }
}
