public class Scripture
{
  private Reference reference;
  private Word word;

  public Scripture(string bookTitle, string chpVerses)
  {
    reference = new Reference(bookTitle, chpVerses);
    word = new Word(reference);
  }

}