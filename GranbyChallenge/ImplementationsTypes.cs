using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GranbyChallenge
{
    public class ImplementationsTypes
    {
        static readonly Stock stock = Stock.GetInstance();

        /// <summary>
        /// Process jobs using the first in first out implementation
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
        /// 
        /// </summary>
        /// <param name="jobs">The list of jobs to complete</param>
        /// <returns></returns>
        public bool InFull(List<JobTemplate> jobs)
        {
            List<JobTemplate> completableJobs = new List<JobTemplate>();
            List<JobTemplate> remainingJobs = new List<JobTemplate>();

            GetRequiredStock(jobs);

            bool stopLoop = false;
            int runNumber = 1;

            do
            {
                int toys = stock.ToyStockAmount;
                int xbox = stock.XboxStockAmount;
                int bubblewrap = stock.BubblewrapStockAmount;
                int boxes = stock.CardboardboxStockAmount;

                foreach(var job in jobs)
                {
                    bubblewrap--;
                    boxes--;
                    if(job is BirthdayJob)
                    {
                        toys--;
                        if(toys > 0 && bubblewrap > 0 && boxes > 0)
                        {
                            completableJobs.Add(job);
                        } else
                        {
                            toys++;
                            bubblewrap++;
                            boxes++;
                            remainingJobs.Add(job);
                        }
                    } else
                    {
                        xbox--;
                        if (xbox >= 0 && bubblewrap >= 0 && boxes >= 0)
                        {
                            completableJobs.Add(job);
                        } else
                        {
                            xbox++;
                            bubblewrap++;
                            boxes++;
                            remainingJobs.Add(job);
                        }
                    }
                }

                foreach (var job in completableJobs)
                {
                    jobs.Remove(job);
                }

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

        public bool OnTime(List<JobTemplate> jobs)
        {
            List<JobTemplate> singleDayJobs = new List<JobTemplate>();
            List<JobTemplate> multiDayJobs = new List<JobTemplate>();
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
            InFull(singleDayJobs);
            InFull(multiDayJobs);
            return true;
        }

        private static void GetRequiredStock(List<JobTemplate> jobs)
        {
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
