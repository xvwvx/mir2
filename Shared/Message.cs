using System.Buffers;
using System.Text;
namespace Shared;

public enum MessageType : byte
{
    Handshake = 0x01,
    HandshakeAck = 0x02,
    Heartbeat = 0x03,
    Data = 0x04,
    Kick = 0x05,

    Request = (0x01 << 4) | Data,
    Notify = (0x02 << 4) | Data,
    Response = (0x03 << 4) | Data,
    Push = (0x04 << 4) | Data,
}

public class Message
{
    private static readonly int BufferSize = 4 * 1024;

    public readonly MessageType MessageType;
    public readonly UInt32 MessageId;
    public readonly UInt16 RouteId;
    public readonly byte[] Data;

    public Message(MessageType messageType, UInt32 messageId = 0, ushort routeId = 0, byte[]? data = null)
    {
        MessageType = messageType;
        MessageId = messageId;
        RouteId = routeId;
        Data = data ?? Array.Empty<byte>();
    }

    public void Encode(ref byte[] buffer, ref int offset, List<ArraySegment<byte>> buffers)
    {
        if (buffer.Length - offset < 9)
        {
            buffers.Add(new ArraySegment<byte>(buffer, 0, offset));
            offset = 0;
            buffer = ArrayPool<byte>.Shared.Rent(BufferSize);
        }

        buffer[offset] = (byte)MessageType;
        offset += 1;
        if (MessageType is MessageType.Request or MessageType.Response)
        {
            const int count = 4;
            for (int i = 0; i < count; i++)
            {
                buffer[offset + i] = (byte)(MessageId >> (8 * i) & 0xFF);
            }
            offset += count;
        }

        if (MessageType is MessageType.Request or MessageType.Notify or MessageType.Push)
        {
            buffer[offset + 0] = (byte)(RouteId >> 0 & 0xFF);
            buffer[offset + 1] = (byte)(RouteId >> 8 & 0xFF);
            offset += 2;
        }

        var dataLength = Data.Length;
        buffer[offset + 0] = (byte)(dataLength >> 0 & 0xFF);
        buffer[offset + 1] = (byte)(dataLength >> 8 & 0xFF);
        offset += 2;

        var writeOffset = 0;
        while (writeOffset < dataLength)
        {
            var length = Math.Min(dataLength - writeOffset, buffer.Length - offset);
            Array.Copy(Data, writeOffset, buffer, offset, length);
            writeOffset += length;
            offset += length;
            if (offset >= buffer.Length)
            {
                buffers.Add(new ArraySegment<byte>(buffer, 0, offset));
                offset = 0;
                buffer = ArrayPool<byte>.Shared.Rent(BufferSize);
            }
        }
    }

    public static Message? Decode(byte[] buffer, ref int start, int end)
    {
        var offset = start;
        if (end - offset < 4)
        {
            return null;
        }
        var messageType = (MessageType)buffer[offset + 0];
        offset += 1;

        UInt32 messageId = 0;
        if (messageType is MessageType.Request or MessageType.Response)
        {
            const int count = 4;
            if (end - offset < count)
            {
                return null;
            }
            for (int i = 0; i < count; i++)
            {
                messageId += (UInt32)(buffer[offset + i] << (i * 8));
            }
            offset += count;
        }

        UInt16 routeId = 0;
        if (messageType is MessageType.Request or MessageType.Notify or MessageType.Push)
        {
            if (end - offset < 2)
            {
                return null;
            }
            routeId += (UInt16)(buffer[offset + 0] << 0);
            routeId += (UInt16)(buffer[offset + 1] << 8);
            offset += 2;
        }

        if (end - offset < 2)
        {
            return null;
        }

        var dataLength = 0;
        dataLength += buffer[offset + 0] << 0;
        dataLength += buffer[offset + 1] << 8;
        offset += 2;

        var data = Array.Empty<byte>();
        if (dataLength > 0)
        {
            if (end - offset < dataLength)
            {
                return null;
            }

            data = new byte[dataLength];
            Array.Copy(buffer, offset, data, 0, dataLength);
            offset += dataLength;
        }
        start = offset;
        return new Message(messageType, messageId, routeId, data);
    }

}