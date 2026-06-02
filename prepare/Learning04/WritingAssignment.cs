public class WritingAssingment : Assignment
{
  private string _title;

  public WritingAssingment(
    string name,
    string topic,
    string title
  ) : base(name, topic)
  {
    _title = title;
  }

  public new string Summary()
  {
    return base.Summary() + $"\nTitle: \"{_title}\" by {base.GetName()}";
  }
}