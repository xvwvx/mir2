namespace Shared
{
    [AttributeUsage(AttributeTargets.Struct | AttributeTargets.Class)]
    public class RouteAttribute : Attribute
    {
        public readonly ClientPacketIds? ClientId;
        public readonly ServerPacketIds? ServerId;

        public RouteAttribute(ClientPacketIds clientId)
        {
            ClientId = clientId;
            ServerId = null;
        }

        public RouteAttribute(ServerPacketIds serverId)
        {
            ClientId = null;
            ServerId = serverId;
        }
    }
}