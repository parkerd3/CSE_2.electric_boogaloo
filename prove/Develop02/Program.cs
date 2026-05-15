using System;
/*


Things Learned and from where:
https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/style-rules/ide0017
-   How to initialize an instance of a class and set its attributes at
    the same time. (A)
https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/documentation-comments
-   How to write and format XML comments for methods, attributes, and
    classes.
*/
class Program
{
    static void Main(string[] args)
    {
        
        Console.WriteLine("Hello Journal World!");
        bool CONTINUE = true;
        
        Prompt Prompt = new Prompt() {_file = "Prompts.txt"}; // A
        Prompt.LoadPrompts();
        do
        {
            // Prompt user with menu:
            Console.WriteLine(
                "Please select one of the following:\n" +
                "1. New Entry\n"+
                "2. Add New Prompt\n"+
                "3. Read Journal\n"+
                "4. Load Journal\n"+
                "5. Save\n"+
                "6. Save As\n"+
                "7. Quit"
            );
            string selection_pbd = Console.ReadLine();

            // New Entry
            if (selection_pbd == "1")
            {
                Entry entry_pbd = new Entry();
                entry_pbd._prompt = Prompt.Generate_pbd();
            }

            // Add Prompt. The various prompts are stored in a file. The
            // user may add one of their own, and it 
            else if (selection_pbd == "2")
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

            // Quit
            else if (selection_pbd == "7")
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
        Console.WriteLine(Prompt);
    }
}