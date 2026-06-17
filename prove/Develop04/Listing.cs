using System.Diagnostics.CodeAnalysis;

public class Listing : Activity
{
  // Attributes
  private List<string> _prompts = [    
    "Who are the people that you appreciate?",
    "What are personal strengths of yours?",
    "Who are people that you have helped this week?",
    "When have you felt the Holy Ghost this month?",
    "Who are some of your personal heros?",
    "Describe every time you noticed a duck watching you this week.",
    "List all the people you know whose name starts with a G.",
    "List every sport you've ever played.",
    "List every sport you've never tried even once before.",
    "List your favorite beverages.",
    "Pick a decade.\nName as many music artists as you can from that decade.",
    "List all the things you've ever baked.",
    "Name as many musical instruments you can think of.",
    "Name as many Christmas Songs as you can think of.",
  ];

  private string _thisPrompt;
  private List<string> _userItems;

  // Behaviors
  public Listing() : base(
    "Listing Exercise",
    
    """
    Listing things out gives your mind something to focus
    on. It can help distract from persistant negative
    thoughts by forcing the brain to work at recalling
    relevant things to memory.

    This exercise will deliver a category/prompt. Write
    down as many things as you can relevant to the prompt
    until the activity is over.
    """,

    """

    1. 30 seconds
    2.  1 minute
    3.  3 minutes
    """,
    ["30 second", "1 minute", "3 minute"],
    [30000, 60000, 180000]
  )
  {
    _userItems = [];
  }

  public void Run()
  {
    base.Begin();
    Middle(_durationValue);
    base.End();
    Console.WriteLine(
    $"""

    Here are the results:
    (Prompt)
    {_thisPrompt}

    (Response(s))
    """
    );
    foreach (string item in _userItems)
    {
      Console.WriteLine(item);
    }
    base.ToMenu();
  }

  private void Middle(int milliseconds)
  {
    DateTime endTime = DateTime.Now.AddMilliseconds(milliseconds);
    Support.Clear();

    // Time-based rng instead of random class.
    string _thisPrompt = _prompts[DateTime.Now.Millisecond % _prompts.Count];

    Console.WriteLine(
      "(When time runs out, the activity will end at your final input.)"
    );
    Console.WriteLine(_thisPrompt);
    while (DateTime.Now < endTime)
    {
      _userItems.Add(Console.ReadLine());
    }
  }
}