using System;

class Program
{
    static PromptGenerator _promptGen = new PromptGenerator();
    static Journal _myJournal = new Journal();

    static void Main(string[] args)
    {
        string input;
        int userInput = 0;
        Console.WriteLine("Welcome to journal");
        do
        {
            ShowMenu();
            input = Console.ReadLine();
            try
            {
                userInput = int.Parse(input);
                Execute(userInput);
            }
            catch (FormatException)
            {
                Console.WriteLine($"{input} is not an int! Please enter only int.");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Error: number too large to be an int.");
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("please enter an input.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: an error occurred, {ex.Message}");
            }
        } while (userInput != 5);
    }

    static void ShowMenu()
    {
        List<string> menuList = new List<string>
        {
            "Write",
            "Display",
            "Load",
            "Save",
            "Quit"
        };

        int i = 1;
        Console.WriteLine("Please choose from the menu below");

        foreach (string item in menuList)
        {
            Console.WriteLine($"{i}. {item}");
            i++;
        }
        Console.Write("What do you want to do? ");
    }

    static void Execute(int userInput)
    {
        switch (userInput)
        {
            case 1:
                {
                    Entry entry = new Entry();

                    string newPrompt = _promptGen.GetRandomPrompt();
                    Console.Write($"{newPrompt} \n> ");

                    string input = Console.ReadLine();
                    entry._entryText = input;
                    entry._promptText = newPrompt;

                    _myJournal.AddEntry(entry);
                    break;
                }
            case 2:
                {
                    _myJournal.Display();
                    break;
                }
            case 3:
                {
                    Console.Write("Enter file name: ");
                    string input = Console.ReadLine();
                    _myJournal.LoadFromFile(input);
                    break;
                }
            case 4:
                {
                    Console.Write("Enter Filename> ");
                    string fileName = Console.ReadLine();
                    _myJournal.SaveToFile(fileName);
                    break;
                }
            case 5:
                {
                    return;
                }
            default:
                {
                    Console.WriteLine("Error: please Enter a valid number from 1 - 5");
                    break;
                }
        }
    }
}