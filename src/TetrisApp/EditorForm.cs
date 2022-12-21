namespace TetrisApp
{
    public partial class EditorForm : Form
    {
        private readonly GameGrid _gameGrid = new(4, 4);
        private readonly BlockStorage _blockStorage = new();

        private readonly Size _size = new(50, 50);
        private Color _color = Color.Black;

        private List<Block> _blocks = new();
        private Block _currentBlock = new UserBlock();

        public EditorForm()
        {
            InitializeComponent();
            LoadUserBlocks();
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

        #region handlers

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TextBoxName.Text))
            {
                MessageBox.Show("Нет названия!");
                return;
            }

            _blockStorage.SaveUserBlock(_currentBlock);
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
                _currentBlock = (Block)BlockSelector.SelectedItem;
                TextBoxName.Text = _currentBlock.Name;
                ButtonColor.BackColor = Color.FromArgb(_currentBlock.ArgbColor);
                EditPanel.Invalidate();
            }
        }

        private void EditPanel_Paint(object sender, PaintEventArgs e)
        {
            Drawing.DrawGrid(e.Graphics, _gameGrid, _size);
            Drawing.DrawBlock(e.Graphics, _currentBlock, _size);
            LabelPosition.Text = $@"Позиция {_currentBlock.RotationState + 1}";
        }

        private void EditPanel_Click(object sender, EventArgs e)
        {
            var args = (MouseEventArgs)e;
            var col = (int)Math.Ceiling((decimal)args.Location.X / _size.Width) - 1;
            var row = (int)Math.Ceiling((decimal)args.Location.Y / _size.Height) - 1;

            if (_currentBlock.RotationState > 0 || col >= _gameGrid.Columns || row >= _gameGrid.Rows)
            {
                return;
            }

            _currentBlock.TryTogglePosition(new Position(row, col));
            EditPanel.Invalidate();
        }

        private void ButtonColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                _color = colorDialog1.Color;
                ButtonColor.BackColor = _color;
                _currentBlock.ArgbColor = _color.ToArgb();

                EditPanel.Invalidate();
            }
        }

        private void ButtonCwRotate_Click(object sender, EventArgs e)
        {
            _currentBlock.RotationCw();
            EditPanel.Invalidate();
        }

        private void ButtonCcwRotate_Click(object sender, EventArgs e)
        {
            _currentBlock.RotationCcw();
            EditPanel.Invalidate();
        }

        private void TextBoxName_TextChanged(object sender, EventArgs e)
        {
            _currentBlock.Name = TextBoxName.Text;
        }

        #endregion
    }

    internal static class BlockExtensions
    {
        internal static void TryTogglePosition(this Block block, Position position)
        {
            var blockTiles = block.Tiles[0];

            // убираем блок
            if (blockTiles.Contains(position) && CanDeleteBlock(blockTiles, position))
            {
                blockTiles = blockTiles.Where(p => p != position).ToArray();
                block.UpdateTiles(blockTiles);
            }
            // или добавляем блок
            else if (!blockTiles.Contains(position) && CanAddBlock(blockTiles, position))
            {
                var newPos = blockTiles.ToList();
                newPos.Add(position);
                blockTiles = newPos.ToArray();
                block.UpdateTiles(blockTiles);
            }
        }

        private static void UpdateTiles(this Block block, Position[] defaultTiles)
        {
            var tiles = new Position[4][];
            tiles[0] = defaultTiles;

            var temp = new int[4, 4];
            foreach (var tile in defaultTiles)
            {
                temp[tile.Row, tile.Column] = 1;
            }

            for (var i = 3; i > 0; i--)
            {
                var positions = new List<Position>();
                temp = RotateMatrix(temp);
                for (var r = 0; r < temp.GetLength(0); r++)
                {
                    for (var c = 0; c < temp.GetLength(1); c++)
                    {
                        if (temp[r, c] == 1)
                        {
                            positions.Add(new Position(r, c));
                        }
                    }
                }

                tiles[i] = positions.ToArray();
            }

            block.Tiles = tiles;
        }

        private static int[,] RotateMatrix(int[,] oldMatrix)
        {
            var newMatrix = new int[oldMatrix.GetLength(1), oldMatrix.GetLength(0)];
            int newColumn, newRow = 0;
            for (var oldColumn = oldMatrix.GetLength(1) - 1; oldColumn >= 0; oldColumn--)
            {
                newColumn = 0;
                for (var oldRow = 0; oldRow < oldMatrix.GetLength(0); oldRow++)
                {
                    newMatrix[newRow, newColumn] = oldMatrix[oldRow, oldColumn];
                    newColumn++;
                }

                newRow++;
            }

            return newMatrix;
        }

        private static bool CanAddBlock(Position[] tiles, Position position)
        {
            if (tiles.Length >= 8)
            {
                return false;
            }

            var hasNeighbors = tiles.Any(t => (t.Row == position.Row - 1 && t.Column == position.Column)
                                     || (t.Row == position.Row + 1 && t.Column == position.Column)
                                     || (t.Column == position.Column - 1 && t.Row == position.Row)
                                     || (t.Column == position.Column + 1 && t.Row == position.Row));

            if (tiles.Length > 1 && !hasNeighbors)
            {
                return false;
            }

            return true;
        }

        private static bool CanDeleteBlock(Position[] tiles, Position position)
        {
            //TODO: fix
            return true;
        }
    }
}