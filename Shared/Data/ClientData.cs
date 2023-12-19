using System.Drawing;
using MemoryPack;


[MemoryPackable]
public partial class ClientMagic
{
    [MemoryPackOrder(0)]
    public string Name;
    [MemoryPackOrder(1)]
    public Spell Spell;
    [MemoryPackOrder(2)]
    public byte BaseCost;
    [MemoryPackOrder(3)]
    public byte LevelCost;
    [MemoryPackOrder(4)]
    public byte Icon;
    [MemoryPackOrder(5)]
    public byte Level1;
    [MemoryPackOrder(6)]
    public byte Level2;
    [MemoryPackOrder(7)]
    public byte Level3;
    [MemoryPackOrder(8)]
    public ushort Need1;
    [MemoryPackOrder(9)]
    public ushort Need2;
    [MemoryPackOrder(10)]
    public ushort Need3;
    [MemoryPackOrder(11)]
    public byte Level;
    [MemoryPackOrder(12)]
    public byte Key;
    [MemoryPackOrder(13)]
    public byte Range;
    [MemoryPackOrder(14)]
    public ushort Experience;
    [MemoryPackIgnore]
    public bool IsTempSpell;
    [MemoryPackOrder(16)]
    public long CastTime;
    [MemoryPackOrder(17)]
    public long Delay;

    [MemoryPackConstructor]
    public ClientMagic() { }

    public ClientMagic(BinaryReader reader)
    {
        Name = reader.ReadString();
        Spell = (Spell)reader.ReadByte();

        BaseCost = reader.ReadByte();
        LevelCost = reader.ReadByte();
        Icon = reader.ReadByte();
        Level1 = reader.ReadByte();
        Level2 = reader.ReadByte();
        Level3 = reader.ReadByte();
        Need1 = reader.ReadUInt16();
        Need2 = reader.ReadUInt16();
        Need3 = reader.ReadUInt16();

        Level = reader.ReadByte();
        Key = reader.ReadByte();
        Experience = reader.ReadUInt16();

        Delay = reader.ReadInt64();

        Range = reader.ReadByte();
        CastTime = reader.ReadInt64();
    }

    public void Save(BinaryWriter writer)
    {
        writer.Write(Name);
        writer.Write((byte)Spell);

        writer.Write(BaseCost);
        writer.Write(LevelCost);
        writer.Write(Icon);
        writer.Write(Level1);
        writer.Write(Level2);
        writer.Write(Level3);
        writer.Write(Need1);
        writer.Write(Need2);
        writer.Write(Need3);

        writer.Write(Level);
        writer.Write(Key);
        writer.Write(Experience);

        writer.Write(Delay);

        writer.Write(Range);
        writer.Write(CastTime);
    }

}

[MemoryPackable]
public partial class ClientRecipeInfo
{
    [MemoryPackOrder(0)]
    public uint Gold;
    [MemoryPackOrder(1)]
    public byte Chance;
    [MemoryPackOrder(2)]
    public UserItem Item;
    [MemoryPackOrder(3)]
    public List<UserItem> Tools = new List<UserItem>();
    [MemoryPackOrder(4)]
    public List<UserItem> Ingredients = new List<UserItem>();
    
    [MemoryPackConstructor]
    public ClientRecipeInfo() { }


    public ClientRecipeInfo(BinaryReader reader)
    {
        Gold = reader.ReadUInt32();
        Chance = reader.ReadByte();

        Item = new UserItem(reader);

        int count = reader.ReadInt32();
        for (int i = 0; i < count; i++)
        {
            Tools.Add(new UserItem(reader));
        }

        count = reader.ReadInt32();
        for (int i = 0; i < count; i++)
        {
            Ingredients.Add(new UserItem(reader));
        }
    }

    public void Save(BinaryWriter writer)
    {
        writer.Write(Gold);
        writer.Write(Chance);
        Item.Save(writer);

        writer.Write(Tools.Count);
        foreach (var tool in Tools)
        {
            tool.Save(writer);
        }

        writer.Write(Ingredients.Count);
        foreach (var ingredient in Ingredients)
        {
            ingredient.Save(writer);
        }
    }
}

[MemoryPackable]
public partial class ClientFriend
{
    [MemoryPackOrder(0)]
    public int Index;
    [MemoryPackOrder(1)]
    public string Name;
    [MemoryPackOrder(2)]
    public string Memo = "";
    [MemoryPackOrder(3)]
    public bool Blocked;
    [MemoryPackOrder(4)]
    public bool Online;

