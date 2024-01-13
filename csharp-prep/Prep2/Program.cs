using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade? ");
        string userGrade = Console.ReadLine();
        int grade = int.Parse(userGrade);

        int lastDigit = grade % 10;
        var plusOrMinus = (dynamic)null;

        if (lastDigit >= 7 && grade <= 90 && grade >= 60)
        {
            plusOrMinus = '+';
        }
        else if (lastDigit < 3 && grade >= 60)
        {
            plusOrMinus = '-';
        }
        else
        {
            //plusOrMinus = (string)null;
        }

        //int[] array = { 1, 3, 5 };
        //var lastItem = array[^1]; // 5

        char letter = 'Z';

        if (grade >= 90 )
        {
            letter = 'A';
        }
        else if (grade >= 80)
        {
            letter = 'B';
        }
        else if (grade >= 70)
        {
            letter = 'C';
        }
        else if (grade >= 60)
        {
            letter = 'D';
        }
        else 
        {
            letter = 'F';
        }

        Console.WriteLine($"You scored {letter}{plusOrMinus} in the class.");

        if (grade >= 70){
            Console.Write("Congratulations! You have passed the class!");
        }

    }
}