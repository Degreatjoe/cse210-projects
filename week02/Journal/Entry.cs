using System;
using System.Collections.Generic;
/*
This is a class file that contains the
entry class for my journal program
*/

public class Entry
{
    /**
     * Entry - this class takes care of the entry of the user
    */
    public string _dateString = DateTime.Now.ToShortDateString();
    public string _timeStamp = DateTime.Now.ToShortTimeString();
    public string _promptText;
    public string _entryText;

    public void Display()
    {
        /**
         * Display - displays a single entry object
         * Return: nothing
        */
        Console.WriteLine($"{_dateString}:");
        Console.WriteLine($"{_timeStamp} - {_promptText}\n{_entryText}");
    }
}