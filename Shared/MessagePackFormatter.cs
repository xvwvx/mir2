using System.Drawing;
using MessagePack;
using MessagePack.Formatters;

namespace Shared;

public sealed class MessagePackFormatter : IMessagePackFormatter<Color>
{
    public void Serialize(ref MessagePackWriter writer, Color value, MessagePackSerializerOptions options)
    {
        writer.Write(value.A);
        writer.Write(value.R);
        writer.Write(value.G);
        writer.Write(value.B);
    }

    public Color Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
    {
        var a = reader.ReadByte();
        var r = reader.ReadByte();
        var g = reader.ReadByte();
        var b = reader.ReadByte();
        return Color.FromArgb(a, r, g, b);
    }
}

public sealed class PointMessagePackFormatter : IMessagePackFormatter<Point>
{

    public void Serialize(ref MessagePackWriter writer, Point value, MessagePackSerializerOptions options)
    {
        writer.Write(value.X);
        writer.Write(value.Y);
    }

    public Point Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
    {
        var x = reader.ReadInt32();
        var y = reader.ReadInt32();
        return new Point(x, y);
    }
}

public sealed class StatsFormatter : IMessagePackFormatter<Stats>
{
    public void Serialize(ref MessagePackWriter writer, Stats value, MessagePackSerializerOptions options)
    {
        var dict = value.Values;
        writer.Write(dict.Count);
        foreach (var pair in dict)
        {
            writer.Write((int)pair.Key);
            writer.Write(pair.Value);
        }
    }

    public Stats Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
    {
        var count = reader.ReadInt32();
        var dict = new SortedDictionary<Stat, int>();
        for (int i = 0; i < count; i++)
        {
            var key = reader.ReadInt32();
            var value = reader.ReadInt32();
            dict[(Stat)key] = value;
        }
        return new Stats() { Values = dict };
    }
}