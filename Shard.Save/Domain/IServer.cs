namespace Shard.Save.Domain
{
    public interface IServer<TServer, TSave, TProperty>
        where TServer : IServer<TServer, TSave, TProperty>
        where TSave : Save<TSave, TServer, TProperty>
        where TProperty : IProperty
    {
        public TSave Save { get; }
    }
}
