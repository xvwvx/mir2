using System.Drawing;
using MemoryPack;

using Shared;

namespace ClientPackets
{
    [MemoryPackable, Route((ushort)ClientPacketIds.ClientVersion)]
    public sealed partial class ClientVersion : Packet
    {
        [MemoryPackOrder(0)]
        public byte[] VersionHash;
    }

    [MemoryPackable, Route((ushort)ClientPacketIds.Disconnect)]
    public sealed partial class Disconnect : Packet
    {

    }

    [MemoryPackable, Route((ushort)ClientPacketIds.KeepAlive)]
    public sealed partial class KeepAlive : Packet
    {
        [MemoryPackOrder(0)]
        public long Time;
    }

    [MemoryPackable, Route((ushort)ClientPacketIds.NewAccount)]
    public sealed partial class NewAccount : Packet
    {
        [MemoryPackOrder(0)]
        public string AccountID = string.Empty;
        [MemoryPackOrder(1)]
        public string Password = string.Empty;
        [MemoryPackOrder(2)]
        public DateTime BirthDate;
        [MemoryPackOrder(3)]
        public string UserName = string.Empty;
        [MemoryPackOrder(4)]
        public string SecretQuestion = string.Empty;
        [MemoryPackOrder(5)]
        public string SecretAnswer = string.Empty;
        [MemoryPackOrder(6)]
        public string EMailAddress = string.Empty;
    }

    [MemoryPackable, Route((ushort)ClientPacketIds.ChangePassword)]
    public sealed partial class ChangePassword : Packet
    {
        [MemoryPackOrder(0)]
        public string AccountID = string.Empty;
        [MemoryPackOrder(1)]
        public string CurrentPassword = string.Empty;
        [MemoryPackOrder(2)]
        public string NewPassword = string.Empty;
    }

    [MemoryPackable, Route((ushort)ClientPacketIds.Login)]
    public sealed partial class Login : Packet
    {
        [MemoryPackOrder(0)]
        public string AccountID = string.Empty;
        [MemoryPackOrder(1)]
        public string Password = string.Empty;
    }

    [MemoryPackable, Route((ushort)ClientPacketIds.NewCharacter)]
    public sealed partial class NewCharacter : Packet
    {
        [MemoryPackOrder(0)]
        public string Name = string.Empty;
        [MemoryPackOrder(1)]
        public MirGender Gender;
        [MemoryPackOrder(2)]
        public MirClass Class;
    }

    [MemoryPackable, Route((ushort)ClientPacketIds.DeleteCharacter)]
    public sealed partial class DeleteCharacter : Packet
    {
        [MemoryPackOrder(0)]
        public int CharacterIndex;
    }

    [MemoryPackable, Route((ushort)ClientPacketIds.StartGame)]
    public sealed partial class StartGame : Packet
    {
        [MemoryPackOrder(0)]
        public int CharacterIndex;
    }

    [MemoryPackable, Route((ushort)ClientPacketIds.LogOut)]
    public sealed partial class LogOut : Packet
    {

    }

    [MemoryPackable, Route((ushort)ClientPacketIds.Turn)]
    public sealed partial class Turn : Packet
    {
        [MemoryPackOrder(0)]
        public MirDirection Direction;
    }

    [MemoryPackable, Route((ushort)ClientPacketIds.Walk)]
    public sealed partial class Walk : Packet
    {
        [MemoryPackOrder(0)]
        public MirDirection Direction;
    }

    [MemoryPackable, Route((ushort)ClientPacketIds.Run)]
    public sealed partial class Run : Packet
    {
        [MemoryPackOrder(0)]
        public MirDirection Direction;
    }

    [MemoryPackable, Route((ushort)ClientPacketIds.Chat)]
    public sealed partial class Chat : Packet
    {
        [MemoryPackOrder(0)]
        public string Message = string.Empty;
        [MemoryPackOrder(1)]
        public List<ChatItem> LinkedItems = new List<ChatItem>();
    }

    [MemoryPackable, Route((ushort)ClientPacketIds.MoveItem)]
    public sealed partial class MoveItem : Packet
    {
        [MemoryPackOrder(0)]
        public MirGridType Grid;
        [MemoryPackOrder(1)]
        public int From;
        [MemoryPackOrder(2)]
        public int To;
    }

    [MemoryPackable, Route((ushort)ClientPacketIds.StoreItem)]
    public sealed partial class StoreItem : Packet
    {
        [MemoryPackOrder(0)]
        public int From;
        [MemoryPackOrder(1)]
        public int To;
    }

    [MemoryPackable, Route((ushort)ClientPacketIds.DepositRefineItem)]
    public sealed partial class DepositRefineItem : Packet
    {
        [MemoryPackOrder(0)]
        public int From;
        [MemoryPackOrder(1)]
        public int To;
    }

