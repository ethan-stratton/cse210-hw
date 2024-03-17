using System;
class Program
{
    static void Main()
    {
        Console.Clear();
        GoalHandler tracker = new GoalHandler();

        // Add sample goals
        // tracker.AddGoal(new SimpleGoal("Run a Marathon", 1000));
        // tracker.AddGoal(new EternalGoal("Read Scriptures", 100));
        // tracker.AddGoal(new ChecklistGoal("Attend Temple", 0, 5, 200));

        bool exit = false;

        while (!exit)
        {

            tracker.DisplayScore();

            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save to File");
            Console.WriteLine("4. Load from File");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Exit");

            Console.Write("\nEnter your choice (1-6): ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    tracker.AddGoal();
                    break;

                case "2":
                    tracker.DisplayGoals();
                    break;

                case "3":
                    Console.Write("Enter file name to save: ");
                    string saveFileName = Console.ReadLine();
                    tracker.SaveToFile(saveFileName);
                    Console.WriteLine($"Data saved to {saveFileName}");
                    break;

                case "4":
                    Console.Write("Enter file name to load: ");
                    string loadFileName = Console.ReadLine();
                    tracker.LoadFromFile(loadFileName);
                    Console.WriteLine($"Data loaded from {loadFileName}");
                    break;

                case "5":
                    tracker.RecordGoalCompletion();
                    break;

                case "6":
                    Console.WriteLine("Thanks for tracking your goals with us!");
                    exit = true;
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 6.");
                    break;
            }
        }
    }
}
