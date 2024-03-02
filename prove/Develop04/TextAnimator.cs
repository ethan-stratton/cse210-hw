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

    public void StartGrowingAnimation(string text)
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

    public void PrintLargeText(string text, int fontSize)
    {
        Console.Clear();
        Console.WriteLine(GetCenteredText(text, fontSize));
    }

    private string GetCenteredText(string text, int textSize)
    {
        int leftPadding = Math.Max((Console.WindowWidth - textSize) / 2, 0);
        return new string(' ', leftPadding) + text;
    }
}
