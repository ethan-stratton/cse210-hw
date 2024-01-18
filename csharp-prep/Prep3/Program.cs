using System;

class Program
{

    static class count_stuff
    {
        public static int counter;
    }
    static void Main(string[] args)
    {

        // In the Guess My Number game the computer picks a magic number, 
        // and then the user tries to guess it. After each guess, 
        // the computer tells the user to guess "higher" or "lower" until they guess the magic number.

        //Console.Write("What is your magic number? ");
        //string magNumber = Console.ReadLine();
        //int target = int.Parse(magNumber);
        string play_again_query;
        do
        {
                    Random rnd = new Random();
        int target = rnd.Next(0, 100);

        Console.Write("What is your guess? ");
        string user_guess = Console.ReadLine();
        int guess = int.Parse(user_guess);        

        count_stuff.counter = 0;

        while (guess != target)
        {
            if (guess > target)
            {
                Console.Write("Your guess was too high. ");
                Console.Write("What is your guess? ");
                user_guess = Console.ReadLine();
                guess = int.Parse(user_guess);
                count_stuff.counter++;
            }
            else if (guess < target) 
            {
                Console.Write("Your guess was too low. ");
                Console.Write("What is your guess? ");
                user_guess = Console.ReadLine();
                guess = int.Parse(user_guess);  
                count_stuff.counter++; 
            }
        }
        Console.WriteLine("Congratulations! You guessed the right number!");
        Console.WriteLine($"Total guesses: {count_stuff.counter}");


        Console.Write("Do you want to continue? Type 'yes' ");
        play_again_query = Console.ReadLine();
        } while (play_again_query == "yes");

}
}