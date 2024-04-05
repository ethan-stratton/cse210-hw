using System;
using System.Threading;

public class FishBowlAnimation
{
    private static int bowlWidth = 30;
    private static int bowlHeight = 10;
    private static int fishX = 0;
    private static int fishDirection = 1;
    private static int fishSpeed = 100; // milliseconds
    private static bool continueAnimation = true; // Flag to control animation
    private static bool showPrompt = false; // Flag to control prompt display

    public static void RunAnimation()
    {
        Console.CursorVisible = false;

        // Start the animation
        Thread animationThread = new Thread(() =>
        {
            while (continueAnimation)
            {
                Console.Clear();
                DrawBowl();
                DrawFish();

                Thread.Sleep(fishSpeed);

                fishX += fishDirection;

                if (fishX + 5 >= bowlWidth || fishX <= 0)
                {
                    fishDirection *= -1;
                }
            }
        });
        animationThread.Start();

        // Start thread to display prompt after 5 seconds
        Thread promptThread = new Thread(() =>
        {
            Thread.Sleep(5000);
            showPrompt = true;
            while (continueAnimation)
            {
                if (showPrompt)
                {
                    DisplayQuitPrompt();
                }
                Thread.Sleep(100); // Delay before checking for animation termination
            }
        });
        promptThread.Start();

        // Wait for Enter key press to terminate animation
        while (continueAnimation)
        {
            if (showPrompt && Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Enter)
            {
                StopAnimation();
            }
            Thread.Sleep(100); // To avoid high CPU usage
        }
    }

    private static void DrawBowl()
    {
        for (int i = 0; i < bowlHeight; i++)
        {
            for (int j = 0; j < bowlWidth; j++)
            {
                if (i == 0 || i == bowlHeight - 1 || j == 0 || j == bowlWidth - 1)
                    Console.Write("#");
                else
                    Console.Write(" ");
            }
            Console.WriteLine();
        }
    }

    private static void DrawFish()
    {
        Console.SetCursorPosition(fishX, bowlHeight / 2);
        Console.Write("<°(((< ");
    }

    private static void DisplayQuitPrompt()
    {
        //unfortunately can't quit prevent blinking text
        Console.SetCursorPosition(0, bowlHeight + 1);
        Console.Write("Press Enter to quit...");
    }

    public static void StopAnimation()
    {
        Console.Clear();
        continueAnimation = false;
    }
}