    [MemoryPackable, Route((ushort)ClientPacketIds.RetrieveRefineItem)]
    public sealed partial class RetrieveRefineItem : Packet
    {
        [MemoryPackOrder(0)]
        public int From;
        [MemoryPackOrder(1)]
        public int To;
    }

    [MemoryPackable, Route((ushort)ClientPacketIds.RefineCancel)]
    public sealed partial class RefineCancel : Packet
    {

    }

    [MemoryPackable, Route((ushort)ClientPacketIds.RefineItem)]
    public sealed partial class RefineItem : Packet
    {
        [MemoryPackOrder(0)]
        public ulong UniqueID;
    }

    [MemoryPackable, Route((ushort)ClientPacketIds.CheckRefine)]
    public sealed partial class CheckRefine : Packet
    {
        [MemoryPackOrder(0)]
        public ulong UniqueID;
    }

    [MemoryPackable, Route((ushort)ClientPacketIds.ReplaceWedRing)]
    public sealed partial class ReplaceWedRing : Packet
    {
        [MemoryPackOrder(0)]
        public ulong UniqueID;
    }


    [MemoryPackable, Route((ushort)ClientPacketIds.DepositTradeItem)]
    public sealed partial class DepositTradeItem : Packet
    {
        [MemoryPackOrder(0)]
        public int From;
        [MemoryPackOrder(1)]
        public int To;
    }

    [MemoryPackable, Route((ushort)ClientPacketIds.RetrieveTradeItem)]
    public sealed partial class RetrieveTradeItem : Packet
    {
        [MemoryPackOrder(0)]
        public int From;
        [MemoryPackOrder(1)]
        public int To;
    }

    [MemoryPackable, Route((ushort)ClientPacketIds.TakeBackItem)]
    public sealed partial class TakeBackItem : Packet
    {
        [MemoryPackOrder(0)]
        public int From;
        [MemoryPackOrder(1)]
        public int To;
    }

