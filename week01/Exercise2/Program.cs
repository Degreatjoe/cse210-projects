using System;
using System.ComponentModel;

class Program
{
    static void Main(string[] args)
    {
        char grade = 'F';
        int convertedGradePoint = 0;

        Console.Write("Pleas input Your grade point");
        Console.Write("if you do not input anything the program automatically assigns you 'F'.");
        string gradePoint = Console.ReadLine();
        if (gradePoint != "")
        {
            convertedGradePoint = int.Parse(gradePoint);
        }

        if (convertedGradePoint >= 90)
        {
            grade = 'A';
        }
        else if (convertedGradePoint >= 80)
        {
            grade = 'B';
        }
        else if (convertedGradePoint >= 70)
        {
            grade = 'C';
        }
        else if (convertedGradePoint >= 60)
        {
            grade = 'D';
        }
        else if (convertedGradePoint < 60)
        {
            grade = 'F';
        }

        Console.WriteLine($"Your grade is {grade}.");

        if (convertedGradePoint >= 70)
        {
            Console.WriteLine("Congratulations! You have done great.");
        }
        else
        {
            Console.WriteLine("You did not do so well this time, try again.");
        }

    }
}