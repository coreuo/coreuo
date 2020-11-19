namespace Game.Data.Domain
{
    public interface IEntity
    {
        string Name { set; }

        ushort Graphic { get; }

        int DisplayIndex { get; }
    }
}
