using System.Drawing;
using System.Dynamic;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;

public class SquareMatrix : Matrix
{
  // Attributes

  protected double? _determinant = null;
  protected bool? _isInvertible = null;
  protected int _size;



  

  // ===========================================================================
  // Constructors
  // ===========================================================================
  internal SquareMatrix(double[,] data) : base(data)
  {
    _isSquare = true;
    _size = _colCount;
  }

  // Private/Helper functions


  private void CalculateDeterminant()
  /*
  I know the comments in here look like AI but I promise this was all me, it's
  just a complicated algorithm and I needed to reason through the steps for
  myself.
  */
  {
    if (IsUpperTriangular() || IsLowerTriangular())
    {
      double det = 1;
      for (int n = 0; n < _size; n++)
      {
        det = det * _data[n,n];
      }
      _determinant = det;
      return; // Stop executing this function.
    }
    // The idea is to row reduce into an upper triangular matrix, and keep track
    // of each transformation. Then multiply the diagonal entries to get the
    // determinant, and then correct for the row operations performed on it.

    // We'll use a dummy so as not to mess with the actual data array.    
    SquareMatrix dummy = new SquareMatrix((double[,])_data.Clone());
    // Note to self: you must use a matrix object as the RowOperations only work
    // on Matrix objects.
    int swapCount = 0;

    // We do this column by column.
    int pivotRow = 0;
    for (int j = 0; j < _size; j++)
    {
      bool freeVariable = false;
      // Search for first nonzero entry (pivot)
      if (dummy._data[pivotRow, j] == 0) // Only runs if a swap is necessary
      {
        freeVariable = true;
        // If it makes it through every iteration and fails every check then
        // every entry is zero => no pivot => column has a free variable.
        for (int i = pivotRow + 1; i < _size; i++)
        {
          if (dummy._data[i, j] != 0)
          {
            // If the pivot wasn't there, move it to the proper index, record
            // the transformation, and carry on.
            RowOperation.SwapRows(dummy, i, pivotRow);
            swapCount++;
            freeVariable = false; // This code only runs if there's a pivot.
            break;
          }
        }
      }


      if (freeVariable)
      {
        _determinant = 0;
        return; // Abandon ship! No point in doing any more computation.
      }
      else // There's a pivot and we can start reducing all the rows below.
      {
        // Make every entry below the pivot a zero.
        for (int i = pivotRow+1; i < _size; i++)
        {
          if (dummy._data[i,j] == 0)
          {
            continue;
          }
          else
          {
            double k = -dummy._data[i,j]/dummy._data[pivotRow, j];
            RowOperation.AddRow(dummy, pivotRow, k, i);
            // This should effectively scale down the pivot to 1, then multply
            // it by the additive inverse of the entry below it, so when the
            // rows are added together, the entry becomes zero like we want.
          }
        }
      }

      pivotRow++;
    }
    // Finally! dummy has been reduced into an Upper Triangular matrix, now we
    // may use this formula to find the determinant:
    if (swapCount % 2 == 1)
    {
      _determinant = -1;
    }
    else
    {
      _determinant = 1;
    }

    for (int n = 0; n < _size; n++)
    {
      _determinant = _determinant * dummy._data[n,n];
    }
  }
  

  // ===========================================================================
  // Getters
  // ===========================================================================
  
  public double GetDeterminant()
  {
    if (_determinant.HasValue)
    {
      return _determinant.Value;
    }
    else
    {
      CalculateDeterminant();
      return _determinant.Value;
    }
  }

  public bool IsInvertible()
  {
    if (_isInvertible.HasValue)
    {
      return _isInvertible.Value;
    }
    else
    {
      if (GetDeterminant() == 0)
      {
        _isInvertible = false;
      }
      else if (GetDeterminant() != 0)
      {
        _isInvertible = true;
      }
      return _isInvertible.Value;
    }
  }

  public SquareMatrix Inverse()
  {
    if (!IsInvertible())
    {
      throw new InvalidOperationException("Matrix is not invertible");
    }
    else
    {
      double[,] tempData = new double[_size, 2* _size];
      for (int i = 0; i < _rowCount; i++)
      {
        tempData[i, _size+i] = 1;
        for (int j = 0; j < _colCount; j++)
        {
          tempData[i,j] = _data[i,j];
        }
      }
      Matrix tempInverse = new Matrix(tempData);
      Matrix tempInverted = tempInverse.RREF();

      double[,] tempInvData = new double[_size, _size];
      for (int i = 0; i < _size; i++)
      {
        for (int j = 0; j < _size; j++)
        {
          tempInvData[i,j] = tempInverted._data[i, _size+j];
        }
      }
      return new SquareMatrix(tempInvData);
    }
  }

}