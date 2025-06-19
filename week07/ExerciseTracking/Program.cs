using System;
using System.Globalization;

class Program
{
    static Random _rng = new Random();
    static Dictionary<string, Type> _activityTypes = new Dictionary<string, Type>
    {
        { "Running", typeof(Running) },
        { "Swimming", typeof(Swimming) },
        { "Cycling", typeof(Cycling) }
    };

    static void Main(string[] args)
    {
        List<Activity> myActivities = new List<Activity>();
        GreetUser();

        Console.Write("How many exercises would you like to log today? ");
        int count;
        while (!int.TryParse(Console.ReadLine(), out count))
        {
            Console.WriteLine("Oops! Please enter a valid number.");
        }

        for (int i = 0; i < count; i++)
        {
            Type selectedType = GetActivityType();
            int sessionDuration = GetDuration();
            DateTime sessionDate = GetRandomDate();

            if (selectedType == typeof(Running))
            {
                double distance = GetDistance();
                myActivities.Add(new Running(sessionDate, sessionDuration, distance));
            }
            else if (selectedType == typeof(Swimming))
            {
                int laps = GetLaps();
                myActivities.Add(new Swimming(sessionDate, sessionDuration, laps));
            }
            else
            {
                double speed = GetSpeed();
                myActivities.Add(new Cycling(sessionDate, sessionDuration, speed));
            }
        }

        Console.WriteLine("\n📋 Your Activity Summaries:");
        foreach (Activity activity in myActivities)
        {
            activity.GetSummary();
            ShowEncouragement();
        }
    }

    static void GreetUser()
    {
        int hour = DateTime.Now.Hour;
        string greeting = hour switch
        {
            >= 6 and < 12 => "🌞 Good Morning!",
            >= 12 and < 18 => "🌤️ Good Afternoon!",
            _ => "🌙 Good Evening!"
        };

        Console.WriteLine($"\n{greeting}\nLet's stay active today!\n");
    }

    static Type GetActivityType()
    {
        string[] types = { "Running", "Swimming", "Cycling" };
        string choice = types[_rng.Next(types.Length)];
        return _activityTypes[choice];
    }

    static int GetDuration()
    {
        int[] options = { 20, 30, 45, 60, 75 };
        return options[_rng.Next(options.Length)];
    }

    static DateTime GetRandomDate()
    {
        int month = _rng.Next(1, 13);
        int year = 2025;
        int day = _rng.Next(1, DateTime.DaysInMonth(year, month) + 1);

        return new DateTime(year, month, day);
    }

    static double GetDistance()
    {
        double[] distances = { 3.0, 4.5, 6.0, 7.5, 9.0 };
        return distances[_rng.Next(distances.Length)];
    }

    static int GetLaps()
    {
        int[] laps = { 10, 20, 30, 50 };
        return laps[_rng.Next(laps.Length)];
    }

    static double GetSpeed()
    {
        double[] speeds = { 8.5, 10.0, 12.0, 14.5 };
        return speeds[_rng.Next(speeds.Length)];
    }

    static void ShowEncouragement()
    {
        string[] quotes =
        {
            "💪 Keep pushing!",
            "🔥 You're doing great!",
            "🚴‍♀️ Small steps lead to big results.",
            "🏃 Keep going — progress is power!",
            "👏 That’s how champions train!"
        };

        Console.WriteLine(quotes[_rng.Next(quotes.Length)]);
        Console.WriteLine();
    }
}
