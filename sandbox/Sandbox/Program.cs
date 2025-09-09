using System;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        // Console.WriteLine("Hello World! This is the Sandbox Project.");
        int x;
        int y;

        try
        {

            Console.Write("enter a number: ");
            string inp1 = Console.ReadLine();
            x = int.Parse(inp1);

            Console.Write("enter a seond number: ");
            string inp2 = Console.ReadLine();
            y = int.Parse(inp2);

            int RES = x + y;
            Console.WriteLine(RES);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error: {e}");
        }

    }
}