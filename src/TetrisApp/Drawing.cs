namespace TetrisApp;

internal static class Drawing
{
    // отрисовка сетки
    internal static void DrawGrid(Graphics graphics, GameGrid gameGrid, Size size)
    {
        for (var row = 0; row < gameGrid.Rows; row++)
        {
            for (var column = 0; column < gameGrid.Columns; column++)
            {
                var rect = new Rectangle(new Point(column * size.Width, row * size.Height), size);
                var color = gameGrid[row, column];
                if (color == 0)
                {
                    graphics.DrawRectangle(Pens.Gray, rect);
                }
                else
                {
                    graphics.FillRectangle(new SolidBrush(Color.FromArgb(color)), rect);
                }
            }
        }
    }

    // отрисовка блока
    internal static void DrawBlock(Graphics graphics, Block currentBlock, Size size)
    {
        foreach (var position in currentBlock.TilePositions())
        {
            if (position.Column < 0 || position.Row < 0)
            {
                continue;
            }
            graphics.FillRectangle(new SolidBrush(Color.FromArgb(currentBlock.ArgbColor)),
                new Rectangle(new Point(position.Column * size.Width, position.Row * size.Height), size));
        }
    }

    // отрисовка подсказки
    internal static void DrawGhostBlock(Graphics graphics, Block currentBlock, int dropDistance, Size size)
    {
        foreach (var position in currentBlock.TilePositions())
        {
            graphics.FillRectangle(Brushes.LightGray,
                new Rectangle(
                    new Point(position.Column * size.Width, (position.Row + dropDistance) * size.Height), size));
        }
    }

    // отрисовка следующего блока, спрятанного блока
    internal static void DrawHintBlock(Graphics graphics, Block block, Size size)
    {
        foreach (var p in block.Tiles[0])
        {
            graphics.FillRectangle(new SolidBrush(Color.FromArgb(block.ArgbColor)),
                new Rectangle(new Point(70 + p.Column * size.Width, 100 + p.Row * size.Height), size));
        }
    }
}
