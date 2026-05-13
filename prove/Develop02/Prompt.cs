public class Prompt_pbd
{
    // Attributes
    public static List<string> _prompts_pbd = new List<string>();

    // Behaviors
    public static void LoadPrompts_pbd(string file_name_pbd)
    {
        _prompts_pbd.Clear();
        string[] prompt_array_pbd = File.ReadAllLines(file_name_pbd);
        foreach (string line_pbd in prompt_array_pbd)
        {
            _prompts_pbd.Add(line_pbd);
        }
    }
    public static string Generate_pbd()
    {

        return "";
    }
    public static void AddPrompt_pbd(string new_prompt_pbd, string file_name_pbd)
    {
        using (StreamWriter file_pbd = new StreamWriter(file_name_pbd))
        {
            file_pbd.WriteLine(new_prompt_pbd);
            // Prompts that were supposed to be added, but I need to debug the program:
            // In what ways were you better today than you were yesterday?
            // In what way do you want to be better tomorrow?
            // Have you done any good in the world today?
            // Do you feel like you're missing something out of life? What is it that you think you need?
            // What kind of gratitude do you have for today?
        }
    }
}