using System.Dynamic;

public class MathAssignment : Assignment
{
  private string _textbookSection;
  private string _problemSet;
  
  public MathAssignment(
    string name,
    string topic,
    string section,
    string problems
  ) : base(name, topic)
  {
    _textbookSection = section;
    _problemSet = problems;
  }

  public string GetProblemSet()
  {
    return _problemSet;
  }

  public new string Summary()
  {
    return base.Summary() + $"\nSection {_textbookSection}, Problems {_problemSet}.";
  }
}