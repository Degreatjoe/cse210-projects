using System;
using System.Globalization;
using System.Security.Cryptography;

class Program
{
    static void Main(string[] args)
    {
        Random numberGen = new Random();
        int number = numberGen.Next(1, 100);
        Console.WriteLine("Welcome to the guessing game.");
        string inpoot;
        int convertedInput;

        do
        {
            Console.Write("Guess the number. ");
            inpoot = Console.ReadLine();
            convertedInput = int.Parse(inpoot);

            if (convertedInput != number && convertedInput < number)
        {
            Console.WriteLine("Higher!");
        }
        else if (convertedInput != number && convertedInput > number)
        {
            Console.WriteLine("lower");
        }
        else
        {
                Console.WriteLine("You guessed it!");
        }
        } while (convertedInput != number);

    }
}