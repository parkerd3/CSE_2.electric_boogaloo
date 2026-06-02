public class Assignment
{
  private string _studentName;
  private string _topic;

  public string Summary()
  {
    return $"Name: {_studentName}\nTopic: {_topic}";
  }
  public string GetName()
  {
    return _studentName;
  }

  public Assignment(string name, string topic)
  {
    _studentName = name;
    _topic = topic;
  }
}