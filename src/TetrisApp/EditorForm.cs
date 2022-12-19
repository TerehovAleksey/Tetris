using TetrisApp.Core;
using TetrisApp.Core.Blocks;

namespace TetrisApp
{
    public partial class EditorForm : Form
    {
        private int _rows;
        private int _columns;
        private int _cellSize;
        private Size _size;

        private List<Block> _blocks = new();
        private int _position;

        private Color _color = Color.Black;
        private List<Position> _tiles = new();

        private readonly Dictionary<Position, Rectangle> _rectangles = new();
        private readonly BlockStorage _blockStorage = new BlockStorage();

        public EditorForm()
        {
            InitializeComponent();
            InitEditor();
            InitGrid();
            LoadUserBlocks();
        }

        private void InitEditor()
        {
            _cellSize = 50;
            _size = new Size(_cellSize, _cellSize);
            _position = 0;
            _rows = 4;
            _columns = 4;
        }

        private void InitGrid()
        {
            for (var row = 0; row < _rows; row++)
            {
                for (var column = 0; column < _columns; column++)
                {
                    var position = new Position(row, column);
                    var rect = new Rectangle(new Point(column * _cellSize, row * _cellSize), _size);
                    _rectangles.Add(position, rect);
                }
            }
        }

        private void LoadUserBlocks()
        {
            _blocks = _blockStorage.LoadUserBlocks().ToList();
            if (_blocks.Count == 0)
            {
                ButtonDelete.Enabled = false;
            }

            BlockSelector.DataSource = _blocks;
            BlockSelector.DisplayMember = "Name";
        }

        #region обработчики

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TextBoxName.Text))
            {
                MessageBox.Show("Нет названия!");
                return;
            }

            _blockStorage.CreateUserBlock(TextBoxName.Text, _color, _tiles.ToArray());
            Close();
        }

        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            if (BlockSelector.SelectedItem is not null)
            {
                var editedBlock = (Block)BlockSelector.SelectedItem;
                _blockStorage.RemoveUserBlock(editedBlock.Name);
            }
            Close();
        }

        private void BlockSelector_SelectedValueChanged(object sender, EventArgs e)
        {
            if (BlockSelector.SelectedItem is not null)
            {
                var editedBlock = (Block)BlockSelector.SelectedItem;

                _tiles = editedBlock.Tiles.First().ToList();
                _color = Color.FromArgb(editedBlock.ArgbColor);
                TextBoxName.Text = editedBlock?.Name ?? string.Empty;
                ButtonColor.BackColor = Color.FromArgb(editedBlock!.ArgbColor);
                EditPanel.Invalidate();
            }
        }

        private void EditPanel_Paint(object sender, PaintEventArgs e)
        {
            DrawGrid(e.Graphics);
            DrawBlock(e.Graphics);
            LabelPosition.Text = $@"Позиция {_position + 1}";
        }

        private void EditPanel_Click(object sender, EventArgs e)
        {
            var args = (MouseEventArgs)e;
            foreach (var (position, value) in _rectangles)
            {
                if (value.Contains(args.Location))
                {
                    if (_tiles.Contains(position))
                    {
                        // проверка на возможность удаления
                        var canDelete = true;
                        var neighbors = GetNeighbors(position);
                        foreach (var neighbor in neighbors)
                        {
                            if (GetNeighbors(neighbor).Count() == 1)
                            {
                                canDelete = false;
                            }
                        }

                        if (_tiles.Count <= 2)
                        {
                            canDelete = true;
                        }

                        if (canDelete)
                        {
                            _tiles.Remove(position);
                        }
                    }

                    // проверка на возможность добавления
                    else if (_tiles.Count < 8)
                    {
                        if (!_tiles.Any())
                        {
                            _tiles.Add(position);
                        }
                        else
                        {
                            if (GetNeighbors(position).Any())
                            {
                                _tiles.Add(position);
                            }
                        }
                    }
                }
            }

            EditPanel.Invalidate();
        }

        private void ButtonColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                _color = colorDialog1.Color;
                ButtonColor.BackColor = _color;
                EditPanel.Invalidate();
            }
        }

        private void ButtonCwRotate_Click(object sender, EventArgs e)
        {
            _position++;
            if (_position == 4)
            {
                _position = 0;
            }

            EditPanel.Invalidate();
        }

        private void ButtonCcwRotate_Click(object sender, EventArgs e)
        {
            _position--;
            if (_position == -1)
            {
                _position = 3;
            }

            EditPanel.Invalidate();
        }

        #endregion

        #region отрисовка

        private void DrawGrid(Graphics graphics)
        {
            foreach (var rect in _rectangles.Values)
            {
                graphics.DrawRectangle(Pens.Gray, rect);
            }
        }

        private void DrawBlock(Graphics graphics)
        {
            foreach (var tile in _tiles)
            {
                graphics.FillRectangle(new SolidBrush(_color), new Rectangle(new Point(tile.Column * _cellSize, tile.Row * _cellSize), _size));
            }
        }

        #endregion

        private IEnumerable<Position> GetNeighbors(Position position)
        {
            return _tiles.Where(x => (x.Row == position.Row - 1 && x.Column == position.Column)
                                     || (x.Row == position.Row + 1 && x.Column == position.Column)
                                     || (x.Column == position.Column - 1 && x.Row == position.Row)
                                     || (x.Column == position.Column + 1 && x.Row == position.Row));
        }
    }
}