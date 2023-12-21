using System.Buffers;
using System.Collections.Immutable;
using System.Reflection;
using MessagePack;
using MessagePack.Formatters;
using MessagePack.Resolvers;
using Shared;
using C = ClientPackets;
using S = ServerPackets;


[MessagePackObject]
public abstract class Packet
{
    private static readonly Dictionary<ushort, Type> IdsMap;
    private static readonly Dictionary<Type, ushort> TypeMap;

    static Packet()
    {
        var types = Assembly.GetAssembly(typeof(Packet))
            .GetTypes()
            .Where(type => type.IsSubclassOf(typeof(Packet)));

        var idsMap = new Dictionary<ushort, Type>();
        var typeMap = new Dictionary<Type, ushort>();
        foreach (Type type in types)
        {
            var attribute = (RouteAttribute)type
                .GetCustomAttributes(typeof(RouteAttribute), true)
                .First();
            var id = attribute.RouteId;
            idsMap.Add(id, type);
            typeMap.Add(type, id);
        }
        IdsMap = idsMap;
        TypeMap = typeMap;
    }

    private static readonly MessagePackSerializerOptions Options = MessagePackSerializerOptions.Standard.WithResolver(
        CompositeResolver.Create(
            new IMessagePackFormatter[]
            {
                new MessagePackFormatter(), new PointMessagePackFormatter(),
            },
            new IFormatterResolver[]
            {
                GeneratedResolver.Instance,
                StandardResolver.Instance,
            }));

    public static bool IsServer;
    [IgnoreMember] public virtual bool Observable => true;

    [IgnoreMember] public short Index { get; private set; }

    private static uint _messageIndex;
    private static readonly Dictionary<uint, ushort> _reqIds = new();
    private static readonly Dictionary<ushort, uint> _respIds = new();

    public static Packet? ReceivePacket(byte[] rawBytes, out byte[] extra)
    {
        extra = rawBytes;

        var start = 0;
        if (Message.Decode(rawBytes, ref start, rawBytes.Length) is not { } message)
        {
            return null;
        }

        var routeId = message.RouteId;
        switch (message.MessageType)
        {
            case MessageType.Request:
            {
                _respIds[routeId] = message.MessageId;
                break;
            }
            case MessageType.Response:
            {
                _reqIds.Remove(message.MessageId, out routeId);
                break;
            }
        }

        var type = IdsMap[routeId];
        var p = (Packet)MessagePackSerializer.Deserialize(type, message.Data, Options);
        p.Index = (short)routeId;

        var time = DateTime.Now.ToString("hh:mm:ss.fff");
        Console.WriteLine($"{time} Recv: {p.GetType().FullName} {message.MessageId}");

        extra = new byte[rawBytes.Length - start];
        Buffer.BlockCopy(rawBytes, start, extra, 0, extra.Length);

        return p;
    }

    public IEnumerable<byte> GetPacketBytes()
    {
        Index = (short)TypeMap[GetType()];

        var data = MessagePackSerializer.Serialize(GetType(), this, Options);

        uint messageId = 0;
        var routeId = (ushort)Index;

        var messageType = MessageType.Push;
        // if ((routeId >> 8 & 0xFF) == (short)SystemID.All)
        // {
        //     if (_respIds.Remove(routeId, out messageId))
        //     {
        //         messageType = MessageType.Response;
        //     }
        //     else
        //     {
        //         messageId = _messageIndex++;
        //         messageType = MessageType.Request;
        //         _reqIds[messageId] = routeId;
        //     }
        // }
        var message = new Message(messageType, messageId, routeId, data);

        var buffer = ArrayPool<byte>.Shared.Rent(64 * 1024);
        var start = 0;
        message.Encode(ref buffer, ref start, new List<ArraySegment<byte>>());

        data = new byte[start];
        Array.Copy(buffer, data, data.Length);
        ArrayPool<byte>.Shared.Return(buffer);

        var time = DateTime.Now.ToString("hh:mm:ss.fff");
        Console.WriteLine($"{time} Send: {GetType().FullName} {messageId}");
        return data;
    }
}