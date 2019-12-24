namespace Shard.Message.Domain.Incoming
{
    public interface IEncryptionResponse
    {
        public int PublicKeyLength { get; set; }

        public byte[] PublicKey { get; set; }

        internal int ReadEncryptionResponse(IData data)
        {
            PublicKeyLength = data.ReadInt(3);

            PublicKey = data.ReadByteArray(7, PublicKeyLength);

            return data.ReadShort(1);
        }
    }
}
