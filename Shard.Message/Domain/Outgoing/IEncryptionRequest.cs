namespace Shard.Message.Domain.Outgoing
{
    public interface IEncryptionRequest
    {
        byte[] EncryptionBase { get; }

        byte[] EncryptionPrime { get; }

        byte[] EncryptionPublicKey { get; }

        int EncryptionKeySize { get; }

        byte[] EncryptionIv { get; }

        internal void WriteEncryptionRequest(IData data)
        {
            data.Write(3, EncryptionBase.Length);

            data.Write(7, EncryptionBase);

            data.Write(7 + EncryptionBase.Length, EncryptionPrime.Length);

            data.Write(7 + EncryptionBase.Length + 4, EncryptionPrime);

            data.Write(7 + EncryptionBase.Length + 4 + EncryptionPrime.Length, EncryptionPublicKey.Length);

            data.Write(7 + EncryptionBase.Length + 4 + EncryptionPrime.Length + 4, EncryptionPublicKey);

            data.Write(7 + EncryptionBase.Length + 4 + EncryptionPrime.Length + 4 + EncryptionPublicKey.Length, EncryptionKeySize);

            data.Write(7 + EncryptionBase.Length + 4 + EncryptionPrime.Length + 4 + EncryptionPublicKey.Length + 4, EncryptionIv.Length);

            data.Write(7 + EncryptionBase.Length + 4 + EncryptionPrime.Length + 4 + EncryptionPublicKey.Length + 4 + 4, EncryptionIv);
        }
    }
}