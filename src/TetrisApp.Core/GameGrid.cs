namespace TetrisApp.Core;

public class GameGrid
{
    private readonly string[,] _grid;

    public int Rows { get; }
    public int Columns { get; }

    public string this[int row, int column]
    {
        get => _grid[row, column];
        set => _grid[row, column] = value;
    }

    public GameGrid(int rows, int columns)
    {
        _grid = new string[rows, columns];
        Rows = rows;
        Columns = columns;
    }

    public int ClearFullRows()
    {
        var cleared = 0;
        for (var row = Rows - 1; row >= 0; row--)
        {
            if (IsRowFull(row))
            {
                ClearRow(row);
                cleared++;
            }
            else if (cleared > 0)
            {
                MoveRowDown(row, cleared);
            }
        }

        return cleared;
    }

    #region Private Methods

    private bool IsInside(int row, int column) => row >= 0 && row < Rows && column >= 0 && column < Columns;
    public bool IsEmpty(int row, int column) => IsInside(row, column) && string.IsNullOrEmpty(_grid[row, column]);

    private bool IsRowFull(int row)
    {
        for (var column = 0; column < Columns; column++)
        {
            if (string.IsNullOrEmpty(_grid[row, column]))
            {
                return false;
            }
        }

        return true;
    }

    public bool IsRowEmpty(int row)
    {
        for (var column = 0; column < Columns; column++)
        {
            if (!string.IsNullOrEmpty(_grid[row, column]))
            {
                return false;
            }
        }

        return true;
    }

    private void ClearRow(int row)
    {
        for (var column = 0; column < Columns; column++)
        {
            _grid[row, column] = string.Empty;
        }
    }

    private void MoveRowDown(int row, int numRows)
    {
        for (var column = 0; column < Columns; column++)
        {
            _grid[row + numRows, column] = _grid[row, column];
            _grid[row, column] = string.Empty;
        }
    }

    #endregion
}