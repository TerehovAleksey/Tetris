namespace TetrisApp.Core.Blocks;

public class TBlock : Block
{
    public override int ArgbColor { get; set; } = Color.Purple.ToArgb();
    public override string Name { get; set; } = "TBlock";
    public override Position[][] Tiles { get; set; } = {
        new Position[]{new(0,1), new(1,0), new(1,1), new(1,2)},
        new Position[]{new(0,1), new(1,1), new(1,2), new(2,1)},
        new Position[]{new(1,0), new(1,1), new(1,2), new(2,1)},
        new Position[]{new(0,1), new(1,0), new(1,1), new(2,1)}
    };
    protected override Position StartOffset => new(0, 3);
}