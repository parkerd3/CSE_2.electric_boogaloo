using Microsoft.VisualBasic;

/// <summary>
/// Handles the organization of the prompts given to the user. 
/// </summary>
public class Prompt
{
  // Attributes

  /// <summary>
  /// Prompts available for display.
  /// </summary>
  public List<string> _pList = new List<string>();

  /// <summary>
  /// File where prompts are read/written.
  /// </summary>
  public string _file;

  // Behaviors

  Random rng = new Random();
  /// <summary>
  /// Randomly pick and return a prompt from the <c>_pList</c>.
  /// </summary>
  public string Generate_pbd()
  {
    int idx = rng.Next(_pList.Count);
    return _pList[idx];
  }

  /// <summary>
  /// Read in prompts from <c>_file</c> and store them in <c>_pList</c>.
  /// </summary>
  public void LoadPrompts()
  {
    _pList.Clear();
    string[] prompt_array = File.ReadAllLines(_file);
    foreach (string line in prompt_array)
    {
      _pList.Add(line);
    }
  }
  /// <summary>
  /// Save <c>new_prompt</c> to the prompt <c>_file</c>, then load the
  /// updated pool into <c>_pList</c>.
  /// </summary>
  public void AddPrompt(string new_prompt)
  {
    using (StreamWriter Writer = new StreamWriter(_file))
    {
      foreach (string prompt in _pList)
      {
        Writer.WriteLine(prompt);
      }
      Writer.WriteLine(new_prompt);
    }
    LoadPrompts();
  }

  /// <summary>
  /// Return a message containing each prompt and the name of the file
  /// they are saved to.
  /// </summary>
  public override string ToString()
  {
    string prompt_list = "";
    foreach (string x in _pList)
    {
      prompt_list += $"{x}\n";
    }
    string message = $"File: \"{_file}\"\n" +
    $"Prompts: \n{prompt_list}";
    return message;
  }
}