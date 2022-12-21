namespace TetrisApp.Core;

public class Position
{
    public int Row { get; set; }
    public int Column { get; set; }

    public Position(int row, int column)
    {
        Row = row;
        Column = column;
    }

    public static bool operator ==(Position left, Position right) => left.Row == right.Row && left.Column == right.Column;
    public static bool operator !=(Position left, Position right) => left.Row != right.Row || left.Column != right.Column;
    public bool Equals(Position other) => Row == other.Row && Column == other.Column;
    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        return obj.GetType() == GetType() && Equals((Position)obj);
    }
    public override int GetHashCode() => HashCode.Combine(Row, Column);
}
