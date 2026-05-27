using System.Collections.Immutable;
using System.ComponentModel.DataAnnotations;
/*
I wanted to hide at least 3 words at a time across the entire range of verses.
However, since each verse is stored as its own Passage object, the best way to
accomplish this is to define an Obscure function which only hides one word at a
time, and just call it three times across random verses.

I'm a novice in probability, so it's highly unlikely that my approach actually
give each word an equal chance of being hidden, but it works well enough.
*/
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
      /*
      Originally the passage construction was much more elegant, in that it
      would take in a single reference object at construction. But since I
      changed the Passage class to only represent a single verse at a time, I
      had to change this so that the scripture class would get the list of
      verses from Reference first, then create a Passage for each verse.
      */
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
    int P = 3;
    int D = passagesPD.Count()/2;

    int hideCountPD = int.Max(P, D);
    Random randomPD = new();

    /*
    At first I had a way to keep track of whether a verse was already totally
    hidden, in which case the program wouldn't even add that verse to the pool
    of verses to draw from. But then I realized, computers are fast! So now I
    have it just roll the dice until it eventually calls a passage that can be
    randomized.
    */
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

  // This flag tells Program.cs whether to return the user to the Main Menu
  // after pressing ENTER.
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
