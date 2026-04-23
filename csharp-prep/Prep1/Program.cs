using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your first name? ");
        string pbd_first = Console.ReadLine();

        Console.Write("What is your last name? ");
        string pbd_last = Console.ReadLine();

        Console.WriteLine("");
        string pbd_agent_name = 
            pbd_last + ", " + pbd_first + " " + pbd_last;
        Console.WriteLine($"Your name is {pbd_agent_name}.");
    }
}