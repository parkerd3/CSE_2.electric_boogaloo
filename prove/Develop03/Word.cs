public class Word
{
  private string _scriptureCSVFileName = "lds-scriptures.csv";
  private string _scriptureText;
  private string _obscuredText;

  public Word(Reference reference)
  {
    string Book = reference.Book();
    List<int> verses = reference.Verses();
  }
}