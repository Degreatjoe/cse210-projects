using System;
using System.ComponentModel;
using System.Globalization;
using System.Numerics;
/*
This is a number input game that taches some cncept
fro byu paptphway.
*/
class Program
{
    static int Add(List<int> args)
    /**
     * This Function adds all the numbers in the
     list of numbers
    */
    {
        int sum = 0;
        foreach (int num in args)
        {
            sum = sum + num;
        }
        return sum;

    }

    static double ComputeAverage(List<int> args)
    {
        int listcount = args.Count;
        int total = Add(args);
        int average = total / listcount;
        return average;
    }
    static void Main(string[] args)
    {
        // declare a list variable named numList
        List<int> numList = new List<int>();
        Console.WriteLine("provide a series of intergers, enter 0 when you are done");
        string userInput;
        int convertedInput;

        do
        {
            Console.WriteLine("Enter a number");
            // recieve user input
            userInput = Console.ReadLine();

            // convert user inpyut to integers
            convertedInput = int.Parse(userInput);

            // chedk if the number inputed is 0
            // if its 0, break the loop (so that 0 is not added to the list)
            if (convertedInput == 0)
            {
                break;
            }
            numList.Add(convertedInput);

        } while (convertedInput != 0);

        int total = Add(numList);
        Console.WriteLine(" Total " + total);
        double avg = ComputeAverage(numList);
        Console.WriteLine("Average " + avg);
    }


}