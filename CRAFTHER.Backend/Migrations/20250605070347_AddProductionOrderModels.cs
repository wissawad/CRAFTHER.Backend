using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRAFTHER.Backend.Migrations
{
    /// <inheritdoc />
    public partial class AddProductionOrderModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductionOrders",
                columns: table => new
                {
                    ProductionOrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductionOrderCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    OrganizationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuantityToProduce = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    UnitOfMeasureId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CompletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionOrders", x => x.ProductionOrderId);
                    table.ForeignKey(
                        name: "FK_ProductionOrders_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "OrganizationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductionOrders_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductionOrders_UnitsOfMeasures_UnitOfMeasureId",
                        column: x => x.UnitOfMeasureId,
                        principalTable: "UnitsOfMeasures",
                        principalColumn: "UnitId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductionOrderItems",
                columns: table => new
                {
                    ProductionOrderItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductionOrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ComponentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ItemType = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    QuantityUsed = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    UsageUnitId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UnitCostAtProduction = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    QuantityUsedInInventoryUnit = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionOrderItems", x => x.ProductionOrderItemId);
                    table.ForeignKey(
                        name: "FK_ProductionOrderItems_Components_ComponentId",
                        column: x => x.ComponentId,
                        principalTable: "Components",
                        principalColumn: "ComponentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductionOrderItems_ProductionOrders_ProductionOrderId",
                        column: x => x.ProductionOrderId,
                        principalTable: "ProductionOrders",
                        principalColumn: "ProductionOrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductionOrderItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductionOrderItems_UnitsOfMeasures_UsageUnitId",
                        column: x => x.UsageUnitId,
                        principalTable: "UnitsOfMeasures",
                        principalColumn: "UnitId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "ItemCategoryId",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000001"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 7, 3, 46, 207, DateTimeKind.Utc).AddTicks(3723), new DateTime(2025, 6, 5, 7, 3, 46, 207, DateTimeKind.Utc).AddTicks(3723) });

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "ItemCategoryId",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000002"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 7, 3, 46, 207, DateTimeKind.Utc).AddTicks(3727), new DateTime(2025, 6, 5, 7, 3, 46, 207, DateTimeKind.Utc).AddTicks(3728) });

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "ItemCategoryId",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000003"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 7, 3, 46, 207, DateTimeKind.Utc).AddTicks(3731), new DateTime(2025, 6, 5, 7, 3, 46, 207, DateTimeKind.Utc).AddTicks(3731) });

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "ItemCategoryId",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000004"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 7, 3, 46, 207, DateTimeKind.Utc).AddTicks(3734), new DateTime(2025, 6, 5, 7, 3, 46, 207, DateTimeKind.Utc).AddTicks(3735) });

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "ItemCategoryId",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000005"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 7, 3, 46, 207, DateTimeKind.Utc).AddTicks(3737), new DateTime(2025, 6, 5, 7, 3, 46, 207, DateTimeKind.Utc).AddTicks(3738) });

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "ItemCategoryId",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000006"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 7, 3, 46, 207, DateTimeKind.Utc).AddTicks(3741), new DateTime(2025, 6, 5, 7, 3, 46, 207, DateTimeKind.Utc).AddTicks(3742) });

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "ItemCategoryId",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000007"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 7, 3, 46, 207, DateTimeKind.Utc).AddTicks(3744), new DateTime(2025, 6, 5, 7, 3, 46, 207, DateTimeKind.Utc).AddTicks(3745) });

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "ItemCategoryId",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000008"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 7, 3, 46, 207, DateTimeKind.Utc).AddTicks(3752), new DateTime(2025, 6, 5, 7, 3, 46, 207, DateTimeKind.Utc).AddTicks(3753) });

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "ItemCategoryId",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000009"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 7, 3, 46, 207, DateTimeKind.Utc).AddTicks(3755), new DateTime(2025, 6, 5, 7, 3, 46, 207, DateTimeKind.Utc).AddTicks(3756) });

            migrationBuilder.UpdateData(
                table: "Levels",
                keyColumn: "LevelId",
                keyValue: new Guid("a0b1c2d3-e4f5-a6b7-c8d9-e0f1a2b3c4d5"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 7, 3, 46, 207, DateTimeKind.Utc).AddTicks(3857), new DateTime(2025, 6, 5, 7, 3, 46, 207, DateTimeKind.Utc).AddTicks(3857) });

            migrationBuilder.UpdateData(
                table: "Levels",
                keyColumn: "LevelId",
                keyValue: new Guid("b1c2d3e4-f5a6-b7c8-d9e0-f1a2b3c4d5e6"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 7, 3, 46, 207, DateTimeKind.Utc).AddTicks(3860), new DateTime(2025, 6, 5, 7, 3, 46, 207, DateTimeKind.Utc).AddTicks(3860) });

            migrationBuilder.UpdateData(
                table: "Levels",
                keyColumn: "LevelId",
                keyValue: new Guid("c2d3e4f5-a6b7-c8d9-e0f1-a2b3c4d5e6f7"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 7, 3, 46, 207, DateTimeKind.Utc).AddTicks(3863), new DateTime(2025, 6, 5, 7, 3, 46, 207, DateTimeKind.Utc).AddTicks(3863) });

            migrationBuilder.UpdateData(
                table: "Levels",
                keyColumn: "LevelId",
                keyValue: new Guid("e1f2a3b4-c5d6-e7f8-a9b0-c1d2e3f4a5b6"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 7, 3, 46, 207, DateTimeKind.Utc).AddTicks(3847), new DateTime(2025, 6, 5, 7, 3, 46, 207, DateTimeKind.Utc).AddTicks(3847) });

            migrationBuilder.UpdateData(
                table: "Levels",
                keyColumn: "LevelId",
                keyValue: new Guid("f2a3b4c5-d6e7-f8a9-b0c1-d2e3f4a5b6c7"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 7, 3, 46, 207, DateTimeKind.Utc).AddTicks(3851), new DateTime(2025, 6, 5, 7, 3, 46, 207, DateTimeKind.Utc).AddTicks(3852) });

            migrationBuilder.UpdateData(
                table: "OrganizationIndustryTypes",
                keyColumn: "IndustryTypeId",
                keyValue: new Guid("a1b2c3d4-e5f6-7890-1234-567890abcdef"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 7, 3, 46, 207, DateTimeKind.Utc).AddTicks(2893), new DateTime(2025, 6, 5, 7, 3, 46, 207, DateTimeKind.Utc).AddTicks(2896) });

            migrationBuilder.UpdateData(
                table: "OrganizationIndustryTypes",
                keyColumn: "IndustryTypeId",
                keyValue: new Guid("b2c3d4e5-f6a1-2345-6789-0abcdef12345"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 7, 3, 46, 207, DateTimeKind.Utc).AddTicks(2899), new DateTime(2025, 6, 5, 7, 3, 46, 207, DateTimeKind.Utc).AddTicks(2900) });

            migrationBuilder.UpdateData(
                table: "OrganizationIndustryTypes",
                keyColumn: "IndustryTypeId",
                keyValue: new Guid("c3d4e5f6-a1b2-3456-7890-cdef12345678"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 7, 3, 46, 207, DateTimeKind.Utc).AddTicks(2901), new DateTime(2025, 6, 5, 7, 3, 46, 207, DateTimeKind.Utc).AddTicks(2902) });

            migrationBuilder.UpdateData(
                table: "OrganizationIndustryTypes",
                keyColumn: "IndustryTypeId",
                keyValue: new Guid("d4e5f6a1-b2c3-4567-890a-bcdef1234567"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 7, 3, 46, 207, DateTimeKind.Utc).AddTicks(2903), new DateTime(2025, 6, 5, 7, 3, 46, 207, DateTimeKind.Utc).AddTicks(2904) });

            migrationBuilder.UpdateData(
                table: "QuestTypes",
                keyColumn: "QuestTypeId",
                keyValue: new Guid("a1b2c3d4-e5f6-7890-abcd-ef0123456789"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 7, 3, 46, 207, DateTimeKind.Utc).AddTicks(3813), new DateTime(2025, 6, 5, 7, 3, 46, 207, DateTimeKind.Utc).AddTicks(3813) });

            migrationBuilder.UpdateData(
                table: "QuestTypes",
                keyColumn: "QuestTypeId",
                keyValue: new Guid("b2c3d4e5-f6a1-2345-cdef-0123456789ab"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 7, 3, 46, 207, DateTimeKind.Utc).AddTicks(3817), new DateTime(2025, 6, 5, 7, 3, 46, 207, DateTimeKind.Utc).AddTicks(3817) });

            migrationBuilder.UpdateData(
                table: "QuestTypes",
                keyColumn: "QuestTypeId",
                keyValue: new Guid("c3d4e5f6-a1b2-3456-7890-abcdef012345"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 7, 3, 46, 207, DateTimeKind.Utc).AddTicks(3819), new DateTime(2025, 6, 5, 7, 3, 46, 207, DateTimeKind.Utc).AddTicks(3819) });

            migrationBuilder.UpdateData(
                table: "QuestTypes",
                keyColumn: "QuestTypeId",
                keyValue: new Guid("d4e5f6a1-b2c3-4567-890a-bcdef0123456"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 7, 3, 46, 207, DateTimeKind.Utc).AddTicks(3821), new DateTime(2025, 6, 5, 7, 3, 46, 207, DateTimeKind.Utc).AddTicks(3821) });

            migrationBuilder.UpdateData(
                table: "StockAdjustmentTypes",
                keyColumn: "AdjustmentTypeId",
                keyValue: new Guid("01a1b2c3-d4e5-6f78-9012-3456789abc01"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 7, 3, 46, 196, DateTimeKind.Utc).AddTicks(6863), new DateTime(2025, 6, 5, 7, 3, 46, 196, DateTimeKind.Utc).AddTicks(6863) });

            migrationBuilder.UpdateData(
                table: "StockAdjustmentTypes",
                keyColumn: "AdjustmentTypeId",
                keyValue: new Guid("02a1b2c3-d4e5-6f78-9012-3456789abc02"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 7, 3, 46, 196, DateTimeKind.Utc).AddTicks(6869), new DateTime(2025, 6, 5, 7, 3, 46, 196, DateTimeKind.Utc).AddTicks(6869) });

            migrationBuilder.UpdateData(
                table: "StockAdjustmentTypes",
                keyColumn: "AdjustmentTypeId",
                keyValue: new Guid("03a1b2c3-d4e5-6f78-9012-3456789abc03"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 7, 3, 46, 196, DateTimeKind.Utc).AddTicks(6872), new DateTime(2025, 6, 5, 7, 3, 46, 196, DateTimeKind.Utc).AddTicks(6873) });

            migrationBuilder.UpdateData(
                table: "StockAdjustmentTypes",
                keyColumn: "AdjustmentTypeId",
                keyValue: new Guid("04a1b2c3-d4e5-6f78-9012-3456789abc04"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 7, 3, 46, 196, DateTimeKind.Utc).AddTicks(6875), new DateTime(2025, 6, 5, 7, 3, 46, 196, DateTimeKind.Utc).AddTicks(6876) });

            migrationBuilder.UpdateData(
                table: "StockAdjustmentTypes",
                keyColumn: "AdjustmentTypeId",
                keyValue: new Guid("05a1b2c3-d4e5-6f78-9012-3456789abc05"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 7, 3, 46, 196, DateTimeKind.Utc).AddTicks(6888), new DateTime(2025, 6, 5, 7, 3, 46, 196, DateTimeKind.Utc).AddTicks(6889) });

            migrationBuilder.UpdateData(
                table: "StockAdjustmentTypes",
                keyColumn: "AdjustmentTypeId",
                keyValue: new Guid("06a1b2c3-d4e5-6f78-9012-3456789abc06"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 7, 3, 46, 196, DateTimeKind.Utc).AddTicks(6892), new DateTime(2025, 6, 5, 7, 3, 46, 196, DateTimeKind.Utc).AddTicks(6892) });

            migrationBuilder.UpdateData(
                table: "SubscriptionPlans",
                keyColumn: "PlanId",
                keyValue: new Guid("11223344-5566-7788-99aa-bbccddeeff00"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 7, 3, 46, 207, DateTimeKind.Utc).AddTicks(2989), new DateTime(2025, 6, 5, 7, 3, 46, 207, DateTimeKind.Utc).AddTicks(2989) });

            migrationBuilder.UpdateData(
                table: "SubscriptionPlans",
                keyColumn: "PlanId",
                keyValue: new Guid("aabbccdd-eeff-1122-3344-5566778899aa"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 7, 3, 46, 207, DateTimeKind.Utc).AddTicks(3008), new DateTime(2025, 6, 5, 7, 3, 46, 207, DateTimeKind.Utc).AddTicks(3009) });

            migrationBuilder.UpdateData(
                table: "SubscriptionPlans",
                keyColumn: "PlanId",
                keyValue: new Guid("ccddeeff-aabb-3344-5566-778899aabbcc"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 7, 3, 46, 207, DateTimeKind.Utc).AddTicks(3033), new DateTime(2025, 6, 5, 7, 3, 46, 207, DateTimeKind.Utc).AddTicks(3034) });

            migrationBuilder.UpdateData(
                table: "UnitGroups",
                keyColumn: "UnitGroupId",
                keyValue: new Guid("a0000000-0000-0000-0000-000000000001"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 7, 3, 46, 192, DateTimeKind.Utc).AddTicks(7930), new DateTime(2025, 6, 5, 7, 3, 46, 192, DateTimeKind.Utc).AddTicks(7932) });

            migrationBuilder.UpdateData(
                table: "UnitGroups",
                keyColumn: "UnitGroupId",
                keyValue: new Guid("a0000000-0000-0000-0000-000000000002"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 7, 3, 46, 192, DateTimeKind.Utc).AddTicks(7936), new DateTime(2025, 6, 5, 7, 3, 46, 192, DateTimeKind.Utc).AddTicks(7936) });

            migrationBuilder.UpdateData(
                table: "UnitGroups",
                keyColumn: "UnitGroupId",
                keyValue: new Guid("a0000000-0000-0000-0000-000000000003"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 7, 3, 46, 192, DateTimeKind.Utc).AddTicks(7939), new DateTime(2025, 6, 5, 7, 3, 46, 192, DateTimeKind.Utc).AddTicks(7940) });

            migrationBuilder.UpdateData(
                table: "UnitGroups",
                keyColumn: "UnitGroupId",
                keyValue: new Guid("a0000000-0000-0000-0000-000000000004"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 7, 3, 46, 192, DateTimeKind.Utc).AddTicks(7942), new DateTime(2025, 6, 5, 7, 3, 46, 192, DateTimeKind.Utc).AddTicks(7943) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasures",
                keyColumn: "UnitId",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000001"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 7, 3, 46, 193, DateTimeKind.Utc).AddTicks(5693), new DateTime(2025, 6, 5, 7, 3, 46, 193, DateTimeKind.Utc).AddTicks(5694) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasures",
                keyColumn: "UnitId",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000002"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 7, 3, 46, 193, DateTimeKind.Utc).AddTicks(5699), new DateTime(2025, 6, 5, 7, 3, 46, 193, DateTimeKind.Utc).AddTicks(5700) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasures",
                keyColumn: "UnitId",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000003"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 7, 3, 46, 193, DateTimeKind.Utc).AddTicks(5704), new DateTime(2025, 6, 5, 7, 3, 46, 193, DateTimeKind.Utc).AddTicks(5704) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasures",
                keyColumn: "UnitId",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000004"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 7, 3, 46, 193, DateTimeKind.Utc).AddTicks(5730), new DateTime(2025, 6, 5, 7, 3, 46, 193, DateTimeKind.Utc).AddTicks(5730) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasures",
                keyColumn: "UnitId",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000005"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 7, 3, 46, 193, DateTimeKind.Utc).AddTicks(5735), new DateTime(2025, 6, 5, 7, 3, 46, 193, DateTimeKind.Utc).AddTicks(5735) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasures",
                keyColumn: "UnitId",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000006"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 7, 3, 46, 193, DateTimeKind.Utc).AddTicks(5739), new DateTime(2025, 6, 5, 7, 3, 46, 193, DateTimeKind.Utc).AddTicks(5740) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasures",
                keyColumn: "UnitId",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000007"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 7, 3, 46, 193, DateTimeKind.Utc).AddTicks(5744), new DateTime(2025, 6, 5, 7, 3, 46, 193, DateTimeKind.Utc).AddTicks(5744) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasures",
                keyColumn: "UnitId",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000008"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 7, 3, 46, 193, DateTimeKind.Utc).AddTicks(5748), new DateTime(2025, 6, 5, 7, 3, 46, 193, DateTimeKind.Utc).AddTicks(5749) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasures",
                keyColumn: "UnitId",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000009"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 7, 3, 46, 193, DateTimeKind.Utc).AddTicks(5753), new DateTime(2025, 6, 5, 7, 3, 46, 193, DateTimeKind.Utc).AddTicks(5753) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasures",
                keyColumn: "UnitId",
                keyValue: new Guid("b0000000-0000-0000-0000-00000000000a"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 7, 3, 46, 193, DateTimeKind.Utc).AddTicks(5757), new DateTime(2025, 6, 5, 7, 3, 46, 193, DateTimeKind.Utc).AddTicks(5757) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasures",
                keyColumn: "UnitId",
                keyValue: new Guid("b0000000-0000-0000-0000-00000000000b"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 7, 3, 46, 193, DateTimeKind.Utc).AddTicks(5761), new DateTime(2025, 6, 5, 7, 3, 46, 193, DateTimeKind.Utc).AddTicks(5762) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasures",
                keyColumn: "UnitId",
                keyValue: new Guid("b0000000-0000-0000-0000-00000000000c"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 7, 3, 46, 193, DateTimeKind.Utc).AddTicks(5769), new DateTime(2025, 6, 5, 7, 3, 46, 193, DateTimeKind.Utc).AddTicks(5769) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasures",
                keyColumn: "UnitId",
                keyValue: new Guid("b0000000-0000-0000-0000-00000000000d"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 7, 3, 46, 193, DateTimeKind.Utc).AddTicks(5784), new DateTime(2025, 6, 5, 7, 3, 46, 193, DateTimeKind.Utc).AddTicks(5784) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasures",
                keyColumn: "UnitId",
                keyValue: new Guid("b0000000-0000-0000-0000-00000000000e"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 7, 3, 46, 193, DateTimeKind.Utc).AddTicks(5788), new DateTime(2025, 6, 5, 7, 3, 46, 193, DateTimeKind.Utc).AddTicks(5788) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasures",
                keyColumn: "UnitId",
                keyValue: new Guid("b0000000-0000-0000-0000-00000000000f"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 7, 3, 46, 193, DateTimeKind.Utc).AddTicks(5796), new DateTime(2025, 6, 5, 7, 3, 46, 193, DateTimeKind.Utc).AddTicks(5797) });

            migrationBuilder.CreateIndex(
                name: "IX_ProductionOrderItems_ComponentId",
                table: "ProductionOrderItems",
                column: "ComponentId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductionOrderItems_ProductId",
                table: "ProductionOrderItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductionOrderItems_ProductionOrderId_ComponentId_ProductId",
                table: "ProductionOrderItems",
                columns: new[] { "ProductionOrderId", "ComponentId", "ProductId" },
                unique: true,
                filter: "[ComponentId] IS NOT NULL AND [ProductId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ProductionOrderItems_UsageUnitId",
                table: "ProductionOrderItems",
                column: "UsageUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductionOrders_OrganizationId_ProductionOrderCode",
                table: "ProductionOrders",
                columns: new[] { "OrganizationId", "ProductionOrderCode" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductionOrders_ProductId",
                table: "ProductionOrders",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductionOrders_UnitOfMeasureId",
                table: "ProductionOrders",
                column: "UnitOfMeasureId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductionOrderItems");

            migrationBuilder.DropTable(
                name: "ProductionOrders");

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "ItemCategoryId",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000001"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 5, 1, 5, 999, DateTimeKind.Utc).AddTicks(3301), new DateTime(2025, 6, 5, 5, 1, 5, 999, DateTimeKind.Utc).AddTicks(3302) });

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "ItemCategoryId",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000002"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 5, 1, 5, 999, DateTimeKind.Utc).AddTicks(3305), new DateTime(2025, 6, 5, 5, 1, 5, 999, DateTimeKind.Utc).AddTicks(3306) });

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "ItemCategoryId",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000003"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 5, 1, 5, 999, DateTimeKind.Utc).AddTicks(3309), new DateTime(2025, 6, 5, 5, 1, 5, 999, DateTimeKind.Utc).AddTicks(3309) });

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "ItemCategoryId",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000004"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 5, 1, 5, 999, DateTimeKind.Utc).AddTicks(3313), new DateTime(2025, 6, 5, 5, 1, 5, 999, DateTimeKind.Utc).AddTicks(3313) });

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "ItemCategoryId",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000005"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 5, 1, 5, 999, DateTimeKind.Utc).AddTicks(3322), new DateTime(2025, 6, 5, 5, 1, 5, 999, DateTimeKind.Utc).AddTicks(3322) });

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "ItemCategoryId",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000006"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 5, 1, 5, 999, DateTimeKind.Utc).AddTicks(3325), new DateTime(2025, 6, 5, 5, 1, 5, 999, DateTimeKind.Utc).AddTicks(3325) });

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "ItemCategoryId",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000007"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 5, 1, 5, 999, DateTimeKind.Utc).AddTicks(3328), new DateTime(2025, 6, 5, 5, 1, 5, 999, DateTimeKind.Utc).AddTicks(3328) });

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "ItemCategoryId",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000008"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 5, 1, 5, 999, DateTimeKind.Utc).AddTicks(3331), new DateTime(2025, 6, 5, 5, 1, 5, 999, DateTimeKind.Utc).AddTicks(3331) });

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "ItemCategoryId",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000009"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 5, 1, 5, 999, DateTimeKind.Utc).AddTicks(3334), new DateTime(2025, 6, 5, 5, 1, 5, 999, DateTimeKind.Utc).AddTicks(3335) });

            migrationBuilder.UpdateData(
                table: "Levels",
                keyColumn: "LevelId",
                keyValue: new Guid("a0b1c2d3-e4f5-a6b7-c8d9-e0f1a2b3c4d5"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 5, 1, 5, 999, DateTimeKind.Utc).AddTicks(3472), new DateTime(2025, 6, 5, 5, 1, 5, 999, DateTimeKind.Utc).AddTicks(3472) });

            migrationBuilder.UpdateData(
                table: "Levels",
                keyColumn: "LevelId",
                keyValue: new Guid("b1c2d3e4-f5a6-b7c8-d9e0-f1a2b3c4d5e6"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 5, 1, 5, 999, DateTimeKind.Utc).AddTicks(3475), new DateTime(2025, 6, 5, 5, 1, 5, 999, DateTimeKind.Utc).AddTicks(3475) });

            migrationBuilder.UpdateData(
                table: "Levels",
                keyColumn: "LevelId",
                keyValue: new Guid("c2d3e4f5-a6b7-c8d9-e0f1-a2b3c4d5e6f7"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 5, 1, 5, 999, DateTimeKind.Utc).AddTicks(3477), new DateTime(2025, 6, 5, 5, 1, 5, 999, DateTimeKind.Utc).AddTicks(3477) });

            migrationBuilder.UpdateData(
                table: "Levels",
                keyColumn: "LevelId",
                keyValue: new Guid("e1f2a3b4-c5d6-e7f8-a9b0-c1d2e3f4a5b6"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 5, 1, 5, 999, DateTimeKind.Utc).AddTicks(3465), new DateTime(2025, 6, 5, 5, 1, 5, 999, DateTimeKind.Utc).AddTicks(3465) });

            migrationBuilder.UpdateData(
                table: "Levels",
                keyColumn: "LevelId",
                keyValue: new Guid("f2a3b4c5-d6e7-f8a9-b0c1-d2e3f4a5b6c7"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 5, 1, 5, 999, DateTimeKind.Utc).AddTicks(3469), new DateTime(2025, 6, 5, 5, 1, 5, 999, DateTimeKind.Utc).AddTicks(3469) });

            migrationBuilder.UpdateData(
                table: "OrganizationIndustryTypes",
                keyColumn: "IndustryTypeId",
                keyValue: new Guid("a1b2c3d4-e5f6-7890-1234-567890abcdef"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 5, 1, 5, 999, DateTimeKind.Utc).AddTicks(2569), new DateTime(2025, 6, 5, 5, 1, 5, 999, DateTimeKind.Utc).AddTicks(2571) });

            migrationBuilder.UpdateData(
                table: "OrganizationIndustryTypes",
                keyColumn: "IndustryTypeId",
                keyValue: new Guid("b2c3d4e5-f6a1-2345-6789-0abcdef12345"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 5, 1, 5, 999, DateTimeKind.Utc).AddTicks(2576), new DateTime(2025, 6, 5, 5, 1, 5, 999, DateTimeKind.Utc).AddTicks(2576) });

            migrationBuilder.UpdateData(
                table: "OrganizationIndustryTypes",
                keyColumn: "IndustryTypeId",
                keyValue: new Guid("c3d4e5f6-a1b2-3456-7890-cdef12345678"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 5, 1, 5, 999, DateTimeKind.Utc).AddTicks(2578), new DateTime(2025, 6, 5, 5, 1, 5, 999, DateTimeKind.Utc).AddTicks(2578) });

            migrationBuilder.UpdateData(
                table: "OrganizationIndustryTypes",
                keyColumn: "IndustryTypeId",
                keyValue: new Guid("d4e5f6a1-b2c3-4567-890a-bcdef1234567"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 5, 1, 5, 999, DateTimeKind.Utc).AddTicks(2590), new DateTime(2025, 6, 5, 5, 1, 5, 999, DateTimeKind.Utc).AddTicks(2590) });

            migrationBuilder.UpdateData(
                table: "QuestTypes",
                keyColumn: "QuestTypeId",
                keyValue: new Guid("a1b2c3d4-e5f6-7890-abcd-ef0123456789"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 5, 1, 5, 999, DateTimeKind.Utc).AddTicks(3430), new DateTime(2025, 6, 5, 5, 1, 5, 999, DateTimeKind.Utc).AddTicks(3430) });

            migrationBuilder.UpdateData(
                table: "QuestTypes",
                keyColumn: "QuestTypeId",
                keyValue: new Guid("b2c3d4e5-f6a1-2345-cdef-0123456789ab"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 5, 1, 5, 999, DateTimeKind.Utc).AddTicks(3434), new DateTime(2025, 6, 5, 5, 1, 5, 999, DateTimeKind.Utc).AddTicks(3434) });

            migrationBuilder.UpdateData(
                table: "QuestTypes",
                keyColumn: "QuestTypeId",
                keyValue: new Guid("c3d4e5f6-a1b2-3456-7890-abcdef012345"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 5, 1, 5, 999, DateTimeKind.Utc).AddTicks(3435), new DateTime(2025, 6, 5, 5, 1, 5, 999, DateTimeKind.Utc).AddTicks(3436) });

            migrationBuilder.UpdateData(
                table: "QuestTypes",
                keyColumn: "QuestTypeId",
                keyValue: new Guid("d4e5f6a1-b2c3-4567-890a-bcdef0123456"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 5, 1, 5, 999, DateTimeKind.Utc).AddTicks(3441), new DateTime(2025, 6, 5, 5, 1, 5, 999, DateTimeKind.Utc).AddTicks(3441) });

            migrationBuilder.UpdateData(
                table: "StockAdjustmentTypes",
                keyColumn: "AdjustmentTypeId",
                keyValue: new Guid("01a1b2c3-d4e5-6f78-9012-3456789abc01"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 5, 1, 5, 993, DateTimeKind.Utc).AddTicks(3094), new DateTime(2025, 6, 5, 5, 1, 5, 993, DateTimeKind.Utc).AddTicks(3095) });

            migrationBuilder.UpdateData(
                table: "StockAdjustmentTypes",
                keyColumn: "AdjustmentTypeId",
                keyValue: new Guid("02a1b2c3-d4e5-6f78-9012-3456789abc02"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 5, 1, 5, 993, DateTimeKind.Utc).AddTicks(3098), new DateTime(2025, 6, 5, 5, 1, 5, 993, DateTimeKind.Utc).AddTicks(3099) });

            migrationBuilder.UpdateData(
                table: "StockAdjustmentTypes",
                keyColumn: "AdjustmentTypeId",
                keyValue: new Guid("03a1b2c3-d4e5-6f78-9012-3456789abc03"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 5, 1, 5, 993, DateTimeKind.Utc).AddTicks(3102), new DateTime(2025, 6, 5, 5, 1, 5, 993, DateTimeKind.Utc).AddTicks(3103) });

            migrationBuilder.UpdateData(
                table: "StockAdjustmentTypes",
                keyColumn: "AdjustmentTypeId",
                keyValue: new Guid("04a1b2c3-d4e5-6f78-9012-3456789abc04"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 5, 1, 5, 993, DateTimeKind.Utc).AddTicks(3168), new DateTime(2025, 6, 5, 5, 1, 5, 993, DateTimeKind.Utc).AddTicks(3169) });

            migrationBuilder.UpdateData(
                table: "StockAdjustmentTypes",
                keyColumn: "AdjustmentTypeId",
                keyValue: new Guid("05a1b2c3-d4e5-6f78-9012-3456789abc05"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 5, 1, 5, 993, DateTimeKind.Utc).AddTicks(3181), new DateTime(2025, 6, 5, 5, 1, 5, 993, DateTimeKind.Utc).AddTicks(3181) });

            migrationBuilder.UpdateData(
                table: "StockAdjustmentTypes",
                keyColumn: "AdjustmentTypeId",
                keyValue: new Guid("06a1b2c3-d4e5-6f78-9012-3456789abc06"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 5, 1, 5, 993, DateTimeKind.Utc).AddTicks(3184), new DateTime(2025, 6, 5, 5, 1, 5, 993, DateTimeKind.Utc).AddTicks(3185) });

            migrationBuilder.UpdateData(
                table: "SubscriptionPlans",
                keyColumn: "PlanId",
                keyValue: new Guid("11223344-5566-7788-99aa-bbccddeeff00"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 5, 1, 5, 999, DateTimeKind.Utc).AddTicks(2685), new DateTime(2025, 6, 5, 5, 1, 5, 999, DateTimeKind.Utc).AddTicks(2685) });

            migrationBuilder.UpdateData(
                table: "SubscriptionPlans",
                keyColumn: "PlanId",
                keyValue: new Guid("aabbccdd-eeff-1122-3344-5566778899aa"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 5, 1, 5, 999, DateTimeKind.Utc).AddTicks(2695), new DateTime(2025, 6, 5, 5, 1, 5, 999, DateTimeKind.Utc).AddTicks(2696) });

            migrationBuilder.UpdateData(
                table: "SubscriptionPlans",
                keyColumn: "PlanId",
                keyValue: new Guid("ccddeeff-aabb-3344-5566-778899aabbcc"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 5, 1, 5, 999, DateTimeKind.Utc).AddTicks(2700), new DateTime(2025, 6, 5, 5, 1, 5, 999, DateTimeKind.Utc).AddTicks(2700) });

            migrationBuilder.UpdateData(
                table: "UnitGroups",
                keyColumn: "UnitGroupId",
                keyValue: new Guid("a0000000-0000-0000-0000-000000000001"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 5, 1, 5, 990, DateTimeKind.Utc).AddTicks(9974), new DateTime(2025, 6, 5, 5, 1, 5, 990, DateTimeKind.Utc).AddTicks(9974) });

            migrationBuilder.UpdateData(
                table: "UnitGroups",
                keyColumn: "UnitGroupId",
                keyValue: new Guid("a0000000-0000-0000-0000-000000000002"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 5, 1, 5, 990, DateTimeKind.Utc).AddTicks(9979), new DateTime(2025, 6, 5, 5, 1, 5, 990, DateTimeKind.Utc).AddTicks(9979) });

            migrationBuilder.UpdateData(
                table: "UnitGroups",
                keyColumn: "UnitGroupId",
                keyValue: new Guid("a0000000-0000-0000-0000-000000000003"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 5, 1, 5, 990, DateTimeKind.Utc).AddTicks(9982), new DateTime(2025, 6, 5, 5, 1, 5, 990, DateTimeKind.Utc).AddTicks(9983) });

            migrationBuilder.UpdateData(
                table: "UnitGroups",
                keyColumn: "UnitGroupId",
                keyValue: new Guid("a0000000-0000-0000-0000-000000000004"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 5, 1, 5, 990, DateTimeKind.Utc).AddTicks(9985), new DateTime(2025, 6, 5, 5, 1, 5, 990, DateTimeKind.Utc).AddTicks(9986) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasures",
                keyColumn: "UnitId",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000001"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 5, 1, 5, 991, DateTimeKind.Utc).AddTicks(5475), new DateTime(2025, 6, 5, 5, 1, 5, 991, DateTimeKind.Utc).AddTicks(5476) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasures",
                keyColumn: "UnitId",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000002"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 5, 1, 5, 991, DateTimeKind.Utc).AddTicks(5481), new DateTime(2025, 6, 5, 5, 1, 5, 991, DateTimeKind.Utc).AddTicks(5482) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasures",
                keyColumn: "UnitId",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000003"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 5, 1, 5, 991, DateTimeKind.Utc).AddTicks(5486), new DateTime(2025, 6, 5, 5, 1, 5, 991, DateTimeKind.Utc).AddTicks(5487) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasures",
                keyColumn: "UnitId",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000004"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 5, 1, 5, 991, DateTimeKind.Utc).AddTicks(5501), new DateTime(2025, 6, 5, 5, 1, 5, 991, DateTimeKind.Utc).AddTicks(5502) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasures",
                keyColumn: "UnitId",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000005"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 5, 1, 5, 991, DateTimeKind.Utc).AddTicks(5506), new DateTime(2025, 6, 5, 5, 1, 5, 991, DateTimeKind.Utc).AddTicks(5506) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasures",
                keyColumn: "UnitId",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000006"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 5, 1, 5, 991, DateTimeKind.Utc).AddTicks(5511), new DateTime(2025, 6, 5, 5, 1, 5, 991, DateTimeKind.Utc).AddTicks(5511) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasures",
                keyColumn: "UnitId",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000007"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 5, 1, 5, 991, DateTimeKind.Utc).AddTicks(5516), new DateTime(2025, 6, 5, 5, 1, 5, 991, DateTimeKind.Utc).AddTicks(5516) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasures",
                keyColumn: "UnitId",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000008"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 5, 1, 5, 991, DateTimeKind.Utc).AddTicks(5520), new DateTime(2025, 6, 5, 5, 1, 5, 991, DateTimeKind.Utc).AddTicks(5521) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasures",
                keyColumn: "UnitId",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000009"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 5, 1, 5, 991, DateTimeKind.Utc).AddTicks(5524), new DateTime(2025, 6, 5, 5, 1, 5, 991, DateTimeKind.Utc).AddTicks(5525) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasures",
                keyColumn: "UnitId",
                keyValue: new Guid("b0000000-0000-0000-0000-00000000000a"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 5, 1, 5, 991, DateTimeKind.Utc).AddTicks(5529), new DateTime(2025, 6, 5, 5, 1, 5, 991, DateTimeKind.Utc).AddTicks(5530) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasures",
                keyColumn: "UnitId",
                keyValue: new Guid("b0000000-0000-0000-0000-00000000000b"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 5, 1, 5, 991, DateTimeKind.Utc).AddTicks(5536), new DateTime(2025, 6, 5, 5, 1, 5, 991, DateTimeKind.Utc).AddTicks(5536) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasures",
                keyColumn: "UnitId",
                keyValue: new Guid("b0000000-0000-0000-0000-00000000000c"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 5, 1, 5, 991, DateTimeKind.Utc).AddTicks(5543), new DateTime(2025, 6, 5, 5, 1, 5, 991, DateTimeKind.Utc).AddTicks(5543) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasures",
                keyColumn: "UnitId",
                keyValue: new Guid("b0000000-0000-0000-0000-00000000000d"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 5, 1, 5, 991, DateTimeKind.Utc).AddTicks(5548), new DateTime(2025, 6, 5, 5, 1, 5, 991, DateTimeKind.Utc).AddTicks(5548) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasures",
                keyColumn: "UnitId",
                keyValue: new Guid("b0000000-0000-0000-0000-00000000000e"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 5, 1, 5, 991, DateTimeKind.Utc).AddTicks(5552), new DateTime(2025, 6, 5, 5, 1, 5, 991, DateTimeKind.Utc).AddTicks(5552) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasures",
                keyColumn: "UnitId",
                keyValue: new Guid("b0000000-0000-0000-0000-00000000000f"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 5, 1, 5, 991, DateTimeKind.Utc).AddTicks(5556), new DateTime(2025, 6, 5, 5, 1, 5, 991, DateTimeKind.Utc).AddTicks(5556) });
        }
    }
}
