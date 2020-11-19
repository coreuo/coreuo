namespace Game.Data.Domain
{
    public interface IItem : IEntity
    {
        byte Layer { set; }

        ushort Display { set; }
    }
}
