using MemoryPack;


[MemoryPackable]
public partial class Notice
{
    [MemoryPackOrder(0)]
    public string Title = string.Empty;
    [MemoryPackOrder(1)]
    public string Message = string.Empty;
    [MemoryPackIgnore]
    public DateTime LastUpdate;
    
    [MemoryPackConstructor]
    public Notice() { }

    public Notice(BinaryReader reader)
    {
        Title = reader.ReadString();
        Message = reader.ReadString();
    }

    public void Save(BinaryWriter writer)
    {
        writer.Write(Title);
        writer.Write(Message);
    }
}