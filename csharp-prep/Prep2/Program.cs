using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade? ");
        string userGrade = Console.ReadLine();

        int grade = int.Parse(userGrade);

        if (grade >= 90 )
        {
            Console.WriteLine("You got an 'A");
        }
        else if (grade >= 80)
        {
            Console.WriteLine("You got a 'B");
        }
        else if (grade >= 70)
        {
            Console.Write("You got a 'C'");
        }
        else if (grade >= 60)
        {
            Console.WriteLine("You got a 'D");
        }
        else 
        {
            Console.WriteLine("You got an F");
        }

    }
}