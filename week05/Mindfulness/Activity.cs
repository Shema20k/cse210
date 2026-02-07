using System;
using System.Threading;

abstract class Activity
{
    private string _name;
    private string _description;
    protected int _duration;

    protected Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public void Run()
    {
        StartMessage();
        PerformActivity();
        EndMessage();
    }

    protected abstract void PerformActivity();

    private void StartMessage()
    {
        Console.Clear();
        Console.WriteLine(_name);
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();
        Console.Write("Enter duration in seconds: ");
        _duration = int.Parse(Console.ReadLine());

        Console.WriteLine("Prepare to begin...");
        Pause(3);
    }

    private void EndMessage()
    {
        Console.WriteLine();
        Console.WriteLine("Well done!");
        Pause(2);
        Console.WriteLine($"You completed {_name} for {_duration} seconds.");
        Pause(3);
    }

    protected void Pause(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }

    protected void Spinner(int seconds)
    {
        char[] spinner = { '|', '/', '-', '\\' };
        int index = 0;
        DateTime end = DateTime.Now.AddSeconds(seconds);

        while (DateTime.Now < end)
        {
            Console.Write(spinner[index++ % spinner.Length]);
            Thread.Sleep(200);
            Console.Write("\b");
        }
    }
}
