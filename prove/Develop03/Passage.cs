using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using Microsoft.VisualBasic;
/*
This was easily the most complicated class that I had to design, which probably
means there's a way I could have broken it up into smaller classes. But this was
my best initial attempt.

These were the considerations I had going into this design:

1.  I wanted to hide at least 3 random words at a time, and to restore 1 random
    word at a time to visibility.

2.  I wanted to guarantee that a NEW word was hidden every single time I called
    the Obscure() method. Since I want to blank out at least 3 words, I wanted
    to make sure the program never blanked out only 2 because it selected one
    that was already blank

3.  Likewise, I wanted to guarantee that 

*/
public class PassagePD
{
  // Handles access to the csv file to find the text of each verse.
  // Contains both the unaltered original passage, and the version with hidden
  // words.
  // Contains a list of indices for both the hidden and visible words in
  // the obscured package to aid the Obscure and Restore methods.
  private string _scriptureCSVFileNamePD = "lds-scriptures.csv";
  private string _verseNumberPD;

  private readonly List<WordPD> _scriptureTextPD = [];
  private List<WordPD> _obscuredTextPD = [];

  private List<int> _visibleWordIndicesPD = [];
  private List<int> _hiddenWordIndicesPD = [];

  public PassagePD(string bookPD, int chapterPD, int versePD)
  {
    _verseNumberPD = versePD.ToString();
    List<string> dataPD = FindRowPD(bookPD, chapterPD, versePD);
    string raw_textPD = dataPD[16];
    string[] wordsPD = raw_textPD.Split(" ");

    foreach (string wordPD in wordsPD)
    {
      _scriptureTextPD.Add(new WordPD(wordPD));
      _obscuredTextPD.Add(new WordPD(wordPD));
    }

    for (int iPD = 0; iPD < _obscuredTextPD.Count(); iPD++)
    {
      _visibleWordIndicesPD.Add(iPD);
    }
  }

  public override string ToString()
  {
    string displayPD = "";
    int lineWidthPD;
    string linePD = $"{_verseNumberPD}.";

    // Construct paragraphs less than 40 characters wide for readability.
    foreach (WordPD wordPD in _obscuredTextPD)
    {
      string textPD = wordPD.ToString();
      lineWidthPD = linePD.Length;
      if (lineWidthPD + textPD.Length >= 40)
      {
        displayPD += linePD + "\n";
        linePD = "";
        linePD += textPD;
      }
      else
      {
        linePD += " " + textPD;
      }
    }
    // Clean up final line that is less than 40 characters
    displayPD += linePD + "\n";
    
    return displayPD;
  }

  // Hidden/Visible indices are kept track of to make sure that every call to
  // these methods will always hide a new word/restore a hidden word.
  public void ObscurePD()
  {
    Random randomPD = new();
    int indexIndexPD = randomPD.Next(_visibleWordIndicesPD.Count());
    int wordIndexPD = _visibleWordIndicesPD[indexIndexPD];
    
    _visibleWordIndicesPD.RemoveAt(indexIndexPD);
    _hiddenWordIndicesPD.Add(wordIndexPD);

    _obscuredTextPD[wordIndexPD].ObscurePD();

  }

  public void RestorePD()
  {
    Random randomPD = new();
    int indexIndexPD = randomPD.Next(_hiddenWordIndicesPD.Count());
    int wordIndexPD = _hiddenWordIndicesPD[indexIndexPD];

    _hiddenWordIndicesPD.RemoveAt(indexIndexPD);
    _visibleWordIndicesPD.Add(wordIndexPD);

    string originalWordPD = _scriptureTextPD[wordIndexPD].ToString();
    _obscuredTextPD[wordIndexPD] = new WordPD(originalWordPD);
  }

  // Flags that Scripture Class will use to make sure it doesn't ask a passage
  // to obscure/restore any words when there are none to do so.
  public bool IsAllVisiblePD()
  {
    return _visibleWordIndicesPD.Count() == _scriptureTextPD.Count();
  }
  public bool IsAllHiddenPD()
  {
    return _hiddenWordIndicesPD.Count() == _scriptureTextPD.Count();
  }

  private List<string> FindRowPD(string targetBookPD, int targetChapterPD, int targetVersePD)
  {
    bool FoundPD = false;
    using (StreamReader readerPD = new StreamReader(_scriptureCSVFileNamePD))
    {
      List<string> columnsPD = new List<string>();
      while (!FoundPD)
      {
        string linePD = readerPD.ReadLine();
        
        columnsPD.Clear();
        bool inQuotesPD = false;
        string valuePD = "";

        // Custom logic to deal with the fact that there are commas in my CSV.
        foreach (char cPD in linePD)
        {
          if (cPD == '"')
          {
            inQuotesPD = !inQuotesPD;
            // value += c;
            continue;
          }

          if (inQuotesPD)
          {
            valuePD += cPD;
            continue;
          }
        
          if (cPD == ',')
          {
            columnsPD.Add(valuePD);
            valuePD = "";
            continue;
          }
          else { valuePD += cPD; }
        }

        // Now I can ACTUALLY check if this is the correct row.
        if ( 
          targetBookPD == columnsPD[5] && 
          targetChapterPD == int.Parse(columnsPD[14]) &&
          targetVersePD == int.Parse(columnsPD[15])
        )
        {
          FoundPD = true;
        }
      }
      return columnsPD;
    }
  }
}