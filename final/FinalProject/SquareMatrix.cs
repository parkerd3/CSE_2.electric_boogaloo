using System.Drawing;
using System.Dynamic;

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
    base._isSquare = true;
    _size = base._colCount;
  }

  // Private/Helper functions


  private void CalculateDeterminant()
  /*
  I know the comments in here look like AI but I promise this was all me, it's
  just a complicated algorithm and I needed to reason through the steps for
  myself.
  */
  {
    List<double> transformations = new List<double>();
    SquareMatrix dummy = new SquareMatrix((double[,])this._data.Clone());
    
    // We do this column by column.
    for (int j = 0; j < _size; j++)
    {
      int pivotRow = 0;
      // Search for first nonzero entry (pivot)
      for (int i = pivotRow; i < _size; i++)
      {
        if (dummy._data[i,j] != 0 && i == pivotRow)
        {
          // If the pivot is already there then move on.
          break;
        }
        else if (dummy._data[i,j] != 0 && i != pivotRow)
        {
          // If the pivot wasn't there, move it to the proper index.
          RowOperation.SwapRows(dummy, i, pivotRow);
          transformations.Add(-1);
        }
      }

      // Now that we have found the pivot, we unitize it 
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


}