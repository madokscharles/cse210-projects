using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;
    private string[] _motivations = new string[]
    {
        "Great job! Keep the momentum going!",
        "You're doing amazing work!",
        "One step closer to your eternal goals!",
        "You're on fire! Stay consistent!",
        "Another win! You’ve got this!"
    };

    private Random _rand = new Random();

    public void Start()
    {
        int choice = 0;
        while (choice != 6)
        {
            Console.Clear();
            DisplayPlayerInfo();
            Console.WriteLine("\nMenu Options\n");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goal");
            Console.WriteLine("  4. Load Goal");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit\n");
            Console.Write("Select a choice from the menu: ");
            if (!int.TryParse(Console.ReadLine(), out choice)) continue;

            switch (choice)
            {
                case 1: CreateGoal(); break;
                case 2: ListGoalDetails(); break;
                case 3: SaveGoals(); break;
                case 4: LoadGoals(); break;
                case 5: RecordEvent(); break;
                case 6: MessageExit(); break;
            }
        }
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"You have {_score} points.");
    }

    public void ListGoalDetails()
    {
        Console.Clear();
        Console.WriteLine("The goals are:\n");
        for (int i = 0; i < _goals.Count; i++)
        {
            string status = _goals[i].IsComplete() ? "[X]" : "[ ]";
            Console.WriteLine($"{i + 1}. {status} {_goals[i].GetDetailString()}");
        }
        Console.WriteLine("\nPress any key to return to the menu.");
        Console.ReadKey();
    }

    public void CreateGoal()
    {
        Console.Clear();
        Console.WriteLine("The types of Goals are:\n");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal\n");
        Console.Write("Which type of goal would you like to create? ");
        int type = int.Parse(Console.ReadLine());

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();
        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();
        Console.Write("What is the amount of points associated with this goal? ");
        int points = int.Parse(Console.ReadLine());

        if (type == 1)
            _goals.Add(new SimpleGoal(name, description, points));
        else if (type == 2)
            _goals.Add(new EternalGoal(name, description, points));
        else if (type == 3)
        {
            Console.Write("What is the bonus for completing this goal? ");
            int bonus = int.Parse(Console.ReadLine());
            Console.Write("How many times is it required? ");
            int target = int.Parse(Console.ReadLine());
            _goals.Add(new CheckListGoal(name, description, points, bonus, target));
        }

        Console.WriteLine("\nGoal created successfully! Press any key to continue.");
        Console.ReadKey();
    }

    public void RecordEvent()
    {
        Console.Clear();
        ListGoalDetails();
        Console.Write("Which goal did you accomplish? ");
        int index = int.Parse(Console.ReadLine()) - 1;
        Goal selectedGoal = _goals[index];
        selectedGoal.RecordEvent();

        int earnedPoints = selectedGoal.GetPoints();
        _score += earnedPoints;

        if (selectedGoal is CheckListGoal checklist && checklist.IsComplete())
        {
            _score += checklist.GetBonus();
            Console.WriteLine($"\nCongrats! You earned {earnedPoints} points + {checklist.GetBonus()} bonus!");
        }
        else
        {
            Console.WriteLine($"\nCongrats! You earned {earnedPoints} points!");
        }

        // Random encouragement
        Console.WriteLine("\n" + _motivations[_rand.Next(_motivations.Length)]);
        Console.WriteLine("\nPress any key to return to the menu.");
        Console.ReadKey();
    }

    public void SaveGoals()
    {
        Console.Clear();
        Console.Write("Filename to save? ");
        string fileName = Console.ReadLine();
        string path = $"./ListGoals/{fileName}.txt";
        Directory.CreateDirectory("./ListGoals");

        using (StreamWriter writer = new StreamWriter(path))
        {
            writer.WriteLine(_score);
            foreach (Goal g in _goals)
                writer.WriteLine(g.GetStringRepresentation());
        }

        Console.WriteLine("Goals saved successfully. Press any key.");
        Console.ReadKey();
    }

    public void LoadGoals()
    {
        Console.Clear();
        Console.Write("Filename to load? ");
        string fileName = Console.ReadLine();
        string path = $"./ListGoals/{fileName}.txt";

        if (!File.Exists(path))
        {
            Console.WriteLine("File not found. Press any key.");
            Console.ReadKey();
            return;
        }

        string[] lines = File.ReadAllLines(path);
        _score = int.Parse(lines[0]);
        _goals.Clear();

        for (int i = 1; i < lines.Length; i++)
        {
            string[] sep = { ":", "," };
            string[] parts = lines[i].Split(sep, StringSplitOptions.None);

            string type = parts[0].Trim();
            string name = parts[1].Trim();
            string desc = parts[2].Trim();
            int points = int.Parse(parts[3].Trim());

            if (type == "SimpleGoal")
                _goals.Add(new SimpleGoal(name, desc, points, bool.Parse(parts[4].Trim())));
            else if (type == "EternalGoal")
                _goals.Add(new EternalGoal(name, desc, points));
            else if (type == "CheckListGoal")
            {
                int bonus = int.Parse(parts[4].Trim());
                int target = int.Parse(parts[5].Trim());
                int done = int.Parse(parts[6].Trim());
                _goals.Add(new CheckListGoal(name, desc, points, bonus, target, done));
            }
        }

        Console.WriteLine("Goals loaded successfully. Press any key.");
        Console.ReadKey();
    }

    public void MessageExit()
    {
        Console.Clear();
        Console.WriteLine("Thanks for using Eternal Quest. Stay strong!");
        Console.WriteLine("Press any key to exit.");
        Console.ReadKey();
    }
}
