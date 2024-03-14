using System;
using System.Collections.Generic;
using System.IO;

class GoalHandler
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;

    public void AddGoal()
{
    Console.WriteLine("Choose the type of goal (enter 1 for Eternal, 2 for Simple, 3 for Checklist):");
    int goalType = int.Parse(Console.ReadLine());

    Console.WriteLine("Enter the name of the goal:");
    string goalName = Console.ReadLine();

    Console.WriteLine("Enter a short description for the goal:");
    string goalDescription = Console.ReadLine();

    Console.WriteLine("How many point are associated with this goal?");
    int goalPoints = int.Parse(Console.ReadLine());

    Goal goal;

    switch (goalType)
    {
        case 1:
            goal = new Eternal(goalName, goalPoints, goalDescription); 
            break;
        case 2:
            goal = new Simple(goalName, goalPoints, goalDescription); 
            break;
        case 3:
            Console.WriteLine("Enter the target count for the checklist goal:");
            int targetCount = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the bonus value for the checklist goal:");
            int bonusValue = int.Parse(Console.ReadLine());
            goal = new Checklist(goalName, goalPoints, goalDescription, targetCount, bonusValue); 
            break;
        default:
            Console.WriteLine("Invalid goal type: Adding a simple goal by default.");
            goal = new Simple(goalName, goalPoints, goalDescription); 
            break;
    }

    _goals.Add(goal);
}

    public void RecordEvent()
    {
        Console.WriteLine("Enter the name of the goal you want to record an event for:");
        string goalName = Console.ReadLine();

        Goal selectedGoal = _goals.Find(g => g._name == goalName); // a handy trick using Linq

        if (selectedGoal != null)
        {
            selectedGoal.RecordEvent();
            _score += selectedGoal._value;
            Console.WriteLine($"Event recorded for {goalName}. You earned {selectedGoal._value} points.");
        }
        else
        {
            Console.WriteLine($"Goal with name {goalName} not found.");
        }
    }

    public void DisplayGoals()
    {
        foreach (var goal in _goals)
        {
            Console.WriteLine(goal.DisplayStatus());
        }
    }

    public void DisplayScore()
    {
        Console.WriteLine($"Current Score: {_score}");
    }
    public void SaveToFile(string fileName)
    {
        using (StreamWriter writer = new StreamWriter(fileName))
        {
            foreach (var goal in _goals)
            {
                writer.WriteLine($"{goal._name},{goal._value},{goal._completed}");

                if (goal is Checklist checklistGoal)
                {
                    writer.WriteLine($"{checklistGoal._targetCount},{checklistGoal._currentCount},{checklistGoal._bonusValue}");
                }
            }
            writer.WriteLine(_score);
        }
    }

    // Load goals and score from a file using StreamReader
    public void LoadFromFile(string fileName)
    {
        if (File.Exists(fileName))
        {
            _goals.Clear(); // Clear existing goals before loading

            using (StreamReader reader = new StreamReader(fileName))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    string name = parts[0];
                    int value = int.Parse(parts[1]);
                    bool completed = bool.Parse(parts[2]);
                    string description = parts[3];

                    Goal goal;

                    if (parts.Length == 4)
                    {
                        goal = new Goal(name, value, description);
                        goal._completed = completed;
                    }
                    else if (parts.Length == 6) // Assuming a checklist goal due to additional parameters
                    {
                        int targetCount = int.Parse(parts[3]);
                        int currentCount = int.Parse(parts[4]);
                        int bonusValue = int.Parse(parts[5]);

                        goal = new Checklist(name, value, description, targetCount, bonusValue);
                        ((Checklist)goal)._currentCount = currentCount;
                        goal._completed = currentCount == targetCount;
                    }
                    else
                    {
                        // Handle other types of goals
                        goal = new Goal(name, value, description);
                    }

                    _goals.Add(goal);
                }

                // Read the score
                if (int.TryParse(reader.ReadLine(), out int loadedScore))
                {
                    _score = loadedScore;
                }
            }
        }
    }
}
