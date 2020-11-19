namespace Shard.Entity.Graphic.Domain
{
    public interface IEntity<in TIdentity>
    {
        int GraphicIndex { set; }

        ushort Graphic { set; }

        int HueIndex { set; }

        ushort Hue { set; }

        int DisplayIndex { set; }

        bool Is(params TIdentity[] identities);
    }
}