    [MemoryPackConstructor]
    public ClientFriend() { }

    public ClientFriend(BinaryReader reader)
    {
        Index = reader.ReadInt32();
        Name = reader.ReadString();
        Memo = reader.ReadString();
        Blocked = reader.ReadBoolean();

        Online = reader.ReadBoolean();
    }

    public void Save(BinaryWriter writer)
    {
        writer.Write(Index);
        writer.Write(Name);
        writer.Write(Memo);
        writer.Write(Blocked);

        writer.Write(Online);
    }
}

[MemoryPackable]
public partial class ClientMail
{
    [MemoryPackOrder(0)]
    public ulong MailID;
    [MemoryPackOrder(1)]
    public string SenderName;
    [MemoryPackOrder(2)]
    public string Message;
    [MemoryPackOrder(3)]
    public bool Opened;
    [MemoryPackOrder(4)]
    public bool Locked;
    [MemoryPackOrder(5)]
    public bool CanReply;
    [MemoryPackOrder(6)]
    public bool Collected;
    [MemoryPackOrder(7)]
    public DateTime DateSent;
    [MemoryPackOrder(8)]
    public uint Gold;
    [MemoryPackOrder(9)]
    public List<UserItem> Items = new List<UserItem>();

    [MemoryPackConstructor]
    public ClientMail() { }

    public ClientMail(BinaryReader reader)
    {
        MailID = reader.ReadUInt64();
        SenderName = reader.ReadString();
        Message = reader.ReadString();
        Opened = reader.ReadBoolean();
        Locked = reader.ReadBoolean();
        CanReply = reader.ReadBoolean();
        Collected = reader.ReadBoolean();

        DateSent = DateTime.FromBinary(reader.ReadInt64());

        Gold = reader.ReadUInt32();
        int count = reader.ReadInt32();

        for (int i = 0; i < count; i++)
            Items.Add(new UserItem(reader));
    }

    public void Save(BinaryWriter writer)
    {
        writer.Write(MailID);
        writer.Write(SenderName);
        writer.Write(Message);
        writer.Write(Opened);
        writer.Write(Locked);
        writer.Write(CanReply);
        writer.Write(Collected);

        writer.Write(DateSent.ToBinary());

        writer.Write(Gold);
        writer.Write(Items.Count);

        for (int i = 0; i < Items.Count; i++)
            Items[i].Save(writer);
    }
}

[MemoryPackable]
public partial class ClientAuction
{
    [MemoryPackOrder(0)]
    public ulong AuctionID;
    [MemoryPackOrder(1)]
    public UserItem Item;
    [MemoryPackOrder(2)]
    public string Seller = string.Empty;
    [MemoryPackOrder(3)]
    public uint Price;
    [MemoryPackOrder(4)]
    public DateTime ConsignmentDate = DateTime.MinValue;
    [MemoryPackOrder(5)]
    public MarketItemType ItemType;

    [MemoryPackConstructor]
    public ClientAuction() { }

    public ClientAuction(BinaryReader reader)
    {
        AuctionID = reader.ReadUInt64();
        Item = new UserItem(reader);
        Seller = reader.ReadString();
        Price = reader.ReadUInt32();
        ConsignmentDate = DateTime.FromBinary(reader.ReadInt64());
        ItemType = (MarketItemType)reader.ReadByte();
    }
    public void Save(BinaryWriter writer)
    {
        writer.Write(AuctionID);
        Item.Save(writer);
        writer.Write(Seller);
        writer.Write(Price);
        writer.Write(ConsignmentDate.ToBinary());
        writer.Write((byte)ItemType);
    }
}

[MemoryPackable]
public partial class ClientMovementInfo
{
    [MemoryPackOrder(0)]
    public int Destination;
    [MemoryPackOrder(1)]
    public string Title;
    [MemoryPackOrder(2)]
    public Point Location;
    [MemoryPackOrder(3)]
    public int Icon;

    [MemoryPackConstructor]
    public ClientMovementInfo() { }

    public ClientMovementInfo(BinaryReader reader)
    {
        Destination = reader.ReadInt32();
        Title = reader.ReadString();
        Location = new Point(reader.ReadInt32(), reader.ReadInt32());
        Icon = reader.ReadInt32();
    }

