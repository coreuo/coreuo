namespace Shard.Message.Domain.Incoming
{
    public interface IItemWear
    {
        int ItemWearSerial { get; set; }

        byte ItemWearLayer { get; set; }

        int ItemWearParentSerial { get; set; }

        internal int ReadItemWear(IData data)
        {
            ItemWearSerial = data.ReadInt(1);

            ItemWearLayer = data.ReadByte(5);

            ItemWearParentSerial = data.ReadInt(6);

            return 10;
        }
    }
}
