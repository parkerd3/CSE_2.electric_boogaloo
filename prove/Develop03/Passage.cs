using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using Microsoft.VisualBasic;

public class Passage
{
  // Handles access to the csv file to find the text of each verse.
  // Contains both the unaltered original passage, and the version with hidden
  // words.
  // Contains a list of indices for both the hidden and visible words in
  // the obscured package to aid the Obscure and Restore methods.
  private string _scriptureCSVFileName = "lds-scriptures.csv";
  private string _verseNumber;

  private readonly List<Word> _scriptureText = [];
  private List<Word> _obscuredText = [];

  private List<int> _visibleWordIndices = [];
  private List<int> _hiddenWordIndices = [];

  public Passage(string book, int chapter, int verse)
  {
    _verseNumber = verse.ToString();
    List<string> data = FindRow(book, chapter, verse);
    string raw_text = data[16];
    string[] words = raw_text.Split(" ");

    foreach (string word in words)
    {
      _scriptureText.Add(new Word(word));
    }
    _obscuredText = _scriptureText;

    for (int i = 0; i < _obscuredText.Count(); i++)
    {
      _visibleWordIndices.Add(i);
    }
  }

  public override string ToString()
  {
    string display = "";
    int lineWidth;
    string line = $"{_verseNumber}.";

    // Construct paragraphs less than 40 characters wide for readability.
    foreach (Word word in _obscuredText)
    {
      string text = word.ToString();
      lineWidth = line.Length;
      if (lineWidth + text.Length >= 40)
      {
        display += line + "\n";
        line = "";
        line += text;
      }
      else
      {
        line += " " + text;
      }
    }
    // Clean up final line that is less than 40 characters
    display += line + "\n";
    
    return display;
  }

  // Hidden/Visible indices are kept track of to make sure that every call to
  // these methods will always hide a new word/restore a hidden word.
  public void Obscure()
  {
    Random random = new();
    int indexIndex = random.Next(_visibleWordIndices.Count());
    int wordIndex = _visibleWordIndices[indexIndex];

    _visibleWordIndices.RemoveAt(indexIndex);
    _hiddenWordIndices.Add(wordIndex);

    _obscuredText[wordIndex].Obscure();

  }

  public void Restore()
  {
    Random random = new();
    int indexIndex = random.Next(_hiddenWordIndices.Count());
    int wordIndex = _hiddenWordIndices[indexIndex];

    _hiddenWordIndices.RemoveAt(indexIndex);
    _visibleWordIndices.Add(wordIndex);

    _obscuredText[wordIndex] = _scriptureText[wordIndex];

  }

  // Flags that Scripture Class will use to make sure it doesn't ask a passage
  // to obscure/restore any words when there are none to do so.
  public bool IsAllVisible()
  {
    return _visibleWordIndices.Count() == _scriptureText.Count();
  }
  public bool IsAllHidden()
  {
    return _hiddenWordIndices.Count() == _scriptureText.Count();
  }

  private List<string> FindRow(string targetBook, int targetChapter, int targetVerse)
  {
    bool Found = false;
    using (StreamReader reader = new StreamReader(_scriptureCSVFileName))
    {
      List<string> columns = new List<string>();
      while (!Found)
      {
        string line = reader.ReadLine();
        
        columns.Clear();
        bool inQuotes = false;
        string value = "";

        // Custom logic to deal with the fact that there are commas in my CSV.
        foreach (char c in line)
        {
          if (c == '"')
          {
            inQuotes = !inQuotes;
            // value += c;
            continue;
          }

          if (inQuotes)
          {
            value += c;
            continue;
          }
        
          if (c == ',')
          {
            columns.Add(value);
            value = "";
            continue;
          }
          else { value += c; }
        }

        // Now I can ACTUALLY check if this is the correct row.
        if ( 
          targetBook == columns[5] && 
          targetChapter == int.Parse(columns[14]) &&
          targetVerse == int.Parse(columns[15])
        )
        {
          Found = true;
        }
      }
      return columns;
    }
  }
}