    public void Save(BinaryWriter writer)
    {
        writer.Write(Destination);
        writer.Write(Title);
        writer.Write(Location.X);
        writer.Write(Location.Y);
        writer.Write(Icon);
    }
}

[MemoryPackable]
public partial class ClientNPCInfo
{
    [MemoryPackOrder(0)]
    public uint ObjectID;
    [MemoryPackOrder(1)]
    public string Name;
    [MemoryPackOrder(2)]
    public Point Location;
    [MemoryPackOrder(3)]
    public int Icon;
    [MemoryPackOrder(4)]
    public bool CanTeleportTo;

    [MemoryPackConstructor]
    public ClientNPCInfo() { }

    public ClientNPCInfo(BinaryReader reader)
    {
        ObjectID = reader.ReadUInt32();
        Name = reader.ReadString();
        Location = new Point(reader.ReadInt32(), reader.ReadInt32());
        Icon = reader.ReadInt32();
        CanTeleportTo = reader.ReadBoolean();
    }

    public void Save(BinaryWriter writer)
    {
        writer.Write(ObjectID);
        writer.Write(Name);
        writer.Write(Location.X);
        writer.Write(Location.Y);
        writer.Write(Icon);
        writer.Write(CanTeleportTo);
    }
}

[MemoryPackable]
public partial class ClientMapInfo
{
    [MemoryPackOrder(0)]
    public int Width;
    [MemoryPackOrder(1)]
    public int Height;
    [MemoryPackOrder(2)]
    public int BigMap;
    [MemoryPackOrder(3)]
    public string Title;
    [MemoryPackOrder(4)]
    public List<ClientMovementInfo> Movements = new List<ClientMovementInfo>();
    [MemoryPackOrder(5)]
    public List<ClientNPCInfo> NPCs = new List<ClientNPCInfo>();

    [MemoryPackConstructor]
    public ClientMapInfo() { }

    public ClientMapInfo(BinaryReader reader)
    {
        Title = reader.ReadString();
        Width = reader.ReadInt32();
        Height = reader.ReadInt32();
        BigMap = reader.ReadInt32();
        var count = reader.ReadInt32();
        for (int i = 0; i < count; i++)
            Movements.Add(new ClientMovementInfo(reader));
        count = reader.ReadInt32();
        for (int i = 0; i < count; i++)
            NPCs.Add(new ClientNPCInfo(reader));
    }

    public void Save(BinaryWriter writer)
    {
        writer.Write(Title);
        writer.Write(Width);
        writer.Write(Height);
        writer.Write(BigMap);
        writer.Write(Movements.Count);
        for (int i = 0; i < Movements.Count; i++)
            Movements[i].Save(writer);
        writer.Write(NPCs.Count);
        for (int i = 0; i < NPCs.Count; i++)
            NPCs[i].Save(writer);
    }
}

[MemoryPackable]
public partial class ClientQuestInfo
{
    [MemoryPackOrder(0)]
    public int Index;
    [MemoryPackOrder(1)]
    public uint NPCIndex;
    [MemoryPackOrder(2)]
    public string Name;
    [MemoryPackOrder(3)]
    public string Group;
    [MemoryPackOrder(4)]
    public List<string> Description = new List<string>();
    [MemoryPackOrder(5)]
    public List<string> TaskDescription = new List<string>();
    [MemoryPackOrder(6)]
    public List<string> ReturnDescription = new List<string>();
    [MemoryPackOrder(7)]
    public List<string> CompletionDescription = new List<string>();
    [MemoryPackOrder(8)]
    public int MinLevelNeeded;
    [MemoryPackOrder(9)]
    public int MaxLevelNeeded;
    [MemoryPackOrder(10)]
    public int QuestNeeded;
    [MemoryPackOrder(11)]
    public RequiredClass ClassNeeded;
    [MemoryPackOrder(12)]
    public QuestType Type;
    [MemoryPackOrder(13)]
    public int TimeLimitInSeconds = 0;
    [MemoryPackOrder(14)]
    public uint RewardGold;
    [MemoryPackOrder(15)]
    public uint RewardExp;
    [MemoryPackOrder(16)]
    public uint RewardCredit;
    [MemoryPackOrder(17)]
    public List<QuestItemReward> RewardsFixedItem = new List<QuestItemReward>();
    [MemoryPackOrder(18)]
    public List<QuestItemReward> RewardsSelectItem = new List<QuestItemReward>();
    [MemoryPackOrder(19)]
    public uint FinishNPCIndex;

