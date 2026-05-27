using System.Data;
/*
The most useful thing this class does is parse a string like 3:7-16,19 into a
list of integers: 7,8,9,10,11,12,13,14,15,16,19. Other than that, it feels very
redundant, since the book title comes from the Menu class, and the display
string... is already formatted correctly because of how the user types it in.

It's really just here for easy access to the book, chapter, and verses.

It is unique in that basically all of its functionality is executed within the
constructor; all of the other methods just return attributes.
*/
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