using MessagePack;

[MessagePackObject]
public class IntelligentCreatureRules
{
    [Key(0)]
    public int MinimalFullness = 1;
    [Key(1)]
    public bool MousePickupEnabled = false;
    [Key(2)]
    public int MousePickupRange = 0;
    [Key(3)]
    public bool AutoPickupEnabled = false;
    [Key(4)]
    public int AutoPickupRange = 0;
    [Key(5)]
    public bool SemiAutoPickupEnabled = false;
    [Key(6)]
    public int SemiAutoPickupRange = 0;
    [Key(7)]
    public bool CanProduceBlackStone = false;

    public IntelligentCreatureRules()
    {
    }

    public IntelligentCreatureRules(BinaryReader reader)
    {
        MinimalFullness = reader.ReadInt32();
        MousePickupEnabled = reader.ReadBoolean();
        MousePickupRange = reader.ReadInt32();
        AutoPickupEnabled = reader.ReadBoolean();
        AutoPickupRange = reader.ReadInt32();
        SemiAutoPickupEnabled = reader.ReadBoolean();
        SemiAutoPickupRange = reader.ReadInt32();

        CanProduceBlackStone = reader.ReadBoolean();
    }

    public void Save(BinaryWriter writer)
    {
        writer.Write(MinimalFullness);
        writer.Write(MousePickupEnabled);
        writer.Write(MousePickupRange);
        writer.Write(AutoPickupEnabled);
        writer.Write(AutoPickupRange);
        writer.Write(SemiAutoPickupEnabled);
        writer.Write(SemiAutoPickupRange);

        writer.Write(CanProduceBlackStone);
    }
}

[MessagePackObject]
public class IntelligentCreatureItemFilter
{
    [Key(0)]
    public bool PetPickupAll = true;
    [Key(1)]
    public bool PetPickupGold = false;
    [Key(2)]
    public bool PetPickupWeapons = false;
    [Key(3)]
    public bool PetPickupArmours = false;
    [Key(4)]
    public bool PetPickupHelmets = false;
    [Key(5)]
    public bool PetPickupBoots = false;
    [Key(6)]
    public bool PetPickupBelts = false;
    [Key(7)]
    public bool PetPickupAccessories = false;
    [Key(8)]
    public bool PetPickupOthers = false;
    [Key(9)]
    public ItemGrade PickupGrade = ItemGrade.None;

    public IntelligentCreatureItemFilter()
    {
    }

    public void SetItemFilter(int idx)
    {
        switch (idx)
        {
            case 0://all items
                PetPickupAll = true;
                PetPickupGold = false;
                PetPickupWeapons = false;
                PetPickupArmours = false;
                PetPickupHelmets = false;
                PetPickupBoots = false;
                PetPickupBelts = false;
                PetPickupAccessories = false;
                PetPickupOthers = false;
                break;
            case 1://gold
                PetPickupAll = false;
                PetPickupGold = !PetPickupGold;
                break;
            case 2://weapons
                PetPickupAll = false;
                PetPickupWeapons = !PetPickupWeapons;
                break;
            case 3://armours
                PetPickupAll = false;
                PetPickupArmours = !PetPickupArmours;
                break;
            case 4://helmets
                PetPickupAll = false;
                PetPickupHelmets = !PetPickupHelmets;
                break;
            case 5://boots
                PetPickupAll = false;
                PetPickupBoots = !PetPickupBoots;
                break;
            case 6://belts
                PetPickupAll = false;
                PetPickupBelts = !PetPickupBelts;
                break;
            case 7://jewelry
                PetPickupAll = false;
                PetPickupAccessories = !PetPickupAccessories;
                break;
            case 8://others
                PetPickupAll = false;
                PetPickupOthers = !PetPickupOthers;
                break;
        }
        if (PetPickupGold && PetPickupWeapons && PetPickupArmours && PetPickupHelmets && PetPickupBoots && PetPickupBelts && PetPickupAccessories && PetPickupOthers)
        {
            PetPickupAll = true;
            PetPickupGold = false;
            PetPickupWeapons = false;
            PetPickupArmours = false;
            PetPickupHelmets = false;
            PetPickupBoots = false;
            PetPickupBelts = false;
            PetPickupAccessories = false;
            PetPickupOthers = false;
        }
        else
            if (!PetPickupGold && !PetPickupWeapons && !PetPickupArmours && !PetPickupHelmets && !PetPickupBoots && !PetPickupBelts && !PetPickupAccessories && !PetPickupOthers)
        {
            PetPickupAll = true;
        }
    }

