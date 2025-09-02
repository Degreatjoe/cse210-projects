using System;
using System.Transactions;

class Program
{
    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the program!");
    }

    static string PromptUserName()
    {
        Console.Write("Enter your name: ");
        string name = Console.ReadLine();
        return name;
    }

    static int PromptUserNumber()
    {
        Console.Write("Enter your favourite number: ");
        string userNumber = Console.ReadLine();
        int convertednumber = int.Parse(userNumber);
        return convertednumber;
    }

    static int SquareNumber(int args)
    {
        int squarednum = args * args;
        return squarednum;
    }

    static void DisplayResult(string name, int squarednum)
    {
        Console.WriteLine($"{name}, the square of your number is {squarednum}");
    }


    static void Main(string[] args)
    {
        DisplayWelcome();
        string name = PromptUserName();
        int num = PromptUserNumber();
        int numsquare = SquareNumber(num);
        DisplayResult(name, numsquare);
    }
}