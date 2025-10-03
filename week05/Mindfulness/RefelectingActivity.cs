using System;
public class ReflectingActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Think of a time you overcame a challenge.",
        "Recall a moment of personal growth.",
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> _questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "What did you learn from it?",
        "How did it affect your life?",
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?",
        "Would you do anything differently?"
    };

    public ReflectingActivity()
    {
        _name = "Reflecting Activity";
        _description = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";
    }

    public void Run()
    {
        DisplayStartingMessage();
        AskForDuration();
        StartLoad();
        DisplayPrompt();

        Console.WriteLine("\nNow reflect on the following questions:\n");


        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        // Shuffle a copy of the questions
        List<string> shuffledQuestions = new List<string>(_questions);
        ShuffleList(shuffledQuestions);

        int questionIndex = 0;

        while (DateTime.Now < endTime)
        {
            // If we've used all questions, reshuffle and start over
            if (questionIndex >= shuffledQuestions.Count)
            {
                ShuffleList(shuffledQuestions);
                questionIndex = 0;
            }

            string question = shuffledQuestions[questionIndex];
            questionIndex++;

            Console.WriteLine($"\t{question}");

            // Spinner duration per question
            ShowSpinner(6);
        }
        DisplayEndingMessage();
    }


    public string GetRandomPrompt()
    {
        Random rand = new Random();
        return _prompts[rand.Next(_prompts.Count)];
    }

    private void ShuffleList(List<string> list)
    {
        Random rand = new Random();
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = rand.Next(n + 1);
            string value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }

    public string GetRandomQuestion()
    {
        Random rand = new Random();
        return _questions[rand.Next(_questions.Count)];
    }

    public void DisplayPrompt()
    {
        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine($"\t-- {GetRandomPrompt()} --\n");
        Console.WriteLine("When you have something in mind, press Enter to continue...");
        Console.ReadLine();
    }

    public void DisplayQuestions()
    {
        foreach (string question in _questions)
        {
            Console.WriteLine($"\t{question}");
            ShowSpinner(5);
        }
    }
}
