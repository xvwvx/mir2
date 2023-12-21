using System.Drawing;
using MessagePack;
using Shared;

namespace ClientPackets
{
    [MessagePackObject, Route((ushort)ClientPacketIds.ClientVersion)]
    public sealed class ClientVersion : Packet
    {
        [Key(0)]
        public byte[] VersionHash;
    }

    [MessagePackObject, Route((ushort)ClientPacketIds.Disconnect)]
    public sealed class Disconnect : Packet
    {

    }

    [MessagePackObject, Route((ushort)ClientPacketIds.KeepAlive)]
    public sealed class KeepAlive : Packet
    {
        [Key(0)]
        public long Time;
    }

    [MessagePackObject, Route((ushort)ClientPacketIds.NewAccount)]
    public sealed class NewAccount : Packet
    {
        [Key(0)]
        public string AccountID = string.Empty;
        [Key(1)]
        public string Password = string.Empty;
        [Key(2)]
        public DateTime BirthDate;
        [Key(3)]
        public string UserName = string.Empty;
        [Key(4)]
        public string SecretQuestion = string.Empty;
        [Key(5)]
        public string SecretAnswer = string.Empty;
        [Key(6)]
        public string EMailAddress = string.Empty;
    }

    [MessagePackObject, Route((ushort)ClientPacketIds.ChangePassword)]
    public sealed class ChangePassword : Packet
    {
        [Key(0)]
        public string AccountID = string.Empty;
        [Key(1)]
        public string CurrentPassword = string.Empty;
        [Key(2)]
        public string NewPassword = string.Empty;
    }

    [MessagePackObject, Route((ushort)ClientPacketIds.Login)]
    public sealed class Login : Packet
    {
        [Key(0)]
        public string AccountID = string.Empty;
        [Key(1)]
        public string Password = string.Empty;
    }

    [MessagePackObject, Route((ushort)ClientPacketIds.NewCharacter)]
    public sealed class NewCharacter : Packet
    {
        [Key(0)]
        public string Name = string.Empty;
        [Key(1)]
        public MirGender Gender;
        [Key(2)]
        public MirClass Class;
    }

    [MessagePackObject, Route((ushort)ClientPacketIds.DeleteCharacter)]
    public sealed class DeleteCharacter : Packet
    {
        [Key(0)]
        public int CharacterIndex;
    }

    [MessagePackObject, Route((ushort)ClientPacketIds.StartGame)]
    public sealed class StartGame : Packet
    {
        [Key(0)]
        public int CharacterIndex;
    }

    [MessagePackObject, Route((ushort)ClientPacketIds.LogOut)]
    public sealed class LogOut : Packet
    {

    }

    [MessagePackObject, Route((ushort)ClientPacketIds.Turn)]
    public sealed class Turn : Packet
    {
        [Key(0)]
        public MirDirection Direction;
    }

    [MessagePackObject, Route((ushort)ClientPacketIds.Walk)]
    public sealed class Walk : Packet
    {
        [Key(0)]
        public MirDirection Direction;
    }

    [MessagePackObject, Route((ushort)ClientPacketIds.Run)]
    public sealed class Run : Packet
    {
        [Key(0)]
        public MirDirection Direction;
    }

    [MessagePackObject, Route((ushort)ClientPacketIds.Chat)]
    public sealed class Chat : Packet
    {
        [Key(0)]
        public string Message = string.Empty;
        [Key(1)]
        public List<ChatItem> LinkedItems = new List<ChatItem>();
    }

    [MessagePackObject, Route((ushort)ClientPacketIds.MoveItem)]
    public sealed class MoveItem : Packet
    {
        [Key(0)]
        public MirGridType Grid;
        [Key(1)]
        public int From;
        [Key(2)]
        public int To;
    }

    [MessagePackObject, Route((ushort)ClientPacketIds.StoreItem)]
    public sealed class StoreItem : Packet
    {
        [Key(0)]
        public int From;
        [Key(1)]
        public int To;
    }

    [MessagePackObject, Route((ushort)ClientPacketIds.DepositRefineItem)]
    public sealed class DepositRefineItem : Packet
    {
        [Key(0)]
        public int From;
        [Key(1)]
        public int To;
    }

