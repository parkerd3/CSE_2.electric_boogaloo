using System;
using System.Collections.Concurrent;
/*


Things learned and from where:
https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/strings/
- How to use raw string literals for multiline strings (see Menu class).
https://learn.microsoft.com/en-us/dotnet/csharp/how-to/parse-strings-using-split
- How to use the .Split() method
https://learn.microsoft.com/en-us/dotnet/api/system.string.contains?view=netframework-4.8.1
- How to use the .Contains() method to parse a verse string. (see Reference class).
*/
class Program
{
  static int GetUserInputInteger(string Prompt)
  {
    int returnValue = 0;
    bool flag = true;
    while (flag)
    {
      try
      {
        Console.WriteLine(Prompt);
        string userInputStr = Console.ReadLine();
        returnValue = int.Parse(userInputStr);
        flag = false;
      } catch (Exception e) {
        Console.WriteLine($"An error occurred: {e}\nPlease type an integer");
      }
    }
    return returnValue;
  }

  static string GetUserInputString(string Prompt)
  {
    string returnValue = "";
    bool flag = true;
    while (flag)
    {
      try
      {
        Console.WriteLine(Prompt);
        returnValue = Console.ReadLine();
        if (string.IsNullOrEmpty(returnValue)==true)
        {
          throw new Exception();
        }
        flag = false;
      } catch (Exception e) {
        Console.WriteLine($"An error occurred: {e}");
      }
    }
    return returnValue;
  }
  static string GetBook()
  {
    int mainPick;
    int volumePick;
    int subPick;
    string userBook;
    
    MainMenu:
    mainPick = GetUserInputInteger(Menu.MainMenu());
    Console.Clear();
    if (mainPick == 0) { return "quit"; }
    if (mainPick == 5) {
      // D&C
      userBook = "Doctrine and Covenants";
      goto Return;
    }

    VolumeMenu:
    volumePick = GetUserInputInteger(Menu.VolumeMenu(mainPick));
    Console.Clear();
    if (volumePick == 0) { goto MainMenu; }
    if (mainPick == 4) {
      // Pearl of Great Price
      subPick = volumePick;
      goto BookStringRetreival;
    }
    
    subPick = GetUserInputInteger(Menu.SubsectionMenu(volumePick));
    Console.Clear();
    if (subPick == 0) { goto VolumeMenu; }

    BookStringRetreival:
    userBook = Menu.BookTitle(subPick);

    Return:
    Menu.Reset();
    return userBook;
  }
  static string GetVerses(string userBook)
  {
    string chpVerses = GetUserInputString($"Selected book: {userBook}\n"+
      "Please enter the desired chapter and verses.\n"+
      "Use a colon after the chapter number,\n"+
      "a hyphen to indicate a range of verses,\n"+
      "and commas to indicate disjoint verses.\n"+
      "(Examples: \"3:7,8-12\", \"15:10-12,17,20\", \"2:6-12,18,21-23\")"
    );
    Console.Clear();
    return chpVerses;
  }


  // MAIN
  static void Main(string[] args)
  {
    Console.WriteLine(
      "Welcome to Scripture Memorizer!\n"+
      "Please press ENTER to continue:"
    );
    Console.ReadLine();
    Console.Clear();
    
    while (true)
    {
      // MENU NAVIGATION
      string userBook = GetBook();
      if (userBook == "quit") { break; }

      string chpVerses = GetVerses(userBook);

      // SCRIPTURE DISPLAY
      Scripture scripture = new Scripture(userBook, chpVerses);

      bool done = false;
      while (!done)
      {
        Console.WriteLine("| (ENTER) Hide more words | 0: Quit to Main Menu | 1: Restore one blank word |\n");
        Console.WriteLine(scripture);

        string userAction = Console.ReadLine();
        if (userAction == "0")
        {
          Console.Clear();
          break;
        }
        else if (userAction == "1")
        {
          scripture.Restore();
        }
        else
        {
          if (scripture.AllHidden())
          {
            break;
          }
          scripture.Obscure();
        }
        Console.Clear();
      }
    }
  }
}