namespace TetrisApp.Core.Blocks;

public class OBlock : Block
{
    public override int ArgbColor { get; set; } = Color.Yellow.ToArgb();
    public override string Name { get; set; } = "OBlock";
    public override Position[][] Tiles { get; set; } = {
        new Position[]{new(0,0), new(0,1), new(1,0), new(1,1)}
    };
}
