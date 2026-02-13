using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score;

    public void Start()
    {
        while (true)
        {
            Console.WriteLine($"\nYour Score: {_score}");
            Console.WriteLine($"Level: {_score / 500}");
            Console.WriteLine("1. Create Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Record Event");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Load");
            Console.WriteLine("6. Quit");

            string choice = Console.ReadLine();

            if (choice == "1") CreateGoal();
            else if (choice == "2") ListGoals();
            else if (choice == "3") RecordEvent();
            else if (choice == "4") SaveGoals();
            else if (choice == "5") LoadGoals();
            else if (choice == "6") break;
        }
    }

    private void CreateGoal()
    {
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");

        string type = Console.ReadLine();

        Console.Write("Name: ");
        string name = Console.ReadLine();

        Console.Write("Description: ");
        string description = Console.ReadLine();

        Console.Write("Points: ");
        int points = int.Parse(Console.ReadLine());

        if (type == "1")
        {
            _goals.Add(new SimpleGoal(name, description, points));
        }
        else if (type == "2")
        {
            _goals.Add(new EternalGoal(name, description, points));
        }
        else if (type == "3")
        {
            Console.Write("Target count: ");
            int target = int.Parse(Console.ReadLine());

            Console.Write("Bonus: ");
            int bonus = int.Parse(Console.ReadLine());

            _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
        }
    }

    private void ListGoals()
    {
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    private void RecordEvent()
    {
        ListGoals();

        Console.Write("Select goal number: ");
        int index = int.Parse(Console.ReadLine()) - 1;

        int pointsEarned = _goals[index].RecordEvent();
        _score += pointsEarned;

        Console.WriteLine($"You earned {pointsEarned} points!");
    }

    private void SaveGoals()
    {
        using (StreamWriter writer = new StreamWriter("goals.txt"))
        {
            writer.WriteLine(_score);

            foreach (Goal goal in _goals)
            {
                writer.WriteLine(goal.GetSaveString());
            }
        }
    }

    private void LoadGoals()
    {
        if (!File.Exists("goals.txt"))
            return;

        string[] lines = File.ReadAllLines("goals.txt");

        _goals.Clear();
        _score = int.Parse(lines[0]);

        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split('|');

            if (parts[0] == "Simple")
            {
                SimpleGoal goal = new SimpleGoal(parts[1], parts[2], int.Parse(parts[3]));
                goal.SetComplete(bool.Parse(parts[4]));
                _goals.Add(goal);
            }
            else if (parts[0] == "Eternal")
            {
                _goals.Add(new EternalGoal(parts[1], parts[2], int.Parse(parts[3])));
            }
            else if (parts[0] == "Checklist")
            {
                ChecklistGoal goal = new ChecklistGoal(
                    parts[1],
                    parts[2],
                    int.Parse(parts[3]),
                    int.Parse(parts[4]),
                    int.Parse(parts[6])
                );

                goal.SetProgress(int.Parse(parts[5]));
                _goals.Add(goal);
            }
        }
    }
}
