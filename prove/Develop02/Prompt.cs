using Microsoft.VisualBasic;

/// <summary>
/// Handles the organization of the prompts given to the user. 
/// </summary>
public class PromptPD
{
  // Attributes

  /// <summary>
  /// Prompts available for display.
  /// </summary>
  public List<string> _pListPD = new List<string>();

  /// <summary>
  /// File where prompts are read/written.
  /// </summary>
  public string _filePD;

  // Behaviors

  Random rngPD = new Random();
  /// <summary>
  /// Randomly pick and return a prompt from the <c>_pListPD</c>.
  /// </summary>
  public string GeneratePD()
  {
    int idxPD = rngPD.Next(_pListPD.Count);
    return _pListPD[idxPD];
  }

  /// <summary>
  /// Read in prompts from <c>_filePD</c> and store them in <c>_pListPD</c>.
  /// </summary>
  public void LoadPromptsPD()
  {
    _pListPD.Clear();
    string[] prompt_arrayPD = File.ReadAllLines(_filePD);
    foreach (string linePD in prompt_arrayPD)
    {
      _pListPD.Add(linePD);
    }
  }
  /// <summary>
  /// Save <c>new_promptPD</c> to the prompt <c>_filePD</c>, then load the
  /// updated pool into <c>_pListPD</c>.
  /// </summary>
  public void AddPromptPD(string new_promptPD)
  {
    using (StreamWriter WriterPD = new StreamWriter(_filePD))
    {
      foreach (string promptPD in _pListPD)
      {
        WriterPD.WriteLine(promptPD);
      }
      WriterPD.WriteLine(new_promptPD);
    }
    LoadPromptsPD();
  }

  /// <summary>
  /// Return a message containing each prompt and the name of the file
  /// they are saved to.
  /// </summary>
  public override string ToString()
  {
    string prompt_listPD = "";
    foreach (string xPD in _pListPD)
    {
      prompt_listPD += $"{xPD}\n";
    }
    string messagePD = $"File: \"{_filePD}\"\n" +
    $"Prompts: \n{prompt_listPD}";
    return messagePD;
  }
}