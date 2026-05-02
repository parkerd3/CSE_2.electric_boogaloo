using System;

class Program
{
    static void Main(string[] args)
    {
        // The Guess my number game:
        // 1. Ask user for a guess, determine if the user needs to
        //    guess higher or lower next time, or tell them if they
        //    successfully guessed it
        // 2. Add a loop that keeps loopiing as long as the guess does
        //    not match the magic number. Have the user keep playing
        //    until they get it right.
        // 3. Have the computer generate the magic number randomly from
        //    1-100. Play the game and make sure it works.
        //
        // Stretch Goals:
        // 1. Keep track of how many guesses the user has made and
        //    inform them of it at the end of the game.
        // 2. After the game is over, ask the user if they want to play
        //    again. Then, loop back and play the whole game again and
        //    continue this loop as long as they keep saying <"yes">.
        Random random = new Random();
        int magic = random.Next(1, 101);

        Console.WriteLine("Guess the magic number!");
        string input = Console.ReadLine();
        int guess = int.Parse(input);

        while (guess != magic)
        {
            if (guess < magic)
            {
                Console.Write("Too low! Try again: ");
                input = Console.ReadLine();
                guess = int.Parse(input);
            }
            else if (guess > magic)
            {
                Console.Write("Too high! Try again: ");
                input = Console.ReadLine();
                guess = int.Parse(input);
            }
        }
        Console.Write("That's absolutely correct! Well done :)");
    }
}