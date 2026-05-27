using System.Data;

public class Reference
{
  // Attributes
  private string _book;
  private int _chapter;
  private List<int> _verses;
  private string _displayString;

  // Behaviors
  public List<int> Verses() { return _verses; }
  public string Book() { return _book; }

  public override string ToString() { return _displayString; }

  // Constructor
  public Reference(string book, string chpVerses)
  { 
    _displayString = $"{book} {chpVerses}";
    _book = book;
    _chapter = int.Parse(chpVerses.Split(":")[0]);

    string[] verseStrings = chpVerses.Split(":")[1].Split(",");
    foreach (string vsStr in verseStrings)
    {
      if ( vsStr.Contains('-') )
      {
        string[] startEnd = vsStr.Split("-");

        int start = int.Parse(startEnd[0]);
        int end = int.Parse(startEnd[1]);

        for (int i = start; i < end + 1; i++) { _verses.Add(i); }
      }
      else { _verses.Add(int.Parse(vsStr)); }
    }
  }
}