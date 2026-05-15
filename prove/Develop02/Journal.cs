public class Journal
{
    public string _title;
    public string _file;
    public List<Entry> _entries = new List<Entry>();
    
    // Behaviors
    public void Load()
    {
        
    }

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }
    
    public override string ToString()
    {   
        // Gives me an easy way to adjust the length of the horizontal
        // section lines.
        int x = 20;

        // Title block:
        // Shows the title of the journal and the number of entries.
        string titleBlock = // Use '―' for title block instead of '-'
        $"{x*'―'}\n{_title},\n{_entries.Count} Entries\n{x*'―'}\n"
        ;

        // Building the block of entries:
        string entries = "";
        foreach (Entry entry in _entries)
        {
            entries += entry.ToString();
            entries += $"\n{x*'-'}\n";
        }

        string display = titleBlock + entries;
        return display;
    }
}