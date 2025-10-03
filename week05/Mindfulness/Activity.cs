using System;
using System.Collections.Generic;
using System.Threading;

public class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;

    public Activity()
    {
    }

    public void AskForDuration()
    {
        Console.Write("\nHow long, in seconds, would you like for your session: ");
        string input = Console.ReadLine();
        if (int.TryParse(input, out int duration))
        {
            _duration = duration;
        }
        else
        {
            Console.WriteLine("Invalid input. Using default duration of 30 seconds.");
            _duration = 30;
        }
    }


    public void DisplayStartingMessage()
    {
        Console.WriteLine($"\nWelcome to the {_name}\n");
        Console.WriteLine(_description);
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine("Well Done!");
        ShowSpinner(3);
        Console.WriteLine($"You have completed the {_name} for {_duration} seconds.");
        ShowSpinner(3);
    }

    public void ShowSpinner(int seconds)
    {
        char[] spinner = { '|', '/', '-', '\\' };
        int spinnerIndex = 0;
        int totalTicks = seconds * 4; // 4 frames per second

        for (int i = 0; i < totalTicks; i++)
        {
            Console.Write(spinner[spinnerIndex]);
            Thread.Sleep(250); // 250ms per frame => 4 frames/sec
            Console.Write("\b"); // backspace to overwrite previous character
            spinnerIndex = (spinnerIndex + 1) % spinner.Length;
        }

        Console.Write(" "); // clear the spinner
        Console.Write("\b"); // move back
    }

    public void StartLoad()
    {
        Console.Clear();
        Console.WriteLine("Get ready...");
        ShowSpinner(5);
    }
    public void EndLoad()
    {
        Console.WriteLine("Well done!!");
        ShowSpinner(4);
    }

    public void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
        Console.WriteLine();
    }
}
