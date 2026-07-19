using System;
using System.Numerics;
/*

https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/nullable-value-types
- Learned how to use nullable data types, specifically `bool?` and learned the
  methods `HasValue` and `Value`. I used these to try and make some of my
  boolean attributes more efficient; only being calculated when called upon.
https://www.geeksforgeeks.org/system-design/factory-method-for-designing-pattern/
https://www.youtube.com/watch?v=2PXAfSfvRKY
https://share.gemini.google/qQVluGzFICae
- Went through the arduous process of learning how to create a "factory"(?) I
  wanted to be able to check if a matrix is square at construction and if so,
  return it as an instance of the SquareMatrix subclass instead of the standard
  Matrix class. Turns out that's not as simple as it seems. I had to learn about
  static methods, and got introduced to the `internal` keyword instead of merely
  `protected`.


*/
class Program
{
  static void Main(string[] args)
  {
    
    Console.WriteLine("hello matrix world");


    Matrix test = new ZeroMatrix(3, 4);
    Console.WriteLine(test);
  }
}