using TetrisApp.Core;
using TetrisApp.Core.Blocks;

namespace TetrisApp;

public partial class MainForm : Form
{
    private int _cellSize;
    private Size _size;
    private Point _gameFieldOffset;
    private System.Windows.Forms.Timer? _timer;
    private Game? _game;

    private int _rows;
    private int _columns;

    private const int MaxDelay = 500;
    private const int MinDelay = 75;
    private const int DelayDecrease = 25;

    public MainForm()
    {
        InitializeComponent();
        InitializeGame();
        InitializeSize();
    }

    private void InitializeGame()
    {
        _cellSize = 50;
        _size = new Size(_cellSize, _cellSize);
        _gameFieldOffset = new Point(20, 20);

        _rows = (int)RowsSelector.Value;
        _columns = (int)ColumnsSelector.Value;
    }

    private void InitializeSize()
    {
        Width = _gameFieldOffset.X * 2 + (_cellSize * _columns) + InfoPanel.Width + 50;
        Height = _gameFieldOffset.Y * 2 + (_cellSize * _rows) + 50;
    }

    #region обработчики

    private void Timer_Tick(object? sender, EventArgs e)
    {
        if (_game is null || _timer is null)
        {
            return;
        }

        _game.MoveBlockDown();
        if (_game.GameOver)
        {
            _timer.Stop();
            ButtonStart.Visible = true;
            ButtonStart.Enabled = true;
            SettingsGroup.Enabled = true;
        }


        if (WithAcceleration.Checked)
        {
            _timer!.Interval = Math.Max(MinDelay, MaxDelay - (_game!.Score * DelayDecrease));
        }

        Invalidate();
        NextBlockGroup.Invalidate();
        HeldBlockGroup.Invalidate();
    }

    private void MainForm_Paint(object sender, PaintEventArgs e)
    {
        Draw(e.Graphics);
    }

    private void NextBlockGroup_Paint(object sender, PaintEventArgs e)
    {
        if (_game != null)
        {
            DrawHintBlock(e.Graphics, _game.BlockQueue.NextBlock);
        }
    }

    private void HeldBlockGroup_Paint(object sender, PaintEventArgs e)
    {
        if (_game != null && _game.HeldBlock is not null)
        {
            DrawHintBlock(e.Graphics, _game.HeldBlock);
        }
    }

    private void RowsSelector_ValueChanged(object sender, EventArgs e)
    {
        _rows = (int)RowsSelector.Value;
        InitializeSize();
        Invalidate();
    }

    private void ColumnsSelector_ValueChanged(object sender, EventArgs e)
    {
        _columns = (int)ColumnsSelector.Value;
        InitializeSize();
        Invalidate();
    }

    private void MainForm_KeyUp(object sender, KeyEventArgs e)
    {
        if (_game == null || _game.GameOver)
        {
            return;
        }

        switch (e.KeyCode)
        {
            case Keys.Left:
                _game.MoveBlockLeft();
                break;
            case Keys.Right:
                _game.MoveBlockRight();
                break;
            case Keys.Down:
                _game.MoveBlockDown();
                break;
            case Keys.Up:
                _game.RotateBlockCw();
                break;
            case Keys.Z:
                _game.RotateBlockCcw();
                break;
            case Keys.C:
                _game.HoldBlock();
                break;
            case Keys.Space:
                _game.DropBlock();
                break;
            default:
                return;
        }

        Invalidate();
        NextBlockGroup.Invalidate();
        HeldBlockGroup.Invalidate();
    }

    private void ButtonStart_Click(object sender, EventArgs e)
    {
        SettingsGroup.Enabled = false;
        ButtonStart.Enabled = false;
        ButtonStart.Visible = false;

        _game = new Game((int)RowsSelector.Value, (int)ColumnsSelector.Value, new BlockStorage());

        if (_timer is null)
        {
            _timer = new System.Windows.Forms.Timer();
            _timer.Tick += Timer_Tick;
        }
        _timer.Interval = MaxDelay;
        _timer.Start();
    }

    private void ButtonEditor_Click(object sender, EventArgs e)
    {
        var editor = new EditorForm();
        editor.ShowDialog();
    }

    #endregion

    #region отрисовка

    private void Draw(Graphics graphics)
    {
        DrawGrid(graphics);
        if (_game != null)
        {
            DrawLines(graphics, _game.GameGrid);
            if (IsGhostEnable.Checked)
            {
                DrawGhostBlock(graphics, _game.CurrentBlock);
            }

            DrawBlock(graphics, _game.CurrentBlock);
            LableScore.Text = $@"Результат:  {_game.Score}";
        }
    }

    // отрисовка сетки
    private void DrawGrid(Graphics graphics)
    {
        for (var row = 0; row <= _rows; row++)
        {
            graphics.DrawLine(Pens.Gray, new Point(_gameFieldOffset.X, _gameFieldOffset.Y + row * _cellSize),
                new Point(_gameFieldOffset.X + _columns * _cellSize, _gameFieldOffset.Y + row * _cellSize));
        }

        for (var column = 0; column <= _columns; column++)
        {
            graphics.DrawLine(Pens.Gray, new Point(_gameFieldOffset.X + column * _cellSize, _gameFieldOffset.Y),
                new Point(_gameFieldOffset.X + column * _cellSize, _gameFieldOffset.Y + _rows * _cellSize));
        }
    }

    // отрисовка заполненных линий
    private void DrawLines(Graphics graphics, GameGrid gameGrid)
    {
        for (var row = 0; row < gameGrid.Rows; row++)
        {
            for (var column = 0; column < gameGrid.Columns; column++)
            {
                var name = gameGrid[row, column];
                if (!string.IsNullOrEmpty(name))
                {
                    graphics.FillRectangle(Brushes.DarkGray,
                        new Rectangle(new Point(_gameFieldOffset.X + column * _cellSize, _gameFieldOffset.Y + row * _cellSize), _size));
                }
            }
        }
    }

    // отрисовка блока
    private void DrawBlock(Graphics graphics, Block currentBlock)
    {
        foreach (var position in currentBlock.TilePositions())
        {
            if (position.Column < 0 || position.Row < 0)
            {
                continue;
            }
            graphics.FillRectangle(new SolidBrush(Color.FromArgb(currentBlock.ArgbColor)),
                new Rectangle(new Point(_gameFieldOffset.X + position.Column * _cellSize, _gameFieldOffset.Y + position.Row * _cellSize), _size));
        }
    }

    // отрисовка подсказки
    private void DrawGhostBlock(Graphics graphics, Block currentBlock)
    {
        var dropDistance = _game?.BlockDropDistance() ?? 0;
        foreach (var position in currentBlock.TilePositions())
        {
            graphics.FillRectangle(Brushes.LightGray,
                new Rectangle(
                    new Point(_gameFieldOffset.X + position.Column * _cellSize, _gameFieldOffset.Y + (position.Row + dropDistance) * _cellSize),
                    _size));
        }
    }

    // отрисовка следующего блока, спрятанного блока
    private void DrawHintBlock(Graphics graphics, Block block)
    {
        foreach (var p in block.Tiles[0])
        {
            graphics.FillRectangle(new SolidBrush(Color.FromArgb(block.ArgbColor)),
                new Rectangle(new Point(70 + p.Column * _cellSize, 100 + p.Row * _cellSize), _size));
        }
    }

    #endregion
}