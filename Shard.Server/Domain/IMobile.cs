namespace Shard.Server.Domain
{
    public interface IMobile<TItem, TEntity> : 
        IEntity<TItem, TEntity>
        where TItem : IItem<TItem, TEntity>
        where TEntity : class, IEntity<TItem, TEntity>
    {
        string Name { get; set; }

        byte WarMode { get; set; }

        byte StatusFlags { get; set; }

        ushort LocationX { get; set; }

        ushort LocationY { get; set; }

        sbyte LocationZ { get; set; }

        byte Direction { get; set; }

        internal void Move(int offsetX, int offsetY, int offsetZ)
        {
            LocationX += (ushort)offsetX;

            LocationY += (ushort)offsetY;

            LocationZ += (sbyte)offsetZ;
        }
    }
}
