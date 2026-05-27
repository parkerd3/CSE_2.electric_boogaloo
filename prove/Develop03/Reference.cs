using System.Data;

public class ReferencePD
{
  // Attributes
  private string _bookPD;
  private int _chapterPD;
  private List<int> _versesPD = new List<int>();
  private string _displayStringPD;

  // Behaviors
  public List<int> VersesPD()
  {
    return _versesPD;
  }

  public string BookPD()
  {

    return _bookPD;
  }

  public int ChapterPD()
  {
    return _chapterPD;
  }

  public override string ToString() { return _displayStringPD; }

  // Constructor
  public ReferencePD(string bookPD, string chpVersesPD)
  { 
    _displayStringPD = $"{bookPD} {chpVersesPD}";
    _bookPD = bookPD;
    _chapterPD = int.Parse(chpVersesPD.Split(":")[0]);

    string[] verseStringsPD = chpVersesPD.Split(":")[1].Split(",");
    foreach (string vsStrPD in verseStringsPD)
    {
      if ( vsStrPD.Contains('-') )
      {
        string[] startEndPD = vsStrPD.Split("-");

        int startPD = int.Parse(startEndPD[0]);
        int endPD = int.Parse(startEndPD[1]);

        for (int i = startPD; i < endPD + 1; i++) { _versesPD.Add(i); }
      }
      else { _versesPD.Add(int.Parse(vsStrPD)); }
    }
  }
}