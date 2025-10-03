using System;
public class BreathingActivity : Activity
{
    public BreathingActivity()
    {
        _name = "Breathing Activity";
        _description = "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.";
    }

    public void Run()
    {
        DisplayStartingMessage();
        AskForDuration();
        StartLoad();

        int totalSeconds = _duration;
        int cycleTime = 6; // 3 in + 3 out
        int cycles = totalSeconds / cycleTime;

        for (int i = 0; i < cycles; i++)
        {
            Console.Write("Breathe in...");
            ShowCountDown(3);
            Console.Write("Now Breathe out...");
            ShowCountDown(3);
            Console.WriteLine("");
        }

        DisplayEndingMessage();
    }
}
