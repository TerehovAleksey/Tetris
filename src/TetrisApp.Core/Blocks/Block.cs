namespace TetrisApp.Core.Blocks;

public abstract class Block
{
    private int _rotationState;
    private Position _offset;
    private Position _startOffset;

    public int RotationState => _rotationState;

    public abstract Position[][] Tiles { get; set; }
    public abstract int ArgbColor { get; set; }
    public abstract string Name { get; set; }
    public virtual Position StartOffset
    {
        get => _startOffset;
        set
        {
            _startOffset = value;
            _offset = new Position(StartOffset.Row, StartOffset.Column);
        }
    }

    public Block()
    {
        _offset = new Position(0, 0);
        _startOffset = new Position(0, 0);
    }

    public IEnumerable<Position> TilePositions() => Tiles[_rotationState].Select(p => new Position(p.Row + _offset.Row, p.Column + _offset.Column));

    public void RotationCw()
    {
        _rotationState = (_rotationState + 1) % Tiles.Length;
    }

    public void RotationCcw()
    {
        if (_rotationState == 0)
        {
            _rotationState = Tiles.Length - 1;
        }
        else
        {
            _rotationState--;
        }
    }

    public void Move(int rows, int columns)
    {
        _offset.Row += rows;
        _offset.Column += columns;
    }

    public void Reset()
    {
        _rotationState = 0;
        _offset.Row -= TilePositions().Min(p => p.Row);
        _offset.Column = StartOffset.Column;

    }
}
