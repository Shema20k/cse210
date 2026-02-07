using System;
using System.Threading;

class BreathingActivity : Activity
{
    public BreathingActivity()
        : base(
            "Breathing Activity",
            "This activity will help you relax by guiding your breathing."
        )
    {
    }

    protected override void PerformActivity()
    {
        int elapsed = 0;

        while (elapsed < _duration)
        {
            Console.Write("Breathe in... ");
            Pause(4);
            elapsed += 4;

            Console.WriteLine();

            Console.Write("Breathe out... ");
            Pause(6);
            elapsed += 6;

            Console.WriteLine();
        }
    }
}
