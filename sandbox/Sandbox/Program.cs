using System;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        // Console.WriteLine("Hello World! This is the Sandbox Project.");
        DateTime today = DateTime.Now;
        string dateString = today.ToLongTimeString();

        Console.WriteLine(dateString);
    }
}