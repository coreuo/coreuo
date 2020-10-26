namespace Shard.Message.Domain.Incoming
{
    public interface IEncryptionResponse
    {
        public int PublicKeyLength { get; set; }

        public byte[] PublicKey { get; set; }

        internal int OnReadEncryptionResponse(IData data)
        {
            PublicKeyLength = data.OnReadInt(3);

            PublicKey = data.OnReadByteArray(7, PublicKeyLength);

            return data.OnReadShort(1);
        }
    }
}
