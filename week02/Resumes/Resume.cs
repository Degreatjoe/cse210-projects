using System;

public class Resume
{
    public string _name;
    public List<Job> _myJobs = new List<Job>();

    public void Display()
    {
        Console.WriteLine($"Name: {_name}");
        Console.WriteLine("Jobs:");
        foreach (Job b in _myJobs)
        {
            b.Display();
        }
    }
}