using System.Drawing;
using MemoryPack;


[MemoryPackable]
public partial class SelectInfo
{
    [MemoryPackOrder(0)]
    public int Index;
    [MemoryPackOrder(1)]
    public string Name = string.Empty;
    [MemoryPackOrder(2)]
    public ushort Level;
    [MemoryPackOrder(3)]
    public MirClass Class;
    [MemoryPackOrder(4)]
    public MirGender Gender;
    [MemoryPackOrder(5)]
    public DateTime LastAccess;
    
    [MemoryPackConstructor]
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

[MemoryPackable]
public partial class Door
{
    [MemoryPackOrder(0)]
    public byte index;
    [MemoryPackOrder(1)]
    public DoorState DoorState;
    [MemoryPackOrder(2)]
    public byte ImageIndex;
    [MemoryPackOrder(3)]
    public long LastTick;
    [MemoryPackOrder(4)]
    public Point Location;

    [MemoryPackConstructor]
    public Door()
    {
        
    }
}

[MemoryPackable]
public partial class RankCharacterInfo
{
    [MemoryPackOrder(0)]
    public long PlayerId;
    [MemoryPackOrder(1)]
    public string Name;
    [MemoryPackOrder(2)]
    public MirClass Class;
    [MemoryPackOrder(3)]
    public int level;
    [MemoryPackIgnore]
    public long Experience;
    [MemoryPackIgnore]
    public object info;
    [MemoryPackIgnore]
    public DateTime LastUpdated;
    
    [MemoryPackConstructor]
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

[MemoryPackable]
public partial class QuestItemReward
{
    [MemoryPackOrder(0)]
    public ItemInfo Item;
    [MemoryPackOrder(1)]
    public ushort Count = 1;
    
    [MemoryPackConstructor]
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

[MemoryPackable]
public partial class WorldMapSetup
{
    [MemoryPackOrder(0)]
    public bool Enabled;
    [MemoryPackOrder(1)]
    public List<WorldMapIcon> Icons = new List<WorldMapIcon>();
    
    [MemoryPackConstructor]
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

[MemoryPackable]
public partial class WorldMapIcon
{
    [MemoryPackOrder(0)]
    public int ImageIndex;
    [MemoryPackOrder(1)]
    public string Title;
    [MemoryPackOrder(2)]
    public int MapIndex;
    
    [MemoryPackConstructor]
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