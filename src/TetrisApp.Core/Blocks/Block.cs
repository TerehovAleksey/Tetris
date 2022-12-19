namespace TetrisApp.Core.Blocks;

public abstract class Block
{
    private int _rotationState;
    private readonly Position _offset;
    
    public abstract Position[][] Tiles { get; set; }
    public abstract int ArgbColor { get; set; }
    public abstract string Name {get; set; }
    protected abstract Position StartOffset { get; }

    protected Block()
    {
        _offset = new Position(StartOffset.Row, StartOffset.Column);
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
        _offset.Row = StartOffset.Row;
        _offset.Column = StartOffset.Column;
    }
}
