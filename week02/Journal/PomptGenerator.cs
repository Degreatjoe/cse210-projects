using System;
/**
 * this file contains the class for generating a random
 * prompt from a list of prompt
*/

public class PromptGenerator
{
    List<string> prompts= new List<string>
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?",
        "What is one thing i am grateful for today"

    };

    public string GetRandomPrompt()
    {
        /**
         * GetRandomPrompt - Generates a Random Prompt from a list
         * of prompt.
         * Return: a string of prompt
        */
        Random randGen = new Random();
        int promptLen = prompts.Count;
        int index = randGen.Next(0, promptLen);

        return prompts[index];

    }
}