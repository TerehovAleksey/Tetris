namespace TetrisApp.Core;

public class BlockQueue
{
    private readonly List<Block> _blocks = new();
    private readonly Random _random = new();

    public Block NextBlock { get; private set; }

    public BlockQueue(IBlockStorage? blockStorage, Position blockOffset)
    {
        _blocks.AddRange(new Block[]
        {
            new IBlock(),
            new JBlock(),
            new LBlock(),
            new OBlock(),
            new SBlock(),
            new TBlock(),
            new ZBlock()
        });
        var userBlocks = blockStorage?.LoadUserBlocks();
        if (userBlocks is not null)
        {
            _blocks.AddRange(userBlocks);
        }

        foreach (var block in _blocks)
        {
            block.StartOffset = blockOffset;
        }

        NextBlock = RandomBlock();
    }

    public Block GetAndUpdate()
    {
        var block = NextBlock;

        do
        {
            NextBlock = RandomBlock();
        } while (block.Name == NextBlock.Name);

        return block;
    }

    private Block RandomBlock() => _blocks[_random.Next(_blocks.Count)];
}