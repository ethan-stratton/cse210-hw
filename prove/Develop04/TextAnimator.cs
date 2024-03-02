using System;
using System.Threading;

class TextAnimator
{
    private int _totalFrames;
    private int _initialSize;
    private int _sizeChangeRate;

    public TextAnimator(int totalFrames, int initialSize, int sizeChangeRate)
    {
        _totalFrames = totalFrames;
        _initialSize = initialSize;
        _sizeChangeRate = sizeChangeRate;
    }

    public void StartGrowingAnimation(string text) //found some basic resources online but they don't work for me
    {
        for (int frame = 0; frame <= _totalFrames; frame++)
        {
            int textSize = _initialSize + (frame * _sizeChangeRate);

            Console.Clear();
            Console.WriteLine(GetCenteredText(text, textSize));
            Thread.Sleep(50);
        }
    }

    public void StartShrinkingAnimation(string text)
    {
        for (int frame = 0; frame <= _totalFrames; frame++)
        {
            int textSize = _initialSize - (frame * _sizeChangeRate);
            textSize = Math.Max(textSize, 1); // supposed to floor text size at 1 but it doesn't work anyway

            Console.Clear();
            Console.WriteLine(GetCenteredText(text, textSize));
            Thread.Sleep(50);
        }
    }

    public void PrintAnySize(string text, int fontSize) // the only way to make things "bigger" is by giving them padding
    {
        Console.WriteLine(GetCenteredText(text, fontSize));
    }

    private string GetCenteredText(string text, int textSize)
        // just adds padding to some text to move the text where you want
        int leftPadding = Math.Max((Console.WindowWidth - textSize) / 2, 0);
        return new string(' ', leftPadding) + text;
    }
}
