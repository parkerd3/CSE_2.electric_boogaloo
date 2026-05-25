using System;
using System.Collections.Concurrent;
/*


Things learned and from where:
https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/strings/
- How to use raw string literals for multiline strings (see Menu class).
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
  static void Main(string[] args)
  {
    bool quitFlag = true;

    Console.WriteLine(
      "Welcome to Scripture Memorizer!\n"+
      "Please press ENTER to continue:"
    );
    Console.ReadLine();
    Console.Clear();
    do
    {
      int mainPick;
      int volumePick;
      int subPick;
      string userBook;

      MainMenu:
      mainPick = GetUserInputInteger(Menu.MainMenu());
      Console.Clear();
      if (mainPick == 0) { break; }
      if (mainPick == 5) {
        // D&C
        userBook = "Doctrine and Covenants";
        goto ReferenceQuery;
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

      ReferenceQuery:
      string chpVerses = GetUserInputString($"Selected book: {userBook}\n"+
        "Please enter the desired chapter and verses.\n"+
        "Use a colon after the chapter number,\n"+
        "a hyphen to indicate a range of verses,\n"+
        "and commas to indicate disjoint verses.\n"+
        "(Examples: \"3:7,8-12\", \"15:10-12,17,20\", \"2:6-12,18,21-23\")"
      );

      
    } while (quitFlag);
  }
}