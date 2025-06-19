using System.ComponentModel;
using System.Security.AccessControl;

public class Activity
{
    private string _name;
    private string _description;
    private int _duration;

    public void SetName(string name)
    {
        _name = name;
    }

    public void SetDescription(string description)
    {
        _description = description;
    }

    public void SetDuration(int duration)
    {
        _duration = duration;
    }

    public string  GetName()
    {
        return _name;
    }

    public string Getdescription()
    {
        return _description;
    }

    public int GetDuration()
    {
        return _duration;
    }


    public void DisplayStartingMessage()
    {
        Console.Clear();
        Console.Write($"Welcome to the {_name}.\n");
        Console.WriteLine($"{_description}");
        Console.WriteLine();
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine();
        Console.WriteLine("Well done!!\n");
        Console.WriteLine($"You have completed another {GetDuration()} seconds of the {_name}");
        Console.WriteLine();
        Console.WriteLine("Press any key to return to the menu");
        Console.ReadKey();

    }

    public void ShowSpinner(int seconds)
    {
        char[] spinner = { '|', '/', '-', '\\' };
        int index = 0;

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(seconds);

        while (DateTime.Now < endTime)
        {
            Console.Write(spinner[index % spinner.Length]);
            Thread.Sleep(500);
            Console.Write("\b \b");
            index++;
        }
    }

    public void CountDown(string sentence, int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            string fullText = $"{sentence} {i}";
            Console.Write($"{fullText}      \r");
            Thread.Sleep(1000);
        }
        Console.Write($"{sentence}          \r");
        Console.WriteLine();
    }

}