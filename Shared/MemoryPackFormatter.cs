using System.Drawing;
using MemoryPack;
namespace Shared;

public class StatsFormatter : MemoryPackFormatter<Stats>
{
    public override void Serialize<TBufferWriter>(ref MemoryPackWriter<TBufferWriter> writer, scoped ref Stats value)
    {
        writer.WriteCollectionHeader(value.Count);
        foreach (var pair in value.Values)
        {
            writer.WriteVarInt((byte)pair.Key);
            writer.WriteVarInt(pair.Value);
        }
    }

    public override void Deserialize(ref MemoryPackReader reader, scoped ref Stats value)
    {
        reader.TryReadCollectionHeader(out var length);

        var dict = new SortedDictionary<Stat, int>();
        for (int i = 0; i < length; i++)
        {
            dict[(Stat)reader.ReadVarIntByte()] = reader.ReadVarIntInt32();
        }


        value = new Stats() { Values = dict };

    }
}

public class ColorFormatter : MemoryPackFormatter<Color>
{
    public override void Serialize<TBufferWriter>(ref MemoryPackWriter<TBufferWriter> writer, scoped ref Color value)
    {
        writer.WriteObjectHeader(4);
        writer.WriteVarInt(value.R);
        writer.WriteVarInt(value.G);
        writer.WriteVarInt(value.B);
        writer.WriteVarInt(value.A);
    }

    public override void Deserialize(ref MemoryPackReader reader, scoped ref Color value)
    {
        reader.TryReadObjectHeader(out var memberCount);
        var r = reader.ReadVarIntByte();
        var g = reader.ReadVarIntByte();
        var b = reader.ReadVarIntByte();
        var a = reader.ReadVarIntByte();
        value = Color.FromArgb(a, r, g, b);
    }
}

public class PointFormatter : MemoryPackFormatter<Point>
{
    public override void Serialize<TBufferWriter>(ref MemoryPackWriter<TBufferWriter> writer, scoped ref Point value)
    {
        writer.WriteObjectHeader(2);
        writer.WriteVarInt(value.X);
        writer.WriteVarInt(value.Y);
    }

    public override void Deserialize(ref MemoryPackReader reader, scoped ref Point value)
    {
        reader.TryReadObjectHeader(out var memberCount);
        var x = reader.ReadVarIntInt32();
        var y = reader.ReadVarIntInt32();
        value = new Point(x, y);
    }
}