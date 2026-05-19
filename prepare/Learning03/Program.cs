using System;

class Program
{
  static void Main(string[] args)
  {
    Console.WriteLine("Hello Fraction World!");

    List<Fraction> constructions = [];
    constructions.Add(new Fraction());
    constructions.Add(new Fraction(5));
    constructions.Add(new Fraction(3, 7));

    // Check that each constructor worked correctly.
    foreach (Fraction frac in constructions)
    {
      Console.WriteLine(frac.GetRationalForm());
    }
    Console.WriteLine("");

    // Check get/set top/bottom
    Fraction dummyFrac = new();
    dummyFrac.SetBottom(36);
    dummyFrac.SetTop(2);
    Console.WriteLine(dummyFrac.GetBottom());
    Console.WriteLine(dummyFrac.GetTop());
    Console.WriteLine("");

    // Check decimal representation
    foreach (Fraction frac in constructions)
    {
      Console.WriteLine(frac.GetDecimalForm());
    }
    Console.WriteLine("");

    Fraction duck = new();
    Random rng = new();
    for (int i = 0; i < 30; i++)
    {
      duck.SetTop(rng.Next(100));
      duck.SetBottom(rng.Next(1, 20));
      Console.WriteLine($"Fraction {i+1}: {duck.GetRationalForm()} ({duck.GetDecimalForm()})");
    }
  }
}