    [MessagePackObject, Route((ushort)ClientPacketIds.RetrieveRefineItem)]
    public sealed class RetrieveRefineItem : Packet
    {
        [Key(0)]
        public int From;
        [Key(1)]
        public int To;
    }

    [MessagePackObject, Route((ushort)ClientPacketIds.RefineCancel)]
    public sealed class RefineCancel : Packet
    {

    }

    [MessagePackObject, Route((ushort)ClientPacketIds.RefineItem)]
    public sealed class RefineItem : Packet
    {
        [Key(0)]
        public ulong UniqueID;
    }

    [MessagePackObject, Route((ushort)ClientPacketIds.CheckRefine)]
    public sealed class CheckRefine : Packet
    {
        [Key(0)]
        public ulong UniqueID;
    }

    [MessagePackObject, Route((ushort)ClientPacketIds.ReplaceWedRing)]
    public sealed class ReplaceWedRing : Packet
    {
        [Key(0)]
        public ulong UniqueID;
    }


    [MessagePackObject, Route((ushort)ClientPacketIds.DepositTradeItem)]
    public sealed class DepositTradeItem : Packet
    {
        [Key(0)]
        public int From;
        [Key(1)]
        public int To;
    }

    [MessagePackObject, Route((ushort)ClientPacketIds.RetrieveTradeItem)]
    public sealed class RetrieveTradeItem : Packet
    {
        [Key(0)]
        public int From;
        [Key(1)]
        public int To;
    }

    [MessagePackObject, Route((ushort)ClientPacketIds.TakeBackItem)]
    public sealed class TakeBackItem : Packet
    {
        [Key(0)]
        public int From;
        [Key(1)]
        public int To;
    }

