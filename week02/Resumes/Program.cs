using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();

        job1._company = "microsoft";
        job1._jobTitle = "Software Developer";
        job1._startYear = 2001;
        job1._endYear = 2005;
        job1.Display();

        Job job2 = new Job();
        job2._company = "aerosky";
        job2._jobTitle = "Manager";
        job2._startYear = 2019;
        job2._endYear = 2022;
        job2.Display();

        Resume myResume = new Resume();
        myResume._name = "Great Joseph";
        myResume._myJobs.Add(job1);
        myResume._myJobs.Add(job2);

        myResume.Display();
    }
}