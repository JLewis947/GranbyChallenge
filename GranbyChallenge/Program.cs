using GranbyChallenge;

// Create a list of jobs to complete
List<JobTemplate> jobs = new List<JobTemplate>();

Random random = new Random();
for(int i = 0; i < 75; i++)
{
    int ranNumber = random.Next(0, 2);
    if(ranNumber == 0)
    {
        jobs.Add(new BirthdayJob(24));
    } else
    {
        jobs.Add(new ChristmasJob(24));
    }
}

// Get the implementation type to use
int implementationType;

// Ask user for input until the input is 1, 2 or 3
do
{
    Console.Clear();
    implementationType = GetImplementationType();
} while (implementationType != 1 && implementationType != 2 && implementationType != 3);

switch(implementationType)
{
    case 1:
        FirstInFirstOut(jobs);
        break;
    case 2:
        break;
    case 3:
        break;
    default:
        Console.WriteLine("Implementation type not available");
        break;
}

Console.ReadKey();

/// <summary>
/// Gets the implementation type from the user
/// </summary>
static int GetImplementationType()
{
    Console.WriteLine("Please select implementation to test");
    Console.WriteLine("1. First in first out");
    Console.WriteLine("2. In full");
    Console.WriteLine("3. On time in full");
    Console.WriteLine("");
    // Get user input
    string? userInput = Console.ReadLine();
    int convertedInput = 0;
    // Try to convert the user input to an integer
    try
    {
       convertedInput = Int32.Parse(userInput);
    } catch (FormatException)
    {
        Console.WriteLine("Could Not Parse Input");
    }
    return convertedInput;
}

/// <summary>
/// Process jobs using the first in first out implementation
/// </summary>
static void FirstInFirstOut(List<JobTemplate> jobs)
{
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
}