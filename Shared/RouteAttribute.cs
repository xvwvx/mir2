namespace Shared
{
    [AttributeUsage(AttributeTargets.Struct | AttributeTargets.Class)]
    public class RouteAttribute : Attribute
    {
        public readonly UInt16 RouteId;

        public RouteAttribute(ushort routeId)
        {
            RouteId = routeId;
        }

    }
}