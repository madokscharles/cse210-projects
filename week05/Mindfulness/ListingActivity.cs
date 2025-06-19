using System.Security.Principal;

public class ListingActivity : Activity
{
    private int _count;
    private List<string> _prompts = new List<string>();
    private static Random random = new Random();

    public ListingActivity() : base()
    {
        SetName("Listing Activity");
        SetDescripton(
            "\nThis activity will help you reflect on the good things in " +
            "your life by having you list as many things as you can in " +
            "a  certain area."
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
        Console.WriteLine("List as many responses you can to the following prompt:");
        GetRandomPrompt();

        Console.WriteLine();
        CountDown("You may begin in ", 5);
        Console.WriteLine();

        Console.WriteLine("Type your answers below:");

        _count = 0;

        while (endTime > DateTime.Now)
        {
            string sentence = Console.ReadLine();
            List<string> _listFromUser = GetListFromUser();
            _listFromUser.Add(sentence);
            Logger.Log($"User listed: {sentence}");
            _count++;
        }

        Console.WriteLine($"\nYou listed {_count} itens!");
        Logger.Log($"User completed Listing Activity with {_count} items in {GetDuration()} seconds");
    }

    public void GetRandomPrompt()
    {
        int index = random.Next(_prompts.Count);
        string prompt = _prompts[index];
        Console.WriteLine($"{prompt}");
    }

    public List<string> GetListFromUser()
    {
        List<string> listFromUser = new List<string>();
        return listFromUser;
    }
}