    [MemoryPackable, Route((ushort)ClientPacketIds.MergeItem)]
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
    }

    [MemoryPackable, Route((ushort)ClientPacketIds.EquipItem)]
    public sealed partial class EquipItem : Packet
    {
        [MemoryPackOrder(0)]
        public MirGridType Grid;
        [MemoryPackOrder(1)]
        public ulong UniqueID;
        [MemoryPackOrder(2)]
        public int To;
    }

    [MemoryPackable, Route((ushort)ClientPacketIds.RemoveItem)]
    public sealed partial class RemoveItem : Packet
    {
        [MemoryPackOrder(0)]
        public MirGridType Grid;
        [MemoryPackOrder(1)]
        public ulong UniqueID;
        [MemoryPackOrder(2)]
        public int To;
    }

    [MemoryPackable, Route((ushort)ClientPacketIds.RemoveSlotItem)]
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
        public ulong FromUniqueID;
    }

    [MemoryPackable, Route((ushort)ClientPacketIds.SplitItem)]
    public sealed partial class SplitItem : Packet
    {
        [MemoryPackOrder(0)]
        public MirGridType Grid;
        [MemoryPackOrder(1)]
        public ulong UniqueID;
        [MemoryPackOrder(2)]
        public ushort Count;
    }

    [MemoryPackable, Route((ushort)ClientPacketIds.UseItem)]
    public sealed partial class UseItem : Packet
    {
        [MemoryPackOrder(0)]
        public ulong UniqueID;
        [MemoryPackOrder(1)]
        public MirGridType Grid;
    }

    [MemoryPackable, Route((ushort)ClientPacketIds.DropItem)]
    public sealed partial class DropItem : Packet
    {
        [MemoryPackOrder(0)]
        public ulong UniqueID;
        [MemoryPackOrder(1)]
        public ushort Count;
        [MemoryPackOrder(2)]
        public bool HeroInventory = false;
    }

    [MemoryPackable, Route((ushort)ClientPacketIds.TakeBackHeroItem)]
    public sealed partial class TakeBackHeroItem : Packet
    {
        [MemoryPackOrder(0)]
        public int From;
        [MemoryPackOrder(1)]
        public int To;
    }

    [MemoryPackable, Route((ushort)ClientPacketIds.TransferHeroItem)]
    public sealed partial class TransferHeroItem : Packet
    {
        [MemoryPackOrder(0)]
        public int From;
        [MemoryPackOrder(1)]
        public int To;
    }

    [MemoryPackable, Route((ushort)ClientPacketIds.DropGold)]
    public sealed partial class DropGold : Packet
    {
        [MemoryPackOrder(0)]
        public uint Amount;
    }

    [MemoryPackable, Route((ushort)ClientPacketIds.PickUp)]
    public sealed partial class PickUp : Packet
    {

    }

    [MemoryPackable, Route((ushort)ClientPacketIds.Inspect)]
    public sealed partial class Inspect : Packet
    {
        [MemoryPackOrder(0)]
        public uint ObjectID;
        [MemoryPackOrder(1)]
        public bool Ranking = false;
        [MemoryPackOrder(2)]
        public bool Hero = false;
    }

    [MemoryPackable, Route((ushort)ClientPacketIds.Observe)]
    public sealed partial class Observe : Packet
    {
        [MemoryPackOrder(0)]
        public string Name;
    }

    [MemoryPackable, Route((ushort)ClientPacketIds.ChangeAMode)]
    public sealed partial class ChangeAMode : Packet
    {
        [MemoryPackOrder(0)]
        public AttackMode Mode;
    }

    [MemoryPackable, Route((ushort)ClientPacketIds.ChangePMode)]
    public sealed partial class ChangePMode : Packet
    {
        [MemoryPackOrder(0)]
        public PetMode Mode;
    }

    [MemoryPackable, Route((ushort)ClientPacketIds.ChangeTrade)]
    public sealed partial class ChangeTrade : Packet
    {
        [MemoryPackOrder(0)]
        public bool AllowTrade;
    }

    [MemoryPackable, Route((ushort)ClientPacketIds.Attack)]
    public sealed partial class Attack : Packet
    {
        [MemoryPackOrder(0)]
        public MirDirection Direction;
        [MemoryPackOrder(1)]
        public Spell Spell;
    }

    [MemoryPackable, Route((ushort)ClientPacketIds.RangeAttack)]
    public sealed partial class RangeAttack : Packet //ArcherTest
    {
        [MemoryPackOrder(0)]
        public MirDirection Direction;
        [MemoryPackOrder(1)]
        public Point Location;
        [MemoryPackOrder(2)]
        public uint TargetID;
        [MemoryPackOrder(3)]
        public Point TargetLocation;
    }

    [MemoryPackable, Route((ushort)ClientPacketIds.Harvest)]
    public sealed partial class Harvest : Packet
    {
        [MemoryPackOrder(0)]
        public MirDirection Direction;
    }

    [MemoryPackable, Route((ushort)ClientPacketIds.CallNPC)]
    public sealed partial class CallNPC : Packet
    {
        [MemoryPackOrder(0)]
        public uint ObjectID;
        [MemoryPackOrder(1)]
        public string Key = string.Empty;
    }

    [MemoryPackable, Route((ushort)ClientPacketIds.BuyItem)]
    public sealed partial class BuyItem : Packet
    {
        [MemoryPackOrder(0)]
        public ulong ItemIndex;
        [MemoryPackOrder(1)]
        public ushort Count;
        [MemoryPackOrder(2)]
        public PanelType Type;
    }

    [MemoryPackable, Route((ushort)ClientPacketIds.SellItem)]
    public sealed partial class SellItem : Packet
    {
        [MemoryPackOrder(0)]
        public ulong UniqueID;
        [MemoryPackOrder(1)]
        public ushort Count;
    }

    [MemoryPackable, Route((ushort)ClientPacketIds.CraftItem)]
    public sealed partial class CraftItem : Packet
    {
        [MemoryPackOrder(0)]
        public ulong UniqueID;
        [MemoryPackOrder(1)]
        public ushort Count;
        [MemoryPackOrder(2)]
        public int[] Slots;
    }

    [MemoryPackable, Route((ushort)ClientPacketIds.RepairItem)]
    public sealed partial class RepairItem : Packet
    {
        [MemoryPackOrder(0)]
        public ulong UniqueID;
    }

    [MemoryPackable, Route((ushort)ClientPacketIds.BuyItemBack)]
    public sealed partial class BuyItemBack : Packet
    {
        [MemoryPackOrder(0)]
        public ulong UniqueID;
        [MemoryPackOrder(1)]
        public ushort Count;
    }

    [MemoryPackable, Route((ushort)ClientPacketIds.SRepairItem)]
    public sealed partial class SRepairItem : Packet
    {
        [MemoryPackOrder(0)]
        public ulong UniqueID;
    }

    [MemoryPackable, Route((ushort)ClientPacketIds.RequestMapInfo)]
    public sealed partial class RequestMapInfo : Packet
    {
        [MemoryPackOrder(0)]
        public int MapIndex;
    }

    [MemoryPackable, Route((ushort)ClientPacketIds.TeleportToNPC)]
    public sealed partial class TeleportToNPC : Packet
    {
        [MemoryPackOrder(0)]
        public uint ObjectID;
    }

    [MemoryPackable, Route((ushort)ClientPacketIds.SearchMap)]
    public sealed partial class SearchMap : Packet
    {
        [MemoryPackOrder(0)]
        public string Text;
    }

    [MemoryPackable, Route((ushort)ClientPacketIds.MagicKey)]
    public sealed partial class MagicKey : Packet
    {
        [MemoryPackOrder(0)]
        public Spell Spell;
        [MemoryPackOrder(1)]
        public byte Key;
        [MemoryPackOrder(2)]
        public byte OldKey;
    }

    [MemoryPackable, Route((ushort)ClientPacketIds.Magic)]
    public sealed partial class Magic : Packet
    {
        [MemoryPackOrder(0)]
        public Spell Spell;
        [MemoryPackOrder(1)]
        public MirDirection Direction;
        [MemoryPackOrder(2)]
        public uint TargetID;
        [MemoryPackOrder(3)]
        public Point Location;
        [MemoryPackOrder(4)]
        public uint ObjectID;
        [MemoryPackOrder(5)]
        public bool SpellTargetLock;
    }

    [MemoryPackable, Route((ushort)ClientPacketIds.SwitchGroup)]
    public sealed partial class SwitchGroup : Packet
    {
        [MemoryPackOrder(0)]
        public bool AllowGroup;
    }

    [MemoryPackable, Route((ushort)ClientPacketIds.AddMember)]
    public sealed partial class AddMember : Packet
    {
        [MemoryPackOrder(0)]
        public string Name = string.Empty;
    }

    [MemoryPackable, Route((ushort)ClientPacketIds.DellMember)]
    public sealed partial class DelMember : Packet
    {
        [MemoryPackOrder(0)]
        public string Name = string.Empty;
    }

    [MemoryPackable, Route((ushort)ClientPacketIds.GroupInvite)]
    public sealed partial class GroupInvite : Packet
    {
        [MemoryPackOrder(0)]
        public bool AcceptInvite;
    }

    [MemoryPackable, Route((ushort)ClientPacketIds.NewHero)]
    public sealed partial class NewHero : Packet
    {
        [MemoryPackOrder(0)]
        public string Name = string.Empty;
        [MemoryPackOrder(1)]
        public MirGender Gender;
        [MemoryPackOrder(2)]
        public MirClass Class;
    }

    [MemoryPackable, Route((ushort)ClientPacketIds.SetAutoPotValue)]
    public sealed partial class SetAutoPotValue : Packet
    {
        [MemoryPackOrder(0)]
        public Stat Stat;
        [MemoryPackOrder(1)]
        public uint Value;
    }

    [MemoryPackable, Route((ushort)ClientPacketIds.SetAutoPotItem)]
    public sealed partial class SetAutoPotItem : Packet
    {
        [MemoryPackOrder(0)]
        public MirGridType Grid;
        [MemoryPackOrder(1)]
        public int ItemIndex;
    }

    [MemoryPackable, Route((ushort)ClientPacketIds.SetHeroBehaviour)]
    public sealed partial class SetHeroBehaviour : Packet
    {
        [MemoryPackOrder(0)]
        public HeroBehaviour Behaviour;
    }

    [MemoryPackable, Route((ushort)ClientPacketIds.ChangeHero)]
    public sealed partial class ChangeHero : Packet
    {
        [MemoryPackOrder(0)]
        public int ListIndex;
    }

    [MemoryPackable, Route((ushort)ClientPacketIds.MarriageRequest)]
    public sealed partial class MarriageRequest : Packet
    {

    }

    [MemoryPackable, Route((ushort)ClientPacketIds.MarriageReply)]
    public sealed partial class MarriageReply : Packet
    {
        [MemoryPackOrder(0)]
        public bool AcceptInvite;
    }

    [MemoryPackable, Route((ushort)ClientPacketIds.ChangeMarriage)]
    public sealed partial class ChangeMarriage : Packet
    {

    }

    [MemoryPackable, Route((ushort)ClientPacketIds.DivorceRequest)]
    public sealed partial class DivorceRequest : Packet
    {

    }

    [MemoryPackable, Route((ushort)ClientPacketIds.DivorceReply)]
    public sealed partial class DivorceReply : Packet
    {
        [MemoryPackOrder(0)]
        public bool AcceptInvite;
    }

    [MemoryPackable, Route((ushort)ClientPacketIds.AddMentor)]
    public sealed partial class AddMentor : Packet
    {
        [MemoryPackOrder(0)]
        public string Name;
    }

    [MemoryPackable, Route((ushort)ClientPacketIds.MentorReply)]
    public sealed partial class MentorReply : Packet
    {
        [MemoryPackOrder(0)]
        public bool AcceptInvite;
    }

    [MemoryPackable, Route((ushort)ClientPacketIds.AllowMentor)]
    public sealed partial class AllowMentor : Packet
    {

    }

    [MemoryPackable, Route((ushort)ClientPacketIds.CancelMentor)]
    public sealed partial class CancelMentor : Packet
    {

    }


    [MemoryPackable, Route((ushort)ClientPacketIds.TradeReply)]
    public sealed partial class TradeReply : Packet
    {
        [MemoryPackOrder(0)]
        public bool AcceptInvite;
    }

    [MemoryPackable, Route((ushort)ClientPacketIds.TradeRequest)]
    public sealed partial class TradeRequest : Packet
    {

    }

    [MemoryPackable, Route((ushort)ClientPacketIds.TradeGold)]
    public sealed partial class TradeGold : Packet
    {
        [MemoryPackOrder(0)]
        public uint Amount;
    }

    [MemoryPackable, Route((ushort)ClientPacketIds.TradeConfirm)]
    public sealed partial class TradeConfirm : Packet
    {
        [MemoryPackOrder(0)]
        public bool Locked;
    }

    [MemoryPackable, Route((ushort)ClientPacketIds.TradeCancel)]
    public sealed partial class TradeCancel : Packet
    {

    }

    [MemoryPackable, Route((ushort)ClientPacketIds.TownRevive)]
    public sealed partial class TownRevive : Packet
    {

    }

    [MemoryPackable, Route((ushort)ClientPacketIds.SpellToggle)]
    public sealed partial class SpellToggle : Packet
    {
        [MemoryPackOrder(0)]
        public Spell Spell;
        [MemoryPackOrder(1)]
        public SpellToggleState canUse = SpellToggleState.None;

        [MemoryPackOrder(2)]
        public bool CanUse
        {
            get { return Convert.ToBoolean(canUse); }
            set { canUse = (SpellToggleState)Convert.ToSByte(value); }
        }
    }

    [MemoryPackable, Route((ushort)ClientPacketIds.ConsignItem)]
    public sealed partial class ConsignItem : Packet
    {
        [MemoryPackOrder(0)]
        public ulong UniqueID;
        [MemoryPackOrder(1)]
        public uint Price;
        [MemoryPackOrder(2)]
        public MarketPanelType Type;
    }

    [MemoryPackable, Route((ushort)ClientPacketIds.MarketSearch)]
    public sealed partial class MarketSearch : Packet
    {
        [MemoryPackOrder(0)]
        public string Match = string.Empty;
        [MemoryPackOrder(1)]
        public ItemType Type = 0;
        [MemoryPackOrder(2)]
        public bool Usermode = false;
        [MemoryPackOrder(3)]
        public short MinShape = 0;
        [MemoryPackOrder(4)]
        public short MaxShape = 5000;
        [MemoryPackOrder(5)]
        public MarketPanelType MarketType = MarketPanelType.Market;
    }

    [MemoryPackable, Route((ushort)ClientPacketIds.MarketRefresh)]
    public sealed partial class MarketRefresh : Packet
    {

    }

    [MemoryPackable, Route((ushort)ClientPacketIds.MarketPage)]
    public sealed partial class MarketPage : Packet
    {
        [MemoryPackOrder(0)]
        public int Page;
    }

    [MemoryPackable, Route((ushort)ClientPacketIds.MarketBuy)]
    public sealed partial class MarketBuy : Packet
    {
        [MemoryPackOrder(0)]
        public ulong AuctionID;
        [MemoryPackOrder(1)]
        public uint BidPrice;
    }

    [MemoryPackable, Route((ushort)ClientPacketIds.MarketSellNow)]
    public sealed partial class MarketSellNow : Packet
    {
        [MemoryPackOrder(0)]
        public ulong AuctionID;
    }

    [MemoryPackable, Route((ushort)ClientPacketIds.MarketGetBack)]
    public sealed partial class MarketGetBack : Packet
    {
        [MemoryPackOrder(0)]
        public ulong AuctionID;
    }

    [MemoryPackable, Route((ushort)ClientPacketIds.RequestUserName)]
    public sealed partial class RequestUserName : Packet
    {
        [MemoryPackOrder(0)]
        public uint UserID;
    }

    [MemoryPackable, Route((ushort)ClientPacketIds.RequestChatItem)]
    public sealed partial class RequestChatItem : Packet
    {
        [MemoryPackOrder(0)]
        public ulong ChatItemID;
    }

    [MemoryPackable, Route((ushort)ClientPacketIds.EditGuildMember)]
    public sealed partial class EditGuildMember : Packet
    {
        [MemoryPackOrder(0)]
        public byte ChangeType = 0;
        [MemoryPackOrder(1)]
        public byte RankIndex = 0;
        [MemoryPackOrder(2)]
        public string Name = "";
        [MemoryPackOrder(3)]
        public string RankName = "";
    }

    [MemoryPackable, Route((ushort)ClientPacketIds.EditGuildNotice)]
    public sealed partial class EditGuildNotice : Packet
    {
        [MemoryPackOrder(0)]
        public List<string> notice = new List<string>();
    }

    [MemoryPackable, Route((ushort)ClientPacketIds.GuildInvite)]
    public sealed partial class GuildInvite : Packet
    {
        [MemoryPackOrder(0)]
        public bool AcceptInvite;
    }

    [MemoryPackable, Route((ushort)ClientPacketIds.RequestGuildInfo)]
    public sealed partial class RequestGuildInfo : Packet
    {
        [MemoryPackOrder(0)]
        public byte Type;
    }

    [MemoryPackable, Route((ushort)ClientPacketIds.GuildNameReturn)]
    public sealed partial class GuildNameReturn : Packet
    {
        [MemoryPackOrder(0)]
        public string Name;
    }

    [MemoryPackable, Route((ushort)ClientPacketIds.GuildWarReturn)]
    public sealed partial class GuildWarReturn : Packet
    {
        [MemoryPackOrder(0)]
        public string Name;
    }

    [MemoryPackable, Route((ushort)ClientPacketIds.GuildStorageGoldChange)]
    public sealed partial class GuildStorageGoldChange : Packet
    {
        [MemoryPackOrder(0)]
        public byte Type = 0;
        [MemoryPackOrder(1)]
        public uint Amount = 0;
    }

    [MemoryPackable, Route((ushort)ClientPacketIds.GuildStorageItemChange)]
    public sealed partial class GuildStorageItemChange : Packet
    {
        [MemoryPackOrder(0)]
        public byte Type = 0;
        [MemoryPackOrder(1)]
        public int From;
        [MemoryPackOrder(2)]
        public int To;
    }

    [MemoryPackable, Route((ushort)ClientPacketIds.EquipSlotItem)]
    public sealed partial class EquipSlotItem : Packet
    {
        [MemoryPackOrder(0)]
        public MirGridType Grid;
        [MemoryPackOrder(1)]
        public ulong UniqueID;
        [MemoryPackOrder(2)]
        public int To;
        [MemoryPackOrder(3)]
        public MirGridType GridTo;
        [MemoryPackOrder(4)]
        public ulong ToUniqueID;
    }

    [MemoryPackable, Route((ushort)ClientPacketIds.FishingCast)]
    public sealed partial class FishingCast : Packet
    {
        [MemoryPackOrder(0)]
        public bool CastOut;
    }

    [MemoryPackable, Route((ushort)ClientPacketIds.FishingChangeAutocast)]
    public sealed partial class FishingChangeAutocast : Packet
    {
        [MemoryPackOrder(0)]
        public bool AutoCast;
    }

    [MemoryPackable, Route((ushort)ClientPacketIds.AcceptQuest)]
    public sealed partial class AcceptQuest : Packet
    {
        [MemoryPackOrder(0)]
        public uint NPCIndex;
        [MemoryPackOrder(1)]
        public int QuestIndex;
    }

    [MemoryPackable, Route((ushort)ClientPacketIds.FinishQuest)]
    public sealed partial class FinishQuest : Packet
    {
        [MemoryPackOrder(0)]
        public int QuestIndex;
        [MemoryPackOrder(1)]
        public int SelectedItemIndex;
    }

    [MemoryPackable, Route((ushort)ClientPacketIds.AbandonQuest)]
    public sealed partial class AbandonQuest : Packet
    {
        [MemoryPackOrder(0)]
        public int QuestIndex;
    }

    [MemoryPackable, Route((ushort)ClientPacketIds.ShareQuest)]
    public sealed partial class ShareQuest : Packet
    {
        [MemoryPackOrder(0)]
        public int QuestIndex;
    }

    [MemoryPackable, Route((ushort)ClientPacketIds.AcceptReincarnation)]
    public sealed partial class AcceptReincarnation : Packet
    {

    }

    [MemoryPackable, Route((ushort)ClientPacketIds.CancelReincarnation)]
    public sealed partial class CancelReincarnation : Packet
    {

    }

    [MemoryPackable, Route((ushort)ClientPacketIds.CombineItem)]
    public sealed partial class CombineItem : Packet
    {
        [MemoryPackOrder(0)]
        public MirGridType Grid;
        [MemoryPackOrder(1)]
        public ulong IDFrom;
        [MemoryPackOrder(2)]
        public ulong IDTo;
    }

    [MemoryPackable, Route((ushort)ClientPacketIds.AwakeningNeedMaterials)]
    public sealed partial class AwakeningNeedMaterials : Packet
    {
        [MemoryPackOrder(0)]
        public ulong UniqueID;
        [MemoryPackOrder(1)]
        public AwakeType Type;
    }

    [MemoryPackable, Route((ushort)ClientPacketIds.AwakeningLockedItem)]
    public sealed partial class AwakeningLockedItem : Packet
    {
        [MemoryPackOrder(0)]
        public ulong UniqueID;
        [MemoryPackOrder(1)]
        public bool Locked;
    }

    [MemoryPackable, Route((ushort)ClientPacketIds.Awakening)]
    public sealed partial class Awakening : Packet
    {
        [MemoryPackOrder(0)]
        public ulong UniqueID;
        [MemoryPackOrder(1)]
        public AwakeType Type;
        [MemoryPackOrder(2)]
        public uint PositionIdx;
    }

    [MemoryPackable, Route((ushort)ClientPacketIds.DisassembleItem)]
    public sealed partial class DisassembleItem : Packet
    {
        [MemoryPackOrder(0)]
        public ulong UniqueID;
    }

    [MemoryPackable, Route((ushort)ClientPacketIds.DowngradeAwakening)]
    public sealed partial class DowngradeAwakening : Packet
    {
        [MemoryPackOrder(0)]
        public ulong UniqueID;
    }

    [MemoryPackable, Route((ushort)ClientPacketIds.ResetAddedItem)]
    public sealed partial class ResetAddedItem : Packet
    {
        [MemoryPackOrder(0)]
        public ulong UniqueID;
    }

    [MemoryPackable, Route((ushort)ClientPacketIds.SendMail)]
    public sealed partial class SendMail : Packet
    {
        [MemoryPackOrder(0)]
        public string Name;
        [MemoryPackOrder(1)]
        public string Message;
        [MemoryPackOrder(2)]
        public uint Gold;
        [MemoryPackOrder(3)]
        public ulong[] ItemsIdx = new ulong[5];
        [MemoryPackOrder(4)]
        public bool Stamped;
    }

    [MemoryPackable, Route((ushort)ClientPacketIds.ReadMail)]
    public sealed partial class ReadMail : Packet
    {
        [MemoryPackOrder(0)]
        public ulong MailID;
    }

    [MemoryPackable, Route((ushort)ClientPacketIds.CollectParcel)]
    public sealed partial class CollectParcel : Packet
    {
        [MemoryPackOrder(0)]
        public ulong MailID;
    }

    [MemoryPackable, Route((ushort)ClientPacketIds.DeleteMail)]
    public sealed partial class DeleteMail : Packet
    {
        [MemoryPackOrder(0)]
        public ulong MailID;
    }

    [MemoryPackable, Route((ushort)ClientPacketIds.LockMail)]
    public sealed partial class LockMail : Packet
    {
        [MemoryPackOrder(0)]
        public ulong MailID;
        [MemoryPackOrder(1)]
        public bool Lock;
    }

    [MemoryPackable, Route((ushort)ClientPacketIds.MailLockedItem)]
    public sealed partial class MailLockedItem : Packet
    {
        [MemoryPackOrder(0)]
        public ulong UniqueID;
        [MemoryPackOrder(1)]
        public bool Locked;
    }

    [MemoryPackable, Route((ushort)ClientPacketIds.MailCost)]
    public sealed partial class MailCost : Packet
    {
        [MemoryPackOrder(0)]
        public uint Gold;
        [MemoryPackOrder(1)]
        public ulong[] ItemsIdx = new ulong[5];
        [MemoryPackOrder(2)]
        public bool Stamped;
    }

    [MemoryPackable, Route((ushort)ClientPacketIds.RequestIntelligentCreatureUpdates)]
    public sealed partial class RequestIntelligentCreatureUpdates : Packet
    {
        [MemoryPackOrder(0)]
        public bool Update = false;
    }

    [MemoryPackable, Route((ushort)ClientPacketIds.UpdateIntelligentCreature)]
    public sealed partial class UpdateIntelligentCreature : Packet
    {
        [MemoryPackOrder(0)]
        public ClientIntelligentCreature Creature;
        [MemoryPackOrder(1)]
        public bool SummonMe = false;
        [MemoryPackOrder(2)]
        public bool UnSummonMe = false;
        [MemoryPackOrder(3)]
        public bool ReleaseMe = false;
    }

    [MemoryPackable, Route((ushort)ClientPacketIds.IntelligentCreaturePickup)]
    public sealed partial class IntelligentCreaturePickup : Packet
    {
        [MemoryPackOrder(0)]
        public bool MouseMode = false;
        [MemoryPackOrder(1)]
        public Point Location = new Point(0, 0);
    }

    [MemoryPackable, Route((ushort)ClientPacketIds.AddFriend)]
    public sealed partial class AddFriend : Packet
    {
        [MemoryPackOrder(0)]
        public string Name;
        [MemoryPackOrder(1)]
        public bool Blocked;
    }

    [MemoryPackable, Route((ushort)ClientPacketIds.RemoveFriend)]
    public sealed partial class RemoveFriend : Packet
    {
        [MemoryPackOrder(0)]
        public int CharacterIndex;
    }

    [MemoryPackable, Route((ushort)ClientPacketIds.RefreshFriends)]
    public sealed partial class RefreshFriends : Packet
    {

    }


    [MemoryPackable, Route((ushort)ClientPacketIds.AddMemo)]
    public sealed partial class AddMemo : Packet
    {
        [MemoryPackOrder(0)]
        public int CharacterIndex;
        [MemoryPackOrder(1)]
        public string Memo;
    }

    [MemoryPackable, Route((ushort)ClientPacketIds.GuildBuffUpdate)]
    public sealed partial class GuildBuffUpdate : Packet
    {
        [MemoryPackOrder(0)]
        public byte Action = 0;
        [MemoryPackOrder(1)]
        public int Id;
    }

    [MemoryPackable, Route((ushort)ClientPacketIds.GameshopBuy)]
    public sealed partial class GameshopBuy : Packet
    {
        [MemoryPackOrder(0)]
        public int GIndex;
        [MemoryPackOrder(1)]
        public byte Quantity;
        [MemoryPackOrder(2)]
        public int PType;
    }

    [MemoryPackable, Route((ushort)ClientPacketIds.NPCConfirmInput)]
    public sealed partial class NPCConfirmInput : Packet
    {
        [MemoryPackOrder(0)]
        public uint NPCID;
        [MemoryPackOrder(1)]
        public string PageName;
        [MemoryPackOrder(2)]
        public string Value;
    }

    [MemoryPackable, Route((ushort)ClientPacketIds.ReportIssue)]
    public sealed partial class ReportIssue : Packet
    {
        [MemoryPackOrder(0)]
        public byte[] Image;
        [MemoryPackOrder(1)]
        public int ImageSize;
        [MemoryPackOrder(2)]
        public int ImageChunk;
        [MemoryPackOrder(3)]
        public string Message;
    }

    [MemoryPackable, Route((ushort)ClientPacketIds.GetRanking)]
    public sealed partial class GetRanking : Packet
    {
        [MemoryPackOrder(0)]
        public byte RankType;
        [MemoryPackOrder(1)]
        public int RankIndex;
        [MemoryPackOrder(2)]
        public bool OnlineOnly;
    }

    [MemoryPackable, Route((ushort)ClientPacketIds.Opendoor)]
    public sealed partial class Opendoor : Packet
    {
        [MemoryPackOrder(0)]
        public byte DoorIndex;
    }

    [MemoryPackable, Route((ushort)ClientPacketIds.GetRentedItems)]
    public sealed partial class GetRentedItems : Packet
    {

    }

    [MemoryPackable, Route((ushort)ClientPacketIds.ItemRentalRequest)]
    public sealed partial class ItemRentalRequest : Packet
    {

    }

    [MemoryPackable, Route((ushort)ClientPacketIds.ItemRentalFee)]
    public sealed partial class ItemRentalFee : Packet
    {
        [MemoryPackOrder(0)]
        public uint Amount;
    }

    [MemoryPackable, Route((ushort)ClientPacketIds.ItemRentalPeriod)]
    public sealed partial class ItemRentalPeriod : Packet
    {
        [MemoryPackOrder(0)]
        public uint Days;
    }

    [MemoryPackable, Route((ushort)ClientPacketIds.DepositRentalItem)]
    public sealed partial class DepositRentalItem : Packet
    {
        [MemoryPackOrder(0)]
        public int From;
        [MemoryPackOrder(1)]
        public int To;
    }

    [MemoryPackable, Route((ushort)ClientPacketIds.RetrieveRentalItem)]
    public sealed partial class RetrieveRentalItem : Packet
    {
        [MemoryPackOrder(0)]
        public int From;
        [MemoryPackOrder(1)]
        public int To;
    }

    [MemoryPackable, Route((ushort)ClientPacketIds.CancelItemRental)]
    public sealed partial class CancelItemRental : Packet
    {

    }

    [MemoryPackable, Route((ushort)ClientPacketIds.ItemRentalLockFee)]
    public sealed partial class ItemRentalLockFee : Packet
    {

    }

    [MemoryPackable, Route((ushort)ClientPacketIds.ItemRentalLockItem)]
    public sealed partial class ItemRentalLockItem : Packet
    {

    }

    [MemoryPackable, Route((ushort)ClientPacketIds.ConfirmItemRental)]
    public sealed partial class ConfirmItemRental : Packet
    {

    }
}