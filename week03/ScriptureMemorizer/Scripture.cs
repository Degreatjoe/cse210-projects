using System;
// this file contains the scripture class

public class Scripture
{
    private Reference _reference;
    private List<Word> _words = new List<Word>();

    public Scripture(string reference, string text)
    {
        _reference = Reference.Parse(reference);

        string[] strings = text.Split(' ');
        foreach (string str in strings)
        {
            Word word = new Word(str);
            _words.Add(word);
        }
    }

    public void HideRandomWords(int number)
    {
        Random rand = new Random();
        int count = 0;

        // Create a list of indices of visible words
        var visibleIndices = _words
            .Select((word, index) => new { word, index })
            .Where(x => !x.word.IsHidden())
            .Select(x => x.index)
            .ToList();

        while (count < number && visibleIndices.Count > 0)
        {
            int randomIndex = rand.Next(visibleIndices.Count);
            int wordIndex = visibleIndices[randomIndex];

            _words[wordIndex].Hide();
            visibleIndices.RemoveAt(randomIndex);
            count++;
        }
    }


    public bool isCompletelyHidden()
    {
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                return false;
            }
        }
        return true;
    }

    public string GetDisplayText()
    {
        string display = _reference.GetDisplayText() + ' ';
        foreach (Word word in _words)
        {
            display += word.GetDisplayText();
        }
        return display.Trim();
    }
}