# Matrices

This program is designed to be a general purpose matrix calculator. It allows
the user to input multiple matrices and perform various basic operations with
them. Functionalities will include:

1. Determinant
1. Transpose
1. Inverse
1. LU Decomposition
1. Matrix addition and multiplication
1. Matrix-Vector multiplication
1. The RREF of a matrix
1. Pseudo-inverse for non-square matrices

## Class Diagram

```mermaid
classDiagram
class Matrix{
    - double[,] _data
    Matrix(int rows, int columns)
    Matrix(double[,] data)
    + GetRowCount()
    + GetColumnCount()
    + IsSquare()
    + IsUpperTriangular()
    + IsLowerTriangular()
    + GetTranspose()
    + static Overloads() +, -, mtx * mtx, sclr * mtx,

    }
```

```mermaid
classDiagram
direction LR
    class Matrix {
        -double[,] _data
        +int RowCount
        +int ColumnCount
        +bool IsSquare
        +Matrix(int rows, int cols)
        +Matrix(double[,] data)
        +double GetEntry(int row, int col)
        +double[] GetColumn(int colIndex)
        +void Insert(Matrix b, int startRow, int startCol)
        +Multiply(Matrix a, Matrix b, Matrix target)$
        +Add(Matrix a, Matrix b, Matrix target)$
        +Subtract(Matrix a, Matrix b, Matrix target)$
    }

    class MatrixDecomposition {
        <<static>>
        +LUFactorize(Matrix a, Matrix targetL, Matrix targetU)$
        +IsLUFactorable(Matrix a)$
        +GetEchelonForm(Matrix a, Matrix target)$
        +CalculateDeterminant(Matrix a)$
    }

    class ElementaryRowOperations {
        <<static>>
        +SwapRows(Matrix a, int row1, int row2)$
        +BuildESwap(int size, int row1, int row2, Matrix target)$
        +ScaleRow(Matrix a, int row, double scalar)$
        +BuildEScale(int size, int row, double scalar, Matrix target)$
        +AddRowSum(Matrix a, int sourceRow, int targetRow, double scalar)$
        +BuildESum(int size, int sourceRow, int targetRow, double scalar, Matrix target)$
    }

    class VectorMath {
        <<static>>
        +InnerProduct(double[] v1, double[] v2)$
        +OuterProduct(double[] col, double[] row, Matrix target)$
        +Scale(double[] vector, double scalar, double[] target)$
        +Unitize(double[] vector)$
    }

    class MatrixFactory {
        <<static>>
        +CreateZero(int rows, int cols)$
        +CreateIdentity(int size)$
        +FillZero(Matrix target)$
        +FillIdentity(Matrix target)$
        +FillRandom(Matrix target, int min, int max)$
    }

    MatrixDecomposition ..> Matrix : depends on
    ElementaryRowOperations ..> Matrix : modifies
    VectorMath ..> Matrix : builds / modifies
    MatrixFactory ..> Matrix : creates / fills
```
