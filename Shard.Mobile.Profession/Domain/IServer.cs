using System.Collections.Generic;
using System.Linq;

namespace Shard.Mobile.Profession.Domain
{
    public interface IServer<TItem, in TEntity, TIdentity>
    {
        TIdentity Male { get; }

        TIdentity Female { get; }

        TIdentity Human { get; }

        TIdentity Elf { get; }

        TIdentity Warrior { get; }
        TIdentity Mage { get; }
        TIdentity Blacksmith { get; }
        TIdentity Paladin { get; }
        TIdentity Necromancer { get; }
        TIdentity Samurai { get; }
        TIdentity Ninja { get; }
        TIdentity CustomProfession { get; }

        Dictionary<HashSet<TIdentity>, List<(HashSet<TIdentity> identities, ushort hue)>> Professions { get; }

        HashSet<TIdentity> GetIdentitiesByGraphic(ushort graphic);

        TItem CreateItem(ushort hue, params TIdentity[] identities);

        void SetItemParent(TEntity parent, TItem item);

        internal void AddItem(TEntity entity, ushort hue, IEnumerable<TIdentity> identity)
        {
            var item = CreateItem(hue, identity.ToArray());

            SetItemParent(entity, item);
        }
    }
}
