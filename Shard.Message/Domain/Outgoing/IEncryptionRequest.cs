namespace Shard.Message.Domain.Outgoing
{
    public interface IEncryptionRequest
    {
        byte[] EncryptionBase { get; }

        byte[] EncryptionPrime { get; }

        byte[] EncryptionPublicKey { get; }

        int EncryptionKeySize { get; }

        byte[] EncryptionIv { get; }

        internal void OnWriteEncryptionRequest(IData data)
        {
            data.OnWrite(3, EncryptionBase.Length);

            data.OnWrite(7, EncryptionBase);

            data.OnWrite(7 + EncryptionBase.Length, EncryptionPrime.Length);

            data.OnWrite(7 + EncryptionBase.Length + 4, EncryptionPrime);

            data.OnWrite(7 + EncryptionBase.Length + 4 + EncryptionPrime.Length, EncryptionPublicKey.Length);

            data.OnWrite(7 + EncryptionBase.Length + 4 + EncryptionPrime.Length + 4, EncryptionPublicKey);

            data.OnWrite(7 + EncryptionBase.Length + 4 + EncryptionPrime.Length + 4 + EncryptionPublicKey.Length, EncryptionKeySize);

            data.OnWrite(7 + EncryptionBase.Length + 4 + EncryptionPrime.Length + 4 + EncryptionPublicKey.Length + 4, EncryptionIv.Length);

            data.OnWrite(7 + EncryptionBase.Length + 4 + EncryptionPrime.Length + 4 + EncryptionPublicKey.Length + 4 + 4, EncryptionIv);
        }
    }
}