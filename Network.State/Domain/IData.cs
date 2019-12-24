namespace Network.State.Domain
{
    public interface IData
    {
        byte[] Value { get; }

        int Offset { get; set; }

        int Length { get; set; }
    }
}
