using GranbyChallenge;

// Create a list of jobs to complete
List<JobTemplate> jobs = new List<JobTemplate>();

Random random = new Random();
// Create 75 random jobs to be used for testing
for(int i = 0; i < 75; i++)
{
    // Create random job and dispatch time
    int ranNumber = random.Next(0, 2);
    int ranDispatchNum = random.Next(0, 2);

    // Set the dispatch time for the job
    int dispatchTime = 24;
    if(ranDispatchNum == 1)
    {
        dispatchTime = 48;
    }

    // Create a job based on the random number value generated
    if(ranNumber == 0)
    {
        jobs.Add(new BirthdayJob(dispatchTime));
    } else
    {
        jobs.Add(new ChristmasJob(dispatchTime));
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

ImplementationsTypes implementationTypes = new ImplementationsTypes();
bool areOrdersProcessed = false;

switch(implementationType)
{
    case 1:
        areOrdersProcessed = implementationTypes.FirstInFirstOut(jobs);
        break;
    case 2:
        areOrdersProcessed = implementationTypes.InFull(jobs);
        break;
    case 3:
        areOrdersProcessed = implementationTypes.OnTime(jobs);
        break;
    default:
        Console.WriteLine("Implementation type not available");
        break;
}

if(areOrdersProcessed)
{
    Console.WriteLine("All orders processed");
} else
{
    Console.WriteLine("Error processing orders");
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