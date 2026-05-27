using System.Collections.Immutable;
using System.ComponentModel.DataAnnotations;

public class ScripturePD
{
  private ReferencePD referencePD;
  private List<PassagePD> passagesPD = new();

  public ScripturePD(string bookTitlePD, string chpVersesPD)
  {
    referencePD = new ReferencePD(bookTitlePD, chpVersesPD);
    foreach (int iPD in referencePD.VersesPD())
    {
      int chpPD = referencePD.ChapterPD();
      passagesPD.Add( new PassagePD(bookTitlePD, chpPD, iPD) );
    }
  }

  public override string ToString()
  {
    string displayPD = referencePD + "\n\n";

    foreach (PassagePD passagePD in passagesPD)
    {
      displayPD += passagePD + "\n";
    }

    return displayPD + "\n";
  }

  public void ObscurePD()
  {
    // Will obscure at least 3 words per call, but more for a lot of verses.
    int x = 3;
    int y = passagesPD.Count()/2;

    int hideCountPD = int.Max(x, y);
    Random randomPD = new();

    int iPD = 0;
    while (iPD < hideCountPD)
    {
      int shootPD = randomPD.Next(passagesPD.Count());
      if (!passagesPD[shootPD].IsAllHiddenPD())
      {
        passagesPD[shootPD].ObscurePD();
        iPD ++;
      }
      else if (AllHiddenPD()){ break; }
    }
  }

  public void RestorePD()
  {
    bool dekitaPD = false;
    Random randomPD = new();

    while (!dekitaPD)
    {
      int shootPD = randomPD.Next(passagesPD.Count());
      if (!passagesPD[shootPD].IsAllVisiblePD())
      {
        passagesPD[shootPD].RestorePD();
        dekitaPD = true;
      }
      else if (AllVisiblePD()){ break; }
    }
  }

  public bool AllHiddenPD()
  {
    foreach (PassagePD passagePD in passagesPD)
    {
      if (!passagePD.IsAllHiddenPD())
      {
        return false;
      }
    }
    return true;
  }
  private bool AllVisiblePD()
  {
    foreach (PassagePD passagePD in passagesPD)
    {
      if (!passagePD.IsAllVisiblePD())
      {
        return false;
      }
    }
    return true;
  }

}
