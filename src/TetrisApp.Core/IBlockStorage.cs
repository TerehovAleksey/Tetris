namespace TetrisApp.Core;

public interface IBlockStorage
{
    public IEnumerable<Block> LoadUserBlocks();
}