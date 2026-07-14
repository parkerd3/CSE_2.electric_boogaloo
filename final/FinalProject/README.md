# Matrices

This program is designed to be a general purpose matrix calculator. It allows
the user to input multiple matrices and perform various basic operations with
them. Functionalities will include:

1. Determinant
1. Transpose
1. Inverse
1. LU, QR, and PDP Decomposition
1. Matrix addition and multiplication
1. Matrix-Vector multiplication
1. The RREF of a matrix
1. Pseudo-inverse for non-square matrices

## Class Diagram

```mermaid
classDiagram
    direction LR
    class Matrix{
        - double[,] _data
        - int + _rowCount
        - int + _colCount
        - bool + _isSquare
        Matrix(double[,])
        + GetRowCount()
        + GetColumnCount()
        + IsSquare()
        + IsUpperTriangular()
        + IsLowerTriangular()
        + GetTranspose()
        + RREF()
        + static Overloads()$ +, -, mtx * mtx, double * mtx, mtx ** int
    }

    class Vector{
        Vector(double[])
        + DotProduct(Vector)
        + Scale(double)
        + Unitize()
    }

    class SquareMatrix{
        - double _determinant
        + GetInverse()
        + CalculateDeterminant()
    }

    class IdentityMtx{
        IdentityMtx(int size)
    }

    class ZeroMtx{
        ZeroMtx(int rows, int columns)
    }

    class RowOperation {
        <<static>>
        +SwapRows(Matrix, int row1, int row2)
        +ScaleRow(Matrix a, int row, double scalar)
        +AddRowSum(Matrix a, int row1, double scalar, int row2)
    }

    class Factor {
        <<static>>
        + LU(mtx)
        + QR(mtx)
        + PDP(mtx)
    }

    Matrix <|-- SquareMatrix
    Matrix <|-- ZeroMtx
    Matrix <.. RowOperation : modifies
    SquareMatrix <|-- IdentityMtx
    Matrix <.. Factor : depends on and creates
    Matrix <|-- Vector
```



```mermaid
classDiagram

    class MatrixDecomposition {
        <<static>>
        +LUFactorize(Matrix a, Matrix targetL, Matrix targetU)$
        +IsLUFactorable(Matrix a)$
        +GetEchelonForm(Matrix a, Matrix target)$
        +CalculateDeterminant(Matrix a)$
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
    VectorMath ..> Matrix : builds / modifies
    MatrixFactory ..> Matrix : creates / fills
```
