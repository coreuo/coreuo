namespace Login.Server.Domain
{
    public interface IState
    {
        public int ShardIndex { get; }
    }
}
