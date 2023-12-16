using System.Drawing;
using MessagePack;

[MessagePackObject]
public class SelectInfo
{
    [Key(0)]
    public int Index;
    [Key(1)]
    public string Name = string.Empty;
    [Key(2)]
    public ushort Level;
    [Key(3)]
    public MirClass Class;
    [Key(4)]
    public MirGender Gender;
    [Key(5)]
    public DateTime LastAccess;

    public SelectInfo() { }

    public SelectInfo(BinaryReader reader)
    {
        Index = reader.ReadInt32();
        Name = reader.ReadString();
        Level = reader.ReadUInt16();
        Class = (MirClass)reader.ReadByte();
        Gender = (MirGender)reader.ReadByte();
        LastAccess = DateTime.FromBinary(reader.ReadInt64());
    }
    public void Save(BinaryWriter writer)
    {
        writer.Write(Index);
        writer.Write(Name);
        writer.Write(Level);
        writer.Write((byte)Class);
        writer.Write((byte)Gender);
        writer.Write(LastAccess.ToBinary());
    }
}

[MessagePackObject]
public class Door
{
    [Key(0)]
    public byte index;
    [Key(1)]
    public DoorState DoorState;
    [Key(2)]
    public byte ImageIndex;
    [Key(3)]
    public long LastTick;
    [Key(4)]
    public Point Location;
}

[MessagePackObject]
public class RankCharacterInfo
{
    [Key(0)]
    public long PlayerId;
    [Key(1)]
    public string Name;
    [Key(2)]
    public MirClass Class;
    [Key(3)]
    public int level;
    [IgnoreMember]
    public long Experience;
    [IgnoreMember]
    public object info;
    [IgnoreMember]
    public DateTime LastUpdated;

    public RankCharacterInfo()
    {

    }
    public RankCharacterInfo(BinaryReader reader)
    {
        PlayerId = reader.ReadInt64();
        Name = reader.ReadString();
        level = reader.ReadInt32();
        Class = (MirClass)reader.ReadByte();

    }
    public void Save(BinaryWriter writer)
    {
        writer.Write(PlayerId);
        writer.Write(Name);
        writer.Write(level);
        writer.Write((byte)Class);
    }
}

[MessagePackObject]
public class QuestItemReward
{
    [Key(0)]
    public ItemInfo Item;
    [Key(1)]
    public ushort Count = 1;

    public QuestItemReward() { }

    public QuestItemReward(BinaryReader reader)
    {
        Item = new ItemInfo(reader);
        Count = reader.ReadUInt16();
    }

    public void Save(BinaryWriter writer)
    {
        Item.Save(writer);
        writer.Write(Count);
    }
}

[MessagePackObject]
public class WorldMapSetup
{
    [Key(0)]
    public bool Enabled;
    [Key(1)]
    public List<WorldMapIcon> Icons = new List<WorldMapIcon>();

    public WorldMapSetup() { }

    public WorldMapSetup(BinaryReader reader)
    {
        Enabled = reader.ReadBoolean();
        int count = reader.ReadInt32();
        for (int i = 0; i < count; i++)
            Icons.Add(new WorldMapIcon(reader));
    }

    public void Save(BinaryWriter writer)
    {
        writer.Write(Enabled);
        writer.Write(Icons.Count);
        for (int i = 0; i < Icons.Count; i++)
            Icons[i].Save(writer);
    }
}

[MessagePackObject]
public class WorldMapIcon
{
    [Key(0)]
    public int ImageIndex;
    [Key(1)]
    public string Title;
    [Key(2)]
    public int MapIndex;

    public WorldMapIcon() { }

    public WorldMapIcon(BinaryReader reader)
    {
        ImageIndex = reader.ReadInt32();
        Title = reader.ReadString();
        MapIndex = reader.ReadInt32();
    }

    public void Save(BinaryWriter writer)
    {
        writer.Write(ImageIndex);
        writer.Write(Title);
        writer.Write(MapIndex);
    }
}