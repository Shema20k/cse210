namespace Journal;

using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();
        FileManager fileManager = new FileManager();

        bool running = true;

        while (running)
        {
            Console.WriteLine("\nJournal Menu:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display journal");
            Console.WriteLine("3. Save journal to file");
            Console.WriteLine("4. Load journal from file");
            Console.WriteLine("5. Quit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    WriteNewEntry(journal, promptGenerator);
                    break;
                case "2":
                    journal.DisplayAll();
                    break;
                case "3":
                    SaveJournal(journal, fileManager);
                    break;
                case "4":
                    LoadJournal(journal, fileManager);
                    break;
                case "5":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid option. Try again.");
                    break;
            }
        }
    }

    static void WriteNewEntry(Journal journal, PromptGenerator promptGenerator)
    {
        string prompt = promptGenerator.GetRandomPrompt();
        Console.WriteLine(prompt);
        Console.Write("Your response: ");
        string response = Console.ReadLine();

        string date = DateTime.Now.ToString("yyyy-MM-dd");
        Entry entry = new Entry(date, prompt, response);
        journal.AddEntry(entry);

        Console.WriteLine("Entry saved!\n");
    }

    static void SaveJournal(Journal journal, FileManager fileManager)
    {
        Console.Write("Enter filename to save: ");
        string filename = Console.ReadLine();
        fileManager.SaveToFile(filename, journal.GetEntries());
        Console.WriteLine("Journal saved to file.\n");
    }

    static void LoadJournal(Journal journal, FileManager fileManager)
    {
        Console.Write("Enter filename to load: ");
        string filename = Console.ReadLine();
        List<Entry> entries = fileManager.LoadFromFile(filename);
        journal.SetEntries(entries);
        Console.WriteLine("Journal loaded from file.\n");
    }
}
