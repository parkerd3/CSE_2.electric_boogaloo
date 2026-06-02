using System;

class Program
{
  static void Main(string[] args)
  {
    MathAssignment s1 = new MathAssignment(
      "Roberto Rodriguez",
      "Fractions",
      "7.3",
      "8-19"
    );

    WritingAssingment s2 = new WritingAssingment(
      "Mary Waters",
      "European History",
      "The Causes of World War II"
    );

    Console.WriteLine(s1.Summary());
    Console.WriteLine(s2.Summary());
  }
}