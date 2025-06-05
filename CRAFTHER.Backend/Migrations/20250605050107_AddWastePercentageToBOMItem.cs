using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRAFTHER.Backend.Migrations
{
    /// <inheritdoc />
    public partial class AddWastePercentageToBOMItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "WastePercentage",
                table: "BOMItems",
                type: "decimal(5,2)",
                nullable: false,
                defaultValue: 0m);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WastePercentage",
                table: "BOMItems");

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "ItemCategoryId",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000001"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 4, 12, 37, 8, 24, DateTimeKind.Utc).AddTicks(8316), new DateTime(2025, 6, 4, 12, 37, 8, 24, DateTimeKind.Utc).AddTicks(8318) });

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "ItemCategoryId",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000002"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 4, 12, 37, 8, 24, DateTimeKind.Utc).AddTicks(8333), new DateTime(2025, 6, 4, 12, 37, 8, 24, DateTimeKind.Utc).AddTicks(8335) });

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "ItemCategoryId",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000003"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 4, 12, 37, 8, 24, DateTimeKind.Utc).AddTicks(8340), new DateTime(2025, 6, 4, 12, 37, 8, 24, DateTimeKind.Utc).AddTicks(8340) });

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "ItemCategoryId",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000004"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 4, 12, 37, 8, 24, DateTimeKind.Utc).AddTicks(8344), new DateTime(2025, 6, 4, 12, 37, 8, 24, DateTimeKind.Utc).AddTicks(8345) });

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "ItemCategoryId",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000005"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 4, 12, 37, 8, 24, DateTimeKind.Utc).AddTicks(8348), new DateTime(2025, 6, 4, 12, 37, 8, 24, DateTimeKind.Utc).AddTicks(8349) });

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "ItemCategoryId",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000006"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 4, 12, 37, 8, 24, DateTimeKind.Utc).AddTicks(8353), new DateTime(2025, 6, 4, 12, 37, 8, 24, DateTimeKind.Utc).AddTicks(8353) });

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "ItemCategoryId",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000007"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 4, 12, 37, 8, 24, DateTimeKind.Utc).AddTicks(8357), new DateTime(2025, 6, 4, 12, 37, 8, 24, DateTimeKind.Utc).AddTicks(8357) });

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "ItemCategoryId",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000008"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 4, 12, 37, 8, 24, DateTimeKind.Utc).AddTicks(8361), new DateTime(2025, 6, 4, 12, 37, 8, 24, DateTimeKind.Utc).AddTicks(8361) });

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "ItemCategoryId",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000009"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 4, 12, 37, 8, 24, DateTimeKind.Utc).AddTicks(8366), new DateTime(2025, 6, 4, 12, 37, 8, 24, DateTimeKind.Utc).AddTicks(8366) });

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
        }
    }
}
