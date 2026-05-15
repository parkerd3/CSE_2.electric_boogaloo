using System;
using System.ComponentModel;
/*
You should know that I wrote all of this code myself, however I put in
all the PD tags _after_ finishing the project as having them attached to
everything makes the code _horribly_ illegible, and actively working on
it becomes impossible. Forgive me if I missed a variable here or there.

Things Learned and from where:
https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/style-rules/ide0017
-   How to initialize an instance of a class and set its attributes at
    the same time. (A)
https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/documentation-comments
-   How to write and format XML comments for methods, attributes, and
    classes.
https://learn.microsoft.com/en-us/dotnet/api/system.datetime.toshortdatestring?view=netframework-4.8.1
-   How to grab the current date as a string. (B)
https://vocal.media/writers/string-repetition-in-c-with-the-new-string-constructor
-   How to concisely create a string consisting of one character n times.
*/
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Journal World!");

        // Set flag for program loop.
        bool CONTINUE = true;
        // Set up Prompt class
        Prompt Prompt = new Prompt() {_file = "Prompts.txt"}; // *A
        Prompt.LoadPrompts();
        // Set up Journal
        Journal journal = new Journal();

        do
        {
            // Prompt user with menu:
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
                Entry entry = new Entry()
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
                Prompt.LoadPrompts();
                Console.WriteLine("Prompt added.");
            }

            // Display Journal Entries
            else if (selection == "3")
            {
                Console.WriteLine(journal);
            }

            // Load Journal

            // Save

            // Save As

            // Quit
            else if (selection == "7")
            {
                Console.WriteLine("Exiting Journal...");
                CONTINUE = false;
            }
            else
            {
                Console.WriteLine("Invalid entry; please type "+
                "a number from the list.");
            }


        } while(CONTINUE);
        // Console.WriteLine(Prompt);
    }
}