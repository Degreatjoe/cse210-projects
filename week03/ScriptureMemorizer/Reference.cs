using System;
using System.Globalization;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic;
/**
 * this fill would contain the reference class
*/
public class Reference
{
    private string _book;
    private int _chapter;
    private int _verse;
    private int _endVerse;
    private bool _isValid = true;


    private Reference(string book, int chapter, int verse, int endVerse, bool isValid = true)
    {
        /**
         * Reference - The constructor that initializes the
         * Reference class.
         * @reference: the reference text to work with e.g "john 3:16"
        */

            _book = book;
            _chapter = chapter;
            _verse = verse;
            _endVerse = endVerse;

    }

    public static Reference Parse(string input)
    {
        TextInfo titleCase = CultureInfo.CurrentCulture.TextInfo;
        input = Regex.Replace(input, @"\s+", " ").Trim();

        Match match = Regex.Match(input, @"^(.+?)\s+(\d+)\s*:\s*(\d+)\s*(?:-\s*(\d+))?$", RegexOptions.IgnoreCase);

        if (!match.Success)
        {
            return new Reference("Invalid", 0, 0, 0, false);
        }

        try
        {
            string book = titleCase.ToTitleCase(match.Groups[1].Value.Trim().ToLower());
            int chapter = int.Parse(match.Groups[2].Value);
            int verse = int.Parse(match.Groups[3].Value);
            int endVerse = match.Groups[4].Success ? int.Parse(match.Groups[4].Value) : verse;

            return new Reference(book, chapter, verse, endVerse);
        }
        catch (Exception)
        {
            return new Reference("Invalid", 0, 0, 0, false);
        }
    }

    public string GetDisplayText()
    {
        if (!_isValid)
        {
            return "Invalid Reference";
        }
        if (_verse == _endVerse)
        {
            return $"{_book} {_chapter}:{_verse}";
        }
        else
        {
            return $"{_book} {_chapter}:{_verse}-{_endVerse}";
        }
    }
}