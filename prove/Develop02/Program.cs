using System;
using System.ComponentModel;
/*
You should know that I wrote all of this code myself, however I put in
all the PD tags _after_ finishing the project as having them attached to
everything makes the code _horribly_ illegible, and actively working on
it becomes impossible. Forgive me if I missed a variable here or there.

Things Learned and from where:
https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/style-rules/ide0017
- How to initialize an instance of a class and set its attributes at
  the same time. (See line 38)
https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/documentation-comments
- How to write and format XML comments for methods, attributes, and
  classes.
https://learn.microsoft.com/en-us/dotnet/api/system.datetime.toshortdatestring?view=netframework-4.8.1
- How to grab the current date as a string. (See line 82)
https://vocal.media/writers/string-repetition-in-c-with-the-new-string-constructor
- How to concisely create a string consisting of one character n times.
https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/style-rules/ide0090
- Learned to implement new() (As opposed to e.g. `new Entry()`)
https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/iteration-statements
- How to use a for loop.
https://stackoverflow.com/questions/2245442/split-a-string-by-another-string-in-c-sharp/56284791#56284791
- How to split strings via substrings instead of single characters.
*/
class Program
{
  static void Main(string[] args)
  {
    /*
    The first handful of lines are just for setup. We want to build the
    Prompt class, and set a few boolean flags; one for the main loop,
    and a couple others to help in the case of saving/displaying a
    journal.
    */
    bool continuePD = true;
    PromptPD PromptPD = new PromptPD() {_filePD = "Prompts.txt"}; // *A
    PromptPD.LoadPromptsPD();

    bool journalLoadedPD = false;
    bool hasTitlePD = false;
    JournalPD journalPD = new JournalPD();
    
    /*
    There are a couple scattered situations where we need to check if
    the journal has a title, and if not, assign one. Hence this function
    gives us a convenient way to grab a title from the User in any such
    situations.
    */
    void GetTitlePD()
    {
      Console.WriteLine("Enter a title for your journal:");
      journalPD._titlePD = Console.ReadLine();
      hasTitlePD = true;
    }

    do
    {
      /*
      The program will return to this menu after every action until the 
      user decides to exit the program.
      */
      Console.WriteLine(
        "Please select one of the following:\n" +
        "1. New Entry\n"+
        "2. Add New Prompt\n"+
        "3. Display Journal Entries\n"+
        "4. Load Journal\n"+
        "5. Save\n"+
        "6. Save As\n"+
        "7. Quit"
      );
      string selectionPD = Console.ReadLine();

      // New Entry
      if (selectionPD == "1")
      {
        EntryPD entryPD = new()
        {
          _promptPD = PromptPD.GeneratePD(),
          _datePD = DateTime.Now.ToShortDateString() // *B
        };

        Console.WriteLine(entryPD._promptPD);
        entryPD._responsePD = Console.ReadLine();
        journalPD.AddEntryPD(entryPD);
      }
      // Add Prompt.
      else if (selectionPD == "2")
      {
        Console.WriteLine(
          "Type a prompt you want to be added to the pool " + 
          "of random prompts:"
        );
        string additionPD = Console.ReadLine();
        PromptPD.AddPromptPD(additionPD);
        Console.WriteLine("Prompt added.");
      }
      // Display Journal Entries
      else if (selectionPD == "3")
      {
        if (!hasTitlePD){ GetTitlePD(); }
        Console.WriteLine(journalPD);
      }
      // Load Journal
      else if (selectionPD == "4")
      {
        /*
        It is courteous to warn the user about unsaved data, and give
        them the option to return to the main menu.
        */
        Console.WriteLine(
          "Are you sure? /!\\ All unsaved data will be lost /!\\\n"+
          "1. Proceed\n2. Return to Main Menu"
        );
        if (Console.ReadLine() == "2"){ continue; }
        
        Console.WriteLine("Enter the name of the file to load:");
        journalPD._filePD = Console.ReadLine();

        journalPD.LoadPD();
        journalLoadedPD = true;
        Console.WriteLine($"Successfully loaded \"{journalPD._filePD}\"");
        hasTitlePD = true;
      }
      // Save and Save As
      else if (selectionPD == "5" || selectionPD == "6")
      { 
        /*
        In either case, if the user selects "Save" or "Save As" we need
        to check if they've already loaded a previous journal. If so,
        then the "Save" option will simply write the changes to the same
        text file the journal was read from, otherwise the "Save" option
        will default to the exact same behavior as "Save As" hence these
        less than ideally convoluted conditions.
        */
        if (selectionPD == "5" && journalLoadedPD)
        {
          Console.WriteLine("Saving...");
          journalPD.SavePD();
          Console.WriteLine("Save complete!");
        }
        else
        {
          if (!hasTitlePD){ GetTitlePD(); }
          else
          {
            /*
            If there's a "Save As" option, there should be a way to
            change the title.
            */
            Console.WriteLine($"The current title is {journalPD._titlePD}"+
            "\nWould you like to rename your journal?"+
            "\n1. Yes"+
            "\n2. No"
            );
            if (Console.ReadLine() == "1"){ GetTitlePD(); }
          }
          Console.WriteLine(
          "Enter the file name (include \".txt\"):"
          );

          journalPD._filePD = Console.ReadLine();
          Console.WriteLine("Saving...");
          journalPD.SavePD();
          Console.WriteLine("Save complete!");
        }
      }
      // Quit
      else if (selectionPD == "7")
      {
        Console.WriteLine("Exiting Journal...");
        continuePD = false;
      }
      // The user may fat-finger a non-option. Best to let them know.
      else
      {
        Console.WriteLine(
          "Invalid entry; please type a number from the list."
        );
      }
    } while(continuePD);
  }
}