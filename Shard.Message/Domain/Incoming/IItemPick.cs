namespace Shard.Message.Domain.Incoming
{
    public interface IItemPick
    {
        int ItemPickSerial { get; set; }

        ushort ItemPickAmount { get; set; }

        internal int ReadItemPick(IData data)
        {
            ItemPickSerial = data.ReadInt(1);

            ItemPickAmount = data.ReadUShort(5);

            return 7;
        }
    }
}
