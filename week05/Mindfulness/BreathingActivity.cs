using System.ComponentModel;
using System.Data;

public class BreathingActivity:Activity
{
    public BreathingActivity() : base()
    {
        SetName("Breathing Activity");
        SetDescription(
            "\nThis activity will help you relax by walking your " +
            "through breathing in and out slowly. \n" +
            "Clear your mind and focus on your breathing."
            );
    }

    public void Run()
    {
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(GetDuration());

        Console.Clear();
        Console.WriteLine("Get ready...\n\n");
        ShowSpinner(3);

        Console.Clear();
        bool toGo = true;
        while (toGo)
        {
            CountDown("Breathe in... ", 5);
            CountDown("Now breathe out... ", 5);
            Console.WriteLine("\n");

            if (DateTime.Now >= endTime)
            {
                toGo = false;
            }
        }
        Logger.Log("Finished all breathing cycles in Breathing Activity.");
    }
}