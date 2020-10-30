using System;
using System.Collections.Generic;
using Shard.Items.Domain;

namespace Shard.Items
{
    public static class Handlers<TServer, TItem>
        where TItem : IItem
    {
        public static HashSet<Action<TServer, TItem>> Containers()
        {
            return new HashSet<Action<TServer, TItem>>
            {
                Backpack
            };
        }

        public static void Backpack(TServer server, TItem item)
        {
            item.EntityDisplayId = 0x003C;

            item.ItemId = 3701;

            item.Layer = 21;
        }

        public static void LeatherChest(TServer server, TItem item)
        {
            item.ItemId = 0x13CC;

            item.Layer = 13;
        }

        public static void Robe(TServer server, TItem item)
        {
            item.ItemId = 0x1F03;

            item.Layer = 22;

            item.Hue = 1721;
        }

        public static void Shirt(TServer server, TItem item)
        {
            item.ItemId = 0x1517;

            item.Layer = 5;

            item.Hue = 2;
        }

        public static void ShortPants(TServer server, TItem item)
        {
            item.ItemId = 0x152E;

            item.Layer = 4;

            item.Hue = 2;
        }

        public static void Shoes(TServer server, TItem item)
        {
            item.ItemId = 0x170F;

            item.Layer = 3;

            item.Hue = 1729;
        }

        public static void FirstFace(TServer server, TItem item)
        {
            item.ItemId = 0x3B44;

            item.Layer = 15;

            item.Hue = 1023;
        }
    }
}
