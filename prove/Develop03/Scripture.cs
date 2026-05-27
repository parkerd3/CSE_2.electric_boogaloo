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

    return display;
  }

  public void Obscure()
  {
    int hideCount = int.Min(3, passages.Count()/2);
    Random random = new();
    for (int i = 0; i < hideCount; i++)
    {
      int idx = random.Next(hideCount);
      // TODO: Make it so that this loops until every word is hidden, or until
      // Passage.Obscure() has been successfully called hideCount times.
    }
  }

  public void Restore()
  {
    
  }
}