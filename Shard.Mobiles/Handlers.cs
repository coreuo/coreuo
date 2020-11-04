using System.Collections.Generic;
using Shard.Mobiles.Domain;

namespace Shard.Mobiles
{
    public static class Handlers<TServer, TMobile, TItem>
        where TServer : IServer<TServer, TItem>
        where TMobile : IMobile<TItem>
        where TItem : IItem
    {
        public static void Human(TServer server, TMobile mobile)
        {
            mobile.CurrentHitPoints = 67;

            mobile.MaximumHitPoints = 67;

            mobile.ClientFlags = 0x6;

            mobile.LightLevel = 0;

            mobile.Body = 400;

            mobile.LocationX = 819;

            mobile.LocationY = 621;

            mobile.LocationZ = 0xD8;

            mobile.Direction = 132;

            mobile.Hue = -31745;

            mobile.StatusFlags = 0x50;

            mobile.Sex = 0;

            mobile.Strength = 35;

            mobile.Dexterity = 35;

            mobile.Intelligence = 10;

            mobile.CurrentStamina = 35;

            mobile.MaximumStamina = 35;

            mobile.CurrentMana = 10;

            mobile.MaximumMana = 10;

            mobile.GoldInPack = 1267;

            mobile.ArmorRating = 44;

            mobile.Weight = 108;

            mobile.MaximumWeight = 222;

            mobile.Race = 1;

            mobile.StatsCap = 225;

            mobile.Followers = 0;

            mobile.MaximumFollowers = 5;

            mobile.FireResist = 44;

            mobile.ColdResist = 44;

            mobile.PoisonResist = 44;

            mobile.EnergyResist = 44;

            mobile.Luck = 0;

            mobile.DamageMinimum = 2;

            mobile.DamageMaximum = 10;

            mobile.TithingPoints = 0;

            mobile.MaximumPhysicalResistance = 70;

            mobile.MaximumFireResistance = 70;

            mobile.MaximumColdResistance = 70;

            mobile.MaximumPoisonResistance = 70;

            mobile.MaximumEnergyResistance = 70;

            mobile.MaximumHitPointsIncrease = 67;

            mobile.MaximumStaminaIncrease = 35;

            mobile.MaximumManaIncrease = 10;

            mobile.Notoriety = 3;

            mobile.Items = new List<TItem>
            {
                server.CreateItem(server.Backpack, (_,b) =>
                {
                    server.AddItem(b, server.CreateItem(server.Robe));

                    server.AddItem(b, server.CreateItem(server.Shirt));
                }),

                server.CreateItem(server.LeatherChest),

                server.CreateItem(server.Robe),

                server.CreateItem(server.Shirt),

                server.CreateItem(server.ShortPants),

                server.CreateItem(server.Shoes),

                server.CreateItem(server.FirstFace)
            };
        }
    }
}
