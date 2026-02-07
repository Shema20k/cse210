using System;
using System.Collections.Generic;

class ReflectionActivity : Activity
{
    private List<string> _prompts = new()
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something selfless."
    };

    private List<string> _questions = new()
    {
        "Why was this experience meaningful to you?",
        "How did you feel afterward?",
        "What did you learn about yourself?",
        "How can this help you in the future?"
    };

    public ReflectionActivity()
        : base(
            "Reflection Activity",
            "This activity helps you reflect on strength and resilience."
        )
    {
    }

    protected override void PerformActivity()
    {
        Random rand = new();

        Console.WriteLine();
        Console.WriteLine(_prompts[rand.Next(_prompts.Count)]);
        Pause(3);

        DateTime end = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < end)
        {
            Console.WriteLine();
            Console.WriteLine(_questions[rand.Next(_questions.Count)]);
            Spinner(5);
        }
    }
}