    public IntelligentCreatureItemFilter(BinaryReader reader)
    {
        PetPickupAll = reader.ReadBoolean();
        PetPickupGold = reader.ReadBoolean();
        PetPickupWeapons = reader.ReadBoolean();
        PetPickupArmours = reader.ReadBoolean();
        PetPickupHelmets = reader.ReadBoolean();
        PetPickupBoots = reader.ReadBoolean();
        PetPickupBelts = reader.ReadBoolean();
        PetPickupAccessories = reader.ReadBoolean();
        PetPickupOthers = reader.ReadBoolean();
        //PickupGrade = (ItemGrade)reader.ReadByte();
    }

    public void Save(BinaryWriter writer)
    {
        writer.Write(PetPickupAll);
        writer.Write(PetPickupGold);
        writer.Write(PetPickupWeapons);
        writer.Write(PetPickupArmours);
        writer.Write(PetPickupHelmets);
        writer.Write(PetPickupBoots);
        writer.Write(PetPickupBelts);
        writer.Write(PetPickupAccessories);
        writer.Write(PetPickupOthers);
        //writer.Write((byte)PickupGrade);
    }
}

[MessagePackObject]
public class ClientIntelligentCreature
{
    [Key(0)]
    public IntelligentCreatureType PetType;
    [Key(1)]
    public int Icon;
    [Key(2)]
    public string CustomName;
    [Key(3)]
    public int Fullness;
    [Key(4)]
    public int SlotIndex;
    [Key(5)]
    public DateTime Expire;
    [Key(6)]
    public long BlackstoneTime;
    [Key(7)]
    public long MaintainFoodTime;
    [Key(8)]
    public IntelligentCreaturePickupMode petMode = IntelligentCreaturePickupMode.SemiAutomatic;
    [Key(9)]
    public IntelligentCreatureRules CreatureRules;
    [Key(10)]
    public IntelligentCreatureItemFilter Filter;


    public ClientIntelligentCreature()
    {
    }

    public ClientIntelligentCreature(BinaryReader reader)
    {
        PetType = (IntelligentCreatureType)reader.ReadByte();
        Icon = reader.ReadInt32();

        CustomName = reader.ReadString();
        Fullness = reader.ReadInt32();
        SlotIndex = reader.ReadInt32();
        Expire = DateTime.FromBinary(reader.ReadInt64());
        BlackstoneTime = reader.ReadInt64();

        petMode = (IntelligentCreaturePickupMode)reader.ReadByte();

        CreatureRules = new IntelligentCreatureRules(reader);
        Filter = new IntelligentCreatureItemFilter(reader)
        {
            PickupGrade = (ItemGrade)reader.ReadByte()
        };
        MaintainFoodTime = reader.ReadInt64();
    }

    public void Save(BinaryWriter writer)
    {
        writer.Write((byte)PetType);
        writer.Write(Icon);

        writer.Write(CustomName);
        writer.Write(Fullness);
        writer.Write(SlotIndex);
        writer.Write(Expire.ToBinary());
        writer.Write(BlackstoneTime);

        writer.Write((byte)petMode);

        CreatureRules.Save(writer);
        Filter.Save(writer);
        writer.Write((byte)Filter.PickupGrade);
        writer.Write(MaintainFoodTime);
    }
}