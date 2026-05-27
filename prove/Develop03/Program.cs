using System;
using System.Collections.Concurrent;
/*
(Special thanks to the LDS Documentation Project! They host the entire LDS
scriptural canon in various data formats. Their CSV has been used for this
project. Visit https://scriptures.nephi.org/ to see their work).

Hello! This is Parker Donaldson's Scripture memory aid program. It is designed
to help the user in memorizing a scripture by displaying to them progressively
further obscured text of a verse. It does this in the following manner:

1.  Provide the user with a menu they can navigate through to choose the book
    from which they want to memorize their scripture. This menu (should be)
    fully functional, allowing the user to return to previous menus or quit the
    program.

2.  Prompt the user for a chapter, and the verses they want to memorize. The
    program allows them to type in their query in the format familiar to members
    of the churhc, i.e. 3:7; 3:16; 42:17-20; etc.

3.  Fetch the specified verses from the LDS Documentation Project CSV file
    included within the program.

4.  Display the verses to the user along with the scripture reference at the top
    and a menu showing the available options.

5.  Options include: (ENTER) -> hides 3 (or more) words at random across each of
    the 3 verses. "0" -> Clear the console and return to the main menu. "1" ->
    restore one blank word to visibility at random.

6.  After a scripture has been memorized (totally hidden) the user can press the
    ENTER key once more to return to the main menu, from which they may quit out
    of the program, or select a new book and memorize a different scripture.

Things learned and from where:
https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/strings/
- How to use raw string literals for multiline strings (see Menu class).
https://learn.microsoft.com/en-us/dotnet/csharp/how-to/parse-strings-using-split
- How to use the .Split() method.
https://learn.microsoft.com/en-us/dotnet/api/system.string.contains?view=netframework-4.8.1
- How to use the .Contains() method to parse a verse string. (see Reference class).
https://gemini.google.com/app
- I used AI to help with ideas for how to handle the CSV file given there are so
  many commas within the values themselves, however ALL THE CODE IN THIS PROJECT
  WAS WRITTEN BY MYSELF. Never have I had AI write any of the code for me.
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