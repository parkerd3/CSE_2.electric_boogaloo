/// <summary>
/// Class dedicated to storing and manipulating data on the full-volume
/// level. Includes methods for saving/loading journals to/from a text
/// file, and for formatting the data to be displayed in the console.
/// Includes attributes for title, file name, and a list of the entries. 
/// </summary>
public class Journal
{
  public string _title;
  public string _file;
  public List<Entry> _entries = new List<Entry>();
  
  // Behaviors

  /// <summary>
  /// Read <c>_file</c> and populate the <c>_title</c> and 
  /// <c>_entries</c> attributes.
  /// </summary>
  public void Load()
  {
    string[] lines = File.ReadAllLines(_file);
    _title = lines[0];
    for (int i = 1; i < lines.Length; i++)
    {
      Entry entry_i = new Entry();
      entry_i.Read(lines[i]);
      _entries.Add(entry_i);
    }
  }
  /// <summary>
  /// Write <c>_title</c> and all <c>_entries</c> to <c>_file</c>.
  /// </summary>
  public void Save()
  {
    using (StreamWriter writer = new StreamWriter(_file))
    {
      writer.WriteLine(_title);
      foreach (Entry entry in _entries)
      {
        writer.WriteLine(entry.Write());
      }
    }
  }
  
  /// <summary>
  /// Append <c>newEntry</c> to <c>_entries</c>.
  /// </summary>
  public void AddEntry(Entry newEntry)
  {
    _entries.Add(newEntry);
  }
  
  public override string ToString()
  {
    string hRule = new string('=', 50);
    string hDash = new string('-', 50);

    // Title block:
    // Shows the title of the journal and the number of entries.
    string titleBlock = // Use '―' for title block instead of '-'
    $"{hRule}\n{_title},\n{_entries.Count} Entries\n{hRule}\n"
    ;

    // Building the block of entries:
    string entries = "";
    int n = 1;
    foreach (Entry entry in _entries)
    {
      entries += $"{n}] "+entry.ToString();
      entries += $"\n{hDash}\n";
      n++;
    }

    string display = titleBlock + entries;
    return display;
  }
}