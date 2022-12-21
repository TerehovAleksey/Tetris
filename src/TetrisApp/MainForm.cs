namespace TetrisApp;

public partial class MainForm : Form
{
    private Size _size;
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
        _size = new Size(50, 50);

        _rows = (int)RowsSelector.Value;
        _columns = (int)ColumnsSelector.Value;
    }

    private void InitializeSize()
    {
        GamePanel.Width = _size.Width * _columns;
        GamePanel.Height = _size.Height * _rows;
        
        Width = GamePanel.Width + InfoPanel.Width + 100;
        Height = GamePanel.Height + 100;
    }

    #region handlers

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

        GamePanel.Invalidate();
        NextBlockGroup.Invalidate();
        HeldBlockGroup.Invalidate();
    }

    private void GamePanel_Paint(object sender, PaintEventArgs e)
    {
        if (_game != null)
        {
            Drawing.DrawGrid(e.Graphics, _game.GameGrid, _size);
            if (IsGhostEnable.Checked)
            {
                var dropDistance = _game?.BlockDropDistance() ?? 0;
                Drawing.DrawGhostBlock(e.Graphics, _game!.CurrentBlock, dropDistance, _size);
            }

            Drawing.DrawBlock(e.Graphics, _game.CurrentBlock, _size);
            LableScore.Text = $@"Результат:  {_game.Score}";
        }
    }

    private void NextBlockGroup_Paint(object sender, PaintEventArgs e)
    {
        if (_game != null)
        {
            Drawing.DrawHintBlock(e.Graphics, _game.BlockQueue.NextBlock, _size);
        }
    }

    private void HeldBlockGroup_Paint(object sender, PaintEventArgs e)
    {
        if (_game != null && _game.HeldBlock is not null)
        {
            Drawing.DrawHintBlock(e.Graphics, _game.HeldBlock, _size);
        }
    }

    private void RowsSelector_ValueChanged(object sender, EventArgs e)
    {
        _rows = (int)RowsSelector.Value;
        InitializeSize();
        GamePanel.Invalidate();
    }

    private void ColumnsSelector_ValueChanged(object sender, EventArgs e)
    {
        _columns = (int)ColumnsSelector.Value;
        InitializeSize();
        GamePanel.Invalidate();
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

        GamePanel.Invalidate();
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
}