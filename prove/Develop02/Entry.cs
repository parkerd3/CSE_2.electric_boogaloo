using System.Diagnostics;
/// <summary>
/// Class dedicated to storing and manipulating data related to journal
/// entries including date written, prompt shown, and response given.
/// </summary>
public class Entry
{
  // Attributes

  public string _prompt;
  public string _response;
  public string _date;
  // Delimiter used for writing entries to a file.
  private string s = "~|~";

  // Behaviors

  /// <summary>
  /// Return a string formatted to display the date, prompt, and
  /// response of an entry.
  /// </summary>
  public override string ToString()
  {
    return _date + $"\n(Prompt: {_prompt})\n" +
    _response;
  }

  /// <summary>
  /// Read a string and populate the <c>_date, _prompt, _response</c>
  /// attributes.
  /// </summary>
  public void Read(string jargon)
  {
    string[] atties = jargon.Split(new string[] {s}, StringSplitOptions.None);
    _date = atties[0];
    _prompt = atties[1];
    _response = atties[2];
  }

  /// <summary>
  /// Return the entry as a string formatted for writing to file.
  /// </summary>
  public string Write()
  {
    return _date+s+_prompt+s+_response;
  }
}