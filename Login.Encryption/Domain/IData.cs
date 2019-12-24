namespace Login.Encryption.Domain
{
    public interface IData
    {
        public byte[] Value { get; }

        public int Offset { get; set; }

        public int Length { get; set; }
    }
}
