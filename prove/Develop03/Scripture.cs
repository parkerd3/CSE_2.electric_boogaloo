using System.Collections.Immutable;
using System.ComponentModel.DataAnnotations;

public class Scripture
{
  private Reference reference;
  private List<Passage> passages = new();

  public Scripture(string bookTitle, string chpVerses)
  {
    reference = new Reference(bookTitle, chpVerses);
    foreach (int i in reference.Verses())
    {
      int chp = reference.Chapter();
      passages.Add( new Passage(bookTitle, chp, i) );
    }
  }

  public override string ToString()
  {
    string display = reference + "\n";

    foreach (Passage passage in passages)
    {
      display += passage + "\n";
    }

    return display + "\n";
  }

  public void Obscure()
  {
    // Will obscure at least 3 words per call, but more for a lot of verses.
    int hideCount = int.Min(3, passages.Count()/2);
    Random random = new();

    int i = 0;
    while (i < hideCount)
    {
      int shoot = random.Next(passages.Count());
      if (!passages[shoot].IsAllHidden())
      {
        passages[shoot].Obscure();
        i ++;
      }
      else if (AllHidden()){ break; }
    }
  }

  public void Restore()
  {
    bool dekita = false;
    Random random = new();

    while (!dekita)
    {
      int shoot = random.Next(passages.Count());
      if (!passages[shoot].IsAllVisible())
      {
        passages[shoot].Restore();
        dekita = true;
      }
      else if (AllVisible()){ break; }
    }
  }

  public bool AllHidden()
  {
    foreach (Passage passage in passages)
    {
      if (!passage.IsAllHidden())
      {
        return false;
      }
    }
    return true;
  }
  private bool AllVisible()
  {
    foreach (Passage passage in passages)
    {
      if (!passage.IsAllVisible())
      {
        return false;
      }
    }
    return true;
  }

}