    [MemoryPackIgnore]
    public bool SameFinishNPC
    {
        get { return NPCIndex == FinishNPCIndex; }
    }

    [MemoryPackConstructor]
    public ClientQuestInfo() { }

    public ClientQuestInfo(BinaryReader reader)
    {
        Index = reader.ReadInt32();
        NPCIndex = reader.ReadUInt32();
        Name = reader.ReadString();
        Group = reader.ReadString();

        int count = reader.ReadInt32();
        for (int i = 0; i < count; i++)
            Description.Add(reader.ReadString());

        count = reader.ReadInt32();
        for (int i = 0; i < count; i++)
            TaskDescription.Add(reader.ReadString());

        count = reader.ReadInt32();
        for (int i = 0; i < count; i++)
            ReturnDescription.Add(reader.ReadString());

        count = reader.ReadInt32();
        for (int i = 0; i < count; i++)
            CompletionDescription.Add(reader.ReadString());

        MinLevelNeeded = reader.ReadInt32();
        MaxLevelNeeded = reader.ReadInt32();
        QuestNeeded = reader.ReadInt32();
        ClassNeeded = (RequiredClass)reader.ReadByte();
        Type = (QuestType)reader.ReadByte();
        TimeLimitInSeconds = reader.ReadInt32();
        RewardGold = reader.ReadUInt32();
        RewardExp = reader.ReadUInt32();
        RewardCredit = reader.ReadUInt32();


        count = reader.ReadInt32();

        for (int i = 0; i < count; i++)
            RewardsFixedItem.Add(new QuestItemReward(reader));

        count = reader.ReadInt32();

        for (int i = 0; i < count; i++)
            RewardsSelectItem.Add(new QuestItemReward(reader));

        FinishNPCIndex = reader.ReadUInt32();
    }
    public void Save(BinaryWriter writer)
    {
        writer.Write(Index);
        writer.Write(NPCIndex);
        writer.Write(Name);
        writer.Write(Group);

        writer.Write(Description.Count);
        for (int i = 0; i < Description.Count; i++)
            writer.Write(Description[i]);

        writer.Write(TaskDescription.Count);
        for (int i = 0; i < TaskDescription.Count; i++)
            writer.Write(TaskDescription[i]);

        writer.Write(ReturnDescription.Count);
        for (int i = 0; i < ReturnDescription.Count; i++)
            writer.Write(ReturnDescription[i]);

        writer.Write(CompletionDescription.Count);
        for (int i = 0; i < CompletionDescription.Count; i++)
            writer.Write(CompletionDescription[i]);

        writer.Write(MinLevelNeeded);
        writer.Write(MaxLevelNeeded);
        writer.Write(QuestNeeded);
        writer.Write((byte)ClassNeeded);
        writer.Write((byte)Type);
        writer.Write(TimeLimitInSeconds);
        writer.Write(RewardGold);
        writer.Write(RewardExp);
        writer.Write(RewardCredit);

        writer.Write(RewardsFixedItem.Count);

        for (int i = 0; i < RewardsFixedItem.Count; i++)
            RewardsFixedItem[i].Save(writer);

        writer.Write(RewardsSelectItem.Count);

        for (int i = 0; i < RewardsSelectItem.Count; i++)
            RewardsSelectItem[i].Save(writer);

        writer.Write(FinishNPCIndex);
    }

    public QuestIcon GetQuestIcon(bool taken = false, bool completed = false)
    {
        QuestIcon icon = QuestIcon.None;

        switch (Type)
        {
            case QuestType.General:
            case QuestType.Repeatable:
                if (completed)
                    icon = QuestIcon.QuestionYellow;
                else if (taken)
                    icon = QuestIcon.QuestionWhite;
                else
                    icon = QuestIcon.ExclamationYellow;
                break;
            case QuestType.Daily:
                if (completed)
                    icon = QuestIcon.QuestionBlue;
                else if (taken)
                    icon = QuestIcon.QuestionWhite;
                else
                    icon = QuestIcon.ExclamationBlue;
                break;
            case QuestType.Story:
                if (completed)
                    icon = QuestIcon.QuestionGreen;
                else if (taken)
                    icon = QuestIcon.QuestionWhite;
                else
                    icon = QuestIcon.ExclamationGreen;
                break;
        }

        return icon;
    }
}

