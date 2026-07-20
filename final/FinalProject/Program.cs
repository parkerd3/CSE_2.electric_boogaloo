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

    double[,] phatty = {
    { 2, 5,-3, 1, 0, 4,-2, 8, 1, 0},
    {-1, 4, 2, 9,-3, 3, 1, 0, 6,-2},
    { 3, 1, 7,-2, 4,-1, 5, 2,-3, 4},
    { 0, 6,-1, 3, 8, 2,-4, 1, 0, 5},
    {-2, 3, 5, 1,-6, 0, 9,-3, 2, 1},
    { 4,-5, 2, 0, 1, 7,-3, 3,-1, 6},
    { 5, 2, 3,-1, 8,-4, 4, 1, 5,-6},
    {-1,-2,-1,-6, 9, 5,-5, 6, 4,-6},
    {-4, 5, 5, 0, 9, 0, 4,-3, 2, 1},
    { 4,-5, 0, 1, 7,-3,-3, 3,-1, 6}
    };

    SquareMatrix test = (SquareMatrix)Matrix.Create(phatty);
    Console.WriteLine(test);
    Console.WriteLine(test.RREF());
    Console.WriteLine(test.Inverse());
  }
}