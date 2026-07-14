using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// If it is square, then the Matrix class will automatically create itself as an instance
// of a square matrix specifically.

public class Matrix
{
  
  protected double [,] _data;
  private int _rowCount;
  private int _colCount;
  private bool IsSquare;
  

  // Constructors

  /// <summary>
  /// Create a matrix with an existing 2d array
  /// </summary>
  /// <param name="data"></param>
  public Matrix(double[,] data)
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
  
  // Getters

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

  // Other methods
  public Matrix Transpose()
  {
    double[,] T = new double[_colCount,_rowCount];
    for (int i = 0; i < _rowCount; i++)
    {
      for (int j = 0; j < _colCount; j++)
      {
        T[j,i] = _data[i,j];
      }
    }

    return new Matrix(T);
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
}