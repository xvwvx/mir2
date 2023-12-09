namespace Shared;

public enum SystemID: short
{
    All,
    Server = 1 << 9,
    Client = 1 << 10,
}