namespace TetrisApp.Core.Blocks
{
    public class UserBlock : Block
    {
        public override Position[][] Tiles { get; set; } = new Position[4][];
        public override int ArgbColor { get; set; } = Color.Black.ToArgb();
        public override string Name { get; set; } = "Новый блок";
    }
}
