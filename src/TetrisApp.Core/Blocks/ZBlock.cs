namespace TetrisApp.Core.Blocks;

public class ZBlock : Block
{
    public override int ArgbColor { get; set; } = Color.Red.ToArgb();
    public override string Name { get; set; } = "ZBlock";
    public override Position[][] Tiles { get; set; } = {
        new Position[]{new(0,0), new(0,1), new(1,1), new(1,2)},
        new Position[]{new(0,2), new(1,1), new(1,2), new(2,1)},
        new Position[]{new(1,0), new(1,1), new(2,1), new(2,2)},
        new Position[]{new(0,1), new(1,0), new(1,1), new(2,0)}
    };
}