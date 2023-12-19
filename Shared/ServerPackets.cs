using System.Drawing;
using System.Runtime.Serialization;
using MemoryPack;

using Shared;

namespace ServerPackets
{
    [MemoryPackable, Route((ushort)ServerPacketIds.KeepAlive)]
    public sealed partial class KeepAlive : Packet
    {
        [MemoryPackOrder(0)]
        public long Time;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.Connected)]
    public sealed partial class Connected : Packet
    {

    }

    [MemoryPackable, Route((ushort)ServerPacketIds.ClientVersion)]
    public sealed partial class ClientVersion : Packet
    {
        [MemoryPackOrder(0)]
        public byte Result;

        /*
        * 0: Wrong Version
        * 1: Correct Version
        */
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.Disconnect)]
    public sealed partial class Disconnect : Packet
    {
        [MemoryPackOrder(0)]
        public byte Reason;

        /*
         * 0: Server Closing.
         * 1: Another User.
         * 2: Packet Error.
         * 3: Server Crashed.
         */

    }

    [MemoryPackable, Route((ushort)ServerPacketIds.NewAccount)]
    public sealed partial class NewAccount : Packet
    {
        [MemoryPackOrder(0)]
        public byte Result;

        /*
        * 0: Disabled
        * 1: Bad AccountID
        * 2: Bad Password
        * 3: Bad Email
        * 4: Bad Name
        * 5: Bad Question
        * 6: Bad Answer
        * 7: Account Exists.
        * 8: Success
        */
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.ChangePassword)]
    public sealed partial class ChangePassword : Packet
    {
        [MemoryPackOrder(0)]
        public byte Result;
        /*
        * 0: Disabled
        * 1: Bad AccountID
        * 2: Bad Current Password
        * 3: Bad New Password
        * 4: Account Not Exist
        * 5: Wrong Password
        * 6: Success
        */
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.ChangePasswordBanned)]
    public sealed partial class ChangePasswordBanned : Packet
    {
        [MemoryPackOrder(0)]
        public string Reason = string.Empty;
        [MemoryPackOrder(1)]
        public DateTime ExpiryDate;

    }

    [MemoryPackable, Route((ushort)ServerPacketIds.Login)]
    public sealed partial class Login : Packet
    {
        [MemoryPackOrder(0)]
        public byte Result;

        /*
        * 0: Disabled
        * 1: Bad AccountID
        * 2: Bad Password
        * 3: Account Not Exist
        * 4: Wrong Password
        */
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.LoginBanned)]
    public sealed partial class LoginBanned : Packet
    {
        [MemoryPackOrder(0)]
        public string Reason = string.Empty;
        [MemoryPackOrder(1)]
        public DateTime ExpiryDate;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.LoginSuccess)]
    public sealed partial class LoginSuccess : Packet
    {
        [MemoryPackOrder(0)]
        public List<SelectInfo> Characters = new List<SelectInfo>();
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.NewCharacter)]
    public sealed partial class NewCharacter : Packet
    {
        /*
         * 0: Disabled.
         * 1: Bad Character Name
         * 2: Bad Gender
         * 3: Bad Class
         * 4: Max Characters
         * 5: Character Exists.
         * 
         * 10: Success
         * */
        [MemoryPackOrder(0)]
        public byte Result;

    }

    [MemoryPackable, Route((ushort)ServerPacketIds.NewCharacterSuccess)]
    public sealed partial class NewCharacterSuccess : Packet
    {
        [MemoryPackOrder(0)]
        public SelectInfo CharInfo;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.DeleteCharacter)]
    public sealed partial class DeleteCharacter : Packet
    {
        [MemoryPackOrder(0)]
        public byte Result;

        /*
         * 0: Disabled.
         * 1: Character Not Found
         * */
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.DeleteCharacterSuccess)]
    public sealed partial class DeleteCharacterSuccess : Packet
    {
        [MemoryPackOrder(0)]
        public int CharacterIndex;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.StartGame)]
    public sealed partial class StartGame : Packet
    {
        [MemoryPackOrder(0)]
        public byte Result;
        [MemoryPackOrder(1)]
        public int Resolution;

        /*
         * 0: Disabled.
         * 1: Not logged in
         * 2: Character not found.
         * 3: Start Game Error
         * */
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.StartGameBanned)]
    public sealed partial class StartGameBanned : Packet
    {
        [MemoryPackOrder(0)]
        public string Reason = string.Empty;
        [MemoryPackOrder(1)]
        public DateTime ExpiryDate;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.StartGameDelay)]
    public sealed partial class StartGameDelay : Packet
    {
        [MemoryPackOrder(0)]
        public long Milliseconds;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.MapInformation)]
    public sealed partial class MapInformation : Packet
    {
        [MemoryPackOrder(0)]
        public int MapIndex;
        [MemoryPackOrder(1)]
        public string FileName = string.Empty;
        [MemoryPackOrder(2)]
        public string Title = string.Empty;
        [MemoryPackOrder(3)]
        public ushort MiniMap;
        [MemoryPackOrder(4)]
        public ushort BigMap;
        [MemoryPackOrder(5)]
        public ushort Music;
        [MemoryPackOrder(6)]
        public LightSetting Lights;
        [MemoryPackOrder(7)]
        public bool Lightning;
        [MemoryPackOrder(8)]
        public bool Fire;
        [MemoryPackOrder(9)]
        public byte MapDarkLight;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.NewMapInfo)]
    public sealed partial class NewMapInfo : Packet
    {
        [MemoryPackOrder(0)]
        public int MapIndex;
        [MemoryPackOrder(1)]
        public ClientMapInfo Info;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.WorldMapSetup)]
    public sealed partial class WorldMapSetupInfo : Packet
    {
        [MemoryPackOrder(0)]
        public WorldMapSetup Setup;
        [MemoryPackOrder(1)]
        public int TeleportToNPCCost;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.SearchMapResult)]
    public sealed partial class SearchMapResult : Packet
    {
        [MemoryPackOrder(0)]
        public int MapIndex = -1;
        [MemoryPackOrder(1)]
        public uint NPCIndex;

    }

    [MemoryPackable, Route((ushort)ServerPacketIds.UserInformation)]
    public partial class UserInformation : Packet
    {
        [MemoryPackOrder(0)]
        public uint ObjectID;
        [MemoryPackOrder(1)]
        public uint RealId;
        [MemoryPackOrder(2)]
        public string Name = string.Empty;
        [MemoryPackOrder(3)]
        public string GuildName = string.Empty;
        [MemoryPackOrder(4)]
        public string GuildRank = string.Empty;
        [MemoryPackOrder(5), MemoryPackAllowSerialize]
        public Color NameColour;
        [MemoryPackOrder(6)]
        public MirClass Class;
        [MemoryPackOrder(7)]
        public MirGender Gender;
        [MemoryPackOrder(8)]
        public ushort Level;
        [MemoryPackOrder(9)]
        public Point Location;
        [MemoryPackOrder(10)]
        public MirDirection Direction;
        [MemoryPackOrder(11)]
        public byte Hair;
        [MemoryPackOrder(12)]
        public int HP;
        [MemoryPackOrder(13)]
        public int MP;
        [MemoryPackOrder(14)]
        public long Experience;
        [MemoryPackOrder(15)]
        public long MaxExperience;
        [MemoryPackOrder(16)]
        public LevelEffects LevelEffects;
        [MemoryPackOrder(17)]
        public bool HasHero;
        [MemoryPackOrder(18)]
        public HeroBehaviour HeroBehaviour;
        [MemoryPackOrder(19)]
        public UserItem[] Inventory;
        [MemoryPackOrder(20)]
        public UserItem[] Equipment;
        [MemoryPackOrder(21)]
        public UserItem[] QuestInventory;
        [MemoryPackOrder(22)]
        public uint Gold;
        [MemoryPackOrder(23)]
        public uint Credit;
        [MemoryPackOrder(24)]
        public bool HasExpandedStorage;
        [MemoryPackOrder(25)]
        public DateTime ExpandedStorageExpiryTime;
        [MemoryPackOrder(26)]
        public List<ClientMagic> Magics = new List<ClientMagic>();
        [MemoryPackOrder(27)]
        public List<ClientIntelligentCreature> IntelligentCreatures = new List<ClientIntelligentCreature>();
        [MemoryPackOrder(28)]
        public IntelligentCreatureType SummonedCreatureType = IntelligentCreatureType.None;
        [MemoryPackOrder(29)]
        public bool CreatureSummoned;
        [MemoryPackOrder(30)]
        public bool AllowObserve;
        [MemoryPackOrder(31)]
        public bool Observer;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.UserSlotsRefresh)]
    public sealed partial class UserSlotsRefresh : Packet
    {
        [MemoryPackOrder(0)]
        public UserItem[] Inventory;
        [MemoryPackOrder(1)]
        public UserItem[] Equipment;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.UserLocation)]
    public sealed partial class UserLocation : Packet
    {
        public override bool Observable
        {
            get { return false; }
        }

        [MemoryPackOrder(0)]
        public Point Location;
        [MemoryPackOrder(1)]
        public MirDirection Direction;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.ObjectPlayer)]
    public partial class ObjectPlayer : Packet
    {
        [MemoryPackOrder(0)]
        public uint ObjectID;
        [MemoryPackOrder(1)]
        public string Name = string.Empty;
        [MemoryPackOrder(2)]
        public string GuildName = string.Empty;
        [MemoryPackOrder(3)]
        public string GuildRankName = string.Empty;
        [MemoryPackOrder(4), MemoryPackAllowSerialize]
        public Color NameColour;
        [MemoryPackOrder(5)]
        public MirClass Class;
        [MemoryPackOrder(6)]
        public MirGender Gender;
        [MemoryPackOrder(7)]
        public ushort Level;
        [MemoryPackOrder(8)]
        public Point Location;
        [MemoryPackOrder(9)]
        public MirDirection Direction;
        [MemoryPackOrder(10)]
        public byte Hair;
        [MemoryPackOrder(11)]
        public byte Light;
        [MemoryPackOrder(12)]
        public short Weapon;
        [MemoryPackOrder(13)]
        public short WeaponEffect;
        [MemoryPackOrder(14)]
        public short Armour;
        [MemoryPackOrder(15)]
        public PoisonType Poison;
        [MemoryPackOrder(16)]
        public bool Dead;
        [MemoryPackOrder(17)]
        public bool Hidden;
        [MemoryPackOrder(18)]
        public SpellEffect Effect;
        [MemoryPackOrder(19)]
        public byte WingEffect;
        [MemoryPackOrder(20)]
        public bool Extra;
        [MemoryPackOrder(21)]
        public short MountType;
        [MemoryPackOrder(22)]
        public bool RidingMount;
        [MemoryPackOrder(23)]
        public bool Fishing;
        [MemoryPackOrder(24)]
        public short TransformType;
        [MemoryPackOrder(25)]
        public uint ElementOrbEffect;
        [MemoryPackOrder(26)]
        public uint ElementOrbLvl;
        [MemoryPackOrder(27)]
        public uint ElementOrbMax;
        [MemoryPackOrder(28)]
        public LevelEffects LevelEffects;
        [MemoryPackOrder(29)]
        public List<BuffType> Buffs = new List<BuffType>();
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.ObjectHero)]
    public sealed partial class ObjectHero : ObjectPlayer
    {
        [MemoryPackOrder(30)]
        public string OwnerName;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.ObjectRemove)]
    public sealed partial class ObjectRemove : Packet
    {
        [MemoryPackOrder(0)]
        public uint ObjectID;

    }

    [MemoryPackable, Route((ushort)ServerPacketIds.ObjectTurn)]
    public sealed partial class ObjectTurn : Packet
    {
        [MemoryPackOrder(0)]
        public uint ObjectID;
        [MemoryPackOrder(1)]
        public Point Location;
        [MemoryPackOrder(2)]
        public MirDirection Direction;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.ObjectWalk)]
    public sealed partial class ObjectWalk : Packet
    {
        [MemoryPackOrder(0)]
        public uint ObjectID;
        [MemoryPackOrder(1)]
        public Point Location;
        [MemoryPackOrder(2)]
        public MirDirection Direction;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.ObjectRun)]
    public sealed partial class ObjectRun : Packet
    {
        [MemoryPackOrder(0)]
        public uint ObjectID;
        [MemoryPackOrder(1)]
        public Point Location;
        [MemoryPackOrder(2)]
        public MirDirection Direction;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.Chat)]
    public sealed partial class Chat : Packet
    {
        public override bool Observable
        {
            get { return Type != ChatType.WhisperIn && Type != ChatType.WhisperOut; }
        }

        [MemoryPackOrder(0)]
        public string Message = string.Empty;
        [MemoryPackOrder(1)]
        public ChatType Type;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.ObjectChat)]
    public sealed partial class ObjectChat : Packet
    {
        [MemoryPackOrder(0)]
        public uint ObjectID;
        [MemoryPackOrder(1)]
        public string Text = string.Empty;
        [MemoryPackOrder(2)]
        public ChatType Type;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.NewItemInfo)]
    public sealed partial class NewItemInfo : Packet
    {
        [MemoryPackOrder(0)]
        public ItemInfo Info;

    }

    [MemoryPackable, Route((ushort)ServerPacketIds.NewHeroInfo)]
    public sealed partial class NewHeroInfo : Packet
    {
        [MemoryPackOrder(0)]
        public ClientHeroInformation Info;
        [MemoryPackOrder(1)]
        public int StorageIndex = -1;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.NewChatItem)]
    public sealed partial class NewChatItem : Packet
    {
        [MemoryPackOrder(0)]
        public UserItem Item;

    }

    [MemoryPackable, Route((ushort)ServerPacketIds.MoveItem)]
    public sealed partial class MoveItem : Packet
    {
        [MemoryPackOrder(0)]
        public MirGridType Grid;
        [MemoryPackOrder(1)]
        public int From;
        [MemoryPackOrder(2)]
        public int To;
        [MemoryPackOrder(3)]
        public bool Success;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.EquipItem)]
    public sealed partial class EquipItem : Packet
    {
        [MemoryPackOrder(0)]
        public MirGridType Grid;
        [MemoryPackOrder(1)]
        public ulong UniqueID;
        [MemoryPackOrder(2)]
        public int To;
        [MemoryPackOrder(3)]
        public bool Success;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.MergeItem)]
    public sealed partial class MergeItem : Packet
    {
        [MemoryPackOrder(0)]
        public MirGridType GridFrom;
        [MemoryPackOrder(1)]
        public MirGridType GridTo;
        [MemoryPackOrder(2)]
        public ulong IDFrom;
        [MemoryPackOrder(3)]
        public ulong IDTo;
        [MemoryPackOrder(4)]
        public bool Success;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.RemoveItem)]
    public sealed partial class RemoveItem : Packet
    {
        [MemoryPackOrder(0)]
        public MirGridType Grid;
        [MemoryPackOrder(1)]
        public ulong UniqueID;
        [MemoryPackOrder(2)]
        public int To;
        [MemoryPackOrder(3)]
        public bool Success;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.RemoveSlotItem)]
    public sealed partial class RemoveSlotItem : Packet
    {
        [MemoryPackOrder(0)]
        public MirGridType Grid;
        [MemoryPackOrder(1)]
        public MirGridType GridTo;
        [MemoryPackOrder(2)]
        public ulong UniqueID;
        [MemoryPackOrder(3)]
        public int To;
        [MemoryPackOrder(4)]
        public bool Success;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.TakeBackItem)]
    public sealed partial class TakeBackItem : Packet
    {
        [MemoryPackOrder(0)]
        public int From;
        [MemoryPackOrder(1)]
        public int To;
        [MemoryPackOrder(2)]
        public bool Success;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.StoreItem)]
    public sealed partial class StoreItem : Packet
    {
        [MemoryPackOrder(0)]
        public int From;
        [MemoryPackOrder(1)]
        public int To;
        [MemoryPackOrder(2)]
        public bool Success;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.DepositRefineItem)]
    public sealed partial class DepositRefineItem : Packet
    {
        [MemoryPackOrder(0)]
        public int From;
        [MemoryPackOrder(1)]
        public int To;
        [MemoryPackOrder(2)]
        public bool Success;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.RetrieveRefineItem)]
    public sealed partial class RetrieveRefineItem : Packet
    {
        [MemoryPackOrder(0)]
        public int From;
        [MemoryPackOrder(1)]
        public int To;
        [MemoryPackOrder(2)]
        public bool Success;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.RefineCancel)]
    public sealed partial class RefineCancel : Packet
    {
        [MemoryPackOrder(0)]
        public bool Unlock;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.RefineItem)]
    public sealed partial class RefineItem : Packet
    {
        [MemoryPackOrder(0)]
        public ulong UniqueID;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.DepositTradeItem)]
    public sealed partial class DepositTradeItem : Packet
    {
        [MemoryPackOrder(0)]
        public int From;
        [MemoryPackOrder(1)]
        public int To;
        [MemoryPackOrder(2)]
        public bool Success;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.RetrieveTradeItem)]
    public sealed partial class RetrieveTradeItem : Packet
    {
        [MemoryPackOrder(0)]
        public int From;
        [MemoryPackOrder(1)]
        public int To;
        [MemoryPackOrder(2)]
        public bool Success;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.SplitItem)]
    public sealed partial class SplitItem : Packet
    {
        [MemoryPackOrder(0)]
        public UserItem Item;
        [MemoryPackOrder(1)]
        public MirGridType Grid;

    }

    [MemoryPackable, Route((ushort)ServerPacketIds.SplitItem1)]
    public sealed partial class SplitItem1 : Packet
    {
        [MemoryPackOrder(0)]
        public MirGridType Grid;
        [MemoryPackOrder(1)]
        public ulong UniqueID;
        [MemoryPackOrder(2)]
        public ushort Count;
        [MemoryPackOrder(3)]
        public bool Success;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.UseItem)]
    public sealed partial class UseItem : Packet
    {
        [MemoryPackOrder(0)]
        public ulong UniqueID;
        [MemoryPackOrder(1)]
        public bool Success;
        [MemoryPackOrder(2)]
        public MirGridType Grid;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.DropItem)]
    public sealed partial class DropItem : Packet
    {
        [MemoryPackOrder(0)]
        public ulong UniqueID;
        [MemoryPackOrder(1)]
        public ushort Count;
        [MemoryPackOrder(2)]
        public bool HeroItem = false;
        [MemoryPackOrder(3)]
        public bool Success;

    }

    [MemoryPackable, Route((ushort)ServerPacketIds.TakeBackHeroItem)]
    public sealed partial class TakeBackHeroItem : Packet
    {
        [MemoryPackOrder(0)]
        public int From;
        [MemoryPackOrder(1)]
        public int To;
        [MemoryPackOrder(2)]
        public bool Success;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.TransferHeroItem)]
    public sealed partial class TransferHeroItem : Packet
    {
        [MemoryPackOrder(0)]
        public int From;
        [MemoryPackOrder(1)]
        public int To;
        [MemoryPackOrder(2)]
        public bool Success;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.PlayerUpdate)]
    public sealed partial class PlayerUpdate : Packet
    {
        [MemoryPackOrder(0)]
        public uint ObjectID;
        [MemoryPackOrder(1)]
        public byte Light;
        [MemoryPackOrder(2)]
        public short Weapon;
        [MemoryPackOrder(3)]
        public short WeaponEffect;
        [MemoryPackOrder(4)]
        public short Armour;
        [MemoryPackOrder(5)]
        public byte WingEffect;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.PlayerInspect)]
    public sealed partial class PlayerInspect : Packet
    {
        public override bool Observable
        {
            get { return false; }
        }

        [MemoryPackOrder(0)]
        public string Name = string.Empty;
        [MemoryPackOrder(1)]
        public string GuildName = string.Empty;
        [MemoryPackOrder(2)]
        public string GuildRank = string.Empty;
        [MemoryPackOrder(3)]
        public UserItem[] Equipment;
        [MemoryPackOrder(4)]
        public MirClass Class;
        [MemoryPackOrder(5)]
        public MirGender Gender;
        [MemoryPackOrder(6)]
        public byte Hair;
        [MemoryPackOrder(7)]
        public ushort Level;
        [MemoryPackOrder(8)]
        public string LoverName;
        [MemoryPackOrder(9)]
        public bool AllowObserve;
        [MemoryPackOrder(10)]
        public bool IsHero = false;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.MarriageRequest)]
    public sealed partial class MarriageRequest : Packet
    {
        [MemoryPackOrder(0)]
        public string Name;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.DivorceRequest)]
    public sealed partial class DivorceRequest : Packet
    {
        [MemoryPackOrder(0)]
        public string Name;

    }

    [MemoryPackable, Route((ushort)ServerPacketIds.MentorRequest)]
    public sealed partial class MentorRequest : Packet
    {
        [MemoryPackOrder(0)]
        public string Name;
        [MemoryPackOrder(1)]
        public ushort Level;

    }

    [MemoryPackable, Route((ushort)ServerPacketIds.TradeRequest)]
    public sealed partial class TradeRequest : Packet
    {
        [MemoryPackOrder(0)]
        public string Name;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.TradeAccept)]
    public sealed partial class TradeAccept : Packet
    {
        [MemoryPackOrder(0)]
        public string Name;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.TradeGold)]
    public sealed partial class TradeGold : Packet
    {
        [MemoryPackOrder(0)]
        public uint Amount;

    }

    [MemoryPackable, Route((ushort)ServerPacketIds.TradeItem)]
    public sealed partial class TradeItem : Packet
    {
        [MemoryPackOrder(0)]
        public UserItem[] TradeItems;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.TradeConfirm)]
    public sealed partial class TradeConfirm : Packet
    {

    }

    [MemoryPackable, Route((ushort)ServerPacketIds.TradeCancel)]
    public sealed partial class TradeCancel : Packet
    {
        [MemoryPackOrder(0)]
        public bool Unlock;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.LogOutSuccess)]
    public sealed partial class LogOutSuccess : Packet
    {
        public override bool Observable => false;

        [MemoryPackOrder(0)]
        public List<SelectInfo> Characters = new List<SelectInfo>();
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.LogOutFailed)]
    public sealed partial class LogOutFailed : Packet
    {
        public override bool Observable => false;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.ReturnToLogin)]
    public sealed partial class ReturnToLogin : Packet
    {
        public override bool Observable => false;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.TimeOfDay)]
    public sealed partial class TimeOfDay : Packet
    {
        [MemoryPackOrder(0)]
        public LightSetting Lights;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.ChangeAMode)]
    public sealed partial class ChangeAMode : Packet
    {
        [MemoryPackOrder(0)]
        public AttackMode Mode;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.ChangePMode)]
    public sealed partial class ChangePMode : Packet
    {
        [MemoryPackOrder(0)]
        public PetMode Mode;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.ObjectItem)]
    public sealed partial class ObjectItem : Packet
    {
        [MemoryPackOrder(0)]
        public uint ObjectID;
        [MemoryPackOrder(1)]
        public string Name = string.Empty;
        [MemoryPackOrder(2), MemoryPackAllowSerialize]
        public Color NameColour;
        [MemoryPackOrder(3)]
        public Point Location;
        [MemoryPackOrder(4)]
        public ushort Image;
        [MemoryPackOrder(5)]
        public ItemGrade grade;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.ObjectGold)]
    public sealed partial class ObjectGold : Packet
    {
        [MemoryPackOrder(0)]
        public uint ObjectID;
        [MemoryPackOrder(1)]
        public uint Gold;
        [MemoryPackOrder(2)]
        public Point Location;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.GainedItem)]
    public sealed partial class GainedItem : Packet
    {
        [MemoryPackOrder(0)]
        public UserItem Item;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.GainedGold)]
    public sealed partial class GainedGold : Packet
    {
        [MemoryPackOrder(0)]
        public uint Gold;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.LoseGold)]
    public sealed partial class LoseGold : Packet
    {
        [MemoryPackOrder(0)]
        public uint Gold;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.GainedCredit)]
    public sealed partial class GainedCredit : Packet
    {
        [MemoryPackOrder(0)]
        public uint Credit;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.LoseCredit)]
    public sealed partial class LoseCredit : Packet
    {
        [MemoryPackOrder(0)]
        public uint Credit;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.ObjectMonster)]
    public sealed partial class ObjectMonster : Packet
    {
        [MemoryPackOrder(0)]
        public uint ObjectID;
        [MemoryPackOrder(1)]
        public string Name = string.Empty;
        [MemoryPackOrder(2), MemoryPackAllowSerialize]
        public Color NameColour;
        [MemoryPackOrder(3)]
        public Point Location;
        [MemoryPackOrder(4)]
        public Monster Image;
        [MemoryPackOrder(5)]
        public MirDirection Direction;
        [MemoryPackOrder(6)]
        public byte Effect;
        [MemoryPackOrder(7)]
        public byte AI;
        [MemoryPackOrder(8)]
        public byte Light;
        [MemoryPackOrder(9)]
        public bool Dead;
        [MemoryPackOrder(10)]
        public bool Skeleton;
        [MemoryPackOrder(11)]
        public PoisonType Poison;
        [MemoryPackOrder(12)]
        public bool Hidden;
        [MemoryPackOrder(13)]
        public bool Extra;
        [MemoryPackOrder(14)]
        public byte ExtraByte;
        [MemoryPackOrder(15)]
        public long ShockTime;
        [MemoryPackOrder(16)]
        public bool BindingShotCenter;
        [MemoryPackOrder(17)]
        public List<BuffType> Buffs = new List<BuffType>();

    }

    [MemoryPackable, Route((ushort)ServerPacketIds.ObjectAttack)]
    public sealed partial class ObjectAttack : Packet
    {
        [MemoryPackOrder(0)]
        public uint ObjectID;
        [MemoryPackOrder(1)]
        public Point Location;
        [MemoryPackOrder(2)]
        public MirDirection Direction;
        [MemoryPackOrder(3)]
        public Spell Spell;
        [MemoryPackOrder(4)]
        public byte Level;
        [MemoryPackOrder(5)]
        public byte Type;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.Struck)]
    public sealed partial class Struck : Packet
    {
        [MemoryPackOrder(0)]
        public uint AttackerID;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.ObjectStruck)]
    public sealed partial class ObjectStruck : Packet
    {
        [MemoryPackOrder(0)]
        public uint ObjectID;
        [MemoryPackOrder(1)]
        public uint AttackerID;
        [MemoryPackOrder(2)]
        public Point Location;
        [MemoryPackOrder(3)]
        public MirDirection Direction;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.DamageIndicator)]
    public sealed partial class DamageIndicator : Packet
    {
        [MemoryPackOrder(0)]
        public int Damage;
        [MemoryPackOrder(1)]
        public DamageType Type;
        [MemoryPackOrder(2)]
        public uint ObjectID;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.DuraChanged)]
    public sealed partial class DuraChanged : Packet
    {
        [MemoryPackOrder(0)]
        public ulong UniqueID;
        [MemoryPackOrder(1)]
        public ushort CurrentDura;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.HealthChanged)]
    public sealed partial class HealthChanged : Packet
    {
        [MemoryPackOrder(0)]
        public int HP;
        [MemoryPackOrder(1)]
        public int MP;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.HeroHealthChanged)]
    public sealed partial class HeroHealthChanged : Packet
    {
        [MemoryPackOrder(0)]
        public int HP;
        [MemoryPackOrder(1)]
        public int MP;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.DeleteItem)]
    public sealed partial class DeleteItem : Packet
    {
        [MemoryPackOrder(0)]
        public ulong UniqueID;
        [MemoryPackOrder(1)]
        public ushort Count;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.Death)]
    public sealed partial class Death : Packet
    {
        [MemoryPackOrder(0)]
        public Point Location;
        [MemoryPackOrder(1)]
        public MirDirection Direction;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.ObjectDied)]
    public sealed partial class ObjectDied : Packet
    {
        [MemoryPackOrder(0)]
        public uint ObjectID;
        [MemoryPackOrder(1)]
        public Point Location;
        [MemoryPackOrder(2)]
        public MirDirection Direction;
        [MemoryPackOrder(3)]
        public byte Type;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.ColourChanged)]
    public sealed partial class ColourChanged : Packet
    {
        [MemoryPackOrder(0), MemoryPackAllowSerialize]
        public Color NameColour;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.ObjectColourChanged)]
    public sealed partial class ObjectColourChanged : Packet
    {
        [MemoryPackOrder(0)]
        public uint ObjectID;
        [MemoryPackOrder(1), MemoryPackAllowSerialize]
        public Color NameColour;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.ObjectGuildNameChanged)]
    public sealed partial class ObjectGuildNameChanged : Packet
    {
        [MemoryPackOrder(0)]
        public uint ObjectID;
        [MemoryPackOrder(1)]
        public string GuildName;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.GainExperience)]
    public sealed partial class GainExperience : Packet
    {
        [MemoryPackOrder(0)]
        public uint Amount;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.GainHeroExperience)]
    public sealed partial class GainHeroExperience : Packet
    {
        [MemoryPackOrder(0)]
        public uint Amount;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.LevelChanged)]
    public sealed partial class LevelChanged : Packet
    {
        [MemoryPackOrder(0)]
        public ushort Level;
        [MemoryPackOrder(1)]
        public long Experience;
        [MemoryPackOrder(2)]
        public long MaxExperience;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.HeroLevelChanged)]
    public sealed partial class HeroLevelChanged : Packet
    {
        [MemoryPackOrder(0)]
        public ushort Level;
        [MemoryPackOrder(1)]
        public long Experience;
        [MemoryPackOrder(2)]
        public long MaxExperience;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.ObjectLeveled)]
    public sealed partial class ObjectLeveled : Packet
    {
        [MemoryPackOrder(0)]
        public uint ObjectID;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.ObjectHarvest)]
    public sealed partial class ObjectHarvest : Packet
    {
        [MemoryPackOrder(0)]
        public uint ObjectID;
        [MemoryPackOrder(1)]
        public Point Location;
        [MemoryPackOrder(2)]
        public MirDirection Direction;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.ObjectHarvested)]
    public sealed partial class ObjectHarvested : Packet
    {
        [MemoryPackOrder(0)]
        public uint ObjectID;
        [MemoryPackOrder(1)]
        public Point Location;
        [MemoryPackOrder(2)]
        public MirDirection Direction;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.ObjectNpc)]
    public sealed partial class ObjectNPC : Packet
    {
        [MemoryPackOrder(0)]
        public uint ObjectID;
        [MemoryPackOrder(1)]
        public string Name = string.Empty;
        [MemoryPackOrder(2), MemoryPackAllowSerialize]
        public Color NameColour;
        [MemoryPackOrder(3)]
        public ushort Image;
        [MemoryPackOrder(4), MemoryPackAllowSerialize]
        public Color Colour;
        [MemoryPackOrder(5)]
        public Point Location;
        [MemoryPackOrder(6)]
        public MirDirection Direction;
        [MemoryPackOrder(7)]
        public List<int> QuestIDs = new List<int>();
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.NPCResponse)]
    public sealed partial class NPCResponse : Packet
    {
        [MemoryPackOrder(0)]
        public List<string> Page;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.ObjectHide)]
    public sealed partial class ObjectHide : Packet
    {
        [MemoryPackOrder(0)]
        public uint ObjectID;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.ObjectShow)]
    public sealed partial class ObjectShow : Packet
    {
        [MemoryPackOrder(0)]
        public uint ObjectID;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.Poisoned)]
    public sealed partial class Poisoned : Packet
    {
        [MemoryPackOrder(0)]
        public PoisonType Poison;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.ObjectPoisoned)]
    public sealed partial class ObjectPoisoned : Packet
    {
        [MemoryPackOrder(0)]
        public uint ObjectID;
        [MemoryPackOrder(1)]
        public PoisonType Poison;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.MapChanged)]
    public sealed partial class MapChanged : Packet
    {
        [MemoryPackOrder(0)]
        public int MapIndex;
        [MemoryPackOrder(1)]
        public string FileName = string.Empty;
        [MemoryPackOrder(2)]
        public string Title = string.Empty;
        [MemoryPackOrder(3)]
        public ushort MiniMap;
        [MemoryPackOrder(4)]
        public ushort BigMap;
        [MemoryPackOrder(5)]
        public ushort Music;
        [MemoryPackOrder(6)]
        public LightSetting Lights;
        [MemoryPackOrder(7)]
        public Point Location;
        [MemoryPackOrder(8)]
        public MirDirection Direction;
        [MemoryPackOrder(9)]
        public byte MapDarkLight;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.ObjectTeleportOut)]
    public sealed partial class ObjectTeleportOut : Packet
    {
        [MemoryPackOrder(0)]
        public uint ObjectID;
        [MemoryPackOrder(1)]
        public byte Type;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.ObjectTeleportIn)]
    public sealed partial class ObjectTeleportIn : Packet
    {
        [MemoryPackOrder(0)]
        public uint ObjectID;
        [MemoryPackOrder(1)]
        public byte Type;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.TeleportIn)]
    public sealed partial class TeleportIn : Packet
    {

    }

    [MemoryPackable, Route((ushort)ServerPacketIds.NPCGoods)]
    public sealed partial class NPCGoods : Packet
    {
        [MemoryPackOrder(0)]
        public List<UserItem> List = new List<UserItem>();
        [MemoryPackOrder(1)]
        public float Rate;
        [MemoryPackOrder(2)]
        public PanelType Type;
        [MemoryPackOrder(3)]
        public bool HideAddedStats;

    }

    [MemoryPackable, Route((ushort)ServerPacketIds.NPCSell)]
    public sealed partial class NPCSell : Packet
    {

    }

    [MemoryPackable, Route((ushort)ServerPacketIds.NPCRepair)]
    public sealed partial class NPCRepair : Packet
    {
        [MemoryPackOrder(0)]
        public float Rate;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.NPCSRepair)]
    public sealed partial class NPCSRepair : Packet
    {
        [MemoryPackOrder(0)]
        public float Rate;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.NPCRefine)]
    public sealed partial class NPCRefine : Packet
    {
        [MemoryPackOrder(0)]
        public float Rate;
        [MemoryPackOrder(1)]
        public bool Refining;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.NPCCheckRefine)]
    public sealed partial class NPCCheckRefine : Packet
    {

    }

    [MemoryPackable, Route((ushort)ServerPacketIds.NPCCollectRefine)]
    public sealed partial class NPCCollectRefine : Packet
    {
        [MemoryPackOrder(0)]
        public bool Success;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.NPCReplaceWedRing)]
    public sealed partial class NPCReplaceWedRing : Packet
    {
        [MemoryPackOrder(0)]
        public float Rate;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.NPCStorage)]
    public sealed partial class NPCStorage : Packet
    {

    }

    [MemoryPackable, Route((ushort)ServerPacketIds.SellItem)]
    public sealed partial class SellItem : Packet
    {
        [MemoryPackOrder(0)]
        public ulong UniqueID;
        [MemoryPackOrder(1)]
        public ushort Count;
        [MemoryPackOrder(2)]
        public bool Success;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.RepairItem)]
    public sealed partial class RepairItem : Packet
    {
        [MemoryPackOrder(0)]
        public ulong UniqueID;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.ItemRepaired)]
    public sealed partial class ItemRepaired : Packet
    {
        [MemoryPackOrder(0)]
        public ulong UniqueID;
        [MemoryPackOrder(1)]
        public ushort MaxDura;
        [MemoryPackOrder(2)]
        public ushort CurrentDura;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.ItemSlotSizeChanged)]
    public sealed partial class ItemSlotSizeChanged : Packet
    {
        [MemoryPackOrder(0)]
        public ulong UniqueID;
        [MemoryPackOrder(1)]
        public int SlotSize;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.ItemSealChanged)]
    public sealed partial class ItemSealChanged : Packet
    {
        [MemoryPackOrder(0)]
        public ulong UniqueID;
        [MemoryPackOrder(1)]
        public DateTime ExpiryDate;
    }


    [MemoryPackable, Route((ushort)ServerPacketIds.NewMagic)]
    public sealed partial class NewMagic : Packet
    {
        [MemoryPackOrder(0)]
        public ClientMagic Magic;
        [MemoryPackOrder(1)]
        public bool Hero;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.RemoveMagic)]
    public sealed partial class RemoveMagic : Packet
    {
        [MemoryPackOrder(0)]
        public int PlaceId;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.MagicLeveled)]
    public sealed partial class MagicLeveled : Packet
    {
        [MemoryPackOrder(0)]
        public uint ObjectID;
        [MemoryPackOrder(1)]
        public Spell Spell;
        [MemoryPackOrder(2)]
        public byte Level;
        [MemoryPackOrder(3)]
        public ushort Experience;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.Magic)]
    public sealed partial class Magic : Packet
    {
        [MemoryPackOrder(0)]
        public Spell Spell;
        [MemoryPackOrder(1)]
        public uint TargetID;
        [MemoryPackOrder(2)]
        public Point Target;
        [MemoryPackOrder(3)]
        public bool Cast;
        [MemoryPackOrder(4)]
        public byte Level;
        [MemoryPackOrder(5)]
        public List<uint> SecondaryTargetIDs = new List<uint>();
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.MagicDelay)]
    public sealed partial class MagicDelay : Packet
    {
        [MemoryPackOrder(0)]
        public uint ObjectID;
        [MemoryPackOrder(1)]
        public Spell Spell;
        [MemoryPackOrder(2)]
        public long Delay;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.MagicCast)]
    public sealed partial class MagicCast : Packet
    {
        [MemoryPackOrder(0)]
        public Spell Spell;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.ObjectMagic)]
    public sealed partial class ObjectMagic : Packet
    {
        [MemoryPackOrder(0)]
        public uint ObjectID;
        [MemoryPackOrder(1)]
        public Point Location;
        [MemoryPackOrder(2)]
        public MirDirection Direction;
        [MemoryPackOrder(3)]
        public Spell Spell;
        [MemoryPackOrder(4)]
        public uint TargetID;
        [MemoryPackOrder(5)]
        public Point Target;
        [MemoryPackOrder(6)]
        public bool Cast;
        [MemoryPackOrder(7)]
        public byte Level;
        [MemoryPackOrder(8)]
        public bool SelfBroadcast = false;
        [MemoryPackOrder(9)]
        public List<uint> SecondaryTargetIDs = new List<uint>();
    }


    [MemoryPackable, Route((ushort)ServerPacketIds.ObjectEffect)]
    public sealed partial class ObjectEffect : Packet
    {
        [MemoryPackOrder(0)]
        public uint ObjectID;
        [MemoryPackOrder(1)]
        public SpellEffect Effect;
        [MemoryPackOrder(2)]
        public uint EffectType;
        [MemoryPackOrder(3)]
        public uint DelayTime = 0;
        [MemoryPackOrder(4)]
        public uint Time = 0;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.ObjectProjectile)]
    public sealed partial class ObjectProjectile : Packet
    {
        [MemoryPackOrder(0)]
        public Spell Spell;
        [MemoryPackOrder(1)]
        public uint Source;
        [MemoryPackOrder(2)]
        public uint Destination;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.RangeAttack)]
    public sealed partial class RangeAttack : Packet //ArcherTest
    {
        [MemoryPackOrder(0)]
        public uint TargetID;
        [MemoryPackOrder(1)]
        public Point Target;
        [MemoryPackOrder(2)]
        public Spell Spell;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.Pushed)]
    public sealed partial class Pushed : Packet
    {
        [MemoryPackOrder(0)]
        public Point Location;
        [MemoryPackOrder(1)]
        public MirDirection Direction;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.ObjectPushed)]
    public sealed partial class ObjectPushed : Packet
    {
        [MemoryPackOrder(0)]
        public uint ObjectID;
        [MemoryPackOrder(1)]
        public Point Location;
        [MemoryPackOrder(2)]
        public MirDirection Direction;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.ObjectName)]
    public sealed partial class ObjectName : Packet
    {
        [MemoryPackOrder(0)]
        public uint ObjectID;
        [MemoryPackOrder(1)]
        public string Name = string.Empty;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.UserStorage)]
    public sealed partial class UserStorage : Packet
    {
        [MemoryPackOrder(0)]
        public UserItem[] Storage;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.SwitchGroup)]
    public sealed partial class SwitchGroup : Packet
    {
        [MemoryPackOrder(0)]
        public bool AllowGroup;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.DeleteGroup)]
    public sealed partial class DeleteGroup : Packet
    {

    }

    [MemoryPackable, Route((ushort)ServerPacketIds.DeleteMember)]
    public sealed partial class DeleteMember : Packet
    {
        [MemoryPackOrder(0)]
        public string Name = string.Empty;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.GroupInvite)]
    public sealed partial class GroupInvite : Packet
    {
        [MemoryPackOrder(0)]
        public string Name = string.Empty;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.AddMember)]
    public sealed partial class AddMember : Packet
    {
        [MemoryPackOrder(0)]
        public string Name = string.Empty;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.GroupMembersMap)]
    public sealed partial class GroupMembersMap : Packet
    {
        [MemoryPackOrder(0)]
        public string PlayerName = string.Empty;
        [MemoryPackOrder(1)]
        public string PlayerMap = string.Empty;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.SendMemberLocation)]
    public sealed partial class SendMemberLocation : Packet
    {
        [MemoryPackOrder(0)]
        public string MemberName;
        [MemoryPackOrder(1)]
        public Point MemberLocation;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.Revived)]
    public sealed partial class Revived : Packet
    {

    }

    [MemoryPackable, Route((ushort)ServerPacketIds.ObjectRevived)]
    public sealed partial class ObjectRevived : Packet
    {
        [MemoryPackOrder(0)]
        public uint ObjectID;
        [MemoryPackOrder(1)]
        public bool Effect;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.SpellToggle)]
    public sealed partial class SpellToggle : Packet
    {
        [MemoryPackOrder(0)]
        public uint ObjectID;
        [MemoryPackOrder(1)]
        public Spell Spell;
        [MemoryPackOrder(2)]
        public bool CanUse;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.ObjectHealth)]
    public sealed partial class ObjectHealth : Packet
    {
        [MemoryPackOrder(0)]
        public uint ObjectID;
        [MemoryPackOrder(1)]
        public byte Percent;
        [MemoryPackOrder(2)]
        public byte Expire;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.ObjectMana)]
    public sealed partial class ObjectMana : Packet
    {
        [MemoryPackOrder(0)]
        public uint ObjectID;
        [MemoryPackOrder(1)]
        public byte Percent;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.MapEffect)]
    public sealed partial class MapEffect : Packet
    {
        [MemoryPackOrder(0)]
        public Point Location;
        [MemoryPackOrder(1)]
        public SpellEffect Effect;
        [MemoryPackOrder(2)]
        public byte Value;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.AllowObserve)]
    public sealed partial class AllowObserve : Packet
    {
        [MemoryPackOrder(0)]
        public bool Allow;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.ObjectRangeAttack)]
    public sealed partial class ObjectRangeAttack : Packet
    {
        [MemoryPackOrder(0)]
        public uint ObjectID;
        [MemoryPackOrder(1)]
        public Point Location;
        [MemoryPackOrder(2)]
        public MirDirection Direction;
        [MemoryPackOrder(3)]
        public uint TargetID;
        [MemoryPackOrder(4)]
        public Point Target;
        [MemoryPackOrder(5)]
        public byte Type;
        [MemoryPackOrder(6)]
        public Spell Spell;
        [MemoryPackOrder(7)]
        public byte Level;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.AddBuff)]
    public sealed partial class AddBuff : Packet
    {
        [MemoryPackOrder(0)]
        public ClientBuff Buff;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.RemoveBuff)]
    public sealed partial class RemoveBuff : Packet
    {
        [MemoryPackOrder(0)]
        public BuffType Type;
        [MemoryPackOrder(1)]
        public uint ObjectID;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.PauseBuff)]
    public sealed partial class PauseBuff : Packet
    {
        [MemoryPackOrder(0)]
        public BuffType Type;
        [MemoryPackOrder(1)]
        public uint ObjectID;
        [MemoryPackOrder(2)]
        public bool Paused;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.ObjectHidden)]
    public sealed partial class ObjectHidden : Packet
    {
        [MemoryPackOrder(0)]
        public uint ObjectID;
        [MemoryPackOrder(1)]
        public bool Hidden;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.RefreshItem)]
    public sealed partial class RefreshItem : Packet
    {
        [MemoryPackOrder(0)]
        public UserItem Item;

    }

    [MemoryPackable, Route((ushort)ServerPacketIds.ObjectSpell)]
    public sealed partial class ObjectSpell : Packet
    {
        [MemoryPackOrder(0)]
        public uint ObjectID;
        [MemoryPackOrder(1)]
        public Point Location;
        [MemoryPackOrder(2)]
        public Spell Spell;
        [MemoryPackOrder(3)]
        public MirDirection Direction;
        [MemoryPackOrder(4)]
        public bool Param;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.UserDash)]
    public sealed partial class UserDash : Packet
    {
        [MemoryPackOrder(0)]
        public Point Location;
        [MemoryPackOrder(1)]
        public MirDirection Direction;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.ObjectDash)]
    public sealed partial class ObjectDash : Packet
    {
        [MemoryPackOrder(0)]
        public uint ObjectID;
        [MemoryPackOrder(1)]
        public Point Location;
        [MemoryPackOrder(2)]
        public MirDirection Direction;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.UserDashFail)]
    public sealed partial class UserDashFail : Packet
    {
        [MemoryPackOrder(0)]
        public Point Location;
        [MemoryPackOrder(1)]
        public MirDirection Direction;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.ObjectDashFail)]
    public sealed partial class ObjectDashFail : Packet
    {
        [MemoryPackOrder(0)]
        public uint ObjectID;
        [MemoryPackOrder(1)]
        public Point Location;
        [MemoryPackOrder(2)]
        public MirDirection Direction;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.RemoveDelayedExplosion)]
    public sealed partial class RemoveDelayedExplosion : Packet
    {
        [MemoryPackOrder(0)]
        public uint ObjectID;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.NPCConsign)]
    public sealed partial class NPCConsign : Packet
    {

    }

    [MemoryPackable, Route((ushort)ServerPacketIds.NPCMarket)]
    public sealed partial class NPCMarket : Packet
    {
        [MemoryPackOrder(0)]
        public List<ClientAuction> Listings = new List<ClientAuction>();
        [MemoryPackOrder(1)]
        public int Pages;
        [MemoryPackOrder(2)]
        public bool UserMode;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.NPCMarketPage)]
    public sealed partial class NPCMarketPage : Packet
    {
        [MemoryPackOrder(0)]
        public List<ClientAuction> Listings = new List<ClientAuction>();
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.ConsignItem)]
    public sealed partial class ConsignItem : Packet
    {
        [MemoryPackOrder(0)]
        public ulong UniqueID;
        [MemoryPackOrder(1)]
        public bool Success;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.MarketFail)]
    public sealed partial class MarketFail : Packet
    {
        [MemoryPackOrder(0)]
        public byte Reason;

        /*
         * 0: Dead.
         * 1: Not talking to TrustMerchant.
         * 2: Already Sold.
         * 3: Expired.
         * 4: Not enough Gold.
         * 5: Not enough bag space.
         * 6: You cannot buy your own items.
         * 7: Trust Merchant is too far.
         * 8: Too much Gold.
         */
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.MarketSuccess)]
    public sealed partial class MarketSuccess : Packet
    {
        [MemoryPackOrder(0)]
        public string Message = string.Empty;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.ObjectSitDown)]
    public sealed partial class ObjectSitDown : Packet
    {
        [MemoryPackOrder(0)]
        public uint ObjectID;
        [MemoryPackOrder(1)]
        public Point Location;
        [MemoryPackOrder(2)]
        public MirDirection Direction;
        [MemoryPackOrder(3)]
        public bool Sitting;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.InTrapRock)]
    public sealed partial class InTrapRock : Packet
    {
        [MemoryPackOrder(0)]
        public bool Trapped;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.BaseStatsInfo)]
    public sealed partial class BaseStatsInfo : Packet
    {
        [MemoryPackOrder(0)]
        public BaseStats Stats;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.HeroBaseStatsInfo)]
    public sealed partial class HeroBaseStatsInfo : Packet
    {
        [MemoryPackOrder(0)]
        public BaseStats Stats;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.UserName)]
    public sealed partial class UserName : Packet
    {
        [MemoryPackOrder(0)]
        public uint Id;
        [MemoryPackOrder(1)]
        public string Name;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.ChatItemStats)]
    public sealed partial class ChatItemStats : Packet
    {
        [MemoryPackOrder(0)]
        public ulong ChatItemId;
        [MemoryPackOrder(1)]
        public UserItem Stats;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.GuildNoticeChange)]
    public sealed partial class GuildNoticeChange : Packet
    {
        [MemoryPackOrder(0)]
        public int update = 0;
        [MemoryPackOrder(1)]
        public List<string> notice = new List<string>();
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.GuildMemberChange)]
    public sealed partial class GuildMemberChange : Packet
    {
        [MemoryPackOrder(0)]
        public string Name = string.Empty;
        [MemoryPackOrder(1)]
        public byte Status = 0;
        [MemoryPackOrder(2)]
        public byte RankIndex = 0;
        [MemoryPackOrder(3)]
        public List<GuildRank> Ranks = new List<GuildRank>();
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.GuildStatus)]
    public sealed partial class GuildStatus : Packet
    {
        [MemoryPackOrder(0)]
        public string GuildName = string.Empty;
        [MemoryPackOrder(1)]
        public string GuildRankName = string.Empty;
        [MemoryPackOrder(2)]
        public byte Level;
        [MemoryPackOrder(3)]
        public long Experience;
        [MemoryPackOrder(4)]
        public long MaxExperience;
        [MemoryPackOrder(5)]
        public uint Gold;
        [MemoryPackOrder(6)]
        public byte SparePoints;
        [MemoryPackOrder(7)]
        public int MemberCount;
        [MemoryPackOrder(8)]
        public int MaxMembers;
        [MemoryPackOrder(9)]
        public bool Voting;
        [MemoryPackOrder(10)]
        public byte ItemCount;
        [MemoryPackOrder(11)]
        public byte BuffCount;
        [MemoryPackOrder(12)]
        public GuildRankOptions MyOptions;
        [MemoryPackOrder(13)]
        public int MyRankId;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.GuildInvite)]
    public sealed partial class GuildInvite : Packet
    {
        [MemoryPackOrder(0)]
        public string Name = string.Empty;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.GuildExpGain)]
    public sealed partial class GuildExpGain : Packet
    {
        [MemoryPackOrder(0)]
        public uint Amount = 0;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.GuildNameRequest)]
    public sealed partial class GuildNameRequest : Packet
    {

    }

    [MemoryPackable, Route((ushort)ServerPacketIds.GuildStorageGoldChange)]
    public sealed partial class GuildStorageGoldChange : Packet
    {
        [MemoryPackOrder(0)]
        public uint Amount = 0;
        [MemoryPackOrder(1)]
        public byte Type = 0;
        [MemoryPackOrder(2)]
        public string Name = string.Empty;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.GuildStorageItemChange)]
    public sealed partial class GuildStorageItemChange : Packet
    {
        [MemoryPackOrder(0)]
        public int User = 0;
        [MemoryPackOrder(1)]
        public byte Type = 0;
        [MemoryPackOrder(2)]
        public int To = 0;
        [MemoryPackOrder(3)]
        public int From = 0;
        [MemoryPackOrder(4)]
        public GuildStorageItem Item = null;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.GuildStorageList)]
    public sealed partial class GuildStorageList : Packet
    {
        [MemoryPackOrder(0)]
        public GuildStorageItem[] Items;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.GuildRequestWar)]
    public sealed partial class GuildRequestWar : Packet
    {

    }

    [MemoryPackable, Route((ushort)ServerPacketIds.HeroCreateRequest)]
    public sealed partial class HeroCreateRequest : Packet
    {
        [MemoryPackOrder(0)]
        public bool[] CanCreateClass;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.NewHero)]
    public sealed partial class NewHero : Packet
    {
        /*
         * 0: Disabled.
         * 1: Bad Character Name
         * 2: Bad Gender
         * 3: Bad Class
         * 4: Max Heroes
         * 5: Name Exists.
         * */
        [MemoryPackOrder(0)]
        public byte Result;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.HeroInformation)]
    public sealed partial class HeroInformation : UserInformation
    {
        [MemoryPackOrder(32)]
        public bool AutoPot;
        [MemoryPackOrder(33)]
        public byte AutoHPPercent;
        [MemoryPackOrder(34)]
        public byte AutoMPPercent;
        [MemoryPackOrder(35)]
        public int HPItemIndex;
        [MemoryPackOrder(36)]
        public int MPItemIndex;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.UpdateHeroSpawnState)]
    public sealed partial class UpdateHeroSpawnState : Packet
    {
        [MemoryPackOrder(0)]
        public HeroSpawnState State;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.UnlockHeroAutoPot)]
    public sealed partial class UnlockHeroAutoPot : Packet
    {

    }

    [MemoryPackable, Route((ushort)ServerPacketIds.SetAutoPotValue)]
    public sealed partial class SetAutoPotValue : Packet
    {
        [MemoryPackOrder(0)]
        public Stat Stat;
        [MemoryPackOrder(1)]
        public uint Value;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.SetAutoPotItem)]
    public sealed partial class SetAutoPotItem : Packet
    {
        [MemoryPackOrder(0)]
        public MirGridType Grid;
        [MemoryPackOrder(1)]
        public int ItemIndex;

    }

    [MemoryPackable, Route((ushort)ServerPacketIds.SetHeroBehaviour)]
    public sealed partial class SetHeroBehaviour : Packet
    {
        [MemoryPackOrder(0)]
        public HeroBehaviour Behaviour;

    }

    [MemoryPackable, Route((ushort)ServerPacketIds.ManageHeroes)]
    public sealed partial class ManageHeroes : Packet
    {
        [MemoryPackOrder(0)]
        public int MaximumCount;
        [MemoryPackOrder(1)]
        public ClientHeroInformation CurrentHero;
        [MemoryPackOrder(2)]
        public ClientHeroInformation[] Heroes;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.ChangeHero)]
    public sealed partial class ChangeHero : Packet
    {
        [MemoryPackOrder(0)]
        public int FromIndex;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.DefaultNPC)]
    public sealed partial class DefaultNPC : Packet
    {
        [MemoryPackOrder(0)]
        public uint ObjectID;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.NPCUpdate)]
    public sealed partial class NPCUpdate : Packet
    {
        [MemoryPackOrder(0)]
        public uint NPCID;
    }


    [MemoryPackable, Route((ushort)ServerPacketIds.NPCImageUpdate)]
    public sealed partial class NPCImageUpdate : Packet
    {
        [MemoryPackOrder(0)]
        public long ObjectID;
        [MemoryPackOrder(1)]
        public ushort Image;
        [MemoryPackOrder(2), MemoryPackAllowSerialize]
        public Color Colour;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.MountUpdate)]
    public sealed partial class MountUpdate : Packet
    {
        [MemoryPackOrder(0)]
        public long ObjectID;
        [MemoryPackOrder(1)]
        public short MountType;
        [MemoryPackOrder(2)]
        public bool RidingMount;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.TransformUpdate)]
    public sealed partial class TransformUpdate : Packet
    {
        [MemoryPackOrder(0)]
        public long ObjectID;
        [MemoryPackOrder(1)]
        public short TransformType;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.EquipSlotItem)]
    public sealed partial class EquipSlotItem : Packet
    {
        [MemoryPackOrder(0)]
        public MirGridType Grid;
        [MemoryPackOrder(1)]
        public ulong UniqueID;
        [MemoryPackOrder(2)]
        public int To;
        [MemoryPackOrder(3)]
        public bool Success;
        [MemoryPackOrder(4)]
        public MirGridType GridTo;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.FishingUpdate)]
    public sealed partial class FishingUpdate : Packet
    {
        [MemoryPackOrder(0)]
        public long ObjectID;
        [MemoryPackOrder(1)]
        public bool Fishing;
        [MemoryPackOrder(2)]
        public int ProgressPercent;
        [MemoryPackOrder(3)]
        public int ChancePercent;
        [MemoryPackOrder(4)]
        public Point FishingPoint;
        [MemoryPackOrder(5)]
        public bool FoundFish;
    }

    //public sealed partial class UpdateQuests : Packet
    //{
    //    public override short Index
    //    {
    //        get { return (short)ServerPacketIds.UpdateQuests; }
    //    }

    //    public List<ClientQuestProgress> CurrentQuests = new List<ClientQuestProgress>();
    //    public List<int> CompletedQuests = new List<int>();

    //    protected override void ReadPacket(BinaryReader reader)
    //    {
    //        int count = reader.ReadInt32();
    //        for (var i = 0; i < count; i++)
    //            CurrentQuests.Add(new ClientQuestProgress(reader));

    //        count = reader.ReadInt32();
    //        for (var i = 0; i < count; i++)
    //            CompletedQuests.Add(reader.ReadInt32());
    //    }
    //    protected override void WritePacket(BinaryWriter writer)
    //    {
    //        writer.Write(CurrentQuests.Count);
    //        foreach (var q in CurrentQuests)
    //            q.Save(writer);

    //        writer.Write(CompletedQuests.Count);
    //        foreach (int q in CompletedQuests)
    //            writer.Write(q);
    //    }
    //}


    [MemoryPackable, Route((ushort)ServerPacketIds.ChangeQuest)]
    public sealed partial class ChangeQuest : Packet
    {
        [MemoryPackOrder(0)]
        public ClientQuestProgress Quest = new ClientQuestProgress();
        [MemoryPackOrder(1)]
        public QuestState QuestState;
        [MemoryPackOrder(2)]
        public bool TrackQuest;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.CompleteQuest)]
    public sealed partial class CompleteQuest : Packet
    {
        [MemoryPackOrder(0)]
        public List<int> CompletedQuests = new List<int>();
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.ShareQuest)]
    public sealed partial class ShareQuest : Packet
    {
        [MemoryPackOrder(0)]
        public int QuestIndex;
        [MemoryPackOrder(1)]
        public string SharerName;
    }


    [MemoryPackable, Route((ushort)ServerPacketIds.NewQuestInfo)]
    public sealed partial class NewQuestInfo : Packet
    {
        [MemoryPackOrder(0)]
        public ClientQuestInfo Info;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.GainedQuestItem)]
    public sealed partial class GainedQuestItem : Packet
    {
        [MemoryPackOrder(0)]
        public UserItem Item;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.DeleteQuestItem)]
    public sealed partial class DeleteQuestItem : Packet
    {
        [MemoryPackOrder(0)]
        public ulong UniqueID;
        [MemoryPackOrder(1)]
        public ushort Count;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.GameShopInfo)]
    public sealed partial class GameShopInfo : Packet
    {
        [MemoryPackOrder(0)]
        public GameShopItem Item;
        [MemoryPackOrder(1)]
        public int StockLevel;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.GameShopStock)]
    public sealed partial class GameShopStock : Packet
    {
        [MemoryPackOrder(0)]
        public int GIndex;
        [MemoryPackOrder(1)]
        public int StockLevel;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.CancelReincarnation)]
    public sealed partial class CancelReincarnation : Packet
    {

    }

    [MemoryPackable, Route((ushort)ServerPacketIds.RequestReincarnation)]
    public sealed partial class RequestReincarnation : Packet
    {

    }

    [MemoryPackable, Route((ushort)ServerPacketIds.UserBackStep)]
    public sealed partial class UserBackStep : Packet
    {
        [MemoryPackOrder(0)]
        public Point Location;
        [MemoryPackOrder(1)]
        public MirDirection Direction;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.ObjectBackStep)]
    public sealed partial class ObjectBackStep : Packet
    {
        [MemoryPackOrder(0)]
        public uint ObjectID;
        [MemoryPackOrder(1)]
        public Point Location;
        [MemoryPackOrder(2)]
        public MirDirection Direction;
        [MemoryPackOrder(3)]
        public int Distance;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.UserDashAttack)]
    public sealed partial class UserDashAttack : Packet
    {
        [MemoryPackOrder(0)]
        public Point Location;
        [MemoryPackOrder(1)]
        public MirDirection Direction;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.ObjectDashAttack)]
    public sealed partial class ObjectDashAttack : Packet
    {
        [MemoryPackOrder(0)]
        public uint ObjectID;
        [MemoryPackOrder(1)]
        public Point Location;
        [MemoryPackOrder(2)]
        public MirDirection Direction;
        [MemoryPackOrder(3)]
        public int Distance;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.UserAttackMove)]
    public sealed partial class UserAttackMove : Packet //warrior skill - SlashingBurst move packet 
    {
        [MemoryPackOrder(0)]
        public Point Location;
        [MemoryPackOrder(1)]
        public MirDirection Direction;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.CombineItem)]
    public sealed partial class CombineItem : Packet
    {
        [MemoryPackOrder(0)]
        public MirGridType Grid;
        [MemoryPackOrder(1)]
        public ulong IDFrom;
        [MemoryPackOrder(2)]
        public ulong IDTo;
        [MemoryPackOrder(3)]
        public bool Success;
        [MemoryPackOrder(4)]
        public bool Destroy;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.ItemUpgraded)]
    public sealed partial class ItemUpgraded : Packet
    {
        [MemoryPackOrder(0)]
        public UserItem Item;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.SetConcentration)]
    public sealed partial class SetConcentration : Packet
    {
        [MemoryPackOrder(0)]
        public uint ObjectID;
        [MemoryPackOrder(1)]
        public bool Enabled;
        [MemoryPackOrder(2)]
        public bool Interrupted;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.SetElemental)]
    public sealed partial class SetElemental : Packet
    {
        [MemoryPackOrder(0)]
        public uint ObjectID;
        [MemoryPackOrder(1)]
        public bool Enabled;
        [MemoryPackOrder(2)]
        public bool Casted;
        [MemoryPackOrder(3)]
        public uint Value;
        [MemoryPackOrder(4)]
        public uint ElementType;
        [MemoryPackOrder(5)]
        public uint ExpLast;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.ObjectDeco)]
    public sealed partial class ObjectDeco : Packet
    {
        [MemoryPackOrder(0)]
        public uint ObjectID;
        [MemoryPackOrder(1)]
        public Point Location;
        [MemoryPackOrder(2)]
        public int Image;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.ObjectSneaking)]
    public sealed partial class ObjectSneaking : Packet
    {
        [MemoryPackOrder(0)]
        public uint ObjectID;
        [MemoryPackOrder(1)]
        public bool SneakingActive;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.ObjectLevelEffects)]
    public sealed partial class ObjectLevelEffects : Packet
    {
        [MemoryPackOrder(0)]
        public uint ObjectID;
        [MemoryPackOrder(1)]
        public LevelEffects LevelEffects;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.SetBindingShot)]
    public sealed partial class SetBindingShot : Packet
    {
        [MemoryPackOrder(0)]
        public uint ObjectID;
        [MemoryPackOrder(1)]
        public bool Enabled;
        [MemoryPackOrder(2)]
        public long Value;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.SendOutputMessage)]
    public sealed partial class SendOutputMessage : Packet
    {
        [MemoryPackOrder(0)]
        public string Message;
        [MemoryPackOrder(1)]
        public OutputMessageType Type;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.NPCAwakening)]
    public sealed partial class NPCAwakening : Packet
    {

    }

    [MemoryPackable, Route((ushort)ServerPacketIds.NPCDisassemble)]
    public sealed partial class NPCDisassemble : Packet
    {

    }

    [MemoryPackable, Route((ushort)ServerPacketIds.NPCDowngrade)]
    public sealed partial class NPCDowngrade : Packet
    {

    }

    [MemoryPackable, Route((ushort)ServerPacketIds.NPCReset)]
    public sealed partial class NPCReset : Packet
    {

    }

    [MemoryPackable, Route((ushort)ServerPacketIds.AwakeningNeedMaterials)]
    public sealed partial class AwakeningNeedMaterials : Packet
    {
        [MemoryPackOrder(0)]
        public ItemInfo[] Materials;
        [MemoryPackOrder(1)]
        public byte[] MaterialsCount;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.AwakeningLockedItem)]
    public sealed partial class AwakeningLockedItem : Packet
    {
        [MemoryPackOrder(0)]
        public ulong UniqueID;
        [MemoryPackOrder(1)]
        public bool Locked;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.Awakening)]
    public sealed partial class Awakening : Packet
    {
        [MemoryPackOrder(0)]
        public int result;
        [MemoryPackOrder(1)]
        public long removeID = -1;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.ReceiveMail)]
    public sealed partial class ReceiveMail : Packet
    {
        [MemoryPackOrder(0)]
        public List<ClientMail> Mail = new List<ClientMail>();
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.MailLockedItem)]
    public sealed partial class MailLockedItem : Packet
    {
        [MemoryPackOrder(0)]
        public ulong UniqueID;
        [MemoryPackOrder(1)]
        public bool Locked;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.MailSent)]
    public sealed partial class MailSent : Packet
    {
        [MemoryPackOrder(0)]
        public sbyte Result;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.MailSendRequest)]
    public sealed partial class MailSendRequest : Packet
    {

    }

    [MemoryPackable, Route((ushort)ServerPacketIds.ParcelCollected)]
    public sealed partial class ParcelCollected : Packet
    {
        [MemoryPackOrder(0)]
        public sbyte Result;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.MailCost)]
    public sealed partial class MailCost : Packet
    {
        [MemoryPackOrder(0)]
        public uint Cost;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.ResizeInventory)]
    public sealed partial class ResizeInventory : Packet
    {
        [MemoryPackOrder(0)]
        public int Size;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.ResizeStorage)]
    public sealed partial class ResizeStorage : Packet
    {
        [MemoryPackOrder(0)]
        public int Size;
        [MemoryPackOrder(1)]
        public bool HasExpandedStorage;
        [MemoryPackOrder(2)]
        public DateTime ExpiryTime;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.NewIntelligentCreature)]
    public sealed partial class NewIntelligentCreature : Packet
    {
        [MemoryPackOrder(0)]
        public ClientIntelligentCreature Creature;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.UpdateIntelligentCreatureList)]
    public sealed partial class UpdateIntelligentCreatureList : Packet
    {
        [MemoryPackOrder(0)]
        public List<ClientIntelligentCreature> CreatureList = new List<ClientIntelligentCreature>();
        [MemoryPackOrder(1)]
        public bool CreatureSummoned = false;
        [MemoryPackOrder(2)]
        public IntelligentCreatureType SummonedCreatureType = IntelligentCreatureType.None;
        [MemoryPackOrder(3)]
        public int PearlCount = 0;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.IntelligentCreatureEnableRename)]
    public sealed partial class IntelligentCreatureEnableRename : Packet
    {

    }

    [MemoryPackable, Route((ushort)ServerPacketIds.IntelligentCreaturePickup)]
    public sealed partial class IntelligentCreaturePickup : Packet
    {
        [MemoryPackOrder(0)]
        public uint ObjectID;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.NPCPearlGoods)]
    public sealed partial class NPCPearlGoods : Packet
    {
        [MemoryPackOrder(0)]
        public List<UserItem> List = new List<UserItem>();
        [MemoryPackOrder(1)]
        public float Rate;
        [MemoryPackOrder(2)]
        public PanelType Type;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.FriendUpdate)]
    public sealed partial class FriendUpdate : Packet
    {
        [MemoryPackOrder(0)]
        public List<ClientFriend> Friends = new List<ClientFriend>();
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.GuildBuffList)]
    public sealed partial class GuildBuffList : Packet
    {
        [MemoryPackOrder(0)]
        public byte Remove = 0;
        [MemoryPackOrder(1)]
        public List<GuildBuff> ActiveBuffs = new List<GuildBuff>();
        [MemoryPackOrder(2)]
        public List<GuildBuffInfo> GuildBuffs = new List<GuildBuffInfo>();
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.LoverUpdate)]
    public sealed partial class LoverUpdate : Packet
    {
        [MemoryPackOrder(0)]
        public string Name;
        [MemoryPackOrder(1)]
        public DateTime Date;
        [MemoryPackOrder(2)]
        public string MapName;
        [MemoryPackOrder(3)]
        public short MarriedDays;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.MentorUpdate)]
    public sealed partial class MentorUpdate : Packet
    {
        [MemoryPackOrder(0)]
        public string Name;
        [MemoryPackOrder(1)]
        public ushort Level;
        [MemoryPackOrder(2)]
        public bool Online;
        [MemoryPackOrder(3)]
        public long MenteeEXP;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.NPCRequestInput)]
    public sealed partial class NPCRequestInput : Packet
    {
        [MemoryPackOrder(0)]
        public uint NPCID;
        [MemoryPackOrder(1)]
        public string PageName;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.Rankings)]
    public sealed partial class Rankings : Packet
    {
        public override bool Observable
        {
            get { return false; }
        }

        [MemoryPackOrder(0)]
        public byte RankType = 0;
        [MemoryPackOrder(1)]
        public int MyRank = 0;
        [MemoryPackOrder(2)]
        public List<RankCharacterInfo> ListingDetails = new List<RankCharacterInfo>();
        [MemoryPackOrder(3)]
        public List<long> Listings = new List<long>();
        [MemoryPackOrder(4)]
        public int Count;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.Opendoor)]
    public sealed partial class Opendoor : Packet
    {
        [MemoryPackOrder(0)]
        public bool Close = false;
        [MemoryPackOrder(1)]
        public byte DoorIndex;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.GetRentedItems)]
    public sealed partial class GetRentedItems : Packet
    {
        [MemoryPackOrder(0)]
        public List<ItemRentalInformation> RentedItems = new List<ItemRentalInformation>();
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.ItemRentalRequest)]
    public sealed partial class ItemRentalRequest : Packet
    {
        [MemoryPackOrder(0)]
        public string Name;
        [MemoryPackOrder(1)]
        public bool Renting;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.ItemRentalFee)]
    public sealed partial class ItemRentalFee : Packet
    {
        [MemoryPackOrder(0)]
        public uint Amount;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.ItemRentalPeriod)]
    public sealed partial class ItemRentalPeriod : Packet
    {
        [MemoryPackOrder(0)]
        public uint Days;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.DepositRentalItem)]
    public sealed partial class DepositRentalItem : Packet
    {
        [MemoryPackOrder(0)]
        public int From;
        [MemoryPackOrder(1)]
        public int To;
        [MemoryPackOrder(2)]
        public bool Success;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.RetrieveRentalItem)]
    public sealed partial class RetrieveRentalItem : Packet
    {
        [MemoryPackOrder(0)]
        public int From;
        [MemoryPackOrder(1)]
        public int To;
        [MemoryPackOrder(2)]
        public bool Success;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.UpdateRentalItem)]
    public sealed partial class UpdateRentalItem : Packet
    {
        [MemoryPackOrder(0)]
        public bool HasData;
        [MemoryPackOrder(1)]
        public UserItem LoanItem;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.CancelItemRental)]
    public sealed partial class CancelItemRental : Packet
    {

    }

    [MemoryPackable, Route((ushort)ServerPacketIds.ItemRentalLock)]
    public sealed partial class ItemRentalLock : Packet
    {
        [MemoryPackOrder(0)]
        public bool Success;
        [MemoryPackOrder(1)]
        public bool GoldLocked;
        [MemoryPackOrder(2)]
        public bool ItemLocked;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.ItemRentalPartnerLock)]
    public sealed partial class ItemRentalPartnerLock : Packet
    {
        [MemoryPackOrder(0)]
        public bool GoldLocked;
        [MemoryPackOrder(1)]
        public bool ItemLocked;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.CanConfirmItemRental)]
    public sealed partial class CanConfirmItemRental : Packet
    {

    }

    [MemoryPackable, Route((ushort)ServerPacketIds.ConfirmItemRental)]
    public sealed partial class ConfirmItemRental : Packet
    {

    }


    [MemoryPackable, Route((ushort)ServerPacketIds.NewRecipeInfo)]
    public sealed partial class NewRecipeInfo : Packet
    {
        [MemoryPackOrder(0)]
        public ClientRecipeInfo Info;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.CraftItem)]
    public sealed partial class CraftItem : Packet
    {
        [MemoryPackOrder(0)]
        public bool Success;
    }


    [MemoryPackable, Route((ushort)ServerPacketIds.OpenBrowser)]
    public sealed partial class OpenBrowser : Packet
    {
        [MemoryPackOrder(0)]
        public string Url;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.PlaySound)]
    public sealed partial class PlaySound : Packet
    {
        [MemoryPackOrder(0)]
        public int Sound;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.SetTimer)]
    public sealed partial class SetTimer : Packet
    {
        [MemoryPackOrder(0)]
        public string Key;
        [MemoryPackOrder(1)]
        public byte Type;
        [MemoryPackOrder(2)]
        public int Seconds;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.ExpireTimer)]
    public sealed partial class ExpireTimer : Packet
    {
        [MemoryPackOrder(0)]
        public string Key;
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.UpdateNotice)]
    public sealed partial class UpdateNotice : Packet
    {
        [MemoryPackOrder(0)]
        public Notice Notice = new Notice();
    }

    [MemoryPackable, Route((ushort)ServerPacketIds.Roll)]
    public sealed partial class Roll : Packet
    {
        [MemoryPackOrder(0)]
        public int Type;
        [MemoryPackOrder(1)]
        public string Page;
        [MemoryPackOrder(2)]
        public int Result;
        [MemoryPackOrder(3)]
        public bool AutoRoll;
    }


    [MemoryPackable, Route((ushort)ServerPacketIds.SetCompass)]
    public sealed partial class SetCompass : Packet
    {
        [MemoryPackOrder(0)]
        public Point Location;
    }
}