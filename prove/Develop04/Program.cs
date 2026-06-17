using System;
/*
Parker Donaldson
Professor William Clements
CSE 210; Programming with Classes

This is my submission for the mindfulness program. I didn't have as much time to
work on this as the others, so it will understandably be noticably less polished
than the last couple projects.

Since this project is late as it is, I also didn't take the time to tag all of
my variables. I hope that by this point I've demonstrated sufficient passion and
skill to inspire confidence in the originality of my own work.

// Features

This program includes the required subclasses and their corresponding
functionalities.

To exceed the requirements, I made a custom animation for the breathing exercise
and also changed the programs to display a menu to the user with preset times
instead of typing in the seconds themselves (some activities, particularly the
breathing activity are better suited for longer periods of time, and are only
effective if done for such time. This is why I didn't allow the user to choose
the length of the activity themselves. If I were to do it differently I would
have also included the option to enter a custom time, however I think for the
most part the user doesn't want to have to think about the right amount of time
themselves and would rather just do the activity).
*/
class Program
{
  static void Main(string[] args)
  {
    while (true)
    {
      int activity = Support.GetUserInt(
        """
        Welcome to the mindfulness helper. Please choose an
        activity from the options below:

        1. Breathing Exercise (2 - 8 minutes)
        2. Listing Activity (0.5 - 3 minutes)
        3. Reflection Activity (1 - 5 minutes)
        4. Quit
        """
      );

      if (activity == 1)
      {
        Breathing breath = new Breathing();
        breath.Run();
      }
      else if (activity == 2)
      {
        Listing listing = new Listing();
        listing.Run();
      }
      else if (activity == 3)
      {
        Reflection reflect = new Reflection();
        reflect.Run();
      }
      else if (activity == 4)
      {
        Support.Clear();
        break;
      }
      else
      {
        Console.WriteLine("Oops, it seems like you didn't choose one of the options. Try again please.");
        Thread.Sleep(2000);
      }
      Support.Clear();
    }
  }
}