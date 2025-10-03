using System;

public class ListingActivity : Activity
{
    private int _count;
    private List<string> _prompts = new List<string>
    {
        "List things you are grateful for.",
        "List your recent achievements.",
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?",
        "List people who make you happy."
    };

    public ListingActivity()
    {
        _name = "Listing Activity";
        _description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";
    }

    public void Run()
    {
        DisplayStartingMessage();
        AskForDuration();
        StartLoad();

        string prompt = GetRandomPrompt();
        Console.WriteLine(prompt);
        Console.WriteLine($"List as many response you can to the following prompt.");
        Console.Write("Start typing in ...");
        ShowCountDown(5);


        List<string> responses = new List<string>();
        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            if (Console.KeyAvailable)
            {
                Console.Write("> ");
                string input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input))
                {
                    responses.Add(input);
                }
            }
        }

        _count = responses.Count;
        Console.WriteLine($"You listed {_count} items.\n");
        DisplayEndingMessage();
    }


    public string GetRandomPrompt()
    {
        Random rand = new Random();
        return _prompts[rand.Next(_prompts.Count)];
    }

    public List<string> GetListFromUser()
    {
        List<string> responses = new List<string>();
        Console.WriteLine("Start listing. Type 'done' to finish:");
        string input;
        while ((input = Console.ReadLine())?.ToLower() != "done")
        {
            if (!string.IsNullOrWhiteSpace(input))
                responses.Add(input);
        }
        return responses;
    }
}
