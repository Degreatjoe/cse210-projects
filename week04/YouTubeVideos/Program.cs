using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create a list to store videos
        List<Video> videos = new List<Video>();

        // ----- Video 1 -----
        Video video1 = new Video("The Art of Coding", "Alice Johnson", 320);
        video1.AddComment(new Comment("John", "Great explanation, very clear!"));
        video1.AddComment(new Comment("Sarah", "Loved the visuals."));
        video1.AddComment(new Comment("Mike", "Please make a part two!"));
        videos.Add(video1);

        // ----- Video 2 -----
        Video video2 = new Video("History of Space Travel", "Dr. Neil", 540);
        video2.AddComment(new Comment("Anna", "Super informative!"));
        video2.AddComment(new Comment("Jake", "That launch footage was incredible."));
        video2.AddComment(new Comment("Lily", "I learned so much. Thanks!"));
        videos.Add(video2);

        // ----- Video 3 -----
        Video video3 = new Video("Mastering Chess", "Grandmaster Lee", 275);
        video3.AddComment(new Comment("Tom", "This really helped my opening strategy."));
        video3.AddComment(new Comment("Nina", "Love your teaching style."));
        video3.AddComment(new Comment("Sam", "More endgame tips please!"));
        videos.Add(video3);

        // ----- Video 4 -----
        Video video4 = new Video("Beginner's Guide to Cooking", "Chef Maria", 410);
        video4.AddComment(new Comment("Ella", "Delicious recipes!"));
        video4.AddComment(new Comment("Raj", "I finally made a decent pasta thanks to this."));
        video4.AddComment(new Comment("Derek", "Simple and easy to follow."));
        videos.Add(video4);

        // Display all videos and their comments
        foreach (Video video in videos)
        {
            Console.WriteLine(video.GetDisplayString());
        }
    }
}
