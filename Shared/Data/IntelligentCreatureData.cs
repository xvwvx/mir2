using MemoryPack;


[MemoryPackable]
public partial class IntelligentCreatureRules
{
    [MemoryPackOrder(0)]
    public int MinimalFullness = 1;
    [MemoryPackOrder(1)]
    public bool MousePickupEnabled = false;
    [MemoryPackOrder(2)]
    public int MousePickupRange = 0;
    [MemoryPackOrder(3)]
    public bool AutoPickupEnabled = false;
    [MemoryPackOrder(4)]
    public int AutoPickupRange = 0;
    [MemoryPackOrder(5)]
    public bool SemiAutoPickupEnabled = false;
    [MemoryPackOrder(6)]
    public int SemiAutoPickupRange = 0;
    [MemoryPackOrder(7)]
    public bool CanProduceBlackStone = false;
    
    [MemoryPackConstructor]
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

[MemoryPackable]
public partial class IntelligentCreatureItemFilter
{
    [MemoryPackOrder(0)]
    public bool PetPickupAll = true;
    [MemoryPackOrder(1)]
    public bool PetPickupGold = false;
    [MemoryPackOrder(2)]
    public bool PetPickupWeapons = false;
    [MemoryPackOrder(3)]
    public bool PetPickupArmours = false;
    [MemoryPackOrder(4)]
    public bool PetPickupHelmets = false;
    [MemoryPackOrder(5)]
    public bool PetPickupBoots = false;
    [MemoryPackOrder(6)]
    public bool PetPickupBelts = false;
    [MemoryPackOrder(7)]
    public bool PetPickupAccessories = false;
    [MemoryPackOrder(8)]
    public bool PetPickupOthers = false;
    [MemoryPackOrder(9)]
    public ItemGrade PickupGrade = ItemGrade.None;
    
    [MemoryPackConstructor]
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

[MemoryPackable]
public partial class ClientIntelligentCreature
{
    [MemoryPackOrder(0)]
    public IntelligentCreatureType PetType;
    [MemoryPackOrder(1)]
    public int Icon;
    [MemoryPackOrder(2)]
    public string CustomName;
    [MemoryPackOrder(3)]
    public int Fullness;
    [MemoryPackOrder(4)]
    public int SlotIndex;
    [MemoryPackOrder(5)]
    public DateTime Expire;
    [MemoryPackOrder(6)]
    public long BlackstoneTime;
    [MemoryPackOrder(7)]
    public long MaintainFoodTime;
    [MemoryPackOrder(8)]
    public IntelligentCreaturePickupMode petMode = IntelligentCreaturePickupMode.SemiAutomatic;
    [MemoryPackOrder(9)]
    public IntelligentCreatureRules CreatureRules;
    [MemoryPackOrder(10)]
    public IntelligentCreatureItemFilter Filter;

    
    [MemoryPackConstructor]
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