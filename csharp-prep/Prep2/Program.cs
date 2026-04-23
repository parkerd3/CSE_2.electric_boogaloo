using System;

class Program
{
    static void Main(string[] args)
    {
        string pbd_grade = "an F";
        string pbd_pm = "";
        bool pbd_pass = false;
        
        Console.Write("Please enter your class percentage: ");
        string pbd_user_input = Console.ReadLine();
        float pbd_perc = float.Parse(pbd_user_input);
        float pbd_remainder = pbd_perc % 10;

        if (pbd_remainder < 3)
        {
            pbd_pm = "-";
        }
        else if (pbd_remainder >= 7)
        {
            pbd_pm = "+";
        }
        
        // I'm putting the correct article with each grade so that the
        // displayed sentence reads better.
        if (pbd_perc >= 90)
        {
            // Convert A+ to A
            if (pbd_pm == "+")
            {
                pbd_pm = "";
            }
            pbd_grade = "an A";
            pbd_pass = true;
        }
        else if (pbd_perc >= 80)
        {
            pbd_grade = "a B";
            pbd_pass = true;
        }
        else if (pbd_perc >= 70)
        {
            pbd_grade = "a C";
            pbd_pass = true;
        }
        else if (pbd_perc >= 60)
        {
            pbd_grade = "a D";
        }
        else
        {
            pbd_pm = "";
        }
        // This is more efficient than to write four different
        // concatenations for each if statement.
        pbd_grade += pbd_pm;

        Console.WriteLine($"Your final grade is {pbd_grade},");
        if (pbd_pass)
        {
            Console.WriteLine(
                "so congratulations! You've passed the course."
            );
        }
        else
        {
            Console.WriteLine(
                "which is not a passing grade. Better luck next time."
            );
        }   
    }
}
