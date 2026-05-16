/// <summary>
/// Class dedicated to storing and manipulating data on the full-volume
/// level. Includes methods for saving/loading journals to/from a text
/// file, and for formatting the data to be displayed in the console.
/// Includes attributes for title, file name, and a list of the entries. 
/// </summary>
public class JournalPD
{
  public string _titlePD;
  public string _filePD;
  public List<EntryPD> _entriesPD = new List<EntryPD>();
  
  // Behaviors

  /// <summary>
  /// Read <c>_filePD</c> and populate the <c>_titlePD</c> and 
  /// <c>_entriesPD</c> attributes.
  /// </summary>
  public void LoadPD()
  {
    string[] linesPD = File.ReadAllLines(_filePD);
    _titlePD = linesPD[0];
    for (int iPD = 1; iPD < linesPD.Length; iPD++)
    {
      EntryPD entry_iPD = new EntryPD();
      entry_iPD.ReadPD(linesPD[iPD]);
      _entriesPD.Add(entry_iPD);
    }
  }
  /// <summary>
  /// Write <c>_titlePD</c> and all <c>_entriesPD</c> to <c>_filePD</c>.
  /// </summary>
  public void SavePD()
  {
    using (StreamWriter writerPD = new StreamWriter(_filePD))
    {
      writerPD.WriteLine(_titlePD);
      foreach (EntryPD entryPD in _entriesPD)
      {
        writerPD.WriteLine(entryPD.WritePD());
      }
    }
  }
  
  /// <summary>
  /// Append <c>newEntryPD</c> to <c>_entriesPD</c>.
  /// </summary>
  public void AddEntryPD(EntryPD newEntryPD)
  {
    _entriesPD.Add(newEntryPD);
  }
  
  public override string ToString()
  {
    string hRulePD = new string('=', 50);
    string hDashPD = new string('-', 50);

    // Title block:
    // Shows the title of the journal and the number of entries.
    string titleBlockPD = // Use '―' for title block instead of '-'
    $"{hRulePD}\n{_titlePD},\n{_entriesPD.Count} Entries\n{hRulePD}\n"
    ;

    // Building the block of entries:
    string entriesPD = "";
    int nPD = 1;
    foreach (EntryPD entryPD in _entriesPD)
    {
      entriesPD += $"{nPD}] "+entryPD.ToString();
      entriesPD += $"\n{hDashPD}\n";
      nPD++;
    }

    string displayPD = titleBlockPD + entriesPD;
    return displayPD;
  }
}