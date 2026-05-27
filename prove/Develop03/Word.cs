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