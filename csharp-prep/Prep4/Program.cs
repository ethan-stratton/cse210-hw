using System;


class Program
{
    static void Main(string[] args)
    {
        //Ask the user for a series of numbers, and append each one to a list. Stop when they enter 0.

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        List<int> nums = new List<int>();

        while (true)
        {
            Console.Write("Enter Number: ");
            string user_num = Console.ReadLine();
            int num = int.Parse(user_num); 
            if (num == 0)
            {
                break;
            }
            nums.Add(num);
        } 



        //Compute the sum, or total, of the numbers in the list.

        int sum = nums.Sum();
        Console.WriteLine($"Sum of your numbers: {sum}");

        //Compute the average of the numbers in the list.

        int avg = sum / nums.Count;
        Console.WriteLine($"Average of your numbers: {avg}");


        //Find the maximum, or largest, number in the list.

        int maximum = nums.Max();
        Console.WriteLine($"Maximum value of your numbers: {maximum}");

        //Have the user enter both positive and negative numbers, 
        //then find the smallest positive number (the positive number that is closest to zero).

        int smllstPosNum = maximum;
        foreach (var number in nums)
        {
            if (number > 0 && number < smllstPosNum)
            smllstPosNum = number;
        }
        Console.WriteLine($"Your smallest positive number: {smllstPosNum}");
        

        //Sort the numbers in the list and display the new, sorted list. 
        //Hint: There are C# libraries that can help you here, try searching the internet for them.

        Console.WriteLine("New Sorted List:");
        nums.Sort();
        foreach(var number in nums)
        {
            Console.WriteLine(number);
        }





    }
}