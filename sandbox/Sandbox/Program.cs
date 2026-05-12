using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        string fileName = "Bad_joke_Dad_joke.txt";

        using (StreamWriter outputFile = new StreamWriter(fileName))
        {
            outputFile.WriteLine("Why did the chicken cross the road? \n");
            outputFile.WriteLine("To get to the other side");
        }
    }
}