[MemoryPackable]
public partial class ClientQuestProgress
{
    [MemoryPackOrder(0)]
    public int Id;
    [MemoryPackIgnore]
    public ClientQuestInfo QuestInfo;
    [MemoryPackOrder(2)]
    public List<string> TaskList = new List<string>();
    [MemoryPackOrder(3)]
    public bool Taken;
    [MemoryPackOrder(4)]
    public bool Completed;
    [MemoryPackOrder(5)]
    public bool New;

    [MemoryPackIgnore]
    public QuestIcon Icon
    {
        get
        {
            return QuestInfo.GetQuestIcon(Taken, Completed);
        }
    }

    [MemoryPackConstructor]
    public ClientQuestProgress() { }

    public ClientQuestProgress(BinaryReader reader)
    {
        Id = reader.ReadInt32();

        int count = reader.ReadInt32();

        for (int i = 0; i < count; i++)
            TaskList.Add(reader.ReadString());

        Taken = reader.ReadBoolean();
        Completed = reader.ReadBoolean();
        New = reader.ReadBoolean();
    }

    public void Save(BinaryWriter writer)
    {
        writer.Write(Id);

        writer.Write(TaskList.Count);

        for (int i = 0; i < TaskList.Count; i++)
            writer.Write(TaskList[i]);

        writer.Write(Taken);
        writer.Write(Completed);
        writer.Write(New);
    }
}

[MemoryPackable]
public partial class ClientBuff
{
    [MemoryPackOrder(0)]
    public BuffType Type;
    [MemoryPackIgnore]
    public string Caster;
    [MemoryPackOrder(2)]
    public bool Visible;
    [MemoryPackOrder(3)]
    public uint ObjectID;
    [MemoryPackOrder(4)]
    public long ExpireTime;
    [MemoryPackOrder(5)]
    public bool Infinite;
    [MemoryPackOrder(6), MemoryPackAllowSerialize]
    public Stats Stats;
    [MemoryPackOrder(7)]
    public bool Paused;
    [MemoryPackOrder(8)]
    public int[] Values;

    [MemoryPackConstructor]
    public ClientBuff()
    {
        Stats = new Stats();
    }

    public ClientBuff(BinaryReader reader)
    {
        Caster = null;

        Type = (BuffType)reader.ReadByte();
        Visible = reader.ReadBoolean();
        ObjectID = reader.ReadUInt32();
        ExpireTime = reader.ReadInt64();
        Infinite = reader.ReadBoolean();
        Paused = reader.ReadBoolean();

        Stats = new Stats(reader);

        int count = reader.ReadInt32();

        Values = new int[count];

        for (int i = 0; i < count; i++)
        {
            Values[i] = reader.ReadInt32();
        }
    }

    public void Save(BinaryWriter writer)
    {
        writer.Write((byte)Type);
        writer.Write(Visible);
        writer.Write(ObjectID);
        writer.Write(ExpireTime);
        writer.Write(Infinite);
        writer.Write(Paused);

        Stats.Save(writer);

        writer.Write(Values.Length);
        for (int i = 0; i < Values.Length; i++)
        {
            writer.Write(Values[i]);
        }
    }
}

[MemoryPackable]
public partial class ClientHeroInformation
{
    [MemoryPackOrder(0)]
    public int Index;
    [MemoryPackOrder(1)]
    public string Name;
    [MemoryPackOrder(2)]
    public ushort Level;
    [MemoryPackOrder(3)]
    public MirClass Class;
    [MemoryPackOrder(4)]
    public MirGender Gender;

    [MemoryPackConstructor]
    public ClientHeroInformation() { }

    public ClientHeroInformation(BinaryReader reader)
    {
        Index = reader.ReadInt32();
        Name = reader.ReadString();
        Level = reader.ReadUInt16();
        Class = (MirClass)reader.ReadByte();
        Gender = (MirGender)reader.ReadByte();
    }

    public void Save(BinaryWriter writer)
    {
        writer.Write(Index);
        writer.Write(Name);
        writer.Write(Level);
        writer.Write((byte)Class);
        writer.Write((byte)Gender);
    }

    public override string ToString()
    {
        string text = Name;
        text += Environment.NewLine + $"Level {Level} {Enum.GetName(typeof(MirGender), Gender).ToLower()} {Enum.GetName(typeof(MirClass), Class).ToLower()}";
        return text;
    }
}