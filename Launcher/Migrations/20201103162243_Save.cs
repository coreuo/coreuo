using Microsoft.EntityFrameworkCore.Migrations;

namespace Launcher.Migrations
{
    public partial class Save : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Map",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MapId = table.Column<byte>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Map", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShardServer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Identity = table.Column<string>(type: "TEXT", nullable: true),
                    IpAddress = table.Column<string>(type: "TEXT", nullable: true),
                    Port = table.Column<int>(type: "INTEGER", nullable: false),
                    Percentage = table.Column<int>(type: "INTEGER", nullable: false),
                    TimeZone = table.Column<int>(type: "INTEGER", nullable: false),
                    MobileSerialPool = table.Column<string>(type: "TEXT", nullable: true),
                    ItemSerialPool = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShardServer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Entity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Serial = table.Column<int>(type: "INTEGER", nullable: false),
                    EntityDisplayId = table.Column<short>(type: "INTEGER", nullable: false),
                    MapId = table.Column<int>(type: "INTEGER", nullable: true),
                    ShardServerId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Entity_Map_MapId",
                        column: x => x.MapId,
                        principalTable: "Map",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Entity_ShardServer_ShardServerId",
                        column: x => x.ShardServerId,
                        principalTable: "ShardServer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ItemId = table.Column<ushort>(type: "INTEGER", nullable: false),
                    Layer = table.Column<byte>(type: "INTEGER", nullable: false),
                    Hue = table.Column<short>(type: "INTEGER", nullable: false),
                    Amount = table.Column<ushort>(type: "INTEGER", nullable: false),
                    LocationX = table.Column<ushort>(type: "INTEGER", nullable: false),
                    LocationY = table.Column<ushort>(type: "INTEGER", nullable: false),
                    LocationZ = table.Column<byte>(type: "INTEGER", nullable: false),
                    GridIndex = table.Column<byte>(type: "INTEGER", nullable: false),
                    EntityId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Item_Entity_EntityId",
                        column: x => x.EntityId,
                        principalTable: "Entity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Item_Entity_Id",
                        column: x => x.Id,
                        principalTable: "Entity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Mobile",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Slot = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Profession = table.Column<byte>(type: "INTEGER", nullable: false),
                    CurrentHitPoints = table.Column<short>(type: "INTEGER", nullable: false),
                    MaximumHitPoints = table.Column<short>(type: "INTEGER", nullable: false),
                    Body = table.Column<short>(type: "INTEGER", nullable: false),
                    LocationX = table.Column<ushort>(type: "INTEGER", nullable: false),
                    LocationY = table.Column<ushort>(type: "INTEGER", nullable: false),
                    LocationZ = table.Column<byte>(type: "INTEGER", nullable: false),
                    Direction = table.Column<byte>(type: "INTEGER", nullable: false),
                    Hue = table.Column<short>(type: "INTEGER", nullable: false),
                    Gender = table.Column<byte>(type: "INTEGER", nullable: false),
                    Sex = table.Column<byte>(type: "INTEGER", nullable: false),
                    Strength = table.Column<short>(type: "INTEGER", nullable: false),
                    SkinColor = table.Column<short>(type: "INTEGER", nullable: false),
                    SkillFirst = table.Column<byte>(type: "INTEGER", nullable: false),
                    SkillFirstValue = table.Column<byte>(type: "INTEGER", nullable: false),
                    SkillSecond = table.Column<byte>(type: "INTEGER", nullable: false),
                    SkillSecondValue = table.Column<byte>(type: "INTEGER", nullable: false),
                    SkillThird = table.Column<byte>(type: "INTEGER", nullable: false),
                    SkillThirdValue = table.Column<byte>(type: "INTEGER", nullable: false),
                    SkillFourth = table.Column<byte>(type: "INTEGER", nullable: false),
                    SkillFourthValue = table.Column<byte>(type: "INTEGER", nullable: false),
                    HairColor = table.Column<short>(type: "INTEGER", nullable: false),
                    HairStyle = table.Column<short>(type: "INTEGER", nullable: false),
                    ShirtColor = table.Column<short>(type: "INTEGER", nullable: false),
                    ShirtStyle = table.Column<short>(type: "INTEGER", nullable: false),
                    FaceColor = table.Column<short>(type: "INTEGER", nullable: false),
                    FaceStyle = table.Column<short>(type: "INTEGER", nullable: false),
                    BeardStyle = table.Column<short>(type: "INTEGER", nullable: false),
                    BeardColor = table.Column<short>(type: "INTEGER", nullable: false),
                    Dexterity = table.Column<short>(type: "INTEGER", nullable: false),
                    Intelligence = table.Column<short>(type: "INTEGER", nullable: false),
                    CurrentStamina = table.Column<short>(type: "INTEGER", nullable: false),
                    MaximumStamina = table.Column<short>(type: "INTEGER", nullable: false),
                    CurrentMana = table.Column<short>(type: "INTEGER", nullable: false),
                    MaximumMana = table.Column<short>(type: "INTEGER", nullable: false),
                    GoldInPack = table.Column<int>(type: "INTEGER", nullable: false),
                    ArmorRating = table.Column<short>(type: "INTEGER", nullable: false),
                    Weight = table.Column<short>(type: "INTEGER", nullable: false),
                    MaximumWeight = table.Column<short>(type: "INTEGER", nullable: false),
                    Race = table.Column<byte>(type: "INTEGER", nullable: false),
                    StatsCap = table.Column<short>(type: "INTEGER", nullable: false),
                    Followers = table.Column<byte>(type: "INTEGER", nullable: false),
                    MaximumFollowers = table.Column<byte>(type: "INTEGER", nullable: false),
                    FireResist = table.Column<short>(type: "INTEGER", nullable: false),
                    ColdResist = table.Column<short>(type: "INTEGER", nullable: false),
                    PoisonResist = table.Column<short>(type: "INTEGER", nullable: false),
                    EnergyResist = table.Column<short>(type: "INTEGER", nullable: false),
                    Luck = table.Column<short>(type: "INTEGER", nullable: false),
                    DamageMinimum = table.Column<short>(type: "INTEGER", nullable: false),
                    DamageMaximum = table.Column<short>(type: "INTEGER", nullable: false),
                    TithingPoints = table.Column<int>(type: "INTEGER", nullable: false),
                    MaximumPhysicalResistance = table.Column<short>(type: "INTEGER", nullable: false),
                    MaximumFireResistance = table.Column<short>(type: "INTEGER", nullable: false),
                    MaximumColdResistance = table.Column<short>(type: "INTEGER", nullable: false),
                    MaximumPoisonResistance = table.Column<short>(type: "INTEGER", nullable: false),
                    MaximumEnergyResistance = table.Column<short>(type: "INTEGER", nullable: false),
                    HitChanceIncrease = table.Column<short>(type: "INTEGER", nullable: false),
                    SwingSpeedIncrease = table.Column<short>(type: "INTEGER", nullable: false),
                    DamageChanceIncrease = table.Column<short>(type: "INTEGER", nullable: false),
                    LowerReagentCost = table.Column<short>(type: "INTEGER", nullable: false),
                    HitPointsRegeneration = table.Column<short>(type: "INTEGER", nullable: false),
                    StaminaRegeneration = table.Column<short>(type: "INTEGER", nullable: false),
                    ManaRegeneration = table.Column<short>(type: "INTEGER", nullable: false),
                    ReflectPhysicalDamage = table.Column<short>(type: "INTEGER", nullable: false),
                    EnhancePotions = table.Column<short>(type: "INTEGER", nullable: false),
                    DefenseChanceIncrease = table.Column<short>(type: "INTEGER", nullable: false),
                    SpellDamageIncrease = table.Column<short>(type: "INTEGER", nullable: false),
                    FasterCastRecovery = table.Column<short>(type: "INTEGER", nullable: false),
                    FasterCasting = table.Column<short>(type: "INTEGER", nullable: false),
                    LowerManaCost = table.Column<short>(type: "INTEGER", nullable: false),
                    StrengthIncrease = table.Column<short>(type: "INTEGER", nullable: false),
                    DexterityIncrease = table.Column<short>(type: "INTEGER", nullable: false),
                    IntelligenceIncrease = table.Column<short>(type: "INTEGER", nullable: false),
                    HitPointsIncrease = table.Column<short>(type: "INTEGER", nullable: false),
                    StaminaIncrease = table.Column<short>(type: "INTEGER", nullable: false),
                    ManaIncrease = table.Column<short>(type: "INTEGER", nullable: false),
                    MaximumHitPointsIncrease = table.Column<short>(type: "INTEGER", nullable: false),
                    MaximumStaminaIncrease = table.Column<short>(type: "INTEGER", nullable: false),
                    MaximumManaIncrease = table.Column<short>(type: "INTEGER", nullable: false),
                    Notoriety = table.Column<byte>(type: "INTEGER", nullable: false),
                    LoginCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mobile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mobile_Entity_Id",
                        column: x => x.Id,
                        principalTable: "Entity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShardState",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Identity = table.Column<string>(type: "TEXT", nullable: true),
                    IpAddress = table.Column<string>(type: "TEXT", nullable: true),
                    Port = table.Column<int>(type: "INTEGER", nullable: false),
                    Seed = table.Column<int>(type: "INTEGER", nullable: false),
                    AuthorizationId = table.Column<int>(type: "INTEGER", nullable: false),
                    MoveDirection = table.Column<byte>(type: "INTEGER", nullable: false),
                    MoveNumber = table.Column<byte>(type: "INTEGER", nullable: false),
                    MoveKey = table.Column<int>(type: "INTEGER", nullable: false),
                    PingNumber = table.Column<byte>(type: "INTEGER", nullable: false),
                    Season = table.Column<byte>(type: "INTEGER", nullable: false),
                    Sound = table.Column<byte>(type: "INTEGER", nullable: false),
                    WarMode = table.Column<byte>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    ChatName = table.Column<string>(type: "TEXT", nullable: true),
                    MobileQueryType = table.Column<byte>(type: "INTEGER", nullable: false),
                    MobileQuerySerial = table.Column<int>(type: "INTEGER", nullable: false),
                    Number = table.Column<byte>(type: "INTEGER", nullable: false),
                    ClientLanguage = table.Column<string>(type: "TEXT", nullable: true),
                    ClientType = table.Column<int>(type: "INTEGER", nullable: false),
                    MobileId = table.Column<int>(type: "INTEGER", nullable: true),
                    DoubleClickSerial = table.Column<int>(type: "INTEGER", nullable: false),
                    RequestProfileMode = table.Column<byte>(type: "INTEGER", nullable: false),
                    RequestProfileSerial = table.Column<int>(type: "INTEGER", nullable: false),
                    RequestProfileEditType = table.Column<short>(type: "INTEGER", nullable: false),
                    RequestProfileEditText = table.Column<string>(type: "TEXT", nullable: true),
                    ShardServerId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShardState", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShardState_Mobile_MobileId",
                        column: x => x.MobileId,
                        principalTable: "Mobile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ShardState_ShardServer_ShardServerId",
                        column: x => x.ShardServerId,
                        principalTable: "ShardServer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Skill",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SkillId = table.Column<ushort>(type: "INTEGER", nullable: false),
                    Value = table.Column<ushort>(type: "INTEGER", nullable: false),
                    Base = table.Column<ushort>(type: "INTEGER", nullable: false),
                    Lock = table.Column<byte>(type: "INTEGER", nullable: false),
                    Cap = table.Column<ushort>(type: "INTEGER", nullable: false),
                    MobileId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skill", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Skill_Mobile_MobileId",
                        column: x => x.MobileId,
                        principalTable: "Mobile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Entity_MapId",
                table: "Entity",
                column: "MapId");

            migrationBuilder.CreateIndex(
                name: "IX_Entity_ShardServerId",
                table: "Entity",
                column: "ShardServerId");

            migrationBuilder.CreateIndex(
                name: "IX_Item_EntityId",
                table: "Item",
                column: "EntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ShardState_MobileId",
                table: "ShardState",
                column: "MobileId");

            migrationBuilder.CreateIndex(
                name: "IX_ShardState_ShardServerId",
                table: "ShardState",
                column: "ShardServerId");

            migrationBuilder.CreateIndex(
                name: "IX_Skill_MobileId",
                table: "Skill",
                column: "MobileId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropTable(
                name: "ShardState");

            migrationBuilder.DropTable(
                name: "Skill");

            migrationBuilder.DropTable(
                name: "Mobile");

            migrationBuilder.DropTable(
                name: "Entity");

            migrationBuilder.DropTable(
                name: "Map");

            migrationBuilder.DropTable(
                name: "ShardServer");
        }
    }
}
