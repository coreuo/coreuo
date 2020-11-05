namespace Shard.Message.Domain.Incoming
{
    public interface IItemPlace
    {
        int ItemPlaceSerial { get; set; }

        ushort ItemPlaceLocationX { get; set; }

        ushort ItemPlaceLocationY { get; set; }

        sbyte ItemPlaceLocationZ { get; set; }

        byte ItemPlaceGridIndex { get; set; }

        int ItemPlaceContainerSerial { get; set; }

        internal int ReadItemPlace(IData data)
        {
            ItemPlaceSerial = data.ReadInt(1);

            ItemPlaceLocationX = data.ReadUShort(5);

            ItemPlaceLocationY = data.ReadUShort(7);

            ItemPlaceLocationZ = data.ReadSByte(9);

            ItemPlaceGridIndex = data.ReadByte(10);

            ItemPlaceContainerSerial = data.ReadInt(11);

            return 15;
        }
    }
}
