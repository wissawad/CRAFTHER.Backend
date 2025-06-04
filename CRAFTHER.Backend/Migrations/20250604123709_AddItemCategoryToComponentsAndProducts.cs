using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CRAFTHER.Backend.Migrations
{
    /// <inheritdoc />
    public partial class AddItemCategoryToComponentsAndProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ItemCategoryId",
                table: "Products",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ItemCategoryId",
                table: "Components",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "ItemCategories",
                columns: table => new
                {
                    ItemCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemCategories", x => x.ItemCategoryId);
                });

            migrationBuilder.InsertData(
                table: "ItemCategories",
                columns: new[] { "ItemCategoryId", "CategoryName", "CreatedAt", "Description", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("c0000000-0000-0000-0000-000000000001"), "Food Ingredient", new DateTime(2025, 6, 4, 12, 37, 8, 24, DateTimeKind.Utc).AddTicks(8316), "Raw materials used in food and beverage production.", new DateTime(2025, 6, 4, 12, 37, 8, 24, DateTimeKind.Utc).AddTicks(8318) },
                    { new Guid("c0000000-0000-0000-0000-000000000002"), "Beverage Ingredient", new DateTime(2025, 6, 4, 12, 37, 8, 24, DateTimeKind.Utc).AddTicks(8333), "Raw materials used in beverage production.", new DateTime(2025, 6, 4, 12, 37, 8, 24, DateTimeKind.Utc).AddTicks(8335) },
                    { new Guid("c0000000-0000-0000-0000-000000000003"), "Finished Food Product", new DateTime(2025, 6, 4, 12, 37, 8, 24, DateTimeKind.Utc).AddTicks(8340), "Ready-to-sell food items.", new DateTime(2025, 6, 4, 12, 37, 8, 24, DateTimeKind.Utc).AddTicks(8340) },
                    { new Guid("c0000000-0000-0000-0000-000000000004"), "Finished Beverage Product", new DateTime(2025, 6, 4, 12, 37, 8, 24, DateTimeKind.Utc).AddTicks(8344), "Ready-to-sell beverage items.", new DateTime(2025, 6, 4, 12, 37, 8, 24, DateTimeKind.Utc).AddTicks(8345) },
                    { new Guid("c0000000-0000-0000-0000-000000000005"), "Fabric", new DateTime(2025, 6, 4, 12, 37, 8, 24, DateTimeKind.Utc).AddTicks(8348), "Textile materials for garment production.", new DateTime(2025, 6, 4, 12, 37, 8, 24, DateTimeKind.Utc).AddTicks(8349) },
                    { new Guid("c0000000-0000-0000-0000-000000000006"), "Accessory (Clothing)", new DateTime(2025, 6, 4, 12, 37, 8, 24, DateTimeKind.Utc).AddTicks(8353), "Buttons, zippers, threads, etc. for clothing.", new DateTime(2025, 6, 4, 12, 37, 8, 24, DateTimeKind.Utc).AddTicks(8353) },
                    { new Guid("c0000000-0000-0000-0000-000000000007"), "Finished Garment", new DateTime(2025, 6, 4, 12, 37, 8, 24, DateTimeKind.Utc).AddTicks(8357), "Ready-to-sell clothing items.", new DateTime(2025, 6, 4, 12, 37, 8, 24, DateTimeKind.Utc).AddTicks(8357) },
                    { new Guid("c0000000-0000-0000-0000-000000000008"), "Packaging Material", new DateTime(2025, 6, 4, 12, 37, 8, 24, DateTimeKind.Utc).AddTicks(8361), "Materials used for product packaging.", new DateTime(2025, 6, 4, 12, 37, 8, 24, DateTimeKind.Utc).AddTicks(8361) },
                    { new Guid("c0000000-0000-0000-0000-000000000009"), "Other", new DateTime(2025, 6, 4, 12, 37, 8, 24, DateTimeKind.Utc).AddTicks(8366), "Miscellaneous items not fitting other categories.", new DateTime(2025, 6, 4, 12, 37, 8, 24, DateTimeKind.Utc).AddTicks(8366) }
                });

            migrationBuilder.UpdateData(
                table: "Levels",
                keyColumn: "LevelId",
                keyValue: new Guid("a0b1c2d3-e4f5-a6b7-c8d9-e0f1a2b3c4d5"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 4, 12, 37, 8, 24, DateTimeKind.Utc).AddTicks(8542), new DateTime(2025, 6, 4, 12, 37, 8, 24, DateTimeKind.Utc).AddTicks(8542) });

            migrationBuilder.UpdateData(
                table: "Levels",
                keyColumn: "LevelId",
                keyValue: new Guid("b1c2d3e4-f5a6-b7c8-d9e0-f1a2b3c4d5e6"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 4, 12, 37, 8, 24, DateTimeKind.Utc).AddTicks(8546), new DateTime(2025, 6, 4, 12, 37, 8, 24, DateTimeKind.Utc).AddTicks(8547) });

            migrationBuilder.UpdateData(
                table: "Levels",
                keyColumn: "LevelId",
                keyValue: new Guid("c2d3e4f5-a6b7-c8d9-e0f1-a2b3c4d5e6f7"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 4, 12, 37, 8, 24, DateTimeKind.Utc).AddTicks(8553), new DateTime(2025, 6, 4, 12, 37, 8, 24, DateTimeKind.Utc).AddTicks(8553) });

            migrationBuilder.UpdateData(
                table: "Levels",
                keyColumn: "LevelId",
                keyValue: new Guid("e1f2a3b4-c5d6-e7f8-a9b0-c1d2e3f4a5b6"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 4, 12, 37, 8, 24, DateTimeKind.Utc).AddTicks(8531), new DateTime(2025, 6, 4, 12, 37, 8, 24, DateTimeKind.Utc).AddTicks(8531) });

            migrationBuilder.UpdateData(
                table: "Levels",
                keyColumn: "LevelId",
                keyValue: new Guid("f2a3b4c5-d6e7-f8a9-b0c1-d2e3f4a5b6c7"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 4, 12, 37, 8, 24, DateTimeKind.Utc).AddTicks(8537), new DateTime(2025, 6, 4, 12, 37, 8, 24, DateTimeKind.Utc).AddTicks(8538) });

            migrationBuilder.UpdateData(
                table: "OrganizationIndustryTypes",
                keyColumn: "IndustryTypeId",
                keyValue: new Guid("a1b2c3d4-e5f6-7890-1234-567890abcdef"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 4, 12, 37, 8, 24, DateTimeKind.Utc).AddTicks(6872), new DateTime(2025, 6, 4, 12, 37, 8, 24, DateTimeKind.Utc).AddTicks(6875) });

            migrationBuilder.UpdateData(
                table: "OrganizationIndustryTypes",
                keyColumn: "IndustryTypeId",
                keyValue: new Guid("b2c3d4e5-f6a1-2345-6789-0abcdef12345"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 4, 12, 37, 8, 24, DateTimeKind.Utc).AddTicks(6880), new DateTime(2025, 6, 4, 12, 37, 8, 24, DateTimeKind.Utc).AddTicks(6881) });

            migrationBuilder.UpdateData(
                table: "OrganizationIndustryTypes",
                keyColumn: "IndustryTypeId",
                keyValue: new Guid("c3d4e5f6-a1b2-3456-7890-cdef12345678"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 4, 12, 37, 8, 24, DateTimeKind.Utc).AddTicks(6883), new DateTime(2025, 6, 4, 12, 37, 8, 24, DateTimeKind.Utc).AddTicks(6884) });

            migrationBuilder.UpdateData(
                table: "OrganizationIndustryTypes",
                keyColumn: "IndustryTypeId",
                keyValue: new Guid("d4e5f6a1-b2c3-4567-890a-bcdef1234567"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 4, 12, 37, 8, 24, DateTimeKind.Utc).AddTicks(6887), new DateTime(2025, 6, 4, 12, 37, 8, 24, DateTimeKind.Utc).AddTicks(6887) });

            migrationBuilder.UpdateData(
                table: "QuestTypes",
                keyColumn: "QuestTypeId",
                keyValue: new Guid("a1b2c3d4-e5f6-7890-abcd-ef0123456789"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 4, 12, 37, 8, 24, DateTimeKind.Utc).AddTicks(8476), new DateTime(2025, 6, 4, 12, 37, 8, 24, DateTimeKind.Utc).AddTicks(8476) });

            migrationBuilder.UpdateData(
                table: "QuestTypes",
                keyColumn: "QuestTypeId",
                keyValue: new Guid("b2c3d4e5-f6a1-2345-cdef-0123456789ab"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 4, 12, 37, 8, 24, DateTimeKind.Utc).AddTicks(8481), new DateTime(2025, 6, 4, 12, 37, 8, 24, DateTimeKind.Utc).AddTicks(8482) });

            migrationBuilder.UpdateData(
                table: "QuestTypes",
                keyColumn: "QuestTypeId",
                keyValue: new Guid("c3d4e5f6-a1b2-3456-7890-abcdef012345"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 4, 12, 37, 8, 24, DateTimeKind.Utc).AddTicks(8484), new DateTime(2025, 6, 4, 12, 37, 8, 24, DateTimeKind.Utc).AddTicks(8484) });

            migrationBuilder.UpdateData(
                table: "QuestTypes",
                keyColumn: "QuestTypeId",
                keyValue: new Guid("d4e5f6a1-b2c3-4567-890a-bcdef0123456"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 4, 12, 37, 8, 24, DateTimeKind.Utc).AddTicks(8486), new DateTime(2025, 6, 4, 12, 37, 8, 24, DateTimeKind.Utc).AddTicks(8487) });

            migrationBuilder.UpdateData(
                table: "StockAdjustmentTypes",
                keyColumn: "AdjustmentTypeId",
                keyValue: new Guid("01a1b2c3-d4e5-6f78-9012-3456789abc01"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 4, 12, 37, 8, 5, DateTimeKind.Utc).AddTicks(1480), new DateTime(2025, 6, 4, 12, 37, 8, 5, DateTimeKind.Utc).AddTicks(1481) });

            migrationBuilder.UpdateData(
                table: "StockAdjustmentTypes",
                keyColumn: "AdjustmentTypeId",
                keyValue: new Guid("02a1b2c3-d4e5-6f78-9012-3456789abc02"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 4, 12, 37, 8, 5, DateTimeKind.Utc).AddTicks(1488), new DateTime(2025, 6, 4, 12, 37, 8, 5, DateTimeKind.Utc).AddTicks(1489) });

            migrationBuilder.UpdateData(
                table: "StockAdjustmentTypes",
                keyColumn: "AdjustmentTypeId",
                keyValue: new Guid("03a1b2c3-d4e5-6f78-9012-3456789abc03"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 4, 12, 37, 8, 5, DateTimeKind.Utc).AddTicks(1497), new DateTime(2025, 6, 4, 12, 37, 8, 5, DateTimeKind.Utc).AddTicks(1498) });

            migrationBuilder.UpdateData(
                table: "StockAdjustmentTypes",
                keyColumn: "AdjustmentTypeId",
                keyValue: new Guid("04a1b2c3-d4e5-6f78-9012-3456789abc04"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 4, 12, 37, 8, 5, DateTimeKind.Utc).AddTicks(1516), new DateTime(2025, 6, 4, 12, 37, 8, 5, DateTimeKind.Utc).AddTicks(1517) });

            migrationBuilder.UpdateData(
                table: "StockAdjustmentTypes",
                keyColumn: "AdjustmentTypeId",
                keyValue: new Guid("05a1b2c3-d4e5-6f78-9012-3456789abc05"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 4, 12, 37, 8, 5, DateTimeKind.Utc).AddTicks(1521), new DateTime(2025, 6, 4, 12, 37, 8, 5, DateTimeKind.Utc).AddTicks(1522) });

            migrationBuilder.UpdateData(
                table: "StockAdjustmentTypes",
                keyColumn: "AdjustmentTypeId",
                keyValue: new Guid("06a1b2c3-d4e5-6f78-9012-3456789abc06"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 4, 12, 37, 8, 5, DateTimeKind.Utc).AddTicks(1527), new DateTime(2025, 6, 4, 12, 37, 8, 5, DateTimeKind.Utc).AddTicks(1527) });

            migrationBuilder.UpdateData(
                table: "SubscriptionPlans",
                keyColumn: "PlanId",
                keyValue: new Guid("11223344-5566-7788-99aa-bbccddeeff00"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 4, 12, 37, 8, 24, DateTimeKind.Utc).AddTicks(6984), new DateTime(2025, 6, 4, 12, 37, 8, 24, DateTimeKind.Utc).AddTicks(6985) });

            migrationBuilder.UpdateData(
                table: "SubscriptionPlans",
                keyColumn: "PlanId",
                keyValue: new Guid("aabbccdd-eeff-1122-3344-5566778899aa"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 4, 12, 37, 8, 24, DateTimeKind.Utc).AddTicks(6997), new DateTime(2025, 6, 4, 12, 37, 8, 24, DateTimeKind.Utc).AddTicks(6997) });

            migrationBuilder.UpdateData(
                table: "SubscriptionPlans",
                keyColumn: "PlanId",
                keyValue: new Guid("ccddeeff-aabb-3344-5566-778899aabbcc"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 4, 12, 37, 8, 24, DateTimeKind.Utc).AddTicks(7002), new DateTime(2025, 6, 4, 12, 37, 8, 24, DateTimeKind.Utc).AddTicks(7002) });

            migrationBuilder.UpdateData(
                table: "UnitGroups",
                keyColumn: "UnitGroupId",
                keyValue: new Guid("a0000000-0000-0000-0000-000000000001"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 4, 12, 37, 7, 996, DateTimeKind.Utc).AddTicks(9092), new DateTime(2025, 6, 4, 12, 37, 7, 996, DateTimeKind.Utc).AddTicks(9092) });

            migrationBuilder.UpdateData(
                table: "UnitGroups",
                keyColumn: "UnitGroupId",
                keyValue: new Guid("a0000000-0000-0000-0000-000000000002"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 4, 12, 37, 7, 996, DateTimeKind.Utc).AddTicks(9099), new DateTime(2025, 6, 4, 12, 37, 7, 996, DateTimeKind.Utc).AddTicks(9099) });

            migrationBuilder.UpdateData(
                table: "UnitGroups",
                keyColumn: "UnitGroupId",
                keyValue: new Guid("a0000000-0000-0000-0000-000000000003"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 4, 12, 37, 7, 996, DateTimeKind.Utc).AddTicks(9104), new DateTime(2025, 6, 4, 12, 37, 7, 996, DateTimeKind.Utc).AddTicks(9105) });

            migrationBuilder.UpdateData(
                table: "UnitGroups",
                keyColumn: "UnitGroupId",
                keyValue: new Guid("a0000000-0000-0000-0000-000000000004"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 4, 12, 37, 7, 996, DateTimeKind.Utc).AddTicks(9110), new DateTime(2025, 6, 4, 12, 37, 7, 996, DateTimeKind.Utc).AddTicks(9111) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasures",
                keyColumn: "UnitId",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000001"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 4, 12, 37, 7, 998, DateTimeKind.Utc).AddTicks(4165), new DateTime(2025, 6, 4, 12, 37, 7, 998, DateTimeKind.Utc).AddTicks(4166) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasures",
                keyColumn: "UnitId",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000002"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 4, 12, 37, 7, 998, DateTimeKind.Utc).AddTicks(4175), new DateTime(2025, 6, 4, 12, 37, 7, 998, DateTimeKind.Utc).AddTicks(4176) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasures",
                keyColumn: "UnitId",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000003"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 4, 12, 37, 7, 998, DateTimeKind.Utc).AddTicks(4182), new DateTime(2025, 6, 4, 12, 37, 7, 998, DateTimeKind.Utc).AddTicks(4183) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasures",
                keyColumn: "UnitId",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000004"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 4, 12, 37, 7, 998, DateTimeKind.Utc).AddTicks(4196), new DateTime(2025, 6, 4, 12, 37, 7, 998, DateTimeKind.Utc).AddTicks(4197) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasures",
                keyColumn: "UnitId",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000005"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 4, 12, 37, 7, 998, DateTimeKind.Utc).AddTicks(4204), new DateTime(2025, 6, 4, 12, 37, 7, 998, DateTimeKind.Utc).AddTicks(4205) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasures",
                keyColumn: "UnitId",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000006"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 4, 12, 37, 7, 998, DateTimeKind.Utc).AddTicks(4211), new DateTime(2025, 6, 4, 12, 37, 7, 998, DateTimeKind.Utc).AddTicks(4211) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasures",
                keyColumn: "UnitId",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000007"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 4, 12, 37, 7, 998, DateTimeKind.Utc).AddTicks(4218), new DateTime(2025, 6, 4, 12, 37, 7, 998, DateTimeKind.Utc).AddTicks(4218) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasures",
                keyColumn: "UnitId",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000008"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 4, 12, 37, 7, 998, DateTimeKind.Utc).AddTicks(4237), new DateTime(2025, 6, 4, 12, 37, 7, 998, DateTimeKind.Utc).AddTicks(4237) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasures",
                keyColumn: "UnitId",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000009"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 4, 12, 37, 7, 998, DateTimeKind.Utc).AddTicks(4243), new DateTime(2025, 6, 4, 12, 37, 7, 998, DateTimeKind.Utc).AddTicks(4243) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasures",
                keyColumn: "UnitId",
                keyValue: new Guid("b0000000-0000-0000-0000-00000000000a"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 4, 12, 37, 7, 998, DateTimeKind.Utc).AddTicks(4249), new DateTime(2025, 6, 4, 12, 37, 7, 998, DateTimeKind.Utc).AddTicks(4249) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasures",
                keyColumn: "UnitId",
                keyValue: new Guid("b0000000-0000-0000-0000-00000000000b"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 4, 12, 37, 7, 998, DateTimeKind.Utc).AddTicks(4256), new DateTime(2025, 6, 4, 12, 37, 7, 998, DateTimeKind.Utc).AddTicks(4256) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasures",
                keyColumn: "UnitId",
                keyValue: new Guid("b0000000-0000-0000-0000-00000000000c"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 4, 12, 37, 7, 998, DateTimeKind.Utc).AddTicks(4263), new DateTime(2025, 6, 4, 12, 37, 7, 998, DateTimeKind.Utc).AddTicks(4263) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasures",
                keyColumn: "UnitId",
                keyValue: new Guid("b0000000-0000-0000-0000-00000000000d"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 4, 12, 37, 7, 998, DateTimeKind.Utc).AddTicks(4320), new DateTime(2025, 6, 4, 12, 37, 7, 998, DateTimeKind.Utc).AddTicks(4321) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasures",
                keyColumn: "UnitId",
                keyValue: new Guid("b0000000-0000-0000-0000-00000000000e"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 4, 12, 37, 7, 998, DateTimeKind.Utc).AddTicks(4328), new DateTime(2025, 6, 4, 12, 37, 7, 998, DateTimeKind.Utc).AddTicks(4329) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasures",
                keyColumn: "UnitId",
                keyValue: new Guid("b0000000-0000-0000-0000-00000000000f"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 4, 12, 37, 7, 998, DateTimeKind.Utc).AddTicks(4343), new DateTime(2025, 6, 4, 12, 37, 7, 998, DateTimeKind.Utc).AddTicks(4344) });

            migrationBuilder.CreateIndex(
                name: "IX_Products_ItemCategoryId",
                table: "Products",
                column: "ItemCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Components_ItemCategoryId",
                table: "Components",
                column: "ItemCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemCategories_CategoryName",
                table: "ItemCategories",
                column: "CategoryName",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Components_ItemCategories_ItemCategoryId",
                table: "Components",
                column: "ItemCategoryId",
                principalTable: "ItemCategories",
                principalColumn: "ItemCategoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ItemCategories_ItemCategoryId",
                table: "Products",
                column: "ItemCategoryId",
                principalTable: "ItemCategories",
                principalColumn: "ItemCategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Components_ItemCategories_ItemCategoryId",
                table: "Components");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_ItemCategories_ItemCategoryId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "ItemCategories");

            migrationBuilder.DropIndex(
                name: "IX_Products_ItemCategoryId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Components_ItemCategoryId",
                table: "Components");

            migrationBuilder.DropColumn(
                name: "ItemCategoryId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ItemCategoryId",
                table: "Components");

            migrationBuilder.UpdateData(
                table: "Levels",
                keyColumn: "LevelId",
                keyValue: new Guid("a0b1c2d3-e4f5-a6b7-c8d9-e0f1a2b3c4d5"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 4, 11, 37, 1, 736, DateTimeKind.Utc).AddTicks(4881), new DateTime(2025, 6, 4, 11, 37, 1, 736, DateTimeKind.Utc).AddTicks(4881) });

            migrationBuilder.UpdateData(
                table: "Levels",
                keyColumn: "LevelId",
                keyValue: new Guid("b1c2d3e4-f5a6-b7c8-d9e0-f1a2b3c4d5e6"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 4, 11, 37, 1, 736, DateTimeKind.Utc).AddTicks(4884), new DateTime(2025, 6, 4, 11, 37, 1, 736, DateTimeKind.Utc).AddTicks(4885) });

            migrationBuilder.UpdateData(
                table: "Levels",
                keyColumn: "LevelId",
                keyValue: new Guid("c2d3e4f5-a6b7-c8d9-e0f1-a2b3c4d5e6f7"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 4, 11, 37, 1, 736, DateTimeKind.Utc).AddTicks(4888), new DateTime(2025, 6, 4, 11, 37, 1, 736, DateTimeKind.Utc).AddTicks(4888) });

            migrationBuilder.UpdateData(
                table: "Levels",
                keyColumn: "LevelId",
                keyValue: new Guid("e1f2a3b4-c5d6-e7f8-a9b0-c1d2e3f4a5b6"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 4, 11, 37, 1, 736, DateTimeKind.Utc).AddTicks(4867), new DateTime(2025, 6, 4, 11, 37, 1, 736, DateTimeKind.Utc).AddTicks(4868) });

            migrationBuilder.UpdateData(
                table: "Levels",
                keyColumn: "LevelId",
                keyValue: new Guid("f2a3b4c5-d6e7-f8a9-b0c1-d2e3f4a5b6c7"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 4, 11, 37, 1, 736, DateTimeKind.Utc).AddTicks(4874), new DateTime(2025, 6, 4, 11, 37, 1, 736, DateTimeKind.Utc).AddTicks(4874) });

            migrationBuilder.UpdateData(
                table: "OrganizationIndustryTypes",
                keyColumn: "IndustryTypeId",
                keyValue: new Guid("a1b2c3d4-e5f6-7890-1234-567890abcdef"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 4, 11, 37, 1, 736, DateTimeKind.Utc).AddTicks(4635), new DateTime(2025, 6, 4, 11, 37, 1, 736, DateTimeKind.Utc).AddTicks(4638) });

            migrationBuilder.UpdateData(
                table: "OrganizationIndustryTypes",
                keyColumn: "IndustryTypeId",
                keyValue: new Guid("b2c3d4e5-f6a1-2345-6789-0abcdef12345"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 4, 11, 37, 1, 736, DateTimeKind.Utc).AddTicks(4642), new DateTime(2025, 6, 4, 11, 37, 1, 736, DateTimeKind.Utc).AddTicks(4643) });

            migrationBuilder.UpdateData(
                table: "OrganizationIndustryTypes",
                keyColumn: "IndustryTypeId",
                keyValue: new Guid("c3d4e5f6-a1b2-3456-7890-cdef12345678"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 4, 11, 37, 1, 736, DateTimeKind.Utc).AddTicks(4647), new DateTime(2025, 6, 4, 11, 37, 1, 736, DateTimeKind.Utc).AddTicks(4647) });

            migrationBuilder.UpdateData(
                table: "OrganizationIndustryTypes",
                keyColumn: "IndustryTypeId",
                keyValue: new Guid("d4e5f6a1-b2c3-4567-890a-bcdef1234567"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 4, 11, 37, 1, 736, DateTimeKind.Utc).AddTicks(4652), new DateTime(2025, 6, 4, 11, 37, 1, 736, DateTimeKind.Utc).AddTicks(4652) });

            migrationBuilder.UpdateData(
                table: "QuestTypes",
                keyColumn: "QuestTypeId",
                keyValue: new Guid("a1b2c3d4-e5f6-7890-abcd-ef0123456789"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 4, 11, 37, 1, 736, DateTimeKind.Utc).AddTicks(4814), new DateTime(2025, 6, 4, 11, 37, 1, 736, DateTimeKind.Utc).AddTicks(4815) });

            migrationBuilder.UpdateData(
                table: "QuestTypes",
                keyColumn: "QuestTypeId",
                keyValue: new Guid("b2c3d4e5-f6a1-2345-cdef-0123456789ab"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 4, 11, 37, 1, 736, DateTimeKind.Utc).AddTicks(4819), new DateTime(2025, 6, 4, 11, 37, 1, 736, DateTimeKind.Utc).AddTicks(4819) });

            migrationBuilder.UpdateData(
                table: "QuestTypes",
                keyColumn: "QuestTypeId",
                keyValue: new Guid("c3d4e5f6-a1b2-3456-7890-abcdef012345"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 4, 11, 37, 1, 736, DateTimeKind.Utc).AddTicks(4821), new DateTime(2025, 6, 4, 11, 37, 1, 736, DateTimeKind.Utc).AddTicks(4822) });

            migrationBuilder.UpdateData(
                table: "QuestTypes",
                keyColumn: "QuestTypeId",
                keyValue: new Guid("d4e5f6a1-b2c3-4567-890a-bcdef0123456"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 4, 11, 37, 1, 736, DateTimeKind.Utc).AddTicks(4824), new DateTime(2025, 6, 4, 11, 37, 1, 736, DateTimeKind.Utc).AddTicks(4824) });

            migrationBuilder.UpdateData(
                table: "StockAdjustmentTypes",
                keyColumn: "AdjustmentTypeId",
                keyValue: new Guid("01a1b2c3-d4e5-6f78-9012-3456789abc01"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 4, 11, 37, 1, 730, DateTimeKind.Utc).AddTicks(9294), new DateTime(2025, 6, 4, 11, 37, 1, 730, DateTimeKind.Utc).AddTicks(9295) });

            migrationBuilder.UpdateData(
                table: "StockAdjustmentTypes",
                keyColumn: "AdjustmentTypeId",
                keyValue: new Guid("02a1b2c3-d4e5-6f78-9012-3456789abc02"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 4, 11, 37, 1, 730, DateTimeKind.Utc).AddTicks(9299), new DateTime(2025, 6, 4, 11, 37, 1, 730, DateTimeKind.Utc).AddTicks(9299) });

            migrationBuilder.UpdateData(
                table: "StockAdjustmentTypes",
                keyColumn: "AdjustmentTypeId",
                keyValue: new Guid("03a1b2c3-d4e5-6f78-9012-3456789abc03"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 4, 11, 37, 1, 730, DateTimeKind.Utc).AddTicks(9302), new DateTime(2025, 6, 4, 11, 37, 1, 730, DateTimeKind.Utc).AddTicks(9303) });

            migrationBuilder.UpdateData(
                table: "StockAdjustmentTypes",
                keyColumn: "AdjustmentTypeId",
                keyValue: new Guid("04a1b2c3-d4e5-6f78-9012-3456789abc04"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 4, 11, 37, 1, 730, DateTimeKind.Utc).AddTicks(9315), new DateTime(2025, 6, 4, 11, 37, 1, 730, DateTimeKind.Utc).AddTicks(9315) });

            migrationBuilder.UpdateData(
                table: "StockAdjustmentTypes",
                keyColumn: "AdjustmentTypeId",
                keyValue: new Guid("05a1b2c3-d4e5-6f78-9012-3456789abc05"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 4, 11, 37, 1, 730, DateTimeKind.Utc).AddTicks(9318), new DateTime(2025, 6, 4, 11, 37, 1, 730, DateTimeKind.Utc).AddTicks(9319) });

            migrationBuilder.UpdateData(
                table: "StockAdjustmentTypes",
                keyColumn: "AdjustmentTypeId",
                keyValue: new Guid("06a1b2c3-d4e5-6f78-9012-3456789abc06"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 4, 11, 37, 1, 730, DateTimeKind.Utc).AddTicks(9322), new DateTime(2025, 6, 4, 11, 37, 1, 730, DateTimeKind.Utc).AddTicks(9322) });

            migrationBuilder.UpdateData(
                table: "SubscriptionPlans",
                keyColumn: "PlanId",
                keyValue: new Guid("11223344-5566-7788-99aa-bbccddeeff00"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 4, 11, 37, 1, 736, DateTimeKind.Utc).AddTicks(4744), new DateTime(2025, 6, 4, 11, 37, 1, 736, DateTimeKind.Utc).AddTicks(4745) });

            migrationBuilder.UpdateData(
                table: "SubscriptionPlans",
                keyColumn: "PlanId",
                keyValue: new Guid("aabbccdd-eeff-1122-3344-5566778899aa"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 4, 11, 37, 1, 736, DateTimeKind.Utc).AddTicks(4766), new DateTime(2025, 6, 4, 11, 37, 1, 736, DateTimeKind.Utc).AddTicks(4767) });

            migrationBuilder.UpdateData(
                table: "SubscriptionPlans",
                keyColumn: "PlanId",
                keyValue: new Guid("ccddeeff-aabb-3344-5566-778899aabbcc"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 4, 11, 37, 1, 736, DateTimeKind.Utc).AddTicks(4771), new DateTime(2025, 6, 4, 11, 37, 1, 736, DateTimeKind.Utc).AddTicks(4771) });

            migrationBuilder.UpdateData(
                table: "UnitGroups",
                keyColumn: "UnitGroupId",
                keyValue: new Guid("a0000000-0000-0000-0000-000000000001"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 4, 11, 37, 1, 728, DateTimeKind.Utc).AddTicks(2514), new DateTime(2025, 6, 4, 11, 37, 1, 728, DateTimeKind.Utc).AddTicks(2514) });

            migrationBuilder.UpdateData(
                table: "UnitGroups",
                keyColumn: "UnitGroupId",
                keyValue: new Guid("a0000000-0000-0000-0000-000000000002"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 4, 11, 37, 1, 728, DateTimeKind.Utc).AddTicks(2519), new DateTime(2025, 6, 4, 11, 37, 1, 728, DateTimeKind.Utc).AddTicks(2519) });

            migrationBuilder.UpdateData(
                table: "UnitGroups",
                keyColumn: "UnitGroupId",
                keyValue: new Guid("a0000000-0000-0000-0000-000000000003"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 4, 11, 37, 1, 728, DateTimeKind.Utc).AddTicks(2522), new DateTime(2025, 6, 4, 11, 37, 1, 728, DateTimeKind.Utc).AddTicks(2523) });

            migrationBuilder.UpdateData(
                table: "UnitGroups",
                keyColumn: "UnitGroupId",
                keyValue: new Guid("a0000000-0000-0000-0000-000000000004"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 4, 11, 37, 1, 728, DateTimeKind.Utc).AddTicks(2526), new DateTime(2025, 6, 4, 11, 37, 1, 728, DateTimeKind.Utc).AddTicks(2526) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasures",
                keyColumn: "UnitId",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000001"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 4, 11, 37, 1, 728, DateTimeKind.Utc).AddTicks(8810), new DateTime(2025, 6, 4, 11, 37, 1, 728, DateTimeKind.Utc).AddTicks(8811) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasures",
                keyColumn: "UnitId",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000002"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 4, 11, 37, 1, 728, DateTimeKind.Utc).AddTicks(8816), new DateTime(2025, 6, 4, 11, 37, 1, 728, DateTimeKind.Utc).AddTicks(8816) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasures",
                keyColumn: "UnitId",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000003"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 4, 11, 37, 1, 728, DateTimeKind.Utc).AddTicks(8830), new DateTime(2025, 6, 4, 11, 37, 1, 728, DateTimeKind.Utc).AddTicks(8831) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasures",
                keyColumn: "UnitId",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000004"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 4, 11, 37, 1, 728, DateTimeKind.Utc).AddTicks(8834), new DateTime(2025, 6, 4, 11, 37, 1, 728, DateTimeKind.Utc).AddTicks(8835) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasures",
                keyColumn: "UnitId",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000005"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 4, 11, 37, 1, 728, DateTimeKind.Utc).AddTicks(8840), new DateTime(2025, 6, 4, 11, 37, 1, 728, DateTimeKind.Utc).AddTicks(8841) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasures",
                keyColumn: "UnitId",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000006"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 4, 11, 37, 1, 728, DateTimeKind.Utc).AddTicks(8845), new DateTime(2025, 6, 4, 11, 37, 1, 728, DateTimeKind.Utc).AddTicks(8845) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasures",
                keyColumn: "UnitId",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000007"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 4, 11, 37, 1, 728, DateTimeKind.Utc).AddTicks(8849), new DateTime(2025, 6, 4, 11, 37, 1, 728, DateTimeKind.Utc).AddTicks(8850) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasures",
                keyColumn: "UnitId",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000008"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 4, 11, 37, 1, 728, DateTimeKind.Utc).AddTicks(8853), new DateTime(2025, 6, 4, 11, 37, 1, 728, DateTimeKind.Utc).AddTicks(8854) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasures",
                keyColumn: "UnitId",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000009"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 4, 11, 37, 1, 728, DateTimeKind.Utc).AddTicks(8858), new DateTime(2025, 6, 4, 11, 37, 1, 728, DateTimeKind.Utc).AddTicks(8858) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasures",
                keyColumn: "UnitId",
                keyValue: new Guid("b0000000-0000-0000-0000-00000000000a"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 4, 11, 37, 1, 728, DateTimeKind.Utc).AddTicks(8862), new DateTime(2025, 6, 4, 11, 37, 1, 728, DateTimeKind.Utc).AddTicks(8862) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasures",
                keyColumn: "UnitId",
                keyValue: new Guid("b0000000-0000-0000-0000-00000000000b"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 4, 11, 37, 1, 728, DateTimeKind.Utc).AddTicks(8869), new DateTime(2025, 6, 4, 11, 37, 1, 728, DateTimeKind.Utc).AddTicks(8869) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasures",
                keyColumn: "UnitId",
                keyValue: new Guid("b0000000-0000-0000-0000-00000000000c"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 4, 11, 37, 1, 728, DateTimeKind.Utc).AddTicks(8873), new DateTime(2025, 6, 4, 11, 37, 1, 728, DateTimeKind.Utc).AddTicks(8874) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasures",
                keyColumn: "UnitId",
                keyValue: new Guid("b0000000-0000-0000-0000-00000000000d"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 4, 11, 37, 1, 728, DateTimeKind.Utc).AddTicks(8877), new DateTime(2025, 6, 4, 11, 37, 1, 728, DateTimeKind.Utc).AddTicks(8878) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasures",
                keyColumn: "UnitId",
                keyValue: new Guid("b0000000-0000-0000-0000-00000000000e"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 4, 11, 37, 1, 728, DateTimeKind.Utc).AddTicks(8881), new DateTime(2025, 6, 4, 11, 37, 1, 728, DateTimeKind.Utc).AddTicks(8882) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasures",
                keyColumn: "UnitId",
                keyValue: new Guid("b0000000-0000-0000-0000-00000000000f"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 4, 11, 37, 1, 728, DateTimeKind.Utc).AddTicks(8886), new DateTime(2025, 6, 4, 11, 37, 1, 728, DateTimeKind.Utc).AddTicks(8887) });
        }
    }
}
