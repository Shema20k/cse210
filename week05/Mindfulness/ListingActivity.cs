using System;
using System.Collections.Generic;

class ListingActivity : Activity
{
    private List<string> _prompts = new()
    {
        "Who are people you appreciate?",
        "What are your personal strengths?",
        "Who have you helped recently?",
        "What blessings do you recognize today?"
    };

    public ListingActivity()
        : base(
            "Listing Activity",
            "This activity helps you list positive things in your life."
        )
    {
    }

    protected override void PerformActivity()
    {
        Random rand = new();
        List<string> items = new();

        Console.WriteLine();
        Console.WriteLine(_prompts[rand.Next(_prompts.Count)]);
        Pause(3);

        DateTime end = DateTime.Now.AddSeconds(_duration);

        Console.WriteLine("Start listing:");

        while (DateTime.Now < end)
        {
            items.Add(Console.ReadLine());
        }

        Console.WriteLine();
        Console.WriteLine($"You listed {items.Count} items.");
    }
}
