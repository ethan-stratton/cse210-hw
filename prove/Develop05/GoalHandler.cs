using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;

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
            Console.WriteLine("Invalid goal type:Adding a simple goal by default.");
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
        Console.WriteLine("\nYour goals: ");
        if (_goals.Count == 0)
        {
            Console.Write("You currently have no goals.");
            return;
        }

        for (int i = 0; i < _goals.Count; i++)
        {
            // Print the goal number and its status
            Console.WriteLine($"{i + 1}. { _goals[i].DisplayStatus()}");
        }
    }

    public void DisplayScore()
    {
        Console.WriteLine($"\nCurrent Score: {_score}");
    }
    public void SaveToFile(string fileName)
    {
        using (StreamWriter writer = new StreamWriter(fileName))
        {
            //save points to top of file
            writer.WriteLine(_score);

            foreach (var goal in _goals)
            {
                if (goal is Simple simpleGoal)
                {
                    writer.WriteLine($"{simpleGoal.getClassName()},{simpleGoal._name},{simpleGoal._description},{simpleGoal._value}, {simpleGoal._completed}");
                }
                if (goal is Eternal eternalGoal)
                {
                    writer.WriteLine($"{eternalGoal.getClassName()},{eternalGoal._name},{eternalGoal._description},{eternalGoal._value}");
                }
                //checklistgoal: 7 parts: name description points, bonus points, times needed, times already done
                if (goal is Checklist checklistGoal)
                {
                    writer.WriteLine($"{checklistGoal.getClassName()},{checklistGoal._description},{checklistGoal._value},{checklistGoal._bonusValue},{checklistGoal._targetCount},{checklistGoal._currentCount}");
                }
            }
        }
    }

    // Load goals and score from a file using StreamReader
    //@3:34
    public void LoadFromFile(string fileName)
{
    if (File.Exists(fileName))
    {
        _goals.Clear(); // Clear existing goals in the list before loading

        using (StreamReader reader = new StreamReader(fileName))
        {
            // Read the score first
            if (int.TryParse(reader.ReadLine(), out int loadedScore))
            {
                _score = loadedScore;
            }

            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split(',');

                string type = parts[0];
                string name = parts[1];
                string description = parts[2];
                int value = int.Parse(parts[3]);

                Goal goal;

                if (type == "Simple")
                {
                    
                    bool completed = bool.Parse(parts[4]);
                    goal = new Simple(name, value, description);
                    goal._completed = completed;

                }
                else if (type == "Eternal")
                {
                    goal = new Eternal(name, value, description);

                }
                else if (type == "Checklist")
                {   
                    int bonusValue = int.Parse(parts[4]);
                    int targetCount = int.Parse(parts[5]);
                    int currentCount = int.Parse(parts[6]);

                    goal = new Checklist(name, value, description, targetCount, bonusValue);
                    ((Checklist)goal)._currentCount = currentCount;
                    goal._completed = currentCount == targetCount;

                }
                else
                {
                    continue; // Skip to next line
                }

                _goals.Add(goal);
            }
        }
    }
}

}

