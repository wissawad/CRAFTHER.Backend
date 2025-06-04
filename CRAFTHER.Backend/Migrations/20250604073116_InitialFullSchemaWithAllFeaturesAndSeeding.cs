using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CRAFTHER.Backend.Migrations
{
    /// <inheritdoc />
    public partial class InitialFullSchemaWithAllFeaturesAndSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Levels",
                columns: table => new
                {
                    LevelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LevelNumber = table.Column<int>(type: "int", nullable: false),
                    LevelName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    RequiredPoints = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    BadgeImageUrl = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Levels", x => x.LevelId);
                });

            migrationBuilder.CreateTable(
                name: "OrganizationIndustryTypes",
                columns: table => new
                {
                    IndustryTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IndustryTypeName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationIndustryTypes", x => x.IndustryTypeId);
                });

            migrationBuilder.CreateTable(
                name: "QuestTypes",
                columns: table => new
                {
                    QuestTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuestTypeName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestTypes", x => x.QuestTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StockAdjustmentTypes",
                columns: table => new
                {
                    AdjustmentTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Effect = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockAdjustmentTypes", x => x.AdjustmentTypeId);
                });

            migrationBuilder.CreateTable(
                name: "SubscriptionPlans",
                columns: table => new
                {
                    PlanId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlanName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    MaxProducts = table.Column<int>(type: "int", nullable: true),
                    MaxComponents = table.Column<int>(type: "int", nullable: true),
                    MaxUsers = table.Column<int>(type: "int", nullable: true),
                    StorageSpaceMB = table.Column<int>(type: "int", nullable: true),
                    CanAccessAdvancedReports = table.Column<bool>(type: "bit", nullable: false),
                    CanIntegratePOS = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubscriptionPlans", x => x.PlanId);
                });

            migrationBuilder.CreateTable(
                name: "UnitGroups",
                columns: table => new
                {
                    UnitGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UnitGroupName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitGroups", x => x.UnitGroupId);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaims_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Organizations",
                columns: table => new
                {
                    OrganizationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrganizationName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Website = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    IndustryTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlanId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizations", x => x.OrganizationId);
                    table.ForeignKey(
                        name: "FK_Organizations_OrganizationIndustryTypes_IndustryTypeId",
                        column: x => x.IndustryTypeId,
                        principalTable: "OrganizationIndustryTypes",
                        principalColumn: "IndustryTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Organizations_SubscriptionPlans_PlanId",
                        column: x => x.PlanId,
                        principalTable: "SubscriptionPlans",
                        principalColumn: "PlanId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UnitsOfMeasures",
                columns: table => new
                {
                    UnitId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UnitName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Abbreviation = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    IsBaseUnit = table.Column<bool>(type: "bit", nullable: false),
                    ConversionFactorToBaseUnit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UnitGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitsOfMeasures", x => x.UnitId);
                    table.ForeignKey(
                        name: "FK_UnitsOfMeasures_UnitGroups_UnitGroupId",
                        column: x => x.UnitGroupId,
                        principalTable: "UnitGroups",
                        principalColumn: "UnitGroupId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Quests",
                columns: table => new
                {
                    QuestId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    QuestTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RewardPoints = table.Column<int>(type: "int", nullable: false),
                    IsRepeatable = table.Column<bool>(type: "bit", nullable: false),
                    ExpiresAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RequiredProgress = table.Column<int>(type: "int", nullable: false),
                    TargetFeature = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    OrganizationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quests", x => x.QuestId);
                    table.ForeignKey(
                        name: "FK_Quests_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "OrganizationId");
                    table.ForeignKey(
                        name: "FK_Quests_QuestTypes_QuestTypeId",
                        column: x => x.QuestTypeId,
                        principalTable: "QuestTypes",
                        principalColumn: "QuestTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserDisplayName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    OrganizationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "OrganizationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Components",
                columns: table => new
                {
                    ComponentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ComponentCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ComponentName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    PurchaseUnitId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PurchaseToInventoryConversionFactor = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    InventoryUnitId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CurrentStockQuantity = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    MinimumStockLevel = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    OrganizationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Components", x => x.ComponentId);
                    table.ForeignKey(
                        name: "FK_Components_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "OrganizationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Components_UnitsOfMeasures_InventoryUnitId",
                        column: x => x.InventoryUnitId,
                        principalTable: "UnitsOfMeasures",
                        principalColumn: "UnitId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Components_UnitsOfMeasures_PurchaseUnitId",
                        column: x => x.PurchaseUnitId,
                        principalTable: "UnitsOfMeasures",
                        principalColumn: "UnitId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ProductUnitId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SaleUnitId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductUnitToSaleUnitConversionFactor = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    CurrentStockQuantity = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    SellingPrice = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    CalculatedCost = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    IsSubProduct = table.Column<bool>(type: "bit", nullable: false),
                    OrganizationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "OrganizationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_UnitsOfMeasures_ProductUnitId",
                        column: x => x.ProductUnitId,
                        principalTable: "UnitsOfMeasures",
                        principalColumn: "UnitId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_UnitsOfMeasures_SaleUnitId",
                        column: x => x.SaleUnitId,
                        principalTable: "UnitsOfMeasures",
                        principalColumn: "UnitId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UnitConversions",
                columns: table => new
                {
                    ConversionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrganizationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FromUnitId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ToUnitId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConversionFactor = table.Column<decimal>(type: "decimal(18,8)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitConversions", x => x.ConversionId);
                    table.ForeignKey(
                        name: "FK_UnitConversions_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "OrganizationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UnitConversions_UnitsOfMeasures_FromUnitId",
                        column: x => x.FromUnitId,
                        principalTable: "UnitsOfMeasures",
                        principalColumn: "UnitId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UnitConversions_UnitsOfMeasures_ToUnitId",
                        column: x => x.ToUnitId,
                        principalTable: "UnitsOfMeasures",
                        principalColumn: "UnitId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_UserLogins_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserQuests",
                columns: table => new
                {
                    UserQuestId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuestId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CurrentProgress = table.Column<int>(type: "int", nullable: false),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    CompletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AssignedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserQuests", x => x.UserQuestId);
                    table.ForeignKey(
                        name: "FK_UserQuests_Quests_QuestId",
                        column: x => x.QuestId,
                        principalTable: "Quests",
                        principalColumn: "QuestId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserQuests_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserScores",
                columns: table => new
                {
                    UserScoreId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TotalPoints = table.Column<int>(type: "int", nullable: false),
                    CurrentLevel = table.Column<int>(type: "int", nullable: false),
                    LevelId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserScores", x => x.UserScoreId);
                    table.ForeignKey(
                        name: "FK_UserScores_Levels_LevelId",
                        column: x => x.LevelId,
                        principalTable: "Levels",
                        principalColumn: "LevelId");
                    table.ForeignKey(
                        name: "FK_UserScores_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_UserTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StockAdjustments",
                columns: table => new
                {
                    AdjustmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrganizationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ComponentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AdjustmentTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    UnitOfMeasureId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuantityBeforeAdjustment = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    QuantityAfterAdjustment = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdjustmentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockAdjustments", x => x.AdjustmentId);
                    table.ForeignKey(
                        name: "FK_StockAdjustments_Components_ComponentId",
                        column: x => x.ComponentId,
                        principalTable: "Components",
                        principalColumn: "ComponentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StockAdjustments_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "OrganizationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StockAdjustments_StockAdjustmentTypes_AdjustmentTypeId",
                        column: x => x.AdjustmentTypeId,
                        principalTable: "StockAdjustmentTypes",
                        principalColumn: "AdjustmentTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StockAdjustments_UnitsOfMeasures_UnitOfMeasureId",
                        column: x => x.UnitOfMeasureId,
                        principalTable: "UnitsOfMeasures",
                        principalColumn: "UnitId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BOMItems",
                columns: table => new
                {
                    BOMItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ParentProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ComponentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ComponentType = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    UsageUnitId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SortOrder = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BOMItems", x => x.BOMItemId);
                    table.ForeignKey(
                        name: "FK_BOMItems_Components_ComponentId",
                        column: x => x.ComponentId,
                        principalTable: "Components",
                        principalColumn: "ComponentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BOMItems_Products_ParentProductId",
                        column: x => x.ParentProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BOMItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BOMItems_UnitsOfMeasures_UsageUnitId",
                        column: x => x.UsageUnitId,
                        principalTable: "UnitsOfMeasures",
                        principalColumn: "UnitId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Levels",
                columns: new[] { "LevelId", "BadgeImageUrl", "CreatedAt", "Description", "LevelName", "LevelNumber", "RequiredPoints", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("a0b1c2d3-e4f5-a6b7-c8d9-e0f1a2b3c4d5"), null, new DateTime(2025, 6, 4, 7, 31, 15, 303, DateTimeKind.Utc).AddTicks(4031), "Mastering your ingredient knowledge.", "Ingredient Explorer", 3, 300, new DateTime(2025, 6, 4, 7, 31, 15, 303, DateTimeKind.Utc).AddTicks(4031) },
                    { new Guid("b1c2d3e4-f5a6-b7c8-d9e0-f1a2b3c4d5e6"), null, new DateTime(2025, 6, 4, 7, 31, 15, 303, DateTimeKind.Utc).AddTicks(4033), "Becoming an expert in cost analysis.", "Costing Pro", 4, 600, new DateTime(2025, 6, 4, 7, 31, 15, 303, DateTimeKind.Utc).AddTicks(4034) },
                    { new Guid("c2d3e4f5-a6b7-c8d9-e0f1-a2b3c4d5e6f7"), null, new DateTime(2025, 6, 4, 7, 31, 15, 303, DateTimeKind.Utc).AddTicks(4036), "The ultimate CRAFTHER champion!", "CRAFTHER Master", 5, 1000, new DateTime(2025, 6, 4, 7, 31, 15, 303, DateTimeKind.Utc).AddTicks(4036) },
                    { new Guid("e1f2a3b4-c5d6-e7f8-a9b0-c1d2e3f4a5b6"), null, new DateTime(2025, 6, 4, 7, 31, 15, 303, DateTimeKind.Utc).AddTicks(4022), "Just starting your BOM journey.", "BOM Novice", 1, 0, new DateTime(2025, 6, 4, 7, 31, 15, 303, DateTimeKind.Utc).AddTicks(4023) },
                    { new Guid("f2a3b4c5-d6e7-f8a9-b0c1-d2e3f4a5b6c7"), null, new DateTime(2025, 6, 4, 7, 31, 15, 303, DateTimeKind.Utc).AddTicks(4028), "Learning the ropes of recipe management.", "Recipe Apprentice", 2, 100, new DateTime(2025, 6, 4, 7, 31, 15, 303, DateTimeKind.Utc).AddTicks(4028) }
                });

            migrationBuilder.InsertData(
                table: "OrganizationIndustryTypes",
                columns: new[] { "IndustryTypeId", "CreatedAt", "Description", "IndustryTypeName", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("a1b2c3d4-e5f6-7890-1234-567890abcdef"), new DateTime(2025, 6, 4, 7, 31, 15, 303, DateTimeKind.Utc).AddTicks(3858), "Businesses primarily focused on coffee, tea, and light snacks.", "Cafe / Coffee Shop", new DateTime(2025, 6, 4, 7, 31, 15, 303, DateTimeKind.Utc).AddTicks(3861) },
                    { new Guid("b2c3d4e5-f6a1-2345-6789-0abcdef12345"), new DateTime(2025, 6, 4, 7, 31, 15, 303, DateTimeKind.Utc).AddTicks(3864), "Businesses specializing in baked goods, pastries, and sweets.", "Bakery / Confectionery", new DateTime(2025, 6, 4, 7, 31, 15, 303, DateTimeKind.Utc).AddTicks(3864) },
                    { new Guid("c3d4e5f6-a1b2-3456-7890-cdef12345678"), new DateTime(2025, 6, 4, 7, 31, 15, 303, DateTimeKind.Utc).AddTicks(3866), "Businesses serving prepared meals and beverages.", "Restaurant / Eatery", new DateTime(2025, 6, 4, 7, 31, 15, 303, DateTimeKind.Utc).AddTicks(3866) },
                    { new Guid("d4e5f6a1-b2c3-4567-890a-bcdef1234567"), new DateTime(2025, 6, 4, 7, 31, 15, 303, DateTimeKind.Utc).AddTicks(3875), "Businesses producing and selling handmade products.", "Crafts / Handmade Goods", new DateTime(2025, 6, 4, 7, 31, 15, 303, DateTimeKind.Utc).AddTicks(3875) }
                });

            migrationBuilder.InsertData(
                table: "QuestTypes",
                columns: new[] { "QuestTypeId", "CreatedAt", "Description", "QuestTypeName", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("a1b2c3d4-e5f6-7890-abcd-ef0123456789"), new DateTime(2025, 6, 4, 7, 31, 15, 303, DateTimeKind.Utc).AddTicks(3985), "Quests that refresh daily.", "DAILY", new DateTime(2025, 6, 4, 7, 31, 15, 303, DateTimeKind.Utc).AddTicks(3985) },
                    { new Guid("b2c3d4e5-f6a1-2345-cdef-0123456789ab"), new DateTime(2025, 6, 4, 7, 31, 15, 303, DateTimeKind.Utc).AddTicks(3988), "Quests that refresh weekly.", "WEEKLY", new DateTime(2025, 6, 4, 7, 31, 15, 303, DateTimeKind.Utc).AddTicks(3988) },
                    { new Guid("c3d4e5f6-a1b2-3456-7890-abcdef012345"), new DateTime(2025, 6, 4, 7, 31, 15, 303, DateTimeKind.Utc).AddTicks(3990), "Core progression quests.", "MAIN_STORY", new DateTime(2025, 6, 4, 7, 31, 15, 303, DateTimeKind.Utc).AddTicks(3990) },
                    { new Guid("d4e5f6a1-b2c3-4567-890a-bcdef0123456"), new DateTime(2025, 6, 4, 7, 31, 15, 303, DateTimeKind.Utc).AddTicks(3992), "Difficult, one-time challenges.", "CHALLENGE", new DateTime(2025, 6, 4, 7, 31, 15, 303, DateTimeKind.Utc).AddTicks(3992) }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("c1a2b3d4-e5f6-7890-1234-567890abcdef"), null, "Admin", "ADMIN" },
                    { new Guid("d5e6f7a8-b9c0-1234-5678-90abcdef1234"), null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "StockAdjustmentTypes",
                columns: new[] { "AdjustmentTypeId", "CreatedAt", "Effect", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("01a1b2c3-d4e5-6f78-9012-3456789abc01"), new DateTime(2025, 6, 4, 7, 31, 15, 291, DateTimeKind.Utc).AddTicks(7356), "Increase", "Receive", new DateTime(2025, 6, 4, 7, 31, 15, 291, DateTimeKind.Utc).AddTicks(7356) },
                    { new Guid("02a1b2c3-d4e5-6f78-9012-3456789abc02"), new DateTime(2025, 6, 4, 7, 31, 15, 291, DateTimeKind.Utc).AddTicks(7377), "Decrease", "Issue", new DateTime(2025, 6, 4, 7, 31, 15, 291, DateTimeKind.Utc).AddTicks(7378) },
                    { new Guid("03a1b2c3-d4e5-6f78-9012-3456789abc03"), new DateTime(2025, 6, 4, 7, 31, 15, 291, DateTimeKind.Utc).AddTicks(7382), "Increase", "Positive Adjustment", new DateTime(2025, 6, 4, 7, 31, 15, 291, DateTimeKind.Utc).AddTicks(7382) },
                    { new Guid("04a1b2c3-d4e5-6f78-9012-3456789abc04"), new DateTime(2025, 6, 4, 7, 31, 15, 291, DateTimeKind.Utc).AddTicks(7387), "Decrease", "Negative Adjustment", new DateTime(2025, 6, 4, 7, 31, 15, 291, DateTimeKind.Utc).AddTicks(7388) },
                    { new Guid("05a1b2c3-d4e5-6f78-9012-3456789abc05"), new DateTime(2025, 6, 4, 7, 31, 15, 291, DateTimeKind.Utc).AddTicks(7392), "Increase", "Production In", new DateTime(2025, 6, 4, 7, 31, 15, 291, DateTimeKind.Utc).AddTicks(7393) },
                    { new Guid("06a1b2c3-d4e5-6f78-9012-3456789abc06"), new DateTime(2025, 6, 4, 7, 31, 15, 291, DateTimeKind.Utc).AddTicks(7397), "Decrease", "Consumption", new DateTime(2025, 6, 4, 7, 31, 15, 291, DateTimeKind.Utc).AddTicks(7398) }
                });

            migrationBuilder.InsertData(
                table: "SubscriptionPlans",
                columns: new[] { "PlanId", "CanAccessAdvancedReports", "CanIntegratePOS", "CreatedAt", "Description", "MaxComponents", "MaxProducts", "MaxUsers", "PlanName", "Price", "StorageSpaceMB", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("11223344-5566-7788-99aa-bbccddeeff00"), false, false, new DateTime(2025, 6, 4, 7, 31, 15, 303, DateTimeKind.Utc).AddTicks(3938), "Basic features for small businesses to get started.", 20, 5, 1, "Free", 0.00m, 50, new DateTime(2025, 6, 4, 7, 31, 15, 303, DateTimeKind.Utc).AddTicks(3939) },
                    { new Guid("aabbccdd-eeff-1122-3344-5566778899aa"), true, false, new DateTime(2025, 6, 4, 7, 31, 15, 303, DateTimeKind.Utc).AddTicks(3947), "Essential tools for growing businesses.", 200, 50, 3, "Basic", 199.00m, 500, new DateTime(2025, 6, 4, 7, 31, 15, 303, DateTimeKind.Utc).AddTicks(3948) },
                    { new Guid("ccddeeff-aabb-3344-5566-778899aabbcc"), true, true, new DateTime(2025, 6, 4, 7, 31, 15, 303, DateTimeKind.Utc).AddTicks(3951), "Advanced features for established businesses.", 0, 0, 0, "Pro", 499.00m, 5000, new DateTime(2025, 6, 4, 7, 31, 15, 303, DateTimeKind.Utc).AddTicks(3951) }
                });

            migrationBuilder.InsertData(
                table: "UnitGroups",
                columns: new[] { "UnitGroupId", "CreatedAt", "Description", "UnitGroupName", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("a0000000-0000-0000-0000-000000000001"), new DateTime(2025, 6, 4, 7, 31, 15, 286, DateTimeKind.Utc).AddTicks(5166), null, "Weight", new DateTime(2025, 6, 4, 7, 31, 15, 286, DateTimeKind.Utc).AddTicks(5167) },
                    { new Guid("a0000000-0000-0000-0000-000000000002"), new DateTime(2025, 6, 4, 7, 31, 15, 286, DateTimeKind.Utc).AddTicks(5176), null, "Volume", new DateTime(2025, 6, 4, 7, 31, 15, 286, DateTimeKind.Utc).AddTicks(5178) },
                    { new Guid("a0000000-0000-0000-0000-000000000003"), new DateTime(2025, 6, 4, 7, 31, 15, 286, DateTimeKind.Utc).AddTicks(5183), null, "Count", new DateTime(2025, 6, 4, 7, 31, 15, 286, DateTimeKind.Utc).AddTicks(5184) },
                    { new Guid("a0000000-0000-0000-0000-000000000004"), new DateTime(2025, 6, 4, 7, 31, 15, 286, DateTimeKind.Utc).AddTicks(5195), null, "Length", new DateTime(2025, 6, 4, 7, 31, 15, 286, DateTimeKind.Utc).AddTicks(5196) }
                });

            migrationBuilder.InsertData(
                table: "UnitsOfMeasures",
                columns: new[] { "UnitId", "Abbreviation", "ConversionFactorToBaseUnit", "CreatedAt", "IsBaseUnit", "UnitGroupId", "UnitName", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("b0000000-0000-0000-0000-000000000001"), "g", 1.0m, new DateTime(2025, 6, 4, 7, 31, 15, 287, DateTimeKind.Utc).AddTicks(7356), true, new Guid("a0000000-0000-0000-0000-000000000001"), "Gram", new DateTime(2025, 6, 4, 7, 31, 15, 287, DateTimeKind.Utc).AddTicks(7358) },
                    { new Guid("b0000000-0000-0000-0000-000000000002"), "kg", 1000.0m, new DateTime(2025, 6, 4, 7, 31, 15, 287, DateTimeKind.Utc).AddTicks(7371), false, new Guid("a0000000-0000-0000-0000-000000000001"), "Kilogram", new DateTime(2025, 6, 4, 7, 31, 15, 287, DateTimeKind.Utc).AddTicks(7372) },
                    { new Guid("b0000000-0000-0000-0000-000000000003"), "mg", 0.001m, new DateTime(2025, 6, 4, 7, 31, 15, 287, DateTimeKind.Utc).AddTicks(7384), false, new Guid("a0000000-0000-0000-0000-000000000001"), "Milligram", new DateTime(2025, 6, 4, 7, 31, 15, 287, DateTimeKind.Utc).AddTicks(7384) },
                    { new Guid("b0000000-0000-0000-0000-000000000004"), "lb", 453.59237m, new DateTime(2025, 6, 4, 7, 31, 15, 287, DateTimeKind.Utc).AddTicks(7393), false, new Guid("a0000000-0000-0000-0000-000000000001"), "Pound", new DateTime(2025, 6, 4, 7, 31, 15, 287, DateTimeKind.Utc).AddTicks(7394) },
                    { new Guid("b0000000-0000-0000-0000-000000000005"), "oz", 28.349523125m, new DateTime(2025, 6, 4, 7, 31, 15, 287, DateTimeKind.Utc).AddTicks(7400), false, new Guid("a0000000-0000-0000-0000-000000000001"), "Ounce", new DateTime(2025, 6, 4, 7, 31, 15, 287, DateTimeKind.Utc).AddTicks(7402) },
                    { new Guid("b0000000-0000-0000-0000-000000000006"), "ml", 1.0m, new DateTime(2025, 6, 4, 7, 31, 15, 287, DateTimeKind.Utc).AddTicks(7412), true, new Guid("a0000000-0000-0000-0000-000000000002"), "Milliliter", new DateTime(2025, 6, 4, 7, 31, 15, 287, DateTimeKind.Utc).AddTicks(7413) },
                    { new Guid("b0000000-0000-0000-0000-000000000007"), "l", 1000.0m, new DateTime(2025, 6, 4, 7, 31, 15, 287, DateTimeKind.Utc).AddTicks(7424), false, new Guid("a0000000-0000-0000-0000-000000000002"), "Liter", new DateTime(2025, 6, 4, 7, 31, 15, 287, DateTimeKind.Utc).AddTicks(7425) },
                    { new Guid("b0000000-0000-0000-0000-000000000008"), "tsp", 4.92892m, new DateTime(2025, 6, 4, 7, 31, 15, 287, DateTimeKind.Utc).AddTicks(7433), false, new Guid("a0000000-0000-0000-0000-000000000002"), "Teaspoon", new DateTime(2025, 6, 4, 7, 31, 15, 287, DateTimeKind.Utc).AddTicks(7435) },
                    { new Guid("b0000000-0000-0000-0000-000000000009"), "tbsp", 14.7868m, new DateTime(2025, 6, 4, 7, 31, 15, 287, DateTimeKind.Utc).AddTicks(7450), false, new Guid("a0000000-0000-0000-0000-000000000002"), "Tablespoon", new DateTime(2025, 6, 4, 7, 31, 15, 287, DateTimeKind.Utc).AddTicks(7451) },
                    { new Guid("b0000000-0000-0000-0000-00000000000a"), "cup", 236.588m, new DateTime(2025, 6, 4, 7, 31, 15, 287, DateTimeKind.Utc).AddTicks(7459), false, new Guid("a0000000-0000-0000-0000-000000000002"), "Cup", new DateTime(2025, 6, 4, 7, 31, 15, 287, DateTimeKind.Utc).AddTicks(7461) },
                    { new Guid("b0000000-0000-0000-0000-00000000000b"), "pcs", 1.0m, new DateTime(2025, 6, 4, 7, 31, 15, 287, DateTimeKind.Utc).AddTicks(7470), true, new Guid("a0000000-0000-0000-0000-000000000003"), "Piece", new DateTime(2025, 6, 4, 7, 31, 15, 287, DateTimeKind.Utc).AddTicks(7470) },
                    { new Guid("b0000000-0000-0000-0000-00000000000c"), "dz", 12.0m, new DateTime(2025, 6, 4, 7, 31, 15, 287, DateTimeKind.Utc).AddTicks(7479), false, new Guid("a0000000-0000-0000-0000-000000000003"), "Dozen", new DateTime(2025, 6, 4, 7, 31, 15, 287, DateTimeKind.Utc).AddTicks(7480) },
                    { new Guid("b0000000-0000-0000-0000-00000000000d"), "pr", 2.0m, new DateTime(2025, 6, 4, 7, 31, 15, 287, DateTimeKind.Utc).AddTicks(7490), false, new Guid("a0000000-0000-0000-0000-000000000003"), "Pair", new DateTime(2025, 6, 4, 7, 31, 15, 287, DateTimeKind.Utc).AddTicks(7490) },
                    { new Guid("b0000000-0000-0000-0000-00000000000e"), "m", 1.0m, new DateTime(2025, 6, 4, 7, 31, 15, 287, DateTimeKind.Utc).AddTicks(7502), true, new Guid("a0000000-0000-0000-0000-000000000004"), "Meter", new DateTime(2025, 6, 4, 7, 31, 15, 287, DateTimeKind.Utc).AddTicks(7502) },
                    { new Guid("b0000000-0000-0000-0000-00000000000f"), "cm", 0.01m, new DateTime(2025, 6, 4, 7, 31, 15, 287, DateTimeKind.Utc).AddTicks(7514), false, new Guid("a0000000-0000-0000-0000-000000000004"), "Centimeter", new DateTime(2025, 6, 4, 7, 31, 15, 287, DateTimeKind.Utc).AddTicks(7514) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BOMItems_ComponentId",
                table: "BOMItems",
                column: "ComponentId");

            migrationBuilder.CreateIndex(
                name: "IX_BOMItems_ParentProductId_ComponentId_ProductId",
                table: "BOMItems",
                columns: new[] { "ParentProductId", "ComponentId", "ProductId" },
                unique: true,
                filter: "[ComponentId] IS NOT NULL AND [ProductId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BOMItems_ProductId",
                table: "BOMItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_BOMItems_UsageUnitId",
                table: "BOMItems",
                column: "UsageUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Components_InventoryUnitId",
                table: "Components",
                column: "InventoryUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Components_OrganizationId_ComponentCode",
                table: "Components",
                columns: new[] { "OrganizationId", "ComponentCode" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Components_PurchaseUnitId",
                table: "Components",
                column: "PurchaseUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Organizations_IndustryTypeId",
                table: "Organizations",
                column: "IndustryTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Organizations_PlanId",
                table: "Organizations",
                column: "PlanId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_OrganizationId_ProductCode",
                table: "Products",
                columns: new[] { "OrganizationId", "ProductCode" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductUnitId",
                table: "Products",
                column: "ProductUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_SaleUnitId",
                table: "Products",
                column: "SaleUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Quests_OrganizationId",
                table: "Quests",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Quests_QuestTypeId",
                table: "Quests",
                column: "QuestTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaims_RoleId",
                table: "RoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "Roles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_StockAdjustments_AdjustmentTypeId",
                table: "StockAdjustments",
                column: "AdjustmentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_StockAdjustments_ComponentId",
                table: "StockAdjustments",
                column: "ComponentId");

            migrationBuilder.CreateIndex(
                name: "IX_StockAdjustments_OrganizationId",
                table: "StockAdjustments",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_StockAdjustments_UnitOfMeasureId",
                table: "StockAdjustments",
                column: "UnitOfMeasureId");

            migrationBuilder.CreateIndex(
                name: "IX_StockAdjustmentTypes_Name",
                table: "StockAdjustmentTypes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UnitConversions_FromUnitId",
                table: "UnitConversions",
                column: "FromUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_UnitConversions_OrganizationId_FromUnitId_ToUnitId",
                table: "UnitConversions",
                columns: new[] { "OrganizationId", "FromUnitId", "ToUnitId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UnitConversions_ToUnitId",
                table: "UnitConversions",
                column: "ToUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_UnitGroups_UnitGroupName",
                table: "UnitGroups",
                column: "UnitGroupName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UnitsOfMeasures_UnitGroupId_Abbreviation",
                table: "UnitsOfMeasures",
                columns: new[] { "UnitGroupId", "Abbreviation" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UnitsOfMeasures_UnitGroupId_IsBaseUnit",
                table: "UnitsOfMeasures",
                columns: new[] { "UnitGroupId", "IsBaseUnit" },
                unique: true,
                filter: "[IsBaseUnit] = 1");

            migrationBuilder.CreateIndex(
                name: "IX_UnitsOfMeasures_UnitGroupId_UnitName",
                table: "UnitsOfMeasures",
                columns: new[] { "UnitGroupId", "UnitName" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_UserId",
                table: "UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_UserId",
                table: "UserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserQuests_QuestId",
                table: "UserQuests",
                column: "QuestId");

            migrationBuilder.CreateIndex(
                name: "IX_UserQuests_UserId",
                table: "UserQuests",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_Users_OrganizationId",
                table: "Users",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Users",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserScores_LevelId",
                table: "UserScores",
                column: "LevelId");

            migrationBuilder.CreateIndex(
                name: "IX_UserScores_UserId",
                table: "UserScores",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BOMItems");

            migrationBuilder.DropTable(
                name: "RoleClaims");

            migrationBuilder.DropTable(
                name: "StockAdjustments");

            migrationBuilder.DropTable(
                name: "UnitConversions");

            migrationBuilder.DropTable(
                name: "UserClaims");

            migrationBuilder.DropTable(
                name: "UserLogins");

            migrationBuilder.DropTable(
                name: "UserQuests");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "UserScores");

            migrationBuilder.DropTable(
                name: "UserTokens");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Components");

            migrationBuilder.DropTable(
                name: "StockAdjustmentTypes");

            migrationBuilder.DropTable(
                name: "Quests");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Levels");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "UnitsOfMeasures");

            migrationBuilder.DropTable(
                name: "QuestTypes");

            migrationBuilder.DropTable(
                name: "Organizations");

            migrationBuilder.DropTable(
                name: "UnitGroups");

            migrationBuilder.DropTable(
                name: "OrganizationIndustryTypes");

            migrationBuilder.DropTable(
                name: "SubscriptionPlans");
        }
    }
}
