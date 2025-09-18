using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the ScriptureMemorizer Project.");

        string reference = "john 14:15";
        string text = "if ye love me keep my commandment.";
        string userInput = "";

        Scripture scripture = new Scripture(reference, text);

        while (!scripture.isCompletelyHidden() && userInput.ToLower() != "quit")
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nPress Enter to hide words or enter 'quit' to end the program.");
            userInput = Console.ReadLine();

            if (userInput.ToLower() != "quit")
            {
                scripture.HideRandomWords(3); // Hides 2 words at a time
            }
        }

        Console.WriteLine("\nProgram ended. Goodbye!");
    }
}
