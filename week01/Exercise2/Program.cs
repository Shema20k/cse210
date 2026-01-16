using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter your grade percentage: ");
        if (!int.TryParse(Console.ReadLine(), out int grade) || grade < 0 || grade > 100)
        {
            Console.WriteLine("Please enter a valid grade between 0 and 100.");
            return;
        }

        string letter;
        string sign = "";

        if (grade >= 90)
        {
            letter = "A";
            if (grade == 100) sign = "";
            else if (grade >= 97) sign = "+";
            else if (grade <= 92) sign = "-";
        }
        else if (grade >= 80)
        {
            letter = "B";
            if (grade >= 87) sign = "+";
            else if (grade <= 82) sign = "-";
        }
        else if (grade >= 70)
        {
            letter = "C";
            if (grade >= 77) sign = "+";
            else if (grade <= 72) sign = "-";
        }
        else if (grade >= 60)
        {
            letter = "D";
            if (grade >= 67) sign = "+";
            else if (grade <= 62) sign = "-";
        }
        else
        {
            letter = "F";
        }

        Console.WriteLine($"Your grade is: {letter}{sign}");

        if (grade >= 70)
            Console.WriteLine("Congratulations, you passed the course!");
        else
            Console.WriteLine("Don't give up — try again next time.");
    }
}
