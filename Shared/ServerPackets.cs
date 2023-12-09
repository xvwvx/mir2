using System.Drawing;
using System.Runtime.Serialization;
using MessagePack;
using Shared;

namespace ServerPackets
{
    [MessagePackObject, Route((ushort)ServerPacketIds.KeepAlive)]
    public sealed class KeepAlive : Packet
    {
        [Key(0)]
        public long Time;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.Connected)]
    public sealed class Connected : Packet
    {

    }

    [MessagePackObject, Route((ushort)ServerPacketIds.ClientVersion)]
    public sealed class ClientVersion : Packet
    {
        [Key(0)]
        public byte Result;

        /*
        * 0: Wrong Version
        * 1: Correct Version
        */
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.Disconnect)]
    public sealed class Disconnect : Packet
    {
        [Key(0)]
        public byte Reason;

        /*
         * 0: Server Closing.
         * 1: Another User.
         * 2: Packet Error.
         * 3: Server Crashed.
         */

    }

    [MessagePackObject, Route((ushort)ServerPacketIds.NewAccount)]
    public sealed class NewAccount : Packet
    {
        [Key(0)]
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

    [MessagePackObject, Route((ushort)ServerPacketIds.ChangePassword)]
    public sealed class ChangePassword : Packet
    {
        [Key(0)]
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

    [MessagePackObject, Route((ushort)ServerPacketIds.ChangePasswordBanned)]
    public sealed class ChangePasswordBanned : Packet
    {
        [Key(0)]
        public string Reason = string.Empty;
        [Key(1)]
        public DateTime ExpiryDate;

    }

    [MessagePackObject, Route((ushort)ServerPacketIds.Login)]
    public sealed class Login : Packet
    {
        [Key(0)]
        public byte Result;

        /*
        * 0: Disabled
        * 1: Bad AccountID
        * 2: Bad Password
        * 3: Account Not Exist
        * 4: Wrong Password
        */
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.LoginBanned)]
    public sealed class LoginBanned : Packet
    {
        [Key(0)]
        public string Reason = string.Empty;
        [Key(1)]
        public DateTime ExpiryDate;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.LoginSuccess)]
    public sealed class LoginSuccess : Packet
    {
        [Key(0)]
        public List<SelectInfo> Characters = new List<SelectInfo>();
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.NewCharacter)]
    public sealed class NewCharacter : Packet
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
        [Key(0)]
        public byte Result;

    }

    [MessagePackObject, Route((ushort)ServerPacketIds.NewCharacterSuccess)]
    public sealed class NewCharacterSuccess : Packet
    {
        [Key(0)]
        public SelectInfo CharInfo;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.DeleteCharacter)]
    public sealed class DeleteCharacter : Packet
    {
        [Key(0)]
        public byte Result;

        /*
         * 0: Disabled.
         * 1: Character Not Found
         * */
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.DeleteCharacterSuccess)]
    public sealed class DeleteCharacterSuccess : Packet
    {
        [Key(0)]
        public int CharacterIndex;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.StartGame)]
    public sealed class StartGame : Packet
    {
        [Key(0)]
        public byte Result;
        [Key(1)]
        public int Resolution;

        /*
         * 0: Disabled.
         * 1: Not logged in
         * 2: Character not found.
         * 3: Start Game Error
         * */
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.StartGameBanned)]
    public sealed class StartGameBanned : Packet
    {
        [Key(0)]
        public string Reason = string.Empty;
        [Key(1)]
        public DateTime ExpiryDate;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.StartGameDelay)]
    public sealed class StartGameDelay : Packet
    {
        [Key(0)]
        public long Milliseconds;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.MapInformation)]
    public sealed class MapInformation : Packet
    {
        [Key(0)]
        public int MapIndex;
        [Key(1)]
        public string FileName = string.Empty;
        [Key(2)]
        public string Title = string.Empty;
        [Key(3)]
        public ushort MiniMap;
        [Key(4)]
        public ushort BigMap;
        [Key(5)]
        public ushort Music;
        [Key(6)]
        public LightSetting Lights;
        [Key(7)]
        public bool Lightning;
        [Key(8)]
        public bool Fire;
        [Key(9)]
        public byte MapDarkLight;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.NewMapInfo)]
    public sealed class NewMapInfo : Packet
    {
        [Key(0)]
        public int MapIndex;
        [Key(1)]
        public ClientMapInfo Info;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.WorldMapSetup)]
    public sealed class WorldMapSetupInfo : Packet
    {
        [Key(0)]
        public WorldMapSetup Setup;
        [Key(1)]
        public int TeleportToNPCCost;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.SearchMapResult)]
    public sealed class SearchMapResult : Packet
    {
        [Key(0)]
        public int MapIndex = -1;
        [Key(1)]
        public uint NPCIndex;

    }

    [MessagePackObject, Route((ushort)ServerPacketIds.UserInformation)]
    public class UserInformation : Packet
    {
        [Key(0)]
        public uint ObjectID;
        [Key(1)]
        public uint RealId;
        [Key(2)]
        public string Name = string.Empty;
        [Key(3)]
        public string GuildName = string.Empty;
        [Key(4)]
        public string GuildRank = string.Empty;
        [Key(5)]
        public Color NameColour;
        [Key(6)]
        public MirClass Class;
        [Key(7)]
        public MirGender Gender;
        [Key(8)]
        public ushort Level;
        [Key(9)]
        public Point Location;
        [Key(10)]
        public MirDirection Direction;
        [Key(11)]
        public byte Hair;
        [Key(12)]
        public int HP;
        [Key(13)]
        public int MP;
        [Key(14)]
        public long Experience;
        [Key(15)]
        public long MaxExperience;
        [Key(16)]
        public LevelEffects LevelEffects;
        [Key(17)]
        public bool HasHero;
        [Key(18)]
        public HeroBehaviour HeroBehaviour;
        [Key(19)]
        public UserItem[] Inventory;
        [Key(20)]
        public UserItem[] Equipment;
        [Key(21)]
        public UserItem[] QuestInventory;
        [Key(22)]
        public uint Gold;
        [Key(23)]
        public uint Credit;
        [Key(24)]
        public bool HasExpandedStorage;
        [Key(25)]
        public DateTime ExpandedStorageExpiryTime;
        [Key(26)]
        public List<ClientMagic> Magics = new List<ClientMagic>();
        [Key(27)]
        public List<ClientIntelligentCreature> IntelligentCreatures = new List<ClientIntelligentCreature>();
        [Key(28)]
        public IntelligentCreatureType SummonedCreatureType = IntelligentCreatureType.None;
        [Key(29)]
        public bool CreatureSummoned;
        [Key(30)]
        public bool AllowObserve;
        [Key(31)]
        public bool Observer;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.UserSlotsRefresh)]
    public sealed class UserSlotsRefresh : Packet
    {
        [Key(0)]
        public UserItem[] Inventory;
        [Key(1)]
        public UserItem[] Equipment;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.UserLocation)]
    public sealed class UserLocation : Packet
    {
        [IgnoreMember]
        public override bool Observable
        {
            get { return false; }
        }

        [Key(0)]
        public Point Location;
        [Key(1)]
        public MirDirection Direction;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.ObjectPlayer)]
    public class ObjectPlayer : Packet
    {
        [Key(0)]
        public uint ObjectID;
        [Key(1)]
        public string Name = string.Empty;
        [Key(2)]
        public string GuildName = string.Empty;
        [Key(3)]
        public string GuildRankName = string.Empty;
        [Key(4)]
        public Color NameColour;
        [Key(5)]
        public MirClass Class;
        [Key(6)]
        public MirGender Gender;
        [Key(7)]
        public ushort Level;
        [Key(8)]
        public Point Location;
        [Key(9)]
        public MirDirection Direction;
        [Key(10)]
        public byte Hair;
        [Key(11)]
        public byte Light;
        [Key(12)]
        public short Weapon;
        [Key(13)]
        public short WeaponEffect;
        [Key(14)]
        public short Armour;
        [Key(15)]
        public PoisonType Poison;
        [Key(16)]
        public bool Dead;
        [Key(17)]
        public bool Hidden;
        [Key(18)]
        public SpellEffect Effect;
        [Key(19)]
        public byte WingEffect;
        [Key(20)]
        public bool Extra;
        [Key(21)]
        public short MountType;
        [Key(22)]
        public bool RidingMount;
        [Key(23)]
        public bool Fishing;
        [Key(24)]
        public short TransformType;
        [Key(25)]
        public uint ElementOrbEffect;
        [Key(26)]
        public uint ElementOrbLvl;
        [Key(27)]
        public uint ElementOrbMax;
        [Key(28)]
        public LevelEffects LevelEffects;
        [Key(29)]
        public List<BuffType> Buffs = new List<BuffType>();
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.ObjectHero)]
    public sealed class ObjectHero : ObjectPlayer
    {
        [Key(30)]
        public string OwnerName;

    }

    [MessagePackObject, Route((ushort)ServerPacketIds.ObjectRemove)]
    public sealed class ObjectRemove : Packet
    {
        [Key(0)]
        public uint ObjectID;

    }

    [MessagePackObject, Route((ushort)ServerPacketIds.ObjectTurn)]
    public sealed class ObjectTurn : Packet
    {
        [Key(0)]
        public uint ObjectID;
        [Key(1)]
        public Point Location;
        [Key(2)]
        public MirDirection Direction;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.ObjectWalk)]
    public sealed class ObjectWalk : Packet
    {
        [Key(0)]
        public uint ObjectID;
        [Key(1)]
        public Point Location;
        [Key(2)]
        public MirDirection Direction;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.ObjectRun)]
    public sealed class ObjectRun : Packet
    {
        [Key(0)]
        public uint ObjectID;
        [Key(1)]
        public Point Location;
        [Key(2)]
        public MirDirection Direction;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.Chat)]
    public sealed class Chat : Packet
    {
        [IgnoreMember]
        public override bool Observable
        {
            get { return Type != ChatType.WhisperIn && Type != ChatType.WhisperOut; }
        }

        [Key(0)]
        public string Message = string.Empty;
        [Key(1)]
        public ChatType Type;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.ObjectChat)]
    public sealed class ObjectChat : Packet
    {
        [Key(0)]
        public uint ObjectID;
        [Key(1)]
        public string Text = string.Empty;
        [Key(2)]
        public ChatType Type;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.NewItemInfo)]
    public sealed class NewItemInfo : Packet
    {
        [Key(0)]
        public ItemInfo Info;

    }

    [MessagePackObject, Route((ushort)ServerPacketIds.NewHeroInfo)]
    public sealed class NewHeroInfo : Packet
    {
        [Key(0)]
        public ClientHeroInformation Info;
        [Key(1)]
        public int StorageIndex = -1;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.NewChatItem)]
    public sealed class NewChatItem : Packet
    {
        [Key(0)]
        public UserItem Item;

    }

    [MessagePackObject, Route((ushort)ServerPacketIds.MoveItem)]
    public sealed class MoveItem : Packet
    {
        [Key(0)]
        public MirGridType Grid;
        [Key(1)]
        public int From;
        [Key(2)]
        public int To;
        [Key(3)]
        public bool Success;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.EquipItem)]
    public sealed class EquipItem : Packet
    {
        [Key(0)]
        public MirGridType Grid;
        [Key(1)]
        public ulong UniqueID;
        [Key(2)]
        public int To;
        [Key(3)]
        public bool Success;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.MergeItem)]
    public sealed class MergeItem : Packet
    {
        [Key(0)]
        public MirGridType GridFrom;
        [Key(1)]
        public MirGridType GridTo;
        [Key(2)]
        public ulong IDFrom;
        [Key(3)]
        public ulong IDTo;
        [Key(4)]
        public bool Success;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.RemoveItem)]
    public sealed class RemoveItem : Packet
    {
        [Key(0)]
        public MirGridType Grid;
        [Key(1)]
        public ulong UniqueID;
        [Key(2)]
        public int To;
        [Key(3)]
        public bool Success;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.RemoveSlotItem)]
    public sealed class RemoveSlotItem : Packet
    {
        [Key(0)]
        public MirGridType Grid;
        [Key(1)]
        public MirGridType GridTo;
        [Key(2)]
        public ulong UniqueID;
        [Key(3)]
        public int To;
        [Key(4)]
        public bool Success;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.TakeBackItem)]
    public sealed class TakeBackItem : Packet
    {
        [Key(0)]
        public int From;
        [Key(1)]
        public int To;
        [Key(2)]
        public bool Success;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.StoreItem)]
    public sealed class StoreItem : Packet
    {
        [Key(0)]
        public int From;
        [Key(1)]
        public int To;
        [Key(2)]
        public bool Success;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.DepositRefineItem)]
    public sealed class DepositRefineItem : Packet
    {
        [Key(0)]
        public int From;
        [Key(1)]
        public int To;
        [Key(2)]
        public bool Success;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.RetrieveRefineItem)]
    public sealed class RetrieveRefineItem : Packet
    {
        [Key(0)]
        public int From;
        [Key(1)]
        public int To;
        [Key(2)]
        public bool Success;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.RefineCancel)]
    public sealed class RefineCancel : Packet
    {
        [Key(0)]
        public bool Unlock;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.RefineItem)]
    public sealed class RefineItem : Packet
    {
        [Key(0)]
        public ulong UniqueID;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.DepositTradeItem)]
    public sealed class DepositTradeItem : Packet
    {
        [Key(0)]
        public int From;
        [Key(1)]
        public int To;
        [Key(2)]
        public bool Success;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.RetrieveTradeItem)]
    public sealed class RetrieveTradeItem : Packet
    {
        [Key(0)]
        public int From;
        [Key(1)]
        public int To;
        [Key(2)]
        public bool Success;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.SplitItem)]
    public sealed class SplitItem : Packet
    {
        [Key(0)]
        public UserItem Item;
        [Key(1)]
        public MirGridType Grid;

    }

    [MessagePackObject, Route((ushort)ServerPacketIds.SplitItem1)]
    public sealed class SplitItem1 : Packet
    {
        [Key(0)]
        public MirGridType Grid;
        [Key(1)]
        public ulong UniqueID;
        [Key(2)]
        public ushort Count;
        [Key(3)]
        public bool Success;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.UseItem)]
    public sealed class UseItem : Packet
    {
        [Key(0)]
        public ulong UniqueID;
        [Key(1)]
        public bool Success;
        [Key(2)]
        public MirGridType Grid;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.DropItem)]
    public sealed class DropItem : Packet
    {
        [Key(0)]
        public ulong UniqueID;
        [Key(1)]
        public ushort Count;
        [Key(2)]
        public bool HeroItem = false;
        [Key(3)]
        public bool Success;

    }

    [MessagePackObject, Route((ushort)ServerPacketIds.TakeBackHeroItem)]
    public sealed class TakeBackHeroItem : Packet
    {
        [Key(0)]
        public int From;
        [Key(1)]
        public int To;
        [Key(2)]
        public bool Success;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.TransferHeroItem)]
    public sealed class TransferHeroItem : Packet
    {
        [Key(0)]
        public int From;
        [Key(1)]
        public int To;
        [Key(2)]
        public bool Success;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.PlayerUpdate)]
    public sealed class PlayerUpdate : Packet
    {
        [Key(0)]
        public uint ObjectID;
        [Key(1)]
        public byte Light;
        [Key(2)]
        public short Weapon;
        [Key(3)]
        public short WeaponEffect;
        [Key(4)]
        public short Armour;
        [Key(5)]
        public byte WingEffect;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.PlayerInspect)]
    public sealed class PlayerInspect : Packet
    {
        [IgnoreMember]
        public override bool Observable
        {
            get { return false; }
        }

        [Key(0)]
        public string Name = string.Empty;
        [Key(1)]
        public string GuildName = string.Empty;
        [Key(2)]
        public string GuildRank = string.Empty;
        [Key(3)]
        public UserItem[] Equipment;
        [Key(4)]
        public MirClass Class;
        [Key(5)]
        public MirGender Gender;
        [Key(6)]
        public byte Hair;
        [Key(7)]
        public ushort Level;
        [Key(8)]
        public string LoverName;
        [Key(9)]
        public bool AllowObserve;
        [Key(10)]
        public bool IsHero = false;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.MarriageRequest)]
    public sealed class MarriageRequest : Packet
    {
        [Key(0)]
        public string Name;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.DivorceRequest)]
    public sealed class DivorceRequest : Packet
    {
        [Key(0)]
        public string Name;

    }

    [MessagePackObject, Route((ushort)ServerPacketIds.MentorRequest)]
    public sealed class MentorRequest : Packet
    {
        [Key(0)]
        public string Name;
        [Key(1)]
        public ushort Level;

    }

    [MessagePackObject, Route((ushort)ServerPacketIds.TradeRequest)]
    public sealed class TradeRequest : Packet
    {
        [Key(0)]
        public string Name;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.TradeAccept)]
    public sealed class TradeAccept : Packet
    {
        [Key(0)]
        public string Name;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.TradeGold)]
    public sealed class TradeGold : Packet
    {
        [Key(0)]
        public uint Amount;

    }

    [MessagePackObject, Route((ushort)ServerPacketIds.TradeItem)]
    public sealed class TradeItem : Packet
    {
        [Key(0)]
        public UserItem[] TradeItems;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.TradeConfirm)]
    public sealed class TradeConfirm : Packet
    {

    }

    [MessagePackObject, Route((ushort)ServerPacketIds.TradeCancel)]
    public sealed class TradeCancel : Packet
    {
        [Key(0)]
        public bool Unlock;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.LogOutSuccess)]
    public sealed class LogOutSuccess : Packet
    {
        [IgnoreMember]
        public override bool Observable => false;

        [Key(0)]
        public List<SelectInfo> Characters = new List<SelectInfo>();
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.LogOutFailed)]
    public sealed class LogOutFailed : Packet
    {
        [IgnoreMember]
        public override bool Observable => false;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.ReturnToLogin)]
    public sealed class ReturnToLogin : Packet
    {
        [IgnoreMember]
        public override bool Observable => false;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.TimeOfDay)]
    public sealed class TimeOfDay : Packet
    {
        [Key(0)]
        public LightSetting Lights;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.ChangeAMode)]
    public sealed class ChangeAMode : Packet
    {
        [Key(0)]
        public AttackMode Mode;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.ChangePMode)]
    public sealed class ChangePMode : Packet
    {
        [Key(0)]
        public PetMode Mode;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.ObjectItem)]
    public sealed class ObjectItem : Packet
    {
        [Key(0)]
        public uint ObjectID;
        [Key(1)]
        public string Name = string.Empty;
        [Key(2)]
        public Color NameColour;
        [Key(3)]
        public Point Location;
        [Key(4)]
        public ushort Image;
        [Key(5)]
        public ItemGrade grade;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.ObjectGold)]
    public sealed class ObjectGold : Packet
    {
        [Key(0)]
        public uint ObjectID;
        [Key(1)]
        public uint Gold;
        [Key(2)]
        public Point Location;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.GainedItem)]
    public sealed class GainedItem : Packet
    {
        [Key(0)]
        public UserItem Item;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.GainedGold)]
    public sealed class GainedGold : Packet
    {
        [Key(0)]
        public uint Gold;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.LoseGold)]
    public sealed class LoseGold : Packet
    {
        [Key(0)]
        public uint Gold;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.GainedCredit)]
    public sealed class GainedCredit : Packet
    {
        [Key(0)]
        public uint Credit;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.LoseCredit)]
    public sealed class LoseCredit : Packet
    {
        [Key(0)]
        public uint Credit;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.ObjectMonster)]
    public sealed class ObjectMonster : Packet
    {
        [Key(0)]
        public uint ObjectID;
        [Key(1)]
        public string Name = string.Empty;
        [Key(2)]
        public Color NameColour;
        [Key(3)]
        public Point Location;
        [Key(4)]
        public Monster Image;
        [Key(5)]
        public MirDirection Direction;
        [Key(6)]
        public byte Effect;
        [Key(7)]
        public byte AI;
        [Key(8)]
        public byte Light;
        [Key(9)]
        public bool Dead;
        [Key(10)]
        public bool Skeleton;
        [Key(11)]
        public PoisonType Poison;
        [Key(12)]
        public bool Hidden;
        [Key(13)]
        public bool Extra;
        [Key(14)]
        public byte ExtraByte;
        [Key(15)]
        public long ShockTime;
        [Key(16)]
        public bool BindingShotCenter;
        [Key(17)]
        public List<BuffType> Buffs = new List<BuffType>();

    }

    [MessagePackObject, Route((ushort)ServerPacketIds.ObjectAttack)]
    public sealed class ObjectAttack : Packet
    {
        [Key(0)]
        public uint ObjectID;
        [Key(1)]
        public Point Location;
        [Key(2)]
        public MirDirection Direction;
        [Key(3)]
        public Spell Spell;
        [Key(4)]
        public byte Level;
        [Key(5)]
        public byte Type;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.Struck)]
    public sealed class Struck : Packet
    {
        [Key(0)]
        public uint AttackerID;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.ObjectStruck)]
    public sealed class ObjectStruck : Packet
    {
        [Key(0)]
        public uint ObjectID;
        [Key(1)]
        public uint AttackerID;
        [Key(2)]
        public Point Location;
        [Key(3)]
        public MirDirection Direction;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.DamageIndicator)]
    public sealed class DamageIndicator : Packet
    {
        [Key(0)]
        public int Damage;
        [Key(1)]
        public DamageType Type;
        [Key(2)]
        public uint ObjectID;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.DuraChanged)]
    public sealed class DuraChanged : Packet
    {
        [Key(0)]
        public ulong UniqueID;
        [Key(1)]
        public ushort CurrentDura;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.HealthChanged)]
    public sealed class HealthChanged : Packet
    {
        [Key(0)]
        public int HP;
        [Key(1)]
        public int MP;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.HeroHealthChanged)]
    public sealed class HeroHealthChanged : Packet
    {
        [Key(0)]
        public int HP;
        [Key(1)]
        public int MP;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.DeleteItem)]
    public sealed class DeleteItem : Packet
    {
        [Key(0)]
        public ulong UniqueID;
        [Key(1)]
        public ushort Count;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.Death)]
    public sealed class Death : Packet
    {
        [Key(0)]
        public Point Location;
        [Key(1)]
        public MirDirection Direction;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.ObjectDied)]
    public sealed class ObjectDied : Packet
    {
        [Key(0)]
        public uint ObjectID;
        [Key(1)]
        public Point Location;
        [Key(2)]
        public MirDirection Direction;
        [Key(3)]
        public byte Type;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.ColourChanged)]
    public sealed class ColourChanged : Packet
    {
        [Key(0)]
        public Color NameColour;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.ObjectColourChanged)]
    public sealed class ObjectColourChanged : Packet
    {
        [Key(0)]
        public uint ObjectID;
        [Key(1)]
        public Color NameColour;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.ObjectGuildNameChanged)]
    public sealed class ObjectGuildNameChanged : Packet
    {
        [Key(0)]
        public uint ObjectID;
        [Key(1)]
        public string GuildName;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.GainExperience)]
    public sealed class GainExperience : Packet
    {
        [Key(0)]
        public uint Amount;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.GainHeroExperience)]
    public sealed class GainHeroExperience : Packet
    {
        [Key(0)]
        public uint Amount;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.LevelChanged)]
    public sealed class LevelChanged : Packet
    {
        [Key(0)]
        public ushort Level;
        [Key(1)]
        public long Experience;
        [Key(2)]
        public long MaxExperience;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.HeroLevelChanged)]
    public sealed class HeroLevelChanged : Packet
    {
        [Key(0)]
        public ushort Level;
        [Key(1)]
        public long Experience;
        [Key(2)]
        public long MaxExperience;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.ObjectLeveled)]
    public sealed class ObjectLeveled : Packet
    {
        [Key(0)]
        public uint ObjectID;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.ObjectHarvest)]
    public sealed class ObjectHarvest : Packet
    {
        [Key(0)]
        public uint ObjectID;
        [Key(1)]
        public Point Location;
        [Key(2)]
        public MirDirection Direction;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.ObjectHarvested)]
    public sealed class ObjectHarvested : Packet
    {
        [Key(0)]
        public uint ObjectID;
        [Key(1)]
        public Point Location;
        [Key(2)]
        public MirDirection Direction;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.ObjectNpc)]
    public sealed class ObjectNPC : Packet
    {
        [Key(0)]
        public uint ObjectID;
        [Key(1)]
        public string Name = string.Empty;
        [Key(2)]
        public Color NameColour;
        [Key(3)]
        public ushort Image;
        [Key(4)]
        public Color Colour;
        [Key(5)]
        public Point Location;
        [Key(6)]
        public MirDirection Direction;
        [Key(7)]
        public List<int> QuestIDs = new List<int>();
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.NPCResponse)]
    public sealed class NPCResponse : Packet
    {
        [Key(0)]
        public List<string> Page;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.ObjectHide)]
    public sealed class ObjectHide : Packet
    {
        [Key(0)]
        public uint ObjectID;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.ObjectShow)]
    public sealed class ObjectShow : Packet
    {
        [Key(0)]
        public uint ObjectID;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.Poisoned)]
    public sealed class Poisoned : Packet
    {
        [Key(0)]
        public PoisonType Poison;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.ObjectPoisoned)]
    public sealed class ObjectPoisoned : Packet
    {
        [Key(0)]
        public uint ObjectID;
        [Key(1)]
        public PoisonType Poison;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.MapChanged)]
    public sealed class MapChanged : Packet
    {
        [Key(0)]
        public int MapIndex;
        [Key(1)]
        public string FileName = string.Empty;
        [Key(2)]
        public string Title = string.Empty;
        [Key(3)]
        public ushort MiniMap;
        [Key(4)]
        public ushort BigMap;
        [Key(5)]
        public ushort Music;
        [Key(6)]
        public LightSetting Lights;
        [Key(7)]
        public Point Location;
        [Key(8)]
        public MirDirection Direction;
        [Key(9)]
        public byte MapDarkLight;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.ObjectTeleportOut)]
    public sealed class ObjectTeleportOut : Packet
    {
        [Key(0)]
        public uint ObjectID;
        [Key(1)]
        public byte Type;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.ObjectTeleportIn)]
    public sealed class ObjectTeleportIn : Packet
    {
        [Key(0)]
        public uint ObjectID;
        [Key(1)]
        public byte Type;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.TeleportIn)]
    public sealed class TeleportIn : Packet
    {

    }

    [MessagePackObject, Route((ushort)ServerPacketIds.NPCGoods)]
    public sealed class NPCGoods : Packet
    {
        [Key(0)]
        public List<UserItem> List = new List<UserItem>();
        [Key(1)]
        public float Rate;
        [Key(2)]
        public PanelType Type;
        [Key(3)]
        public bool HideAddedStats;

    }

    [MessagePackObject, Route((ushort)ServerPacketIds.NPCSell)]
    public sealed class NPCSell : Packet
    {

    }

    [MessagePackObject, Route((ushort)ServerPacketIds.NPCRepair)]
    public sealed class NPCRepair : Packet
    {
        [Key(0)]
        public float Rate;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.NPCSRepair)]
    public sealed class NPCSRepair : Packet
    {
        [Key(0)]
        public float Rate;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.NPCRefine)]
    public sealed class NPCRefine : Packet
    {
        [Key(0)]
        public float Rate;
        [Key(1)]
        public bool Refining;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.NPCCheckRefine)]
    public sealed class NPCCheckRefine : Packet
    {

    }

    [MessagePackObject, Route((ushort)ServerPacketIds.NPCCollectRefine)]
    public sealed class NPCCollectRefine : Packet
    {
        [Key(0)]
        public bool Success;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.NPCReplaceWedRing)]
    public sealed class NPCReplaceWedRing : Packet
    {
        [Key(0)]
        public float Rate;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.NPCStorage)]
    public sealed class NPCStorage : Packet
    {

    }

    [MessagePackObject, Route((ushort)ServerPacketIds.SellItem)]
    public sealed class SellItem : Packet
    {
        [Key(0)]
        public ulong UniqueID;
        [Key(1)]
        public ushort Count;
        [Key(2)]
        public bool Success;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.RepairItem)]
    public sealed class RepairItem : Packet
    {
        [Key(0)]
        public ulong UniqueID;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.ItemRepaired)]
    public sealed class ItemRepaired : Packet
    {
        [Key(0)]
        public ulong UniqueID;
        [Key(1)]
        public ushort MaxDura;
        [Key(2)]
        public ushort CurrentDura;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.ItemSlotSizeChanged)]
    public sealed class ItemSlotSizeChanged : Packet
    {
        [Key(0)]
        public ulong UniqueID;
        [Key(1)]
        public int SlotSize;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.ItemSealChanged)]
    public sealed class ItemSealChanged : Packet
    {
        [Key(0)]
        public ulong UniqueID;
        [Key(1)]
        public DateTime ExpiryDate;
    }


    [MessagePackObject, Route((ushort)ServerPacketIds.NewMagic)]
    public sealed class NewMagic : Packet
    {
        [Key(0)]
        public ClientMagic Magic;
        [Key(1)]
        public bool Hero;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.RemoveMagic)]
    public sealed class RemoveMagic : Packet
    {
        [Key(0)]
        public int PlaceId;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.MagicLeveled)]
    public sealed class MagicLeveled : Packet
    {
        [Key(0)]
        public uint ObjectID;
        [Key(1)]
        public Spell Spell;
        [Key(2)]
        public byte Level;
        [Key(3)]
        public ushort Experience;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.Magic)]
    public sealed class Magic : Packet
    {
        [Key(0)]
        public Spell Spell;
        [Key(1)]
        public uint TargetID;
        [Key(2)]
        public Point Target;
        [Key(3)]
        public bool Cast;
        [Key(4)]
        public byte Level;
        [Key(5)]
        public List<uint> SecondaryTargetIDs = new List<uint>();
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.MagicDelay)]
    public sealed class MagicDelay : Packet
    {
        [Key(0)]
        public uint ObjectID;
        [Key(1)]
        public Spell Spell;
        [Key(2)]
        public long Delay;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.MagicCast)]
    public sealed class MagicCast : Packet
    {
        [Key(0)]
        public Spell Spell;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.ObjectMagic)]
    public sealed class ObjectMagic : Packet
    {
        [Key(0)]
        public uint ObjectID;
        [Key(1)]
        public Point Location;
        [Key(2)]
        public MirDirection Direction;
        [Key(3)]
        public Spell Spell;
        [Key(4)]
        public uint TargetID;
        [Key(5)]
        public Point Target;
        [Key(6)]
        public bool Cast;
        [Key(7)]
        public byte Level;
        [Key(8)]
        public bool SelfBroadcast = false;
        [Key(9)]
        public List<uint> SecondaryTargetIDs = new List<uint>();
    }


    [MessagePackObject, Route((ushort)ServerPacketIds.ObjectEffect)]
    public sealed class ObjectEffect : Packet
    {
        [Key(0)]
        public uint ObjectID;
        [Key(1)]
        public SpellEffect Effect;
        [Key(2)]
        public uint EffectType;
        [Key(3)]
        public uint DelayTime = 0;
        [Key(4)]
        public uint Time = 0;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.ObjectProjectile)]
    public sealed class ObjectProjectile : Packet
    {
        [Key(0)]
        public Spell Spell;
        [Key(1)]
        public uint Source;
        [Key(2)]
        public uint Destination;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.RangeAttack)]
    public sealed class RangeAttack : Packet //ArcherTest
    {
        [Key(0)]
        public uint TargetID;
        [Key(1)]
        public Point Target;
        [Key(2)]
        public Spell Spell;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.Pushed)]
    public sealed class Pushed : Packet
    {
        [Key(0)]
        public Point Location;
        [Key(1)]
        public MirDirection Direction;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.ObjectPushed)]
    public sealed class ObjectPushed : Packet
    {
        [Key(0)]
        public uint ObjectID;
        [Key(1)]
        public Point Location;
        [Key(2)]
        public MirDirection Direction;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.ObjectName)]
    public sealed class ObjectName : Packet
    {
        [Key(0)]
        public uint ObjectID;
        [Key(1)]
        public string Name = string.Empty;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.UserStorage)]
    public sealed class UserStorage : Packet
    {
        [Key(0)]
        public UserItem[] Storage;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.SwitchGroup)]
    public sealed class SwitchGroup : Packet
    {
        [Key(0)]
        public bool AllowGroup;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.DeleteGroup)]
    public sealed class DeleteGroup : Packet
    {

    }

    [MessagePackObject, Route((ushort)ServerPacketIds.DeleteMember)]
    public sealed class DeleteMember : Packet
    {
        [Key(0)]
        public string Name = string.Empty;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.GroupInvite)]
    public sealed class GroupInvite : Packet
    {
        [Key(0)]
        public string Name = string.Empty;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.AddMember)]
    public sealed class AddMember : Packet
    {
        [Key(0)]
        public string Name = string.Empty;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.GroupMembersMap)]
    public sealed class GroupMembersMap : Packet
    {
        [Key(0)]
        public string PlayerName = string.Empty;
        [Key(1)]
        public string PlayerMap = string.Empty;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.SendMemberLocation)]
    public sealed class SendMemberLocation : Packet
    {
        [Key(0)]
        public string MemberName;
        [Key(1)]
        public Point MemberLocation;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.Revived)]
    public sealed class Revived : Packet
    {

    }

    [MessagePackObject, Route((ushort)ServerPacketIds.ObjectRevived)]
    public sealed class ObjectRevived : Packet
    {
        [Key(0)]
        public uint ObjectID;
        [Key(1)]
        public bool Effect;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.SpellToggle)]
    public sealed class SpellToggle : Packet
    {
        [Key(0)]
        public uint ObjectID;
        [Key(1)]
        public Spell Spell;
        [Key(2)]
        public bool CanUse;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.ObjectHealth)]
    public sealed class ObjectHealth : Packet
    {
        [Key(0)]
        public uint ObjectID;
        [Key(1)]
        public byte Percent;
        [Key(2)]
        public byte Expire;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.ObjectMana)]
    public sealed class ObjectMana : Packet
    {
        [Key(0)]
        public uint ObjectID;
        [Key(1)]
        public byte Percent;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.MapEffect)]
    public sealed class MapEffect : Packet
    {
        [Key(0)]
        public Point Location;
        [Key(1)]
        public SpellEffect Effect;
        [Key(2)]
        public byte Value;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.AllowObserve)]
    public sealed class AllowObserve : Packet
    {
        [Key(0)]
        public bool Allow;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.ObjectRangeAttack)]
    public sealed class ObjectRangeAttack : Packet
    {
        [Key(0)]
        public uint ObjectID;
        [Key(1)]
        public Point Location;
        [Key(2)]
        public MirDirection Direction;
        [Key(3)]
        public uint TargetID;
        [Key(4)]
        public Point Target;
        [Key(5)]
        public byte Type;
        [Key(6)]
        public Spell Spell;
        [Key(7)]
        public byte Level;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.AddBuff)]
    public sealed class AddBuff : Packet
    {
        [Key(0)]
        public ClientBuff Buff;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.RemoveBuff)]
    public sealed class RemoveBuff : Packet
    {
        [Key(0)]
        public BuffType Type;
        [Key(1)]
        public uint ObjectID;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.PauseBuff)]
    public sealed class PauseBuff : Packet
    {
        [Key(0)]
        public BuffType Type;
        [Key(1)]
        public uint ObjectID;
        [Key(2)]
        public bool Paused;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.ObjectHidden)]
    public sealed class ObjectHidden : Packet
    {
        [Key(0)]
        public uint ObjectID;
        [Key(1)]
        public bool Hidden;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.RefreshItem)]
    public sealed class RefreshItem : Packet
    {
        [Key(0)]
        public UserItem Item;

    }

    [MessagePackObject, Route((ushort)ServerPacketIds.ObjectSpell)]
    public sealed class ObjectSpell : Packet
    {
        [Key(0)]
        public uint ObjectID;
        [Key(1)]
        public Point Location;
        [Key(2)]
        public Spell Spell;
        [Key(3)]
        public MirDirection Direction;
        [Key(4)]
        public bool Param;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.UserDash)]
    public sealed class UserDash : Packet
    {
        [Key(0)]
        public Point Location;
        [Key(1)]
        public MirDirection Direction;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.ObjectDash)]
    public sealed class ObjectDash : Packet
    {
        [Key(0)]
        public uint ObjectID;
        [Key(1)]
        public Point Location;
        [Key(2)]
        public MirDirection Direction;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.UserDashFail)]
    public sealed class UserDashFail : Packet
    {
        [Key(0)]
        public Point Location;
        [Key(1)]
        public MirDirection Direction;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.ObjectDashFail)]
    public sealed class ObjectDashFail : Packet
    {
        [Key(0)]
        public uint ObjectID;
        [Key(1)]
        public Point Location;
        [Key(2)]
        public MirDirection Direction;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.RemoveDelayedExplosion)]
    public sealed class RemoveDelayedExplosion : Packet
    {
        [Key(0)]
        public uint ObjectID;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.NPCConsign)]
    public sealed class NPCConsign : Packet
    {

    }

    [MessagePackObject, Route((ushort)ServerPacketIds.NPCMarket)]
    public sealed class NPCMarket : Packet
    {
        [Key(0)]
        public List<ClientAuction> Listings = new List<ClientAuction>();
        [Key(1)]
        public int Pages;
        [Key(2)]
        public bool UserMode;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.NPCMarketPage)]
    public sealed class NPCMarketPage : Packet
    {
        [Key(0)]
        public List<ClientAuction> Listings = new List<ClientAuction>();
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.ConsignItem)]
    public sealed class ConsignItem : Packet
    {
        [Key(0)]
        public ulong UniqueID;
        [Key(1)]
        public bool Success;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.MarketFail)]
    public sealed class MarketFail : Packet
    {
        [Key(0)]
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

    [MessagePackObject, Route((ushort)ServerPacketIds.MarketSuccess)]
    public sealed class MarketSuccess : Packet
    {
        [Key(0)]
        public string Message = string.Empty;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.ObjectSitDown)]
    public sealed class ObjectSitDown : Packet
    {
        [Key(0)]
        public uint ObjectID;
        [Key(1)]
        public Point Location;
        [Key(2)]
        public MirDirection Direction;
        [Key(3)]
        public bool Sitting;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.InTrapRock)]
    public sealed class InTrapRock : Packet
    {
        [Key(0)]
        public bool Trapped;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.BaseStatsInfo)]
    public sealed class BaseStatsInfo : Packet
    {
        [Key(0)]
        public BaseStats Stats;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.HeroBaseStatsInfo)]
    public sealed class HeroBaseStatsInfo : Packet
    {
        [Key(0)]
        public BaseStats Stats;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.UserName)]
    public sealed class UserName : Packet
    {
        [Key(0)]
        public uint Id;
        [Key(1)]
        public string Name;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.ChatItemStats)]
    public sealed class ChatItemStats : Packet
    {
        [Key(0)]
        public ulong ChatItemId;
        [Key(1)]
        public UserItem Stats;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.GuildNoticeChange)]
    public sealed class GuildNoticeChange : Packet
    {
        [Key(0)]
        public int update = 0;
        [Key(1)]
        public List<string> notice = new List<string>();
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.GuildMemberChange)]
    public sealed class GuildMemberChange : Packet
    {
        [Key(0)]
        public string Name = string.Empty;
        [Key(1)]
        public byte Status = 0;
        [Key(2)]
        public byte RankIndex = 0;
        [Key(3)]
        public List<GuildRank> Ranks = new List<GuildRank>();
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.GuildStatus)]
    public sealed class GuildStatus : Packet
    {
        [Key(0)]
        public string GuildName = string.Empty;
        [Key(1)]
        public string GuildRankName = string.Empty;
        [Key(2)]
        public byte Level;
        [Key(3)]
        public long Experience;
        [Key(4)]
        public long MaxExperience;
        [Key(5)]
        public uint Gold;
        [Key(6)]
        public byte SparePoints;
        [Key(7)]
        public int MemberCount;
        [Key(8)]
        public int MaxMembers;
        [Key(9)]
        public bool Voting;
        [Key(10)]
        public byte ItemCount;
        [Key(11)]
        public byte BuffCount;
        [Key(12)]
        public GuildRankOptions MyOptions;
        [Key(13)]
        public int MyRankId;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.GuildInvite)]
    public sealed class GuildInvite : Packet
    {
        [Key(0)]
        public string Name = string.Empty;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.GuildExpGain)]
    public sealed class GuildExpGain : Packet
    {
        [Key(0)]
        public uint Amount = 0;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.GuildNameRequest)]
    public sealed class GuildNameRequest : Packet
    {

    }

    [MessagePackObject, Route((ushort)ServerPacketIds.GuildStorageGoldChange)]
    public sealed class GuildStorageGoldChange : Packet
    {
        [Key(0)]
        public uint Amount = 0;
        [Key(1)]
        public byte Type = 0;
        [Key(2)]
        public string Name = string.Empty;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.GuildStorageItemChange)]
    public sealed class GuildStorageItemChange : Packet
    {
        [Key(0)]
        public int User = 0;
        [Key(1)]
        public byte Type = 0;
        [Key(2)]
        public int To = 0;
        [Key(3)]
        public int From = 0;
        [Key(4)]
        public GuildStorageItem Item = null;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.GuildStorageList)]
    public sealed class GuildStorageList : Packet
    {
        [Key(0)]
        public GuildStorageItem[] Items;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.GuildRequestWar)]
    public sealed class GuildRequestWar : Packet
    {

    }

    [MessagePackObject, Route((ushort)ServerPacketIds.HeroCreateRequest)]
    public sealed class HeroCreateRequest : Packet
    {
        [Key(0)]
        public bool[] CanCreateClass;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.NewHero)]
    public sealed class NewHero : Packet
    {
        /*
         * 0: Disabled.
         * 1: Bad Character Name
         * 2: Bad Gender
         * 3: Bad Class
         * 4: Max Heroes
         * 5: Name Exists.
         * */
        [Key(0)]
        public byte Result;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.HeroInformation)]
    public sealed class HeroInformation : UserInformation
    {
        [Key(32)]
        public bool AutoPot;
        [Key(33)]
        public byte AutoHPPercent;
        [Key(34)]
        public byte AutoMPPercent;
        [Key(35)]
        public int HPItemIndex;
        [Key(36)]
        public int MPItemIndex;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.UpdateHeroSpawnState)]
    public sealed class UpdateHeroSpawnState : Packet
    {
        [Key(0)]
        public HeroSpawnState State;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.UnlockHeroAutoPot)]
    public sealed class UnlockHeroAutoPot : Packet
    {

    }

    [MessagePackObject, Route((ushort)ServerPacketIds.SetAutoPotValue)]
    public sealed class SetAutoPotValue : Packet
    {
        [Key(0)]
        public Stat Stat;
        [Key(1)]
        public uint Value;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.SetAutoPotItem)]
    public sealed class SetAutoPotItem : Packet
    {
        [Key(0)]
        public MirGridType Grid;
        [Key(1)]
        public int ItemIndex;

    }

    [MessagePackObject, Route((ushort)ServerPacketIds.SetHeroBehaviour)]
    public sealed class SetHeroBehaviour : Packet
    {
        [Key(0)]
        public HeroBehaviour Behaviour;

    }

    [MessagePackObject, Route((ushort)ServerPacketIds.ManageHeroes)]
    public sealed class ManageHeroes : Packet
    {
        [Key(0)]
        public int MaximumCount;
        [Key(1)]
        public ClientHeroInformation CurrentHero;
        [Key(2)]
        public ClientHeroInformation[] Heroes;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.ChangeHero)]
    public sealed class ChangeHero : Packet
    {
        [Key(0)]
        public int FromIndex;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.DefaultNPC)]
    public sealed class DefaultNPC : Packet
    {
        [Key(0)]
        public uint ObjectID;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.NPCUpdate)]
    public sealed class NPCUpdate : Packet
    {
        [Key(0)]
        public uint NPCID;
    }


    [MessagePackObject, Route((ushort)ServerPacketIds.NPCImageUpdate)]
    public sealed class NPCImageUpdate : Packet
    {
        [Key(0)]
        public long ObjectID;
        [Key(1)]
        public ushort Image;
        [Key(2)]
        public Color Colour;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.MountUpdate)]
    public sealed class MountUpdate : Packet
    {
        [Key(0)]
        public long ObjectID;
        [Key(1)]
        public short MountType;
        [Key(2)]
        public bool RidingMount;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.TransformUpdate)]
    public sealed class TransformUpdate : Packet
    {
        [Key(0)]
        public long ObjectID;
        [Key(1)]
        public short TransformType;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.EquipSlotItem)]
    public sealed class EquipSlotItem : Packet
    {
        [Key(0)]
        public MirGridType Grid;
        [Key(1)]
        public ulong UniqueID;
        [Key(2)]
        public int To;
        [Key(3)]
        public bool Success;
        [Key(4)]
        public MirGridType GridTo;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.FishingUpdate)]
    public sealed class FishingUpdate : Packet
    {
        [Key(0)]
        public long ObjectID;
        [Key(1)]
        public bool Fishing;
        [Key(2)]
        public int ProgressPercent;
        [Key(3)]
        public int ChancePercent;
        [Key(4)]
        public Point FishingPoint;
        [Key(5)]
        public bool FoundFish;
    }

    //public sealed class UpdateQuests : Packet
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


    [MessagePackObject, Route((ushort)ServerPacketIds.ChangeQuest)]
    public sealed class ChangeQuest : Packet
    {
        [Key(0)]
        public ClientQuestProgress Quest = new ClientQuestProgress();
        [Key(1)]
        public QuestState QuestState;
        [Key(2)]
        public bool TrackQuest;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.CompleteQuest)]
    public sealed class CompleteQuest : Packet
    {
        [Key(0)]
        public List<int> CompletedQuests = new List<int>();
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.ShareQuest)]
    public sealed class ShareQuest : Packet
    {
        [Key(0)]
        public int QuestIndex;
        [Key(1)]
        public string SharerName;
    }


    [MessagePackObject, Route((ushort)ServerPacketIds.NewQuestInfo)]
    public sealed class NewQuestInfo : Packet
    {
        [Key(0)]
        public ClientQuestInfo Info;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.GainedQuestItem)]
    public sealed class GainedQuestItem : Packet
    {
        [Key(0)]
        public UserItem Item;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.DeleteQuestItem)]
    public sealed class DeleteQuestItem : Packet
    {
        [Key(0)]
        public ulong UniqueID;
        [Key(1)]
        public ushort Count;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.GameShopInfo)]
    public sealed class GameShopInfo : Packet
    {
        [Key(0)]
        public GameShopItem Item;
        [Key(1)]
        public int StockLevel;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.GameShopStock)]
    public sealed class GameShopStock : Packet
    {
        [Key(0)]
        public int GIndex;
        [Key(1)]
        public int StockLevel;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.CancelReincarnation)]
    public sealed class CancelReincarnation : Packet
    {

    }

    [MessagePackObject, Route((ushort)ServerPacketIds.RequestReincarnation)]
    public sealed class RequestReincarnation : Packet
    {

    }

    [MessagePackObject, Route((ushort)ServerPacketIds.UserBackStep)]
    public sealed class UserBackStep : Packet
    {
        [Key(0)]
        public Point Location;
        [Key(1)]
        public MirDirection Direction;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.ObjectBackStep)]
    public sealed class ObjectBackStep : Packet
    {
        [Key(0)]
        public uint ObjectID;
        [Key(1)]
        public Point Location;
        [Key(2)]
        public MirDirection Direction;
        [Key(3)]
        public int Distance;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.UserDashAttack)]
    public sealed class UserDashAttack : Packet
    {
        [Key(0)]
        public Point Location;
        [Key(1)]
        public MirDirection Direction;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.ObjectDashAttack)]
    public sealed class ObjectDashAttack : Packet
    {
        [Key(0)]
        public uint ObjectID;
        [Key(1)]
        public Point Location;
        [Key(2)]
        public MirDirection Direction;
        [Key(3)]
        public int Distance;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.UserAttackMove)]
    public sealed class UserAttackMove : Packet //warrior skill - SlashingBurst move packet 
    {
        [Key(0)]
        public Point Location;
        [Key(1)]
        public MirDirection Direction;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.CombineItem)]
    public sealed class CombineItem : Packet
    {
        [Key(0)]
        public MirGridType Grid;
        [Key(1)]
        public ulong IDFrom;
        [Key(2)]
        public ulong IDTo;
        [Key(3)]
        public bool Success;
        [Key(4)]
        public bool Destroy;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.ItemUpgraded)]
    public sealed class ItemUpgraded : Packet
    {
        [Key(0)]
        public UserItem Item;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.SetConcentration)]
    public sealed class SetConcentration : Packet
    {
        [Key(0)]
        public uint ObjectID;
        [Key(1)]
        public bool Enabled;
        [Key(2)]
        public bool Interrupted;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.SetElemental)]
    public sealed class SetElemental : Packet
    {
        [Key(0)]
        public uint ObjectID;
        [Key(1)]
        public bool Enabled;
        [Key(2)]
        public bool Casted;
        [Key(3)]
        public uint Value;
        [Key(4)]
        public uint ElementType;
        [Key(5)]
        public uint ExpLast;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.ObjectDeco)]
    public sealed class ObjectDeco : Packet
    {
        [Key(0)]
        public uint ObjectID;
        [Key(1)]
        public Point Location;
        [Key(2)]
        public int Image;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.ObjectSneaking)]
    public sealed class ObjectSneaking : Packet
    {
        [Key(0)]
        public uint ObjectID;
        [Key(1)]
        public bool SneakingActive;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.ObjectLevelEffects)]
    public sealed class ObjectLevelEffects : Packet
    {
        [Key(0)]
        public uint ObjectID;
        [Key(1)]
        public LevelEffects LevelEffects;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.SetBindingShot)]
    public sealed class SetBindingShot : Packet
    {
        [Key(0)]
        public uint ObjectID;
        [Key(1)]
        public bool Enabled;
        [Key(2)]
        public long Value;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.SendOutputMessage)]
    public sealed class SendOutputMessage : Packet
    {
        [Key(0)]
        public string Message;
        [Key(1)]
        public OutputMessageType Type;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.NPCAwakening)]
    public sealed class NPCAwakening : Packet
    {

    }

    [MessagePackObject, Route((ushort)ServerPacketIds.NPCDisassemble)]
    public sealed class NPCDisassemble : Packet
    {

    }

    [MessagePackObject, Route((ushort)ServerPacketIds.NPCDowngrade)]
    public sealed class NPCDowngrade : Packet
    {

    }

    [MessagePackObject, Route((ushort)ServerPacketIds.NPCReset)]
    public sealed class NPCReset : Packet
    {

    }

    [MessagePackObject, Route((ushort)ServerPacketIds.AwakeningNeedMaterials)]
    public sealed class AwakeningNeedMaterials : Packet
    {
        [Key(0)]
        public ItemInfo[] Materials;
        [Key(1)]
        public byte[] MaterialsCount;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.AwakeningLockedItem)]
    public sealed class AwakeningLockedItem : Packet
    {
        [Key(0)]
        public ulong UniqueID;
        [Key(1)]
        public bool Locked;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.Awakening)]
    public sealed class Awakening : Packet
    {
        [Key(0)]
        public int result;
        [Key(1)]
        public long removeID = -1;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.ReceiveMail)]
    public sealed class ReceiveMail : Packet
    {
        [Key(0)]
        public List<ClientMail> Mail = new List<ClientMail>();
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.MailLockedItem)]
    public sealed class MailLockedItem : Packet
    {
        [Key(0)]
        public ulong UniqueID;
        [Key(1)]
        public bool Locked;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.MailSent)]
    public sealed class MailSent : Packet
    {
        [Key(0)]
        public sbyte Result;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.MailSendRequest)]
    public sealed class MailSendRequest : Packet
    {

    }

    [MessagePackObject, Route((ushort)ServerPacketIds.ParcelCollected)]
    public sealed class ParcelCollected : Packet
    {
        [Key(0)]
        public sbyte Result;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.MailCost)]
    public sealed class MailCost : Packet
    {
        [Key(0)]
        public uint Cost;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.ResizeInventory)]
    public sealed class ResizeInventory : Packet
    {
        [Key(0)]
        public int Size;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.ResizeStorage)]
    public sealed class ResizeStorage : Packet
    {
        [Key(0)]
        public int Size;
        [Key(1)]
        public bool HasExpandedStorage;
        [Key(2)]
        public DateTime ExpiryTime;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.NewIntelligentCreature)]
    public sealed class NewIntelligentCreature : Packet
    {
        [Key(0)]
        public ClientIntelligentCreature Creature;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.UpdateIntelligentCreatureList)]
    public sealed class UpdateIntelligentCreatureList : Packet
    {
        [Key(0)]
        public List<ClientIntelligentCreature> CreatureList = new List<ClientIntelligentCreature>();
        [Key(1)]
        public bool CreatureSummoned = false;
        [Key(2)]
        public IntelligentCreatureType SummonedCreatureType = IntelligentCreatureType.None;
        [Key(3)]
        public int PearlCount = 0;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.IntelligentCreatureEnableRename)]
    public sealed class IntelligentCreatureEnableRename : Packet
    {

    }

    [MessagePackObject, Route((ushort)ServerPacketIds.IntelligentCreaturePickup)]
    public sealed class IntelligentCreaturePickup : Packet
    {
        [Key(0)]
        public uint ObjectID;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.NPCPearlGoods)]
    public sealed class NPCPearlGoods : Packet
    {
        [Key(0)]
        public List<UserItem> List = new List<UserItem>();
        [Key(1)]
        public float Rate;
        [Key(2)]
        public PanelType Type;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.FriendUpdate)]
    public sealed class FriendUpdate : Packet
    {
        [Key(0)]
        public List<ClientFriend> Friends = new List<ClientFriend>();
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.GuildBuffList)]
    public sealed class GuildBuffList : Packet
    {
        [Key(0)]
        public byte Remove = 0;
        [Key(1)]
        public List<GuildBuff> ActiveBuffs = new List<GuildBuff>();
        [Key(2)]
        public List<GuildBuffInfo> GuildBuffs = new List<GuildBuffInfo>();
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.LoverUpdate)]
    public sealed class LoverUpdate : Packet
    {
        [Key(0)]
        public string Name;
        [Key(1)]
        public DateTime Date;
        [Key(2)]
        public string MapName;
        [Key(3)]
        public short MarriedDays;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.MentorUpdate)]
    public sealed class MentorUpdate : Packet
    {
        [Key(0)]
        public string Name;
        [Key(1)]
        public ushort Level;
        [Key(2)]
        public bool Online;
        [Key(3)]
        public long MenteeEXP;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.NPCRequestInput)]
    public sealed class NPCRequestInput : Packet
    {
        [Key(0)]
        public uint NPCID;
        [Key(1)]
        public string PageName;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.Rankings)]
    public sealed class Rankings : Packet
    {
        [IgnoreMember]
        public override bool Observable
        {
            get { return false; }
        }

        [Key(0)]
        public byte RankType = 0;
        [Key(1)]
        public int MyRank = 0;
        [Key(2)]
        public List<RankCharacterInfo> ListingDetails = new List<RankCharacterInfo>();
        [Key(3)]
        public List<long> Listings = new List<long>();
        [Key(4)]
        public int Count;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.Opendoor)]
    public sealed class Opendoor : Packet
    {
        [Key(0)]
        public bool Close = false;
        [Key(1)]
        public byte DoorIndex;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.GetRentedItems)]
    public sealed class GetRentedItems : Packet
    {
        [Key(0)]
        public List<ItemRentalInformation> RentedItems = new List<ItemRentalInformation>();
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.ItemRentalRequest)]
    public sealed class ItemRentalRequest : Packet
    {
        [Key(0)]
        public string Name;
        [Key(1)]
        public bool Renting;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.ItemRentalFee)]
    public sealed class ItemRentalFee : Packet
    {
        [Key(0)]
        public uint Amount;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.ItemRentalPeriod)]
    public sealed class ItemRentalPeriod : Packet
    {
        [Key(0)]
        public uint Days;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.DepositRentalItem)]
    public sealed class DepositRentalItem : Packet
    {
        [Key(0)]
        public int From;
        [Key(1)]
        public int To;
        [Key(2)]
        public bool Success;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.RetrieveRentalItem)]
    public sealed class RetrieveRentalItem : Packet
    {
        [Key(0)]
        public int From;
        [Key(1)]
        public int To;
        [Key(2)]
        public bool Success;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.UpdateRentalItem)]
    public sealed class UpdateRentalItem : Packet
    {
        [Key(0)]
        public bool HasData;
        [Key(1)]
        public UserItem LoanItem;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.CancelItemRental)]
    public sealed class CancelItemRental : Packet
    {

    }

    [MessagePackObject, Route((ushort)ServerPacketIds.ItemRentalLock)]
    public sealed class ItemRentalLock : Packet
    {
        [Key(0)]
        public bool Success;
        [Key(1)]
        public bool GoldLocked;
        [Key(2)]
        public bool ItemLocked;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.ItemRentalPartnerLock)]
    public sealed class ItemRentalPartnerLock : Packet
    {
        [Key(0)]
        public bool GoldLocked;
        [Key(1)]
        public bool ItemLocked;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.CanConfirmItemRental)]
    public sealed class CanConfirmItemRental : Packet
    {

    }

    [MessagePackObject, Route((ushort)ServerPacketIds.ConfirmItemRental)]
    public sealed class ConfirmItemRental : Packet
    {

    }


    [MessagePackObject, Route((ushort)ServerPacketIds.NewRecipeInfo)]
    public sealed class NewRecipeInfo : Packet
    {
        [Key(0)]
        public ClientRecipeInfo Info;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.CraftItem)]
    public sealed class CraftItem : Packet
    {
        [Key(0)]
        public bool Success;
    }


    [MessagePackObject, Route((ushort)ServerPacketIds.OpenBrowser)]
    public sealed class OpenBrowser : Packet
    {
        [Key(0)]
        public string Url;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.PlaySound)]
    public sealed class PlaySound : Packet
    {
        [Key(0)]
        public int Sound;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.SetTimer)]
    public sealed class SetTimer : Packet
    {
        [Key(0)]
        public string Key;
        [Key(1)]
        public byte Type;
        [Key(2)]
        public int Seconds;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.ExpireTimer)]
    public sealed class ExpireTimer : Packet
    {
        [Key(0)]
        public string Key;
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.UpdateNotice)]
    public sealed class UpdateNotice : Packet
    {
        [Key(0)]
        public Notice Notice = new Notice();
    }

    [MessagePackObject, Route((ushort)ServerPacketIds.Roll)]
    public sealed class Roll : Packet
    {
        [Key(0)]
        public int Type;
        [Key(1)]
        public string Page;
        [Key(2)]
        public int Result;
        [Key(3)]
        public bool AutoRoll;
    }


    [MessagePackObject, Route((ushort)ServerPacketIds.SetCompass)]
    public sealed class SetCompass : Packet
    {
        [Key(0)]
        public Point Location;
    }
}