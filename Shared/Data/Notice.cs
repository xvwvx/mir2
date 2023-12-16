using MessagePack;

[MessagePackObject]
public class Notice
{
    [Key(0)]
    public string Title = string.Empty;
    [Key(1)]
    public string Message = string.Empty;
    [IgnoreMember]
    public DateTime LastUpdate;

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