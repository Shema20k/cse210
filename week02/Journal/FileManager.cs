namespace Journal;

using System;
using System.Collections.Generic;
using System.IO;

class FileManager
{
    public void SaveToFile(string filename, List<Entry> entries)
    {
        using (StreamWriter sw = new StreamWriter(filename))
        {
            foreach (Entry entry in entries)
            {
                sw.WriteLine(entry.ToString());
            }
        }
    }

    public List<Entry> LoadFromFile(string filename)
    {
        List<Entry> entries = new List<Entry>();

        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            return entries;
        }

        foreach (string line in File.ReadAllLines(filename))
        {
            entries.Add(Entry.FromString(line));
        }

        return entries;
    }
}
