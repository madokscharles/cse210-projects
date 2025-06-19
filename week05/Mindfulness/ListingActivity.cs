using System;

public class ListingActivity : Activity
{
    private int _count;
    private List<string> _prompts = new List<string>();
    private List<string> _listFromUser = new List<string>();
    private static Random random = new Random();

    public ListingActivity() : base()
    {
        SetName("Listing Activity");
        SetDescription(
            "\nThis activity will help you reflect on the good things in " +
            "your life by having you list as many things as you can in " +
            "a certain area."
        );

        _prompts.AddRange(new[]
        {
            "\nWho are people that you appreciate?",
            "\nWhat are personal strengths of yours?",
            "\nWho are people that you have helped this week?",
            "\nWhen have you felt the Holy Ghost this month?",
            "\nWho are some of your personal heroes?"
        });
    }

    public void Run()
    {
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(GetDuration());

        Console.Clear();
        Console.WriteLine("Get ready...\n");
        ShowSpinner(3);

        Console.Clear();
        Console.WriteLine("List as many responses as you can to the following prompt:");
        ShowRandomPrompt();

        Console.WriteLine();
        CountDown("You may begin in", 5);
        Console.WriteLine();

        Console.WriteLine("Type your answers below:");

        _count = 0;
        _listFromUser.Clear(); // Ensuring it's empty at the start

        while (DateTime.Now < endTime)
        {
            string sentence = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(sentence))
            {
                _listFromUser.Add(sentence);
                Logger.Log($"User listed: {sentence}");
                _count++;
            }
        }

        Console.WriteLine($"\nYou listed {_count} items!");
        Logger.Log($"User completed Listing Activity with {_count} items in {GetDuration()} seconds");
    }

    private void ShowRandomPrompt()
    {
        int index = random.Next(_prompts.Count);
        string prompt = _prompts[index];
        Console.WriteLine($"{prompt}");
    }
}