namespace Login.Encryption.Domain
{
    public interface IData
    {
        public byte[] Value { get; }

        public int Offset { get; }

        public int Length { get; }
    }
}
