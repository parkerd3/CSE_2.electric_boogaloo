public class Fraction
{
  private int _numerator;
  private int _denominator;

  // Constructors
  public Fraction()
  {
    _numerator = 1;
    _denominator = 1;
  }
  public Fraction(int whole)
  {
    _numerator = whole;
    _denominator = 1;
  }
  public Fraction(int top, int bottom)
  {
    _numerator = top;
    _denominator = bottom;
  }

  // Top
  public int GetTop()
  {
    return _numerator;
  }
  public void SetTop(int top)
  {
    _numerator = top;
  }

  // Bottom
  public int GetBottom()
  {
    return _denominator;
  }
  public void SetBottom(int Bottom)
  {
    _denominator = Bottom;
  }

  // Display
  public string GetRationalForm()
  {
    return $"{_numerator}/{_denominator}";
  }
  public double GetDecimalForm()
  {
    return (double)_numerator/_denominator;
  }
}