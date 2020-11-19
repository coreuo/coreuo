namespace Shard.Server.Domain
{
    public interface IMobile<TItem, TEntity, in TIdentity> : 
        IEntity<TItem, TEntity, TIdentity>
        where TItem : IItem<TItem, TEntity, TIdentity>
        where TEntity : class, IEntity<TItem, TEntity, TIdentity>
    {
        byte WarMode { set; }

        byte StatusFlags { get; set; }

        byte Direction { get; set; }

        internal void Move(int offsetX, int offsetY, int offsetZ)
        {
            LocationX += (ushort)offsetX;

            LocationY += (ushort)offsetY;

            LocationZ += (sbyte)offsetZ;
        }
    }
}
