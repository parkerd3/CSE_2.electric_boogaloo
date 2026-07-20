using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Matrix
{
  
  internal double [,] _data;
  protected int _rowCount;
  protected int _colCount;
  protected bool _isSquare = false;
  protected bool? _isUpperTriangular = null;
  protected bool? _isLowerTriangular = null;
  protected bool? _isDiagonal = null;

  // Constructors
  public static Matrix Create(double[,] data)
  {
    if (data.GetLength(0) == data.GetLength(1))
    {
      return new SquareMatrix(data);
    }
    else
    {
      return new Matrix(data);
    }
  }

  public static Matrix NewIdentity(int n)
  {
    return new IdentityMatrix(n);
  }




  /// <summary>
  /// Create a matrix with an existing 2d array
  /// </summary>
  /// <param name="data"></param>
  internal Matrix(double[,] data)
  {
    _data = data;
    _rowCount = _data.GetLength(0);
    _colCount = _data.GetLength(1);
  }

  /// <summary>
  /// Create a matrix with a specific number of rows and columns
  /// </summary>
  /// <param name="rows"></param>
  /// <param name="cols"></param>
  // public Matrix(int rows, int cols)
  // {
  //   _data = new double[rows,cols];
  //   _rowCount = _data.GetLength(0);
  //   _colCount = _data.GetLength(1);
  // }
  
  // ===========================================================================
  // Getters
  // ===========================================================================

  /// <summary>
  /// Return the value at the specified row and column index.
  /// </summary>
  /// <param name="row"></param>
  /// <param name="col"></param>
  /// <returns></returns>
  public double GetEntry(int row, int col)
  {
    return _data[row, col];
  }
  
  /// <summary>
  /// Return the column at the specified index.
  /// </summary>
  /// <param name="col"></param>
  /// <returns></returns>
  public double[] GetColumn(int col)
  {
    double[] column = new double[_rowCount];
    for (int i = 0; i < _rowCount; i++)
    {
      column[i] = _data[i,col];
    }
    return column;
  }

  /// <summary>
  /// Return the row at the specified index.
  /// </summary>
  /// <param name="row"></param>
  /// <returns></returns>
  public double[] GetRow(int row)
  {
    double[] returnRow = new double[_colCount];
    for (int i = 0; i < _colCount; i++)
    {
      returnRow[i] = _data[row,i];
    }
    return returnRow;
  }

  public int GetRowCount()
  {
    return _rowCount;
  }

  public int GetColumnCount()
  {
    return _colCount;
  }

  /// <summary>
  /// Return the transpose of this matrix.
  /// </summary>
  /// <returns></returns>
  public Matrix GetTranspose()
  {
    double[,] T = new double[_colCount,_rowCount];
    for (int i = 0; i < _rowCount; i++)
    {
      for (int j = 0; j < _colCount; j++)
      {
        T[j,i] = _data[i,j];
      }
    }
    
    if (_isSquare)
    {
      return new SquareMatrix(T);
    }
    else
    {
      return new Matrix(T);
    }
  }

  // ===== Flags =====

  /// <summary>
  /// Return true if every entry below the main diagonal is zero
  /// </summary>
  /// <returns></returns>
  public bool IsUpperTriangular()
  {
    if (_isUpperTriangular.HasValue)
    {
      return _isUpperTriangular.Value;
    }
    else
    {
      _isUpperTriangular = true;
      for (int i = 1; i < _rowCount; i++)
      {
        for (int j = 0; j< i; j++)
        {
          if (_data[i,j] != 0)
          {
            _isUpperTriangular = false;
            break;
          }
        }
      }
      return _isUpperTriangular.Value;
    }
  }

  /// <summary>
  /// Return true if every entry above the main diagonal is zero.
  /// </summary>
  /// <returns></returns>
  public bool IsLowerTriangular()
  {
    if (_isLowerTriangular.HasValue)
    {
      return _isLowerTriangular.Value;
    }
    else
    {
      _isLowerTriangular = true;
      for (int i = 0; i < _rowCount; i++)
      {
        for (int j = i+1; j < _colCount; j++)
        {
          if (_data[i,j] != 0)
          {
            _isLowerTriangular = false;
            break;
          }
        }
      }
      return _isLowerTriangular.Value;
    }
  }

  /// <summary>
  /// Return true if every entry off the main diagonal is zero.
  /// </summary>
  /// <returns></returns>
  public bool IsDiagonal()
  {
    if (_isDiagonal.HasValue)
    {
      return _isDiagonal.Value;
    }
    else
    {
      _isDiagonal = IsUpperTriangular() && IsLowerTriangular();
      return _isDiagonal.Value;
    }
  }

  /// <summary>
  /// Return true if the number of rows and the number of columns are equal.
  /// </summary>
  /// <returns></returns>
  public bool IsSquare()
  {
    return _isSquare;
  }

  // ===========================================================================
  // Other Methods
  // ===========================================================================
  
  /// <summary>
  /// Compute and return the row reduced-echelon form of the matrix.
  /// </summary>
  /// <returns></returns>
  public virtual Matrix RREF()
  /*
  I actually coded the Determinant function for a square matrix first, but the
  algorithms are very similar. The main difference here is that I don't have to
  keep track of the transformations, but I do have to continue even if there is
  a free variable.
  */
  {
    Matrix R = new Matrix((double[,])_data.Clone());
    // Note to self: you must use a matrix object as the RowOperations only work
    // on Matrix objects.

    int pivotRow = 0;
    for (int j = 0; j < R._colCount && pivotRow < R._rowCount; j++)
    {
      // Find entry with the largest absolute value (for efficiency) and also
      // make sure there's actually a pivot.
      double phattest = 0;
      int phatIdx = pivotRow;
      bool freeVariable = true; // assume there's no pivot until one is found
      for (int i = pivotRow; i < R._rowCount; i++)
      {
        if (Math.Abs(R._data[i,j]) > phattest)
        {
          phattest = Math.Abs(R._data[i,j]);
          phatIdx = i;
          freeVariable = false;
        }
      }
      if (freeVariable)
      {
        // Go to next column without iterating pivot row.
        continue; 
      }

      // Put largest entry in pivot position
      RowOperation.SwapRows(R, phatIdx, pivotRow);
      // Unitize first entry
      RowOperation.ScaleRow(R, pivotRow, 1/R._data[pivotRow,j]);
      // Make every entry above and below the pivot a zero.
      for (int i = 0; i < R._rowCount; i++)
      {
        if (R._data[i,j] == 0 || i == pivotRow)
        {
          continue;
        }
        else
        {
          double k = -R._data[i,j];
          RowOperation.AddRow(R, pivotRow, k, i);
        }
      }
      
      pivotRow ++; // Iterate the pivot position and go to next column.
    }

    if (_isSquare)
    {
      return new SquareMatrix(R._data);
    }
    else
    {
      return R;
    }
  }

  public override string ToString()
  {
    string display;

    // $"{value:F2}"
    // ┐┌└┘│
    for (int i = 0; i < _rowCount; i++)
    {
      string currentRow = "│";
      for (int j = 0; j < _colCount; j++)
      {
        currentRow += $"{_data[i,j]:F2}";
      }
    }
    display = "bruh";

    return display;
  }

  // ===========================================================================
  // Operator Overloads
  // ===========================================================================
  // Unitary operators
  public static Matrix operator +(Matrix A) => A;
  public static Matrix operator -(Matrix A)
  {
    double[,] negMtx = new double[A._rowCount, A._colCount];
    for (int i = 0; i < A._rowCount; i++)
    {
      for (int j = 0; j < A._colCount; j++)
      {
        negMtx[i,j] = -A._data[i,j];
      }
    }

    return new Matrix(negMtx);
  }

  // Binary operators
  public static Matrix operator +(Matrix A, Matrix B)
  {
    if (!(A._rowCount == B._rowCount && A._colCount == B._colCount))
    {
      throw new ArgumentException("Matrices must be the same dimension");
    }

    double[,] sum = new double[A._rowCount, A._colCount];
    for (int i = 0; i < A._rowCount; i++)
    {
      for (int j = 0; j < A._colCount; j++)
      {
        sum[i,j] = A._data[i,j] + B._data[i,j];
      }
    }

    return new Matrix(sum);
  }
  public static Matrix operator -(Matrix A, Matrix B) => A + (-B);

  public static Matrix operator *(Matrix A, Matrix B)
  {
    if (A._colCount != B._rowCount)
    {
      throw new ArgumentException(
        $"The number of columns in {nameof(A)} must equal the number of rows in {nameof(B)}"
      );
    }

    int n = A._colCount;
    double[,] product = new double[A._rowCount, B._colCount];
    for (int i = 0; i < A._rowCount; i++)
    {
      for (int j = 0; j < B._colCount; j++)
      {
        double tempSum = 0;
        for (int k = 0; k < n; k++)
        {
          tempSum += A._data[i,k] * B._data[k,j];
        }
        product[i,j] = tempSum;
      }
    }

    return new Matrix(product);
  }
  public static Matrix operator *(double c, Matrix A)
  {
    double[,] mtx = new double[A._rowCount, A._colCount];
    for (int i = 0; i < A._rowCount; i++)
    {
      for (int j = 0; j < A._colCount; j++)
      {
        mtx[i,j] = c * A._data[i,j];
      }
    }

    return new Matrix(mtx);
  }

  // ===========================================================================
  // Static RowOperation Class
  // ===========================================================================
  
  public static class RowOperation
  {
    /// <summary>
    /// Return nothing. Swap row at index row1 with the row at index row2.
    /// </summary>
    /// <param name="mtx"></param>
    /// <param name="row1"></param>
    /// <param name="row2"></param>
    public static void SwapRows(Matrix mtx, int row1, int row2)
    {
      for (int j = 0; j < mtx._colCount; j++)
      {
        double temp = mtx._data[row1, j];
        mtx._data[row1, j] = mtx._data[row2, j];
        mtx._data[row2, j] = temp;
      }
    }

    /// <summary>
    /// Return nothing. Multiply the row at index row_i by the scalar k.
    /// </summary>
    /// <param name="mtx"></param>
    /// <param name="row_i"></param>
    /// <param name="k"></param>
    public static void ScaleRow(Matrix mtx, int row_i, double k)
    {
      for (int j = 0; j < mtx._colCount; j++)
      {
        mtx._data[row_i, j] = k*mtx._data[row_i, j];
      }
    }

    /// <summary>
    /// Return nothing. Add k times the row at index row1 to row2. 
    /// (row2 -> k*row1 + row2)
    /// </summary>
    /// <param name="mtx"></param>
    /// <param name="row1"></param>
    /// <param name="k"></param>
    /// <param name="row2"></param>
    public static void AddRow(Matrix mtx, int row1, double k, int row2)
    {
      for (int j = 0; j < mtx._colCount; j++)
      {
        mtx._data[row2, j] = k*mtx._data[row1, j] + mtx._data[row2, j];
      }
    }
  }
}