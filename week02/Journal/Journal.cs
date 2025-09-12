using System;
using System.IO;
using System.Linq.Expressions;
/**
 * this file contains the journal class
 * used for collecting, displaying, saving , and loading entries
*/
public class Journal
{
    List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry entry)
    {
        /**
         * AddEntry - adds the entry object to the list of entry
         * @entry: the parameter that receives an entry object
         * Return: nothing
        */
        _entries.Add(entry);
    }

    public void Display()
    {
        /**
         * Display - displays the entries in the journal
         * Return: nothing
        */

        var grouped = ToGroupedDict();

        foreach (var date in grouped.Keys)
        {
            Console.WriteLine($"\n{date}:");

            foreach (var line in grouped[date])
            {
                Console.WriteLine(line);
            }
        }
        Console.WriteLine("");
    }


    public int SaveToFile(string filename)
    {
        /**
         * SaveToFile - Saves all entries to a file
         * @filename: the file where the entries will
         * saved.
         * Return: 0 if successful and 1 if failed
        */
        try
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                foreach (Entry entry in _entries)
                {
                    writer.WriteLine("==="); // delimiter
                    writer.WriteLine($"Date: {entry.dateString}");
                    writer.WriteLine($"Time: {entry.timeStamp}");
                    writer.WriteLine($"Prompt: {entry.promptText}");
                    writer.WriteLine("Entry:");
                    writer.WriteLine(entry.entryText);
                }
            }
            Console.WriteLine($"Journal saved to '{filename}'.");
            return 0;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving journal: {ex.Message}");
            return 1;
        }
    }

    public void LoadFromFile(string fileName)
    {
        /**
         * LoadFromFile - Loads entries from a given file
         * @Filename: the name of the file from which thw
         * entries would be loaded.
         * Return: nothing
        */
        try
        {
            _entries.Clear();

            string content = File.ReadAllText(fileName);
            string[] rawEntries = content.Split(new[] { "===" },
            StringSplitOptions.RemoveEmptyEntries);

            foreach (var rawEntry in rawEntries)
            {
                string[] lines = rawEntry.Trim().Split(new[] { '\n', '\r' },
                StringSplitOptions.RemoveEmptyEntries);

                string dateString = "";
                string timeStamp = "";
                string promptText = "";
                string entryText = "";

                bool readingEntryText = false;
                List<string> entryLines = new List<string>();

                foreach (var line in lines)
                {
                    if (readingEntryText)
                    {
                        entryLines.Add(line);
                    }
                    else if (line.StartsWith("Date:"))
                    {
                        dateString = line.Substring(5).Trim();
                    }
                    else if (line.StartsWith("Time:"))
                    {
                        timeStamp = line.Substring(5).Trim();
                    }
                    else if (line.StartsWith("Prompt:"))
                    {
                        promptText = line.Substring(7).Trim();
                    }
                    else if (line == "Entry:")
                    {
                        readingEntryText = true;
                    }
                }

                entryText = string.Join(Environment.NewLine, entryLines);

                if (!string.IsNullOrEmpty(dateString) && !string.IsNullOrEmpty(timeStamp))
                {
                    Entry entry = new Entry
                    {
                        dateString = dateString,
                        timeStamp = timeStamp,
                        promptText = promptText,
                        entryText = entryText
                    };
                    _entries.Add(entry);
                }
            }

            Console.WriteLine($"Loaded {_entries.Count} entries from '{fileName}'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading journal: {ex.Message}");
        }
    }

    public Dictionary<string, List<string>> ToGroupedDict()
    {
        /**
         * ToGroupedDict - this function organizes the entries to
         * dictionary format to improve the readability.
         * datStamp is the key and the timeStamp, prompt,
         * and entry are the value
         * Return: nothing
        */
        Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>();

        foreach (Entry entry in _entries)
        {
            string key = entry.dateString;
            string value = $"{entry.timeStamp} - Prompt: {entry.promptText}\n{entry.entryText}.";

            if (!dict.ContainsKey(key)) // checks if date already exist
            {
                // if yes just add to its content
                dict[key] = new List<string>();
            }

            dict[key].Add(value); //create new dict with date as key and every others as value
        }

        return dict;
    }

}