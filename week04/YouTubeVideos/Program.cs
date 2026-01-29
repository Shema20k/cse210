using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Video video1 = new Video("C# Basics", "Shema Darcy", 300);
        Video video2 = new Video("Programming OOP", "Alice Uwimana", 450);
        Video video3 = new Video("YouTube API Overview", "John Doe", 600);

        video1.AddComment(new Comment("Tom", "Great tutorial!"));
        video1.AddComment(new Comment("Sara", "Very helpful, thanks."));
        video1.AddComment(new Comment("Mike", "Can you explain arrays more?"));

        video2.AddComment(new Comment("Jane", "I love OOP concepts!"));
        video2.AddComment(new Comment("Paul", "Nice examples."));
        video2.AddComment(new Comment("Emma", "Could you do one on inheritance?"));

        video3.AddComment(new Comment("Alice", "This was exactly what I needed."));
        video3.AddComment(new Comment("Bob", "Thanks for sharing!"));
        video3.AddComment(new Comment("Charlie", "Very clear explanation."));

        List<Video> videos = new List<Video> { video1, video2, video3 };

        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.GetTitle()}");
            Console.WriteLine($"Author: {video.GetAuthor()}");
            Console.WriteLine($"Length (seconds): {video.GetLength()}");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");
            Console.WriteLine("Comments:");
            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"- {comment.GetCommenterName()}: {comment.GetText()}");
            }
            Console.WriteLine("------------------------------------");
        }
    }
}
