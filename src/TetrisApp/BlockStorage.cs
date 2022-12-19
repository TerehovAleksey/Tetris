using System.Diagnostics;
using System.Text.Json;
using TetrisApp.Core;
using TetrisApp.Core.Blocks;

namespace TetrisApp;

public class BlockStorage : IBlockStorage
{
    private const string FILE_NAME = "user_blocks.json";
    private readonly string _path;

    public BlockStorage()
    {
        _path = Path.Combine(Environment.CurrentDirectory, FILE_NAME);
    }

    public IEnumerable<Block> LoadUserBlocks()
    {
        var fileInfo = new FileInfo(_path);
        if (fileInfo.Exists)
        {
            using var reader = new StreamReader(_path);
            var json = reader.ReadToEnd();
            try
            {
                return JsonSerializer.Deserialize<List<UserBlock>>(json) ?? new List<UserBlock>();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
        }

        return new List<UserBlock>();
    }

    public void CreateUserBlock(string name, Color color, Position[] positions)
    {
        var str = color.ToArgb();

        var block = new UserBlock()
        {
            Name = name,
            ArgbColor = color.ToArgb(),
            Tiles = new[]
            {
                positions
            }
        };

        var blocks = LoadUserBlocks().ToList();
        var exist = blocks.FirstOrDefault(x => x.Name == block.Name);
        if (exist is not null)
        {
            blocks.Remove(exist);
        }

        blocks.Add(block);
        SaveToFile(blocks);
    }

    public void RemoveUserBlock(string name)
    {
        var blocks = LoadUserBlocks().ToList();

        var exist = blocks.FirstOrDefault(x => x.Name == name);
        if (exist is not null)
        {
            blocks.Remove(exist);
        }

        SaveToFile(blocks);
    }

    private void SaveToFile(List<Block> blocks)
    {
        var json = JsonSerializer.Serialize(blocks);
        File.WriteAllText(_path, json);
    }
}