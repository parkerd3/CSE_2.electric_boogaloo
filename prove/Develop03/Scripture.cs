public class Scripture
{
  private Reference reference;
  private Passage word;

  public Scripture(string bookTitle, string chpVerses)
  {
    reference = new Reference(bookTitle, chpVerses);
    word = new Passage(reference);
  }

}