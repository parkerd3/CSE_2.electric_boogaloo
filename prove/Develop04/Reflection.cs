

using System.Text;

public class Reflection : Activity
{
  private List<string> _primers = [
    "Think of a time when you stood up for someone else.",
    "Think of a time when you did something really difficult.",
    "Think of a time when you helped someone in need.",
    "Think of a time when you did something truly selfless.",
  ];

  private List<string> _prompts = [
    "Why was this experience meaningful to you?",
    "Have you ever done anything like this before?",
    "How did you get started?",
    "How did you feel when it was complete?",
    "What made this time different than other times when you were not as successful?",
    "What is your favorite thing about this experience?",
    "What could you learn from this experience that applies to other situations?",
    "What did you learn about yourself through this experience?",
    "How can you keep this experience in mind in the future?",
  ];

  public Reflection() : base(
    "Reflection Activity",

    """
    This simple activity asks you to meditate for a
    short time on one topic. You may write things down
    if it helps you.

    Try to focus on the prompt for the duration of the
    activity. 
    """,

    """
    1. 1 minute
    2. 2 minutes
    3. 5 minutes
    """,

    ["1 minute", "2 minute", "3 minute"],
    [60000, 120000, 300000]
  )
  {
    
  }

  public void Run()
  {
    base.Begin();
    Middle(_durationValue);
    base.End();
    base.ToMenu();
  }

  // Private (helper) methods

  private void Middle(int milliseconds)
  {
    DateTime startTime = DateTime.Now;
    DateTime endTime = startTime.AddMilliseconds(milliseconds);
    Support.Clear();

    Console.WriteLine(_primers[DateTime.Now.Millisecond%_primers.Count]);
    string [] primerThrob = GetThrobber(DateTime.Now.Millisecond);

    while (DateTime.Now < startTime.AddSeconds(5))
    {
      Throb(primerThrob, int.Parse(primerThrob[0]));
    }

    
    Console.WriteLine(_prompts[(DateTime.Now.Millisecond + 3)%_prompts.Count]);
    string [] promptThrob = GetThrobber(DateTime.Now.Millisecond);

    while (DateTime.Now < endTime)
    {
      Throb(promptThrob, int.Parse(promptThrob[0]));
    }
  }

  private void Throb(string[] throbber, int charLength)
  {
    string backspaces = new string('\b', charLength);
    string spaces = new string(' ', charLength);
    for (int i = 1; i < throbber.Length; i++)
    {
      Console.Write(throbber[i]);
      Thread.Sleep(300);
      Console.Write(backspaces + spaces + backspaces);
    }
  }

  private string[] GetThrobber(int rng)
  {
    // ▀ ▄ ▌ ▐
    // ╤ ╦ ╩ ╧ ═
    // ┌ ┐ └ ┘ ─ │
    string[][] frames = [
      [
        "1",
        "▄","▌","▀","▐",
      ],
      [
        "12",
        "═╧═╩═╧═╤═╦═╤",
        "╤═╧═╩═╧═╤═╦═",
        "═╤═╧═╩═╧═╤═╦",
        "╦═╤═╧═╩═╧═╤═",
        "═╦═╤═╧═╩═╧═╤",
        "╤═╦═╤═╧═╩═╧═",
        "═╤═╦═╤═╧═╩═╧",
        "╧═╤═╦═╤═╧═╩═",
        "═╧═╤═╦═╤═╧═╩",
        "╩═╧═╤═╦═╤═╧═",
        "═╩═╧═╤═╦═╤═╧",
        "╧═╩═╧═╤═╦═╤═",        
      ],
      [
        "1",
        "─","└","│","┘","─","┐","│","┌",
      ],
      [
        "3",
        " . "," o "," O ","( )",":':",". ."
      ],
      [
        "1",
        "q","d","b","p"
      ]
    ];
    
    return frames[rng% frames.Length];
  }
}