using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;

    public void Start()
    {
        bool running = true;
        while (running)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Display Player Info");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Create New Goal");
            Console.WriteLine("4. Record Event");
            Console.WriteLine("5. Save Goals");
            Console.WriteLine("6. Load Goals");
            Console.WriteLine("7. Quit");

            Console.Write("Choose an option: ");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1": DisplayPlayerInfo(); break;
                case "2": ListGoalDetails(); break;
                case "3": CreateGoal(); break;
                case "4": RecordEvent(); break;
                case "5": SaveGoals(); break;
                case "6": LoadGoals(); break;
                case "7": running = false; break;
                default: Console.WriteLine("Invalid option."); break;
            }
        }
    }

    private int GetLevel()
    {
        return (_score / 1000) + 1;
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"Your current score is: {_score}");
        Console.WriteLine($"Your level is: {GetLevel()}");
    }

    public void ListGoalNames()
    {
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void ListGoalDetails()
    {
        foreach (var goal in _goals)
        {
            Console.WriteLine(goal.GetDetailsString());
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("Which type of goal would you like to create?");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");

        string choice = Console.ReadLine();

        Console.Write("Enter name: ");
        string name = Console.ReadLine();
        Console.Write("Enter description: ");
        string description = Console.ReadLine();
        Console.Write("Enter points: ");
        int points = int.Parse(Console.ReadLine());

        Goal newGoal = null;

        if (choice == "1")
            newGoal = new SimpleGoal(name, description, points);
        else if (choice == "2")
            newGoal = new EternalGoal(name, description, points);
        else if (choice == "3")
        {
            Console.Write("Enter target count: ");
            int target = int.Parse(Console.ReadLine());
            Console.Write("Enter bonus points: ");
            int bonus = int.Parse(Console.ReadLine());
            newGoal = new ChecklistGoal(name, description, points, target, bonus);
        }

        if (newGoal != null)
            _goals.Add(newGoal);
    }

    public void RecordEvent()
    {
        Console.WriteLine("Which goal did you accomplish?");
        ListGoalNames();

        if (int.TryParse(Console.ReadLine(), out int index))
        {
            index -= 1;

            if (index >= 0 && index < _goals.Count)
            {
                int oldLevel = GetLevel();

                int earned = _goals[index].RecordEvent();
                _score += earned;

                Console.WriteLine($"You earned {earned} points! Total score: {_score}");

                int newLevel = GetLevel();
                if (newLevel > oldLevel)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"🎉 You leveled up! You are now Level {newLevel}!");
                    Console.ResetColor();
                }
            }
            else
            {
                Console.WriteLine("Invalid goal number.");
            }
        }
        else
        {
            Console.WriteLine("Invalid input.");
        }
    }


    public void SaveGoals()
    {
        Console.Write("Enter filename to save: ");
        string filename = Console.ReadLine();

        using (StreamWriter sw = new StreamWriter(filename))
        {
            sw.WriteLine(_score);
            foreach (var goal in _goals)
            {
                sw.WriteLine(goal.GetStringRepresentation());
            }
        }
    }

    public void LoadGoals()
    {
        Console.Write("Enter filename to load: ");
        string filename = Console.ReadLine();

        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            return;
        }

        string[] lines = File.ReadAllLines(filename);
        _score = int.Parse(lines[0]);
        _goals.Clear();

        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split(':');
            string type = parts[0];
            string[] data = parts[1].Split('|');

            if (type == "SimpleGoal")
            {
                var goal = new SimpleGoal(data[0], data[1], int.Parse(data[2]));
                if (bool.Parse(data[3]))
                    goal.RecordEvent();
                _goals.Add(goal);
            }
            else if (type == "EternalGoal")
            {
                _goals.Add(new EternalGoal(data[0], data[1], int.Parse(data[2])));
            }
            else if (type == "ChecklistGoal")
            {
                var goal = new ChecklistGoal(data[0], data[1], int.Parse(data[2]),
                                             int.Parse(data[4]), int.Parse(data[3]));

                int completions = int.Parse(data[5]);
                for (int j = 0; j < completions; j++)
                    goal.RecordEvent();

                _goals.Add(goal);
            }
        }
    }
}
