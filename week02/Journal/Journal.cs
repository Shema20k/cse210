namespace Journal;

using System;
using System.Collections.Generic;

class Journal
{
    private List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }

    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("No entries yet.\n");
            return;
        }

        foreach (Entry entry in _entries)
        {
            entry.Display();
            Console.WriteLine(new string('-', 40));
        }
    }

    public List<Entry> GetEntries()
    {
        return _entries;
    }

    public void SetEntries(List<Entry> entries)
    {
        _entries = entries;
    }
}
