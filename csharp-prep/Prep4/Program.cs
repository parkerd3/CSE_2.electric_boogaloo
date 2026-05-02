using System;
using System.ComponentModel.DataAnnotations;
using System.Net.Quic;
using System.Numerics;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello there friend,");
        Console.WriteLine("enter a list of numbers, type 0 when finished");
        
        List<int> numbers = new List<int>();
        int num = 0;
        do
        {
            Console.Write("Enter number: ");
            string input = Console.ReadLine();
            num = int.Parse(input);
            if (num != 0)
            {
                numbers.Add(num);
            }
        } while (num != 0);

        // Sum
        int total = 0;
        int max = 0;
        foreach (int number in numbers)
        {
            total += number;
            if (number >= max)
            {
                max = number;
            }
        }
        Console.Write($"The sum is: {total}");
        // Ave
        float average = 0;
        int qty = numbers.Count();
        average = total / qty;
        Console.Write($"The average value is: {average}");
        // Max
        Console.Write($"The maximum value is: {max}");
    }
}