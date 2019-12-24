namespace Shard.Message.Domain.Outgoing
{
    public interface ICharacterInfo
    {
        public string Name { get; set; }

        internal void WriteCharacter(int index, IData data)
        {
            data.Write(4 + index * 60, Name);
        }
    }
}
