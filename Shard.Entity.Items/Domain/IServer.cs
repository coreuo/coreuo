namespace Shard.Entity.Items.Domain
{
    public interface IServer<in TState, in TMobile, TItem, in TEntity, TIdentity>
        where TState : class
        where TItem : IItem
    {
        TItem CreateItem(params TIdentity[] identities);

        void SetItemParent(TEntity parent, TItem item);

        void AssignFace(TMobile mobile, TState state = null);

        void AssignHair(TMobile mobile, TState state = null);

        void AssignBeard(TMobile mobile, TState state = null);

        TIdentity Humanoid { get;  }

        TIdentity Character { get;  }

        TIdentity Backpack { get;  }

        TIdentity Gold { get;  }

        TIdentity RedBook { get;  }

        TIdentity Candle { get;  }

        TIdentity Dagger { get;  }

        void AssignProfessionItems(TMobile mobile);

        internal void AddItem(TEntity entity, TIdentity identity, ushort amount = 1)
        {
            var item = CreateItem(identity);

            item.Amount = amount;

            SetItemParent(entity, item);
        }
    }
}
