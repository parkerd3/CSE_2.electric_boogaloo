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
  the same time. (A)
https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/documentation-comments
- How to write and format XML comments for methods, attributes, and
  classes.
https://learn.microsoft.com/en-us/dotnet/api/system.datetime.toshortdatestring?view=netframework-4.8.1
- How to grab the current date as a string. (B)
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
    bool CONTINUE = true;
    Prompt Prompt = new Prompt() {_file = "Prompts.txt"}; // *A
    Prompt.LoadPrompts();

    bool journalLoaded = false;
    bool hasTitle = false;
    Journal journal = new Journal();
    
    /*
    There are a couple scattered situations where we need to check if
    the journal has a title, and if not, assign one. Hence this function
    gives us a convenient way to grab a title from the User in any such
    situations.
    */
    void GetTitle()
    {
      Console.WriteLine("Enter a title for your journal:");
      journal._title = Console.ReadLine();
      hasTitle = true;
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
      string selection = Console.ReadLine();

      // New Entry
      if (selection == "1")
      {
        Entry entry = new()
        {
          _prompt = Prompt.Generate_pbd(),
          _date = DateTime.Now.ToShortDateString() // *B
        };

        Console.WriteLine(entry._prompt);
        entry._response = Console.ReadLine();
        journal.AddEntry(entry);
      }
      // Add Prompt.
      else if (selection == "2")
      {
        Console.WriteLine(
          "Type a prompt you want to be added to the pool " + 
          "of random prompts:"
        );
        string addition = Console.ReadLine();
        Prompt.AddPrompt(addition);
        Console.WriteLine("Prompt added.");
      }
      // Display Journal Entries
      else if (selection == "3")
      {
        if (!hasTitle){ GetTitle(); }
        Console.WriteLine(journal);
      }
      // Load Journal
      else if (selection == "4")
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
        journal._file = Console.ReadLine();

        journal.Load();
        journalLoaded = true;
        Console.WriteLine($"Successfully loaded \"{journal._file}\"");
        hasTitle = true;
      }
      // Save and Save As
      else if (selection == "5" | selection == "6")
      { 
        /*
        In either case, if the user selects "Save" or "Save As" we need
        to check if they've already loaded a previous journal. If so,
        then the "Save" option will simply write the changes to the same
        text file the journal was read from, otherwise the "Save" option
        will default to the exact same behavior as "Save As" hence these
        less than ideally convoluted conditions.
        */
        if (selection == "5" & journalLoaded)
        {
          Console.WriteLine("Saving...");
          journal.Save();
          Console.WriteLine("Save complete!");
        }
        else
        {
          if (!hasTitle){ GetTitle(); }
          else
          {
            /*
            If there's a "Save As" option, there should be a way to
            change the title.
            */
            Console.WriteLine($"The current title is {journal._title}"+
            "\nWould you like to rename your journal?\n1. Yes\n2. No"
            );
            if (Console.ReadLine() == "1"){ GetTitle(); }
          }
          Console.WriteLine(
          "Enter the file name (include \".txt\"):"
          );

          journal._file = Console.ReadLine();
          Console.WriteLine("Saving...");
          journal.Save();
          Console.WriteLine("Save complete!");
        }
      }
      // Quit
      else if (selection == "7")
      {
        Console.WriteLine("Exiting Journal...");
        CONTINUE = false;
      }
      // The user may fat-finger a non-option. Best to let them know.
      else
      {
        Console.WriteLine("Invalid entry; please type "+
        "a number from the list.");
      }
    } while(CONTINUE);
  }
}