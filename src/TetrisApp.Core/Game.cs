namespace TetrisApp.Core;

public class Game
{
    private bool _canHold;
    private Block _currentBlock;

    public Block CurrentBlock
    {
        get => _currentBlock;
        private set
        {
            _currentBlock = value;
            _currentBlock.Reset();
        }
    }

    public GameGrid GameGrid { get; }
    public BlockQueue BlockQueue { get; }
    public bool GameOver { get; private set; }
    public int Score { get; private set; }

    public Block? HeldBlock { get; private set; }

    public Game(int rows, int columns, IBlockStorage? blockStorage)
    {
        GameGrid = new GameGrid(rows, columns);
        var offset = new Position(0, (columns - 3) / 2);
        BlockQueue = new BlockQueue(blockStorage, offset);
        CurrentBlock = BlockQueue.GetAndUpdate();
        _canHold = true;
    }

    private bool BlockFits()
    {
        foreach (var position in CurrentBlock.TilePositions())
        {
            if (!GameGrid.IsEmpty(position.Row, position.Column))
            {
                return false;
            }
        }

        return true;
    }

    public void HoldBlock()
    {
        if (!_canHold)
        {
            return;
        }

        if (HeldBlock == null)
        {
            HeldBlock = CurrentBlock;
            CurrentBlock = BlockQueue.GetAndUpdate();
        }
        else
        {
            (CurrentBlock, HeldBlock) = (HeldBlock, CurrentBlock);
        }

        _canHold = false;
    }

    public void RotateBlockCw()
    {
        CurrentBlock.RotationCw();

        if (!BlockFits())
        {
            CurrentBlock.RotationCcw();
        }
    }

    public void RotateBlockCcw()
    {
        CurrentBlock.RotationCcw();

        if (!BlockFits())
        {
            CurrentBlock.RotationCw();
        }
    }

    public void MoveBlockLeft()
    {
        CurrentBlock.Move(0, -1);
        if (!BlockFits())
        {
            CurrentBlock.Move(0, 1);
        }
    }

    public void MoveBlockRight()
    {
        CurrentBlock.Move(0, 1);
        if (!BlockFits())
        {
            CurrentBlock.Move(0, -1);
        }
    }

    private bool IsGameOver()
    {
        return !(GameGrid.IsRowEmpty(0) && GameGrid.IsRowEmpty(1));
    }

    private void PlaceBlock()
    {
        foreach (var position in CurrentBlock.TilePositions())
        {
            GameGrid[position.Row, position.Column] = CurrentBlock.ArgbColor;
        }

        Score += GameGrid.ClearFullRows();

        if (IsGameOver())
        {
            GameOver = true;
        }
        else
        {
            CurrentBlock = BlockQueue.GetAndUpdate();
            _canHold = true;
        }
    }

    public void MoveBlockDown()
    {
        CurrentBlock.Move(1, 0);
        if (!BlockFits())
        {
            CurrentBlock.Move(-1, 0);
            PlaceBlock();
        }
    }

    private int TileDropDistance(Position position)
    {
        var drop = 0;
        while (GameGrid.IsEmpty(position.Row + drop + 1, position.Column))
        {
            drop++;
        }

        return drop;
    }

    public int BlockDropDistance()
    {
        var drop = GameGrid.Rows;
        foreach (var position in CurrentBlock.TilePositions())
        {
            drop = Math.Min(drop, TileDropDistance(position));
        }

        return drop;
    }

    public void DropBlock()
    {
        CurrentBlock.Move(BlockDropDistance(), 0);
        PlaceBlock();
    }
}