    [MessagePackObject, Route((ushort)ClientPacketIds.MergeItem)]
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
    }

    [MessagePackObject, Route((ushort)ClientPacketIds.EquipItem)]
    public sealed class EquipItem : Packet
    {
        [Key(0)]
        public MirGridType Grid;
        [Key(1)]
        public ulong UniqueID;
        [Key(2)]
        public int To;
    }

    [MessagePackObject, Route((ushort)ClientPacketIds.RemoveItem)]
    public sealed class RemoveItem : Packet
    {
        [Key(0)]
        public MirGridType Grid;
        [Key(1)]
        public ulong UniqueID;
        [Key(2)]
        public int To;
    }

    [MessagePackObject, Route((ushort)ClientPacketIds.RemoveSlotItem)]
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
        public ulong FromUniqueID;
    }

    [MessagePackObject, Route((ushort)ClientPacketIds.SplitItem)]
    public sealed class SplitItem : Packet
    {
        [Key(0)]
        public MirGridType Grid;
        [Key(1)]
        public ulong UniqueID;
        [Key(2)]
        public ushort Count;
    }

    [MessagePackObject, Route((ushort)ClientPacketIds.UseItem)]
    public sealed class UseItem : Packet
    {
        [Key(0)]
        public ulong UniqueID;
        [Key(1)]
        public MirGridType Grid;
    }

    [MessagePackObject, Route((ushort)ClientPacketIds.DropItem)]
    public sealed class DropItem : Packet
    {
        [Key(0)]
        public ulong UniqueID;
        [Key(1)]
        public ushort Count;
        [Key(2)]
        public bool HeroInventory = false;
    }

    [MessagePackObject, Route((ushort)ClientPacketIds.TakeBackHeroItem)]
    public sealed class TakeBackHeroItem : Packet
    {
        [Key(0)]
        public int From;
        [Key(1)]
        public int To;
    }

    [MessagePackObject, Route((ushort)ClientPacketIds.TransferHeroItem)]
    public sealed class TransferHeroItem : Packet
    {
        [Key(0)]
        public int From;
        [Key(1)]
        public int To;
    }

    [MessagePackObject, Route((ushort)ClientPacketIds.DropGold)]
    public sealed class DropGold : Packet
    {
        [Key(0)]
        public uint Amount;
    }

    [MessagePackObject, Route((ushort)ClientPacketIds.PickUp)]
    public sealed class PickUp : Packet
    {

    }

    [MessagePackObject, Route((ushort)ClientPacketIds.Inspect)]
    public sealed class Inspect : Packet
    {
        [Key(0)]
        public uint ObjectID;
        [Key(1)]
        public bool Ranking = false;
        [Key(2)]
        public bool Hero = false;
    }

    [MessagePackObject, Route((ushort)ClientPacketIds.Observe)]
    public sealed class Observe : Packet
    {
        [Key(0)]
        public string Name;
    }

    [MessagePackObject, Route((ushort)ClientPacketIds.ChangeAMode)]
    public sealed class ChangeAMode : Packet
    {
        [Key(0)]
        public AttackMode Mode;
    }

    [MessagePackObject, Route((ushort)ClientPacketIds.ChangePMode)]
    public sealed class ChangePMode : Packet
    {
        [Key(0)]
        public PetMode Mode;
    }

    [MessagePackObject, Route((ushort)ClientPacketIds.ChangeTrade)]
    public sealed class ChangeTrade : Packet
    {
        [Key(0)]
        public bool AllowTrade;
    }

    [MessagePackObject, Route((ushort)ClientPacketIds.Attack)]
    public sealed class Attack : Packet
    {
        [Key(0)]
        public MirDirection Direction;
        [Key(1)]
        public Spell Spell;
    }

    [MessagePackObject, Route((ushort)ClientPacketIds.RangeAttack)]
    public sealed class RangeAttack : Packet //ArcherTest
    {
        [Key(0)]
        public MirDirection Direction;
        [Key(1)]
        public Point Location;
        [Key(2)]
        public uint TargetID;
        [Key(3)]
        public Point TargetLocation;
    }

    [MessagePackObject, Route((ushort)ClientPacketIds.Harvest)]
    public sealed class Harvest : Packet
    {
        [Key(0)]
        public MirDirection Direction;
    }

    [MessagePackObject, Route((ushort)ClientPacketIds.CallNPC)]
    public sealed class CallNPC : Packet
    {
        [Key(0)]
        public uint ObjectID;
        [Key(1)]
        public string Key = string.Empty;
    }

    [MessagePackObject, Route((ushort)ClientPacketIds.BuyItem)]
    public sealed class BuyItem : Packet
    {
        [Key(0)]
        public ulong ItemIndex;
        [Key(1)]
        public ushort Count;
        [Key(2)]
        public PanelType Type;
    }

    [MessagePackObject, Route((ushort)ClientPacketIds.SellItem)]
    public sealed class SellItem : Packet
    {
        [Key(0)]
        public ulong UniqueID;
        [Key(1)]
        public ushort Count;
    }

    [MessagePackObject, Route((ushort)ClientPacketIds.CraftItem)]
    public sealed class CraftItem : Packet
    {
        [Key(0)]
        public ulong UniqueID;
        [Key(1)]
        public ushort Count;
        [Key(2)]
        public int[] Slots;
    }

    [MessagePackObject, Route((ushort)ClientPacketIds.RepairItem)]
    public sealed class RepairItem : Packet
    {
        [Key(0)]
        public ulong UniqueID;
    }

    [MessagePackObject, Route((ushort)ClientPacketIds.BuyItemBack)]
    public sealed class BuyItemBack : Packet
    {
        [Key(0)]
        public ulong UniqueID;
        [Key(1)]
        public ushort Count;
    }

    [MessagePackObject, Route((ushort)ClientPacketIds.SRepairItem)]
    public sealed class SRepairItem : Packet
    {
        [Key(0)]
        public ulong UniqueID;
    }

    [MessagePackObject, Route((ushort)ClientPacketIds.RequestMapInfo)]
    public sealed class RequestMapInfo : Packet
    {
        [Key(0)]
        public int MapIndex;
    }

    [MessagePackObject, Route((ushort)ClientPacketIds.TeleportToNPC)]
    public sealed class TeleportToNPC : Packet
    {
        [Key(0)]
        public uint ObjectID;
    }

    [MessagePackObject, Route((ushort)ClientPacketIds.SearchMap)]
    public sealed class SearchMap : Packet
    {
        [Key(0)]
        public string Text;
    }

    [MessagePackObject, Route((ushort)ClientPacketIds.MagicKey)]
    public sealed class MagicKey : Packet
    {
        [Key(0)]
        public Spell Spell;
        [Key(1)]
        public byte Key;
        [Key(2)]
        public byte OldKey;
    }

    [MessagePackObject, Route((ushort)ClientPacketIds.Magic)]
    public sealed class Magic : Packet
    {
        [Key(0)]
        public Spell Spell;
        [Key(1)]
        public MirDirection Direction;
        [Key(2)]
        public uint TargetID;
        [Key(3)]
        public Point Location;
        [Key(4)]
        public uint ObjectID;
        [Key(5)]
        public bool SpellTargetLock;
    }

    [MessagePackObject, Route((ushort)ClientPacketIds.SwitchGroup)]
    public sealed class SwitchGroup : Packet
    {
        [Key(0)]
        public bool AllowGroup;
    }

    [MessagePackObject, Route((ushort)ClientPacketIds.AddMember)]
    public sealed class AddMember : Packet
    {
        [Key(0)]
        public string Name = string.Empty;
    }

    [MessagePackObject, Route((ushort)ClientPacketIds.DellMember)]
    public sealed class DelMember : Packet
    {
        [Key(0)]
        public string Name = string.Empty;
    }

    [MessagePackObject, Route((ushort)ClientPacketIds.GroupInvite)]
    public sealed class GroupInvite : Packet
    {
        [Key(0)]
        public bool AcceptInvite;
    }

    [MessagePackObject, Route((ushort)ClientPacketIds.NewHero)]
    public sealed class NewHero : Packet
    {
        [Key(0)]
        public string Name = string.Empty;
        [Key(1)]
        public MirGender Gender;
        [Key(2)]
        public MirClass Class;
    }

    [MessagePackObject, Route((ushort)ClientPacketIds.SetAutoPotValue)]
    public sealed class SetAutoPotValue : Packet
    {
        [Key(0)]
        public Stat Stat;
        [Key(1)]
        public uint Value;
    }

    [MessagePackObject, Route((ushort)ClientPacketIds.SetAutoPotItem)]
    public sealed class SetAutoPotItem : Packet
    {
        [Key(0)]
        public MirGridType Grid;
        [Key(1)]
        public int ItemIndex;
    }

    [MessagePackObject, Route((ushort)ClientPacketIds.SetHeroBehaviour)]
    public sealed class SetHeroBehaviour : Packet
    {
        [Key(0)]
        public HeroBehaviour Behaviour;
    }

    [MessagePackObject, Route((ushort)ClientPacketIds.ChangeHero)]
    public sealed class ChangeHero : Packet
    {
        [Key(0)]
        public int ListIndex;
    }

    [MessagePackObject, Route((ushort)ClientPacketIds.MarriageRequest)]
    public sealed class MarriageRequest : Packet
    {

    }

    [MessagePackObject, Route((ushort)ClientPacketIds.MarriageReply)]
    public sealed class MarriageReply : Packet
    {
        [Key(0)]
        public bool AcceptInvite;
    }

    [MessagePackObject, Route((ushort)ClientPacketIds.ChangeMarriage)]
    public sealed class ChangeMarriage : Packet
    {

    }

    [MessagePackObject, Route((ushort)ClientPacketIds.DivorceRequest)]
    public sealed class DivorceRequest : Packet
    {

    }

    [MessagePackObject, Route((ushort)ClientPacketIds.DivorceReply)]
    public sealed class DivorceReply : Packet
    {
        [Key(0)]
        public bool AcceptInvite;
    }

    [MessagePackObject, Route((ushort)ClientPacketIds.AddMentor)]
    public sealed class AddMentor : Packet
    {
        [Key(0)]
        public string Name;
    }

    [MessagePackObject, Route((ushort)ClientPacketIds.MentorReply)]
    public sealed class MentorReply : Packet
    {
        [Key(0)]
        public bool AcceptInvite;
    }

    [MessagePackObject, Route((ushort)ClientPacketIds.AllowMentor)]
    public sealed class AllowMentor : Packet
    {

    }

    [MessagePackObject, Route((ushort)ClientPacketIds.CancelMentor)]
    public sealed class CancelMentor : Packet
    {

    }


    [MessagePackObject, Route((ushort)ClientPacketIds.TradeReply)]
    public sealed class TradeReply : Packet
    {
        [Key(0)]
        public bool AcceptInvite;
    }

    [MessagePackObject, Route((ushort)ClientPacketIds.TradeRequest)]
    public sealed class TradeRequest : Packet
    {

    }

    [MessagePackObject, Route((ushort)ClientPacketIds.TradeGold)]
    public sealed class TradeGold : Packet
    {
        [Key(0)]
        public uint Amount;
    }

    [MessagePackObject, Route((ushort)ClientPacketIds.TradeConfirm)]
    public sealed class TradeConfirm : Packet
    {
        [Key(0)]
        public bool Locked;
    }

    [MessagePackObject, Route((ushort)ClientPacketIds.TradeCancel)]
    public sealed class TradeCancel : Packet
    {

    }

    [MessagePackObject, Route((ushort)ClientPacketIds.TownRevive)]
    public sealed class TownRevive : Packet
    {

    }

    [MessagePackObject, Route((ushort)ClientPacketIds.SpellToggle)]
    public sealed class SpellToggle : Packet
    {
        [Key(0)]
        public Spell Spell;
        [Key(1)]
        public SpellToggleState canUse = SpellToggleState.None;

        [Key(2)]
        public bool CanUse
        {
            get { return Convert.ToBoolean(canUse); }
            set { canUse = (SpellToggleState)Convert.ToSByte(value); }
        }
    }

    [MessagePackObject, Route((ushort)ClientPacketIds.ConsignItem)]
    public sealed class ConsignItem : Packet
    {
        [Key(0)]
        public ulong UniqueID;
        [Key(1)]
        public uint Price;
        [Key(2)]
        public MarketPanelType Type;
    }

    [MessagePackObject, Route((ushort)ClientPacketIds.MarketSearch)]
    public sealed class MarketSearch : Packet
    {
        [Key(0)]
        public string Match = string.Empty;
        [Key(1)]
        public ItemType Type = 0;
        [Key(2)]
        public bool Usermode = false;
        [Key(3)]
        public short MinShape = 0;
        [Key(4)]
        public short MaxShape = 5000;
        [Key(5)]
        public MarketPanelType MarketType = MarketPanelType.Market;
    }

    [MessagePackObject, Route((ushort)ClientPacketIds.MarketRefresh)]
    public sealed class MarketRefresh : Packet
    {

    }

    [MessagePackObject, Route((ushort)ClientPacketIds.MarketPage)]
    public sealed class MarketPage : Packet
    {
        [Key(0)]
        public int Page;
    }

    [MessagePackObject, Route((ushort)ClientPacketIds.MarketBuy)]
    public sealed class MarketBuy : Packet
    {
        [Key(0)]
        public ulong AuctionID;
        [Key(1)]
        public uint BidPrice;
    }

    [MessagePackObject, Route((ushort)ClientPacketIds.MarketSellNow)]
    public sealed class MarketSellNow : Packet
    {
        [Key(0)]
        public ulong AuctionID;
    }

    [MessagePackObject, Route((ushort)ClientPacketIds.MarketGetBack)]
    public sealed class MarketGetBack : Packet
    {
        [Key(0)]
        public ulong AuctionID;
    }

    [MessagePackObject, Route((ushort)ClientPacketIds.RequestUserName)]
    public sealed class RequestUserName : Packet
    {
        [Key(0)]
        public uint UserID;
    }

    [MessagePackObject, Route((ushort)ClientPacketIds.RequestChatItem)]
    public sealed class RequestChatItem : Packet
    {
        [Key(0)]
        public ulong ChatItemID;
    }

    [MessagePackObject, Route((ushort)ClientPacketIds.EditGuildMember)]
    public sealed class EditGuildMember : Packet
    {
        [Key(0)]
        public byte ChangeType = 0;
        [Key(1)]
        public byte RankIndex = 0;
        [Key(2)]
        public string Name = "";
        [Key(3)]
        public string RankName = "";
    }

    [MessagePackObject, Route((ushort)ClientPacketIds.EditGuildNotice)]
    public sealed class EditGuildNotice : Packet
    {
        [Key(0)]
        public List<string> notice = new List<string>();
    }

    [MessagePackObject, Route((ushort)ClientPacketIds.GuildInvite)]
    public sealed class GuildInvite : Packet
    {
        [Key(0)]
        public bool AcceptInvite;
    }

    [MessagePackObject, Route((ushort)ClientPacketIds.RequestGuildInfo)]
    public sealed class RequestGuildInfo : Packet
    {
        [Key(0)]
        public byte Type;
    }

    [MessagePackObject, Route((ushort)ClientPacketIds.GuildNameReturn)]
    public sealed class GuildNameReturn : Packet
    {
        [Key(0)]
        public string Name;
    }

    [MessagePackObject, Route((ushort)ClientPacketIds.GuildWarReturn)]
    public sealed class GuildWarReturn : Packet
    {
        [Key(0)]
        public string Name;
    }

    [MessagePackObject, Route((ushort)ClientPacketIds.GuildStorageGoldChange)]
    public sealed class GuildStorageGoldChange : Packet
    {
        [Key(0)]
        public byte Type = 0;
        [Key(1)]
        public uint Amount = 0;
    }

    [MessagePackObject, Route((ushort)ClientPacketIds.GuildStorageItemChange)]
    public sealed class GuildStorageItemChange : Packet
    {
        [Key(0)]
        public byte Type = 0;
        [Key(1)]
        public int From;
        [Key(2)]
        public int To;
    }

    [MessagePackObject, Route((ushort)ClientPacketIds.EquipSlotItem)]
    public sealed class EquipSlotItem : Packet
    {
        [Key(0)]
        public MirGridType Grid;
        [Key(1)]
        public ulong UniqueID;
        [Key(2)]
        public int To;
        [Key(3)]
        public MirGridType GridTo;
        [Key(4)]
        public ulong ToUniqueID;
    }

    [MessagePackObject, Route((ushort)ClientPacketIds.FishingCast)]
    public sealed class FishingCast : Packet
    {
        [Key(0)]
        public bool CastOut;
    }

    [MessagePackObject, Route((ushort)ClientPacketIds.FishingChangeAutocast)]
    public sealed class FishingChangeAutocast : Packet
    {
        [Key(0)]
        public bool AutoCast;
    }

    [MessagePackObject, Route((ushort)ClientPacketIds.AcceptQuest)]
    public sealed class AcceptQuest : Packet
    {
        [Key(0)]
        public uint NPCIndex;
        [Key(1)]
        public int QuestIndex;
    }

    [MessagePackObject, Route((ushort)ClientPacketIds.FinishQuest)]
    public sealed class FinishQuest : Packet
    {
        [Key(0)]
        public int QuestIndex;
        [Key(1)]
        public int SelectedItemIndex;
    }

    [MessagePackObject, Route((ushort)ClientPacketIds.AbandonQuest)]
    public sealed class AbandonQuest : Packet
    {
        [Key(0)]
        public int QuestIndex;
    }

    [MessagePackObject, Route((ushort)ClientPacketIds.ShareQuest)]
    public sealed class ShareQuest : Packet
    {
        [Key(0)]
        public int QuestIndex;
    }

    [MessagePackObject, Route((ushort)ClientPacketIds.AcceptReincarnation)]
    public sealed class AcceptReincarnation : Packet
    {

    }

    [MessagePackObject, Route((ushort)ClientPacketIds.CancelReincarnation)]
    public sealed class CancelReincarnation : Packet
    {

    }

    [MessagePackObject, Route((ushort)ClientPacketIds.CombineItem)]
    public sealed class CombineItem : Packet
    {
        [Key(0)]
        public MirGridType Grid;
        [Key(1)]
        public ulong IDFrom;
        [Key(2)]
        public ulong IDTo;
    }

    [MessagePackObject, Route((ushort)ClientPacketIds.AwakeningNeedMaterials)]
    public sealed class AwakeningNeedMaterials : Packet
    {
        [Key(0)]
        public ulong UniqueID;
        [Key(1)]
        public AwakeType Type;
    }

    [MessagePackObject, Route((ushort)ClientPacketIds.AwakeningLockedItem)]
    public sealed class AwakeningLockedItem : Packet
    {
        [Key(0)]
        public ulong UniqueID;
        [Key(1)]
        public bool Locked;
    }

    [MessagePackObject, Route((ushort)ClientPacketIds.Awakening)]
    public sealed class Awakening : Packet
    {
        [Key(0)]
        public ulong UniqueID;
        [Key(1)]
        public AwakeType Type;
        [Key(2)]
        public uint PositionIdx;
    }

    [MessagePackObject, Route((ushort)ClientPacketIds.DisassembleItem)]
    public sealed class DisassembleItem : Packet
    {
        [Key(0)]
        public ulong UniqueID;
    }

    [MessagePackObject, Route((ushort)ClientPacketIds.DowngradeAwakening)]
    public sealed class DowngradeAwakening : Packet
    {
        [Key(0)]
        public ulong UniqueID;
    }

    [MessagePackObject, Route((ushort)ClientPacketIds.ResetAddedItem)]
    public sealed class ResetAddedItem : Packet
    {
        [Key(0)]
        public ulong UniqueID;
    }

    [MessagePackObject, Route((ushort)ClientPacketIds.SendMail)]
    public sealed class SendMail : Packet
    {
        [Key(0)]
        public string Name;
        [Key(1)]
        public string Message;
        [Key(2)]
        public uint Gold;
        [Key(3)]
        public ulong[] ItemsIdx = new ulong[5];
        [Key(4)]
        public bool Stamped;
    }

    [MessagePackObject, Route((ushort)ClientPacketIds.ReadMail)]
    public sealed class ReadMail : Packet
    {
        [Key(0)]
        public ulong MailID;
    }

    [MessagePackObject, Route((ushort)ClientPacketIds.CollectParcel)]
    public sealed class CollectParcel : Packet
    {
        [Key(0)]
        public ulong MailID;
    }

    [MessagePackObject, Route((ushort)ClientPacketIds.DeleteMail)]
    public sealed class DeleteMail : Packet
    {
        [Key(0)]
        public ulong MailID;
    }

    [MessagePackObject, Route((ushort)ClientPacketIds.LockMail)]
    public sealed class LockMail : Packet
    {
        [Key(0)]
        public ulong MailID;
        [Key(1)]
        public bool Lock;
    }

    [MessagePackObject, Route((ushort)ClientPacketIds.MailLockedItem)]
    public sealed class MailLockedItem : Packet
    {
        [Key(0)]
        public ulong UniqueID;
        [Key(1)]
        public bool Locked;
    }

    [MessagePackObject, Route((ushort)ClientPacketIds.MailCost)]
    public sealed class MailCost : Packet
    {
        [Key(0)]
        public uint Gold;
        [Key(1)]
        public ulong[] ItemsIdx = new ulong[5];
        [Key(2)]
        public bool Stamped;
    }

    [MessagePackObject, Route((ushort)ClientPacketIds.RequestIntelligentCreatureUpdates)]
    public sealed class RequestIntelligentCreatureUpdates : Packet
    {
        [Key(0)]
        public bool Update = false;
    }

    [MessagePackObject, Route((ushort)ClientPacketIds.UpdateIntelligentCreature)]
    public sealed class UpdateIntelligentCreature : Packet
    {
        [Key(0)]
        public ClientIntelligentCreature Creature;
        [Key(1)]
        public bool SummonMe = false;
        [Key(2)]
        public bool UnSummonMe = false;
        [Key(3)]
        public bool ReleaseMe = false;
    }

    [MessagePackObject, Route((ushort)ClientPacketIds.IntelligentCreaturePickup)]
    public sealed class IntelligentCreaturePickup : Packet
    {
        [Key(0)]
        public bool MouseMode = false;
        [Key(1)]
        public Point Location = new Point(0, 0);
    }

    [MessagePackObject, Route((ushort)ClientPacketIds.AddFriend)]
    public sealed class AddFriend : Packet
    {
        [Key(0)]
        public string Name;
        [Key(1)]
        public bool Blocked;
    }

    [MessagePackObject, Route((ushort)ClientPacketIds.RemoveFriend)]
    public sealed class RemoveFriend : Packet
    {
        [Key(0)]
        public int CharacterIndex;
    }

    [MessagePackObject, Route((ushort)ClientPacketIds.RefreshFriends)]
    public sealed class RefreshFriends : Packet
    {

    }


    [MessagePackObject, Route((ushort)ClientPacketIds.AddMemo)]
    public sealed class AddMemo : Packet
    {
        [Key(0)]
        public int CharacterIndex;
        [Key(1)]
        public string Memo;
    }

    [MessagePackObject, Route((ushort)ClientPacketIds.GuildBuffUpdate)]
    public sealed class GuildBuffUpdate : Packet
    {
        [Key(0)]
        public byte Action = 0;
        [Key(1)]
        public int Id;
    }

    [MessagePackObject, Route((ushort)ClientPacketIds.GameshopBuy)]
    public sealed class GameshopBuy : Packet
    {
        [Key(0)]
        public int GIndex;
        [Key(1)]
        public byte Quantity;
        [Key(2)]
        public int PType;
    }

    [MessagePackObject, Route((ushort)ClientPacketIds.NPCConfirmInput)]
    public sealed class NPCConfirmInput : Packet
    {
        [Key(0)]
        public uint NPCID;
        [Key(1)]
        public string PageName;
        [Key(2)]
        public string Value;
    }

    [MessagePackObject, Route((ushort)ClientPacketIds.ReportIssue)]
    public sealed class ReportIssue : Packet
    {
        [Key(0)]
        public byte[] Image;
        [Key(1)]
        public int ImageSize;
        [Key(2)]
        public int ImageChunk;
        [Key(3)]
        public string Message;
    }

    [MessagePackObject, Route((ushort)ClientPacketIds.GetRanking)]
    public sealed class GetRanking : Packet
    {
        [Key(0)]
        public byte RankType;
        [Key(1)]
        public int RankIndex;
        [Key(2)]
        public bool OnlineOnly;
    }

    [MessagePackObject, Route((ushort)ClientPacketIds.Opendoor)]
    public sealed class Opendoor : Packet
    {
        [Key(0)]
        public byte DoorIndex;
    }

    [MessagePackObject, Route((ushort)ClientPacketIds.GetRentedItems)]
    public sealed class GetRentedItems : Packet
    {

    }

    [MessagePackObject, Route((ushort)ClientPacketIds.ItemRentalRequest)]
    public sealed class ItemRentalRequest : Packet
    {

    }

    [MessagePackObject, Route((ushort)ClientPacketIds.ItemRentalFee)]
    public sealed class ItemRentalFee : Packet
    {
        [Key(0)]
        public uint Amount;
    }

    [MessagePackObject, Route((ushort)ClientPacketIds.ItemRentalPeriod)]
    public sealed class ItemRentalPeriod : Packet
    {
        [Key(0)]
        public uint Days;
    }

    [MessagePackObject, Route((ushort)ClientPacketIds.DepositRentalItem)]
    public sealed class DepositRentalItem : Packet
    {
        [Key(0)]
        public int From;
        [Key(1)]
        public int To;
    }

    [MessagePackObject, Route((ushort)ClientPacketIds.RetrieveRentalItem)]
    public sealed class RetrieveRentalItem : Packet
    {
        [Key(0)]
        public int From;
        [Key(1)]
        public int To;
    }

    [MessagePackObject, Route((ushort)ClientPacketIds.CancelItemRental)]
    public sealed class CancelItemRental : Packet
    {

    }

    [MessagePackObject, Route((ushort)ClientPacketIds.ItemRentalLockFee)]
    public sealed class ItemRentalLockFee : Packet
    {

    }

    [MessagePackObject, Route((ushort)ClientPacketIds.ItemRentalLockItem)]
    public sealed class ItemRentalLockItem : Packet
    {

    }

    [MessagePackObject, Route((ushort)ClientPacketIds.ConfirmItemRental)]
    public sealed class ConfirmItemRental : Packet
    {

    }
}