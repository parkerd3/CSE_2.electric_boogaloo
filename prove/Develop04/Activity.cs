using System.Diagnostics;
using System.Security.Principal;

public class Activity
{
  // Attributes
  private string _activityName;
  private string _description;
  private string _durationMenu;
  private List<string> _durationStrings;
  private List<int> _durationValues_MiliSeconds;
  private string _duration;
  // This is the only thing needed by the various Middle() functions.
  protected int _durationValue;

  // Methods
  protected Activity(
    string activityName,
    string description,
    string menu,
    List<string> durations,
    List<int> values
  )
  {
    _activityName = activityName;
    _description = description;
    _durationMenu = menu;
    _durationStrings = durations;
    _durationValues_MiliSeconds = values;
  }

  protected void Begin()
  {
    Console.WriteLine($"""
    Welcome. You have chosen the {_activityName}.

    {_description}

    Choose the duration of this activity:
    {_durationMenu}
    """);

    int choice = int.Parse(Console.ReadLine()) - 1;
    _duration = _durationStrings[choice];
    _durationValue = _durationValues_MiliSeconds[choice];
  }

  protected void End()
  {
    Support.Clear();
    Console.WriteLine(
    $"""
    Well done!

    You have completed the {_duration} {_activityName}.
    """
    );
    
  }
}