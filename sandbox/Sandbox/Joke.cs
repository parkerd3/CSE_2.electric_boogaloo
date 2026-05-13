public class Joke
{
    public string _file_name;
    public string _joke;

    
    
    // Functions.

    public void Write(string joke)
    {
        Console.WriteLine("Enter your joke:");
        joke = Console.ReadLine();
        Console.WriteLine("Enter filename to save to:");
        _file_name = Console.ReadLine();

        using (StreamWriter outputFile = new StreamWriter(_file_name))
        {
            outputFile.WriteLine("Why did the chicken turn the page?\n");
            outputFile.WriteLine("To get to the other side");
        }
    }
}
