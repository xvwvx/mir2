// See https://aka.ms/new-console-template for more information


using Shared;
using S = ServerPackets;
using C = ClientPackets;

var s0 = $"{(1 << 8):x8}";
var s1 = $"{(1 << 9):x8}";
var s2 = $"{(1 << 10):x8}";

var types  = typeof(Packet).Assembly
    .GetTypes()
    .Where(type => type.IsSubclassOf(typeof(Packet)))
    .ToArray();

foreach (var type in types)
{
    var attribute = (PacketIdAttribute)type
        .GetCustomAttributes(typeof(PacketIdAttribute), true)
        .FirstOrDefault()!;
    if (attribute.ServerId is { } serverId)
    {
        if (type.Name != serverId.ToString())
        {
            Console.WriteLine(type.FullName);
        }
    }
    else if (attribute.ClientId is { } clientId)
    {
        if (type.Name != clientId.ToString())
        {
            Console.WriteLine(type.FullName);
        }
    }
}

Console.WriteLine("Hello, World!");