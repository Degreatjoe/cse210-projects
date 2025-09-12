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
    public string dateString = DateTime.Now.ToShortDateString();
    public string timeStamp = DateTime.Now.ToShortTimeString();
    public string promptText;
    public string entryText;

    public void Display()
    {
        /**
         * Display - displays a single entry object
         * Return: nothing
        */
        Console.WriteLine($"{dateString}:");
        Console.WriteLine($"{timeStamp} - {promptText}\n{entryText}");
    }
}