using System;

namespace Shard.Entity.Items.Domain
{
    public interface IServer<in TState, in TMobile, TItem, in TEntity, TIdentity>
        where TItem : IItem
    {
        TItem CreateItem(params TIdentity[] identities);

        void SetItemParent(TEntity parent, TItem item);

        Action<TState, TMobile> AssignFace { get; }

        Action<TState, TMobile> AssignHair { get; }

        Action<TState, TMobile> AssignBeard { get; }

        TIdentity Humanoid { get;  }

        TIdentity Character { get;  }

        TIdentity Backpack { get;  }

        TIdentity Gold { get;  }

        TIdentity RedBook { get;  }

        TIdentity Robe { get; }

        TIdentity Candle { get;  }

        TIdentity Dagger { get;  }

        internal void AddItem(TEntity entity, TIdentity identity, ushort amount = 1)
        {
            var item = CreateItem(identity);

            item.Amount = amount;

            SetItemParent(entity, item);
        }
    }
}
