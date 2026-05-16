using System.Diagnostics;
/// <summary>
/// Class dedicated to storing and manipulating data related to journal
/// entries including date written, prompt shown, and response given.
/// </summary>
public class EntryPD
{
  // Attributes

  public string _promptPD;
  public string _responsePD;
  public string _datePD;
  // Delimiter used for writing entries to a file.
  private string sPD = "~|~";

  // Behaviors

  /// <summary>
  /// Return a string formatted to display the date, prompt, and
  /// response of an entry.
  /// </summary>
  public override string ToString()
  {
    return _datePD + $"\n(Prompt: {_promptPD})\n" +
    _responsePD;
  }

  /// <summary>
  /// Read a string and populate the <c>_datePD, _promptPD, _responsePD</c>
  /// attributes.
  /// </summary>
  public void ReadPD(string jargonPD)
  {
    string[] attiesPD = jargonPD.Split(new string[] {sPD}, StringSplitOptions.None);
    _datePD = attiesPD[0];
    _promptPD = attiesPD[1];
    _responsePD = attiesPD[2];
  }

  /// <summary>
  /// Return the entry as a string formatted for writing to file.
  /// </summary>
  public string WritePD()
  {
    return _datePD+sPD+_promptPD+sPD+_responsePD;
  }
}