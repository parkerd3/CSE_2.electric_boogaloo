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
  static string GetBookPD()
  {
    int mainPickPD;
    int volumePickPD;
    int subPickPD;
    string userBookPD;
    
    MainMenuPD:
    mainPickPD = GetUserInputInteger(MenuPD.MainMenuPD());
    Console.Clear();
    if (mainPickPD == 0) { return "quit"; }
    if (mainPickPD == 5) {
      // D&C
      userBookPD = "Doctrine and Covenants";
      goto ReturnPD;
    }

    VolumeMenuPD:
    volumePickPD = GetUserInputInteger(MenuPD.VolumeMenuPD(mainPickPD));
    Console.Clear();
    if (volumePickPD == 0) { goto MainMenuPD; }
    if (mainPickPD == 4) {
      // Pearl of Great Price
      subPickPD = volumePickPD;
      goto BookStringRetreivalPD;
    }
    
    subPickPD = GetUserInputInteger(MenuPD.SubsectionMenuPD(volumePickPD));
    Console.Clear();
    if (subPickPD == 0) { goto VolumeMenuPD; }

    BookStringRetreivalPD:
    userBookPD = MenuPD.BookTitlePD(subPickPD);

    ReturnPD:
    MenuPD.ResetPD();
    return userBookPD;
  }
  static string GetVersesPD(string userBookPD)
  {
    string chpVersesPD = GetUserInputString($"Selected book: {userBookPD}\n"+
      "Please enter the desired chapter and verses.\n"+
      "Use a colon after the chapter number,\n"+
      "a hyphen to indicate a range of verses,\n"+
      "and commas to indicate disjoint verses.\n"+
      "(Examples: \"3:7,8-12\", \"15:10-12,17,20\", \"2:6-12,18,21-23\")"
    );
    Console.Clear();
    return chpVersesPD;
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
      string userBookPD = GetBookPD();
      if (userBookPD == "quit") { break; }

      string chpVersesPD = GetVersesPD(userBookPD);

      // SCRIPTURE DISPLAY
      ScripturePD scripturePD = new ScripturePD(userBookPD, chpVersesPD);

      bool donePD = false;
      while (!donePD)
      {
        Console.WriteLine("| (ENTER) Hide more words | 0: Quit to Main Menu | 1: Restore one blank word |\n");
        Console.WriteLine(scripturePD);

        string userActionPD = Console.ReadLine();
        if (userActionPD == "0")
        {
          Console.Clear();
          break;
        }
        else if (userActionPD == "1")
        {
          scripturePD.RestorePD();
        }
        else
        {
          if (scripturePD.AllHiddenPD())
          {
            Console.Clear();
            break;
          }
          scripturePD.ObscurePD();
        }
        Console.Clear();
      }
    }
  }
}