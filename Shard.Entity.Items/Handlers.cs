using Shard.Entity.Items.Domain;

namespace Shard.Entity.Items
{
    public static class Handlers<TServer, TState, TMobile, TItem, TEntity, TIdentity>
        where TServer : IServer<TState, TMobile, TItem, TEntity, TIdentity>
        where TState : IState
        where TMobile : TEntity, IMobile
        where TItem : class, TEntity, IItem
        where TEntity : IEntity<TIdentity>
    {
        public static void AssignMobileItems(TServer server, TState state, TMobile mobile)
        {
            if (mobile.Is(server.Humanoid))
            {
                server.AssignFace(state, mobile);

                server.AssignHair(state, mobile);

                server.AssignBeard(state, mobile);
            }

            if (!mobile.Is(server.Humanoid)) return;

            var backpack = server.CreateItem(server.Backpack);

            server.SetItemParent(mobile, backpack);

            server.AddItem(mobile, server.Robe);

            if (!mobile.Is(server.Character)) return;

            server.AddItem(backpack, server.RedBook);

            server.AddItem(backpack, server.Gold, 1000);

            server.AddItem(backpack, server.Candle);

            server.AddItem(backpack, server.Dagger);
        }
    }
}
