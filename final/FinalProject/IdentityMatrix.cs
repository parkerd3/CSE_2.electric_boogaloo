public class IdentityMatrix : SquareMatrix
{
  internal IdentityMatrix(int n) : base(new double[n,n])
  {
    for (int i = 0; i < n; i++)
    {
      _data[i,i] = 1;
    }
    _isInvertible = true;
    _determinant = 1;
  }

  public override Matrix RREF()
  {
    return new IdentityMatrix(_size);
  }
}