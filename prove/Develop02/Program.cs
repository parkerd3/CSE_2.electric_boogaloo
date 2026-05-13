using System;

class Program
{
    static void Main(string[] args)
    {
        
        Console.WriteLine("Hello Develop02 World!");
        bool CONTINUE_pbd = true;
        string prompt_file_pbd = "Prompts.txt";
        Prompt_pbd.LoadPrompts_pbd(prompt_file_pbd);
        Prompt_pbd P_pbd = new Prompt_pbd();

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
                entry_pbd._prompt = Prompt_pbd.Generate_pbd();
            }

            // Add Prompt. The various prompts are stored in a file. The
            // user may add one of their own, and it 
            else if (selection_pbd == "2")
            {
                Console.WriteLine("Type a prompt you want to be added "+
                "to the pool of random prompts:");
                string addition_pbd = Console.ReadLine();
                Prompt_pbd.AddPrompt_pbd(addition_pbd, prompt_file_pbd);
                Prompt_pbd.LoadPrompts_pbd(prompt_file_pbd);
                Console.WriteLine("Prompt added.");
            }

            // Quit
            else if (selection_pbd == "7")
            {
                Console.WriteLine("Exiting Journal...");
                CONTINUE_pbd = false;
            }
            else
            {
                Console.WriteLine("Invalid entry; please type "+
                "a number from the list.");
            }


        } while(CONTINUE_pbd);
    }
}