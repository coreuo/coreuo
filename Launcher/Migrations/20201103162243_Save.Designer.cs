﻿// <auto-generated />
using System;
using Launcher.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Launcher.Migrations
{
    [DbContext(typeof(ShardSave))]
    [Migration("20201103162243_Save")]
    partial class Save
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.0-rc.2.20475.6");

            modelBuilder.Entity("Launcher.Domain.Entity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<short>("EntityDisplayId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("MapId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Serial")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ShardServerId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("MapId");

                    b.HasIndex("ShardServerId");

                    b.ToTable("Entity");
                });

            modelBuilder.Entity("Launcher.Domain.Map", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<byte>("MapId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Map");
                });

            modelBuilder.Entity("Launcher.Domain.ShardServer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Identity")
                        .HasColumnType("TEXT");

                    b.Property<string>("IpAddress")
                        .HasColumnType("TEXT");

                    b.Property<string>("ItemSerialPool")
                        .HasColumnType("TEXT");

                    b.Property<string>("MobileSerialPool")
                        .HasColumnType("TEXT");

                    b.Property<int>("Percentage")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Port")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TimeZone")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("ShardServer");
                });

            modelBuilder.Entity("Launcher.Domain.ShardState", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AuthorizationId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ChatName")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClientLanguage")
                        .HasColumnType("TEXT");

                    b.Property<int>("ClientType")
                        .HasColumnType("INTEGER");

                    b.Property<int>("DoubleClickSerial")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Identity")
                        .HasColumnType("TEXT");

                    b.Property<string>("IpAddress")
                        .HasColumnType("TEXT");

                    b.Property<int?>("MobileId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MobileQuerySerial")
                        .HasColumnType("INTEGER");

                    b.Property<byte>("MobileQueryType")
                        .HasColumnType("INTEGER");

                    b.Property<byte>("MoveDirection")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MoveKey")
                        .HasColumnType("INTEGER");

                    b.Property<byte>("MoveNumber")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<byte>("Number")
                        .HasColumnType("INTEGER");

                    b.Property<byte>("PingNumber")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Port")
                        .HasColumnType("INTEGER");

                    b.Property<string>("RequestProfileEditText")
                        .HasColumnType("TEXT");

                    b.Property<short>("RequestProfileEditType")
                        .HasColumnType("INTEGER");

                    b.Property<byte>("RequestProfileMode")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RequestProfileSerial")
                        .HasColumnType("INTEGER");

                    b.Property<byte>("Season")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Seed")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ShardServerId")
                        .HasColumnType("INTEGER");

                    b.Property<byte>("Sound")
                        .HasColumnType("INTEGER");

                    b.Property<byte>("WarMode")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("MobileId");

                    b.HasIndex("ShardServerId");

                    b.ToTable("ShardState");
                });

            modelBuilder.Entity("Launcher.Domain.Skill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<ushort>("Base")
                        .HasColumnType("INTEGER");

                    b.Property<ushort>("Cap")
                        .HasColumnType("INTEGER");

                    b.Property<byte>("Lock")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("MobileId")
                        .HasColumnType("INTEGER");

                    b.Property<ushort>("SkillId")
                        .HasColumnType("INTEGER");

                    b.Property<ushort>("Value")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("MobileId");

                    b.ToTable("Skill");
                });

            modelBuilder.Entity("Launcher.Domain.Item", b =>
                {
                    b.HasBaseType("Launcher.Domain.Entity");

                    b.Property<ushort>("Amount")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("EntityId")
                        .HasColumnType("INTEGER");

                    b.Property<byte>("GridIndex")
                        .HasColumnType("INTEGER");

                    b.Property<short>("Hue")
                        .HasColumnType("INTEGER");

                    b.Property<ushort>("ItemId")
                        .HasColumnType("INTEGER");

                    b.Property<byte>("Layer")
                        .HasColumnType("INTEGER");

                    b.Property<ushort>("LocationX")
                        .HasColumnType("INTEGER");

                    b.Property<ushort>("LocationY")
                        .HasColumnType("INTEGER");

                    b.Property<byte>("LocationZ")
                        .HasColumnType("INTEGER");

                    b.HasIndex("EntityId");

                    b.ToTable("Item");
                });

            modelBuilder.Entity("Launcher.Domain.Mobile", b =>
                {
                    b.HasBaseType("Launcher.Domain.Entity");

                    b.Property<short>("ArmorRating")
                        .HasColumnType("INTEGER");

                    b.Property<short>("BeardColor")
                        .HasColumnType("INTEGER");

                    b.Property<short>("BeardStyle")
                        .HasColumnType("INTEGER");

                    b.Property<short>("Body")
                        .HasColumnType("INTEGER");

                    b.Property<short>("ColdResist")
                        .HasColumnType("INTEGER");

                    b.Property<short>("CurrentHitPoints")
                        .HasColumnType("INTEGER");

                    b.Property<short>("CurrentMana")
                        .HasColumnType("INTEGER");

                    b.Property<short>("CurrentStamina")
                        .HasColumnType("INTEGER");

                    b.Property<short>("DamageChanceIncrease")
                        .HasColumnType("INTEGER");

                    b.Property<short>("DamageMaximum")
                        .HasColumnType("INTEGER");

                    b.Property<short>("DamageMinimum")
                        .HasColumnType("INTEGER");

                    b.Property<short>("DefenseChanceIncrease")
                        .HasColumnType("INTEGER");

                    b.Property<short>("Dexterity")
                        .HasColumnType("INTEGER");

                    b.Property<short>("DexterityIncrease")
                        .HasColumnType("INTEGER");

                    b.Property<byte>("Direction")
                        .HasColumnType("INTEGER");

                    b.Property<short>("EnergyResist")
                        .HasColumnType("INTEGER");

                    b.Property<short>("EnhancePotions")
                        .HasColumnType("INTEGER");

                    b.Property<short>("FaceColor")
                        .HasColumnType("INTEGER");

                    b.Property<short>("FaceStyle")
                        .HasColumnType("INTEGER");

                    b.Property<short>("FasterCastRecovery")
                        .HasColumnType("INTEGER");

                    b.Property<short>("FasterCasting")
                        .HasColumnType("INTEGER");

                    b.Property<short>("FireResist")
                        .HasColumnType("INTEGER");

                    b.Property<byte>("Followers")
                        .HasColumnType("INTEGER");

                    b.Property<byte>("Gender")
                        .HasColumnType("INTEGER");

                    b.Property<int>("GoldInPack")
                        .HasColumnType("INTEGER");

                    b.Property<short>("HairColor")
                        .HasColumnType("INTEGER");

                    b.Property<short>("HairStyle")
                        .HasColumnType("INTEGER");

                    b.Property<short>("HitChanceIncrease")
                        .HasColumnType("INTEGER");

                    b.Property<short>("HitPointsIncrease")
                        .HasColumnType("INTEGER");

                    b.Property<short>("HitPointsRegeneration")
                        .HasColumnType("INTEGER");

                    b.Property<short>("Hue")
                        .HasColumnType("INTEGER");

                    b.Property<short>("Intelligence")
                        .HasColumnType("INTEGER");

                    b.Property<short>("IntelligenceIncrease")
                        .HasColumnType("INTEGER");

                    b.Property<ushort>("LocationX")
                        .HasColumnType("INTEGER");

                    b.Property<ushort>("LocationY")
                        .HasColumnType("INTEGER");

                    b.Property<byte>("LocationZ")
                        .HasColumnType("INTEGER");

                    b.Property<int>("LoginCount")
                        .HasColumnType("INTEGER");

                    b.Property<short>("LowerManaCost")
                        .HasColumnType("INTEGER");

                    b.Property<short>("LowerReagentCost")
                        .HasColumnType("INTEGER");

                    b.Property<short>("Luck")
                        .HasColumnType("INTEGER");

                    b.Property<short>("ManaIncrease")
                        .HasColumnType("INTEGER");

                    b.Property<short>("ManaRegeneration")
                        .HasColumnType("INTEGER");

                    b.Property<short>("MaximumColdResistance")
                        .HasColumnType("INTEGER");

                    b.Property<short>("MaximumEnergyResistance")
                        .HasColumnType("INTEGER");

                    b.Property<short>("MaximumFireResistance")
                        .HasColumnType("INTEGER");

                    b.Property<byte>("MaximumFollowers")
                        .HasColumnType("INTEGER");

                    b.Property<short>("MaximumHitPoints")
                        .HasColumnType("INTEGER");

                    b.Property<short>("MaximumHitPointsIncrease")
                        .HasColumnType("INTEGER");

                    b.Property<short>("MaximumMana")
                        .HasColumnType("INTEGER");

                    b.Property<short>("MaximumManaIncrease")
                        .HasColumnType("INTEGER");

                    b.Property<short>("MaximumPhysicalResistance")
                        .HasColumnType("INTEGER");

                    b.Property<short>("MaximumPoisonResistance")
                        .HasColumnType("INTEGER");

                    b.Property<short>("MaximumStamina")
                        .HasColumnType("INTEGER");

                    b.Property<short>("MaximumStaminaIncrease")
                        .HasColumnType("INTEGER");

                    b.Property<short>("MaximumWeight")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<byte>("Notoriety")
                        .HasColumnType("INTEGER");

                    b.Property<short>("PoisonResist")
                        .HasColumnType("INTEGER");

                    b.Property<byte>("Profession")
                        .HasColumnType("INTEGER");

                    b.Property<byte>("Race")
                        .HasColumnType("INTEGER");

                    b.Property<short>("ReflectPhysicalDamage")
                        .HasColumnType("INTEGER");

                    b.Property<byte>("Sex")
                        .HasColumnType("INTEGER");

                    b.Property<short>("ShirtColor")
                        .HasColumnType("INTEGER");

                    b.Property<short>("ShirtStyle")
                        .HasColumnType("INTEGER");

                    b.Property<byte>("SkillFirst")
                        .HasColumnType("INTEGER");

                    b.Property<byte>("SkillFirstValue")
                        .HasColumnType("INTEGER");

                    b.Property<byte>("SkillFourth")
                        .HasColumnType("INTEGER");

                    b.Property<byte>("SkillFourthValue")
                        .HasColumnType("INTEGER");

                    b.Property<byte>("SkillSecond")
                        .HasColumnType("INTEGER");

                    b.Property<byte>("SkillSecondValue")
                        .HasColumnType("INTEGER");

                    b.Property<byte>("SkillThird")
                        .HasColumnType("INTEGER");

                    b.Property<byte>("SkillThirdValue")
                        .HasColumnType("INTEGER");

                    b.Property<short>("SkinColor")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Slot")
                        .HasColumnType("INTEGER");

                    b.Property<short>("SpellDamageIncrease")
                        .HasColumnType("INTEGER");

                    b.Property<short>("StaminaIncrease")
                        .HasColumnType("INTEGER");

                    b.Property<short>("StaminaRegeneration")
                        .HasColumnType("INTEGER");

                    b.Property<short>("StatsCap")
                        .HasColumnType("INTEGER");

                    b.Property<short>("Strength")
                        .HasColumnType("INTEGER");

                    b.Property<short>("StrengthIncrease")
                        .HasColumnType("INTEGER");

                    b.Property<short>("SwingSpeedIncrease")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TithingPoints")
                        .HasColumnType("INTEGER");

                    b.Property<short>("Weight")
                        .HasColumnType("INTEGER");

                    b.ToTable("Mobile");
                });

            modelBuilder.Entity("Launcher.Domain.Entity", b =>
                {
                    b.HasOne("Launcher.Domain.Map", "Map")
                        .WithMany()
                        .HasForeignKey("MapId");

                    b.HasOne("Launcher.Domain.ShardServer", null)
                        .WithMany("Entities")
                        .HasForeignKey("ShardServerId");

                    b.Navigation("Map");
                });

            modelBuilder.Entity("Launcher.Domain.ShardState", b =>
                {
                    b.HasOne("Launcher.Domain.Mobile", "Mobile")
                        .WithMany()
                        .HasForeignKey("MobileId");

                    b.HasOne("Launcher.Domain.ShardServer", null)
                        .WithMany("States")
                        .HasForeignKey("ShardServerId");

                    b.Navigation("Mobile");
                });

            modelBuilder.Entity("Launcher.Domain.Skill", b =>
                {
                    b.HasOne("Launcher.Domain.Mobile", null)
                        .WithMany("Skills")
                        .HasForeignKey("MobileId");
                });

            modelBuilder.Entity("Launcher.Domain.Item", b =>
                {
                    b.HasOne("Launcher.Domain.Entity", null)
                        .WithMany("Items")
                        .HasForeignKey("EntityId");

                    b.HasOne("Launcher.Domain.Entity", null)
                        .WithOne()
                        .HasForeignKey("Launcher.Domain.Item", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Launcher.Domain.Mobile", b =>
                {
                    b.HasOne("Launcher.Domain.Entity", null)
                        .WithOne()
                        .HasForeignKey("Launcher.Domain.Mobile", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Launcher.Domain.Entity", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("Launcher.Domain.ShardServer", b =>
                {
                    b.Navigation("Entities");

                    b.Navigation("States");
                });

            modelBuilder.Entity("Launcher.Domain.Mobile", b =>
                {
                    b.Navigation("Skills");
                });
#pragma warning restore 612, 618
        }
    }
}
