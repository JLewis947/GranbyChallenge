using GranbyChallenge;

// Create a list of jobs to complete
List<JobTemplate> jobs = new List<JobTemplate>();
jobs.Add(new ChristmasJob(24));
jobs.Add(new BirthdayJob(48));

//// Get the implementation type to use
//int implementationType = 0;

//// Ask user for input until the input is 1, 2 or 3
//do
//{
//    Console.Clear();
//    implementationType = GetImplementationType();
//} while (implementationType != 1 && implementationType != 2 && implementationType != 3);

foreach(var job in jobs)
{
    bool isStockAvailable = job.CheckStock();
    if(isStockAvailable)
    {

    } else
    {
        Console.WriteLine("Stock is not available for current job");
    }
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