public class Word
{
  private string _text;

  public Word(string word)
  {
    _text = word;
  }
 
  public void Obscure()
  {
    int length = _text.Length;
    _text = new string('_', length);
  }

  public override string ToString()
  {
    return _text;
  }
}