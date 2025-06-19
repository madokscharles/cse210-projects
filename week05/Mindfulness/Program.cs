using System;

class Program
{
    static void Main(string[] args)
    {
        int _choice;
        do
        {
            Console.Clear();
            Console.WriteLine("\nMenu Options:");
            Console.WriteLine();
            Console.WriteLine("1. Start breathing activity");
            Console.WriteLine("2. Start refleting activity");
            Console.WriteLine("3. Start listing activity");
            Console.WriteLine("4. Quit");
            Console.WriteLine();
            Console.Write("Select a choice from the menu ");

            _choice = int.Parse(Console.ReadLine());

            switch (_choice)
            {
                case 1:
                    BreathingActivity breathingActivity = new BreathingActivity();
                    breathingActivity.DisplayStartingMessage();
                    Console.Write("How long, in seconds, would you like for your session? ");
                    int duration = int.Parse(Console.ReadLine());
                    breathingActivity.SetDuration(duration);
                    Logger.Log($"Starting {breathingActivity.GetName()} for {duration} seconds");
                    breathingActivity.Run();
                    Logger.Log($"Finished {breathingActivity.GetName()}");
                    breathingActivity.DisplayEndingMessage();
                    break;
                case 2:
                    ReflectingActivity reflectingActivity = new ReflectingActivity();
                    reflectingActivity.DisplayStartingMessage();
                    Console.Write("How long, in seconds, would you like for your session? ");
                    duration = int.Parse(Console.ReadLine());
                    reflectingActivity.SetDuration(duration);
                    Logger.Log($"Starting {reflectingActivity.GetName()} for {duration} seconds");
                    reflectingActivity.Run();
                    Logger.Log($"Finished {reflectingActivity.GetName()}");;
                    reflectingActivity.DisplayEndingMessage();
                    break;
                case 3:
                    ListingActivity listingActivity = new ListingActivity();
                    listingActivity.DisplayStartingMessage();
                    Console.Write("How long, in seconds, would you like for your session? ");
                    duration = int.Parse(Console.ReadLine());
                    listingActivity.SetDuration(duration);
                    Logger.Log($"Starting {listingActivity.GetName()} for {duration} seconds");
                    listingActivity.Run();
                    Logger.Log($"Finished {listingActivity.GetName()}");
                    listingActivity.DisplayEndingMessage();
                    break;
                case 4:
                    Console.Clear();
                    Console.WriteLine("Keep taking care of yourself. Come back whenever you need a moment.");
                    Logger.Log("Program exited by the user.");
                    Console.WriteLine();
                    Console.WriteLine("Press any key to close...");
                    Console.ReadKey();
                    Console.Clear();
                    break;
            }
        } while (_choice != 4);
    }
}