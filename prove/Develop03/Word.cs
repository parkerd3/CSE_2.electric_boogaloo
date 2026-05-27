/*
What a lonely little class. As I say in the comments within Passage.cs, I think
the Restore method would be better suited for this class. But I will rewrite the
program and Word classes for this purpose later.
*/
public class WordPD
{
  private string _textPD;

  public WordPD(string wordPD)
  {
    _textPD = wordPD;
  }
 
  public void ObscurePD()
  {
    int lengthPD = _textPD.Length;
    _textPD = new string('_', lengthPD);
  }

  public override string ToString()
  {
    return _textPD;
  }
}