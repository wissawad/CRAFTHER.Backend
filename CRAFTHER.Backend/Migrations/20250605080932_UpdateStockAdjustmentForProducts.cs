using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRAFTHER.Backend.Migrations
{
    /// <inheritdoc />
    public partial class UpdateStockAdjustmentForProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "ItemCategoryId",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000001"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 8, 9, 31, 98, DateTimeKind.Utc).AddTicks(9570), new DateTime(2025, 6, 5, 8, 9, 31, 98, DateTimeKind.Utc).AddTicks(9571) });

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "ItemCategoryId",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000002"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 8, 9, 31, 98, DateTimeKind.Utc).AddTicks(9575), new DateTime(2025, 6, 5, 8, 9, 31, 98, DateTimeKind.Utc).AddTicks(9576) });

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "ItemCategoryId",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000003"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 8, 9, 31, 98, DateTimeKind.Utc).AddTicks(9579), new DateTime(2025, 6, 5, 8, 9, 31, 98, DateTimeKind.Utc).AddTicks(9580) });

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "ItemCategoryId",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000004"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 8, 9, 31, 98, DateTimeKind.Utc).AddTicks(9583), new DateTime(2025, 6, 5, 8, 9, 31, 98, DateTimeKind.Utc).AddTicks(9583) });

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "ItemCategoryId",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000005"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 8, 9, 31, 98, DateTimeKind.Utc).AddTicks(9591), new DateTime(2025, 6, 5, 8, 9, 31, 98, DateTimeKind.Utc).AddTicks(9592) });

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "ItemCategoryId",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000006"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 8, 9, 31, 98, DateTimeKind.Utc).AddTicks(9597), new DateTime(2025, 6, 5, 8, 9, 31, 98, DateTimeKind.Utc).AddTicks(9597) });

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "ItemCategoryId",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000007"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 8, 9, 31, 98, DateTimeKind.Utc).AddTicks(9600), new DateTime(2025, 6, 5, 8, 9, 31, 98, DateTimeKind.Utc).AddTicks(9601) });

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "ItemCategoryId",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000008"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 8, 9, 31, 98, DateTimeKind.Utc).AddTicks(9604), new DateTime(2025, 6, 5, 8, 9, 31, 98, DateTimeKind.Utc).AddTicks(9605) });

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "ItemCategoryId",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000009"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 8, 9, 31, 98, DateTimeKind.Utc).AddTicks(9608), new DateTime(2025, 6, 5, 8, 9, 31, 98, DateTimeKind.Utc).AddTicks(9609) });

            migrationBuilder.UpdateData(
                table: "Levels",
                keyColumn: "LevelId",
                keyValue: new Guid("a0b1c2d3-e4f5-a6b7-c8d9-e0f1a2b3c4d5"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 8, 9, 31, 98, DateTimeKind.Utc).AddTicks(9725), new DateTime(2025, 6, 5, 8, 9, 31, 98, DateTimeKind.Utc).AddTicks(9725) });

            migrationBuilder.UpdateData(
                table: "Levels",
                keyColumn: "LevelId",
                keyValue: new Guid("b1c2d3e4-f5a6-b7c8-d9e0-f1a2b3c4d5e6"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 8, 9, 31, 98, DateTimeKind.Utc).AddTicks(9728), new DateTime(2025, 6, 5, 8, 9, 31, 98, DateTimeKind.Utc).AddTicks(9729) });

            migrationBuilder.UpdateData(
                table: "Levels",
                keyColumn: "LevelId",
                keyValue: new Guid("c2d3e4f5-a6b7-c8d9-e0f1-a2b3c4d5e6f7"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 8, 9, 31, 98, DateTimeKind.Utc).AddTicks(9731), new DateTime(2025, 6, 5, 8, 9, 31, 98, DateTimeKind.Utc).AddTicks(9732) });

            migrationBuilder.UpdateData(
                table: "Levels",
                keyColumn: "LevelId",
                keyValue: new Guid("e1f2a3b4-c5d6-e7f8-a9b0-c1d2e3f4a5b6"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 8, 9, 31, 98, DateTimeKind.Utc).AddTicks(9714), new DateTime(2025, 6, 5, 8, 9, 31, 98, DateTimeKind.Utc).AddTicks(9714) });

            migrationBuilder.UpdateData(
                table: "Levels",
                keyColumn: "LevelId",
                keyValue: new Guid("f2a3b4c5-d6e7-f8a9-b0c1-d2e3f4a5b6c7"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 8, 9, 31, 98, DateTimeKind.Utc).AddTicks(9721), new DateTime(2025, 6, 5, 8, 9, 31, 98, DateTimeKind.Utc).AddTicks(9721) });

            migrationBuilder.UpdateData(
                table: "OrganizationIndustryTypes",
                keyColumn: "IndustryTypeId",
                keyValue: new Guid("a1b2c3d4-e5f6-7890-1234-567890abcdef"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 8, 9, 31, 98, DateTimeKind.Utc).AddTicks(8787), new DateTime(2025, 6, 5, 8, 9, 31, 98, DateTimeKind.Utc).AddTicks(8789) });

            migrationBuilder.UpdateData(
                table: "OrganizationIndustryTypes",
                keyColumn: "IndustryTypeId",
                keyValue: new Guid("b2c3d4e5-f6a1-2345-6789-0abcdef12345"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 8, 9, 31, 98, DateTimeKind.Utc).AddTicks(8793), new DateTime(2025, 6, 5, 8, 9, 31, 98, DateTimeKind.Utc).AddTicks(8793) });

            migrationBuilder.UpdateData(
                table: "OrganizationIndustryTypes",
                keyColumn: "IndustryTypeId",
                keyValue: new Guid("c3d4e5f6-a1b2-3456-7890-cdef12345678"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 8, 9, 31, 98, DateTimeKind.Utc).AddTicks(8795), new DateTime(2025, 6, 5, 8, 9, 31, 98, DateTimeKind.Utc).AddTicks(8795) });

            migrationBuilder.UpdateData(
                table: "OrganizationIndustryTypes",
                keyColumn: "IndustryTypeId",
                keyValue: new Guid("d4e5f6a1-b2c3-4567-890a-bcdef1234567"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 8, 9, 31, 98, DateTimeKind.Utc).AddTicks(8807), new DateTime(2025, 6, 5, 8, 9, 31, 98, DateTimeKind.Utc).AddTicks(8807) });

            migrationBuilder.UpdateData(
                table: "QuestTypes",
                keyColumn: "QuestTypeId",
                keyValue: new Guid("a1b2c3d4-e5f6-7890-abcd-ef0123456789"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 8, 9, 31, 98, DateTimeKind.Utc).AddTicks(9671), new DateTime(2025, 6, 5, 8, 9, 31, 98, DateTimeKind.Utc).AddTicks(9672) });

            migrationBuilder.UpdateData(
                table: "QuestTypes",
                keyColumn: "QuestTypeId",
                keyValue: new Guid("b2c3d4e5-f6a1-2345-cdef-0123456789ab"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 8, 9, 31, 98, DateTimeKind.Utc).AddTicks(9674), new DateTime(2025, 6, 5, 8, 9, 31, 98, DateTimeKind.Utc).AddTicks(9675) });

            migrationBuilder.UpdateData(
                table: "QuestTypes",
                keyColumn: "QuestTypeId",
                keyValue: new Guid("c3d4e5f6-a1b2-3456-7890-abcdef012345"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 8, 9, 31, 98, DateTimeKind.Utc).AddTicks(9677), new DateTime(2025, 6, 5, 8, 9, 31, 98, DateTimeKind.Utc).AddTicks(9677) });

            migrationBuilder.UpdateData(
                table: "QuestTypes",
                keyColumn: "QuestTypeId",
                keyValue: new Guid("d4e5f6a1-b2c3-4567-890a-bcdef0123456"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 8, 9, 31, 98, DateTimeKind.Utc).AddTicks(9682), new DateTime(2025, 6, 5, 8, 9, 31, 98, DateTimeKind.Utc).AddTicks(9682) });

            migrationBuilder.UpdateData(
                table: "StockAdjustmentTypes",
                keyColumn: "AdjustmentTypeId",
                keyValue: new Guid("01a1b2c3-d4e5-6f78-9012-3456789abc01"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 8, 9, 31, 89, DateTimeKind.Utc).AddTicks(6335), new DateTime(2025, 6, 5, 8, 9, 31, 89, DateTimeKind.Utc).AddTicks(6335) });

            migrationBuilder.UpdateData(
                table: "StockAdjustmentTypes",
                keyColumn: "AdjustmentTypeId",
                keyValue: new Guid("02a1b2c3-d4e5-6f78-9012-3456789abc02"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 8, 9, 31, 89, DateTimeKind.Utc).AddTicks(6347), new DateTime(2025, 6, 5, 8, 9, 31, 89, DateTimeKind.Utc).AddTicks(6347) });

            migrationBuilder.UpdateData(
                table: "StockAdjustmentTypes",
                keyColumn: "AdjustmentTypeId",
                keyValue: new Guid("03a1b2c3-d4e5-6f78-9012-3456789abc03"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 8, 9, 31, 89, DateTimeKind.Utc).AddTicks(6351), new DateTime(2025, 6, 5, 8, 9, 31, 89, DateTimeKind.Utc).AddTicks(6351) });

            migrationBuilder.UpdateData(
                table: "StockAdjustmentTypes",
                keyColumn: "AdjustmentTypeId",
                keyValue: new Guid("04a1b2c3-d4e5-6f78-9012-3456789abc04"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 8, 9, 31, 89, DateTimeKind.Utc).AddTicks(6354), new DateTime(2025, 6, 5, 8, 9, 31, 89, DateTimeKind.Utc).AddTicks(6355) });

            migrationBuilder.UpdateData(
                table: "StockAdjustmentTypes",
                keyColumn: "AdjustmentTypeId",
                keyValue: new Guid("05a1b2c3-d4e5-6f78-9012-3456789abc05"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 8, 9, 31, 89, DateTimeKind.Utc).AddTicks(6358), new DateTime(2025, 6, 5, 8, 9, 31, 89, DateTimeKind.Utc).AddTicks(6358) });

            migrationBuilder.UpdateData(
                table: "StockAdjustmentTypes",
                keyColumn: "AdjustmentTypeId",
                keyValue: new Guid("06a1b2c3-d4e5-6f78-9012-3456789abc06"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 8, 9, 31, 89, DateTimeKind.Utc).AddTicks(6361), new DateTime(2025, 6, 5, 8, 9, 31, 89, DateTimeKind.Utc).AddTicks(6361) });

            migrationBuilder.UpdateData(
                table: "SubscriptionPlans",
                keyColumn: "PlanId",
                keyValue: new Guid("11223344-5566-7788-99aa-bbccddeeff00"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 8, 9, 31, 98, DateTimeKind.Utc).AddTicks(8861), new DateTime(2025, 6, 5, 8, 9, 31, 98, DateTimeKind.Utc).AddTicks(8861) });

            migrationBuilder.UpdateData(
                table: "SubscriptionPlans",
                keyColumn: "PlanId",
                keyValue: new Guid("aabbccdd-eeff-1122-3344-5566778899aa"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 8, 9, 31, 98, DateTimeKind.Utc).AddTicks(8870), new DateTime(2025, 6, 5, 8, 9, 31, 98, DateTimeKind.Utc).AddTicks(8871) });

            migrationBuilder.UpdateData(
                table: "SubscriptionPlans",
                keyColumn: "PlanId",
                keyValue: new Guid("ccddeeff-aabb-3344-5566-778899aabbcc"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 8, 9, 31, 98, DateTimeKind.Utc).AddTicks(8874), new DateTime(2025, 6, 5, 8, 9, 31, 98, DateTimeKind.Utc).AddTicks(8874) });

            migrationBuilder.UpdateData(
                table: "UnitGroups",
                keyColumn: "UnitGroupId",
                keyValue: new Guid("a0000000-0000-0000-0000-000000000001"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 8, 9, 31, 87, DateTimeKind.Utc).AddTicks(3599), new DateTime(2025, 6, 5, 8, 9, 31, 87, DateTimeKind.Utc).AddTicks(3600) });

            migrationBuilder.UpdateData(
                table: "UnitGroups",
                keyColumn: "UnitGroupId",
                keyValue: new Guid("a0000000-0000-0000-0000-000000000002"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 8, 9, 31, 87, DateTimeKind.Utc).AddTicks(3603), new DateTime(2025, 6, 5, 8, 9, 31, 87, DateTimeKind.Utc).AddTicks(3604) });

            migrationBuilder.UpdateData(
                table: "UnitGroups",
                keyColumn: "UnitGroupId",
                keyValue: new Guid("a0000000-0000-0000-0000-000000000003"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 8, 9, 31, 87, DateTimeKind.Utc).AddTicks(3606), new DateTime(2025, 6, 5, 8, 9, 31, 87, DateTimeKind.Utc).AddTicks(3607) });

            migrationBuilder.UpdateData(
                table: "UnitGroups",
                keyColumn: "UnitGroupId",
                keyValue: new Guid("a0000000-0000-0000-0000-000000000004"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 8, 9, 31, 87, DateTimeKind.Utc).AddTicks(3610), new DateTime(2025, 6, 5, 8, 9, 31, 87, DateTimeKind.Utc).AddTicks(3610) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasures",
                keyColumn: "UnitId",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000001"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 8, 9, 31, 87, DateTimeKind.Utc).AddTicks(8615), new DateTime(2025, 6, 5, 8, 9, 31, 87, DateTimeKind.Utc).AddTicks(8616) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasures",
                keyColumn: "UnitId",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000002"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 8, 9, 31, 87, DateTimeKind.Utc).AddTicks(8621), new DateTime(2025, 6, 5, 8, 9, 31, 87, DateTimeKind.Utc).AddTicks(8621) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasures",
                keyColumn: "UnitId",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000003"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 8, 9, 31, 87, DateTimeKind.Utc).AddTicks(8625), new DateTime(2025, 6, 5, 8, 9, 31, 87, DateTimeKind.Utc).AddTicks(8626) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasures",
                keyColumn: "UnitId",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000004"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 8, 9, 31, 87, DateTimeKind.Utc).AddTicks(8630), new DateTime(2025, 6, 5, 8, 9, 31, 87, DateTimeKind.Utc).AddTicks(8630) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasures",
                keyColumn: "UnitId",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000005"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 8, 9, 31, 87, DateTimeKind.Utc).AddTicks(8634), new DateTime(2025, 6, 5, 8, 9, 31, 87, DateTimeKind.Utc).AddTicks(8635) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasures",
                keyColumn: "UnitId",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000006"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 8, 9, 31, 87, DateTimeKind.Utc).AddTicks(8638), new DateTime(2025, 6, 5, 8, 9, 31, 87, DateTimeKind.Utc).AddTicks(8639) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasures",
                keyColumn: "UnitId",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000007"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 8, 9, 31, 87, DateTimeKind.Utc).AddTicks(8642), new DateTime(2025, 6, 5, 8, 9, 31, 87, DateTimeKind.Utc).AddTicks(8643) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasures",
                keyColumn: "UnitId",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000008"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 8, 9, 31, 87, DateTimeKind.Utc).AddTicks(8648), new DateTime(2025, 6, 5, 8, 9, 31, 87, DateTimeKind.Utc).AddTicks(8648) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasures",
                keyColumn: "UnitId",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000009"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 8, 9, 31, 87, DateTimeKind.Utc).AddTicks(8654), new DateTime(2025, 6, 5, 8, 9, 31, 87, DateTimeKind.Utc).AddTicks(8655) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasures",
                keyColumn: "UnitId",
                keyValue: new Guid("b0000000-0000-0000-0000-00000000000a"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 8, 9, 31, 87, DateTimeKind.Utc).AddTicks(8659), new DateTime(2025, 6, 5, 8, 9, 31, 87, DateTimeKind.Utc).AddTicks(8659) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasures",
                keyColumn: "UnitId",
                keyValue: new Guid("b0000000-0000-0000-0000-00000000000b"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 8, 9, 31, 87, DateTimeKind.Utc).AddTicks(8663), new DateTime(2025, 6, 5, 8, 9, 31, 87, DateTimeKind.Utc).AddTicks(8663) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasures",
                keyColumn: "UnitId",
                keyValue: new Guid("b0000000-0000-0000-0000-00000000000c"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 8, 9, 31, 87, DateTimeKind.Utc).AddTicks(8667), new DateTime(2025, 6, 5, 8, 9, 31, 87, DateTimeKind.Utc).AddTicks(8668) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasures",
                keyColumn: "UnitId",
                keyValue: new Guid("b0000000-0000-0000-0000-00000000000d"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 8, 9, 31, 87, DateTimeKind.Utc).AddTicks(8671), new DateTime(2025, 6, 5, 8, 9, 31, 87, DateTimeKind.Utc).AddTicks(8672) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasures",
                keyColumn: "UnitId",
                keyValue: new Guid("b0000000-0000-0000-0000-00000000000e"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 8, 9, 31, 87, DateTimeKind.Utc).AddTicks(8675), new DateTime(2025, 6, 5, 8, 9, 31, 87, DateTimeKind.Utc).AddTicks(8676) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasures",
                keyColumn: "UnitId",
                keyValue: new Guid("b0000000-0000-0000-0000-00000000000f"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 8, 9, 31, 87, DateTimeKind.Utc).AddTicks(8680), new DateTime(2025, 6, 5, 8, 9, 31, 87, DateTimeKind.Utc).AddTicks(8680) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "ItemCategoryId",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000001"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 7, 58, 7, 104, DateTimeKind.Utc).AddTicks(6605), new DateTime(2025, 6, 5, 7, 58, 7, 104, DateTimeKind.Utc).AddTicks(6606) });

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "ItemCategoryId",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000002"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 7, 58, 7, 104, DateTimeKind.Utc).AddTicks(6609), new DateTime(2025, 6, 5, 7, 58, 7, 104, DateTimeKind.Utc).AddTicks(6610) });

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "ItemCategoryId",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000003"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 7, 58, 7, 104, DateTimeKind.Utc).AddTicks(6613), new DateTime(2025, 6, 5, 7, 58, 7, 104, DateTimeKind.Utc).AddTicks(6613) });

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "ItemCategoryId",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000004"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 7, 58, 7, 104, DateTimeKind.Utc).AddTicks(6616), new DateTime(2025, 6, 5, 7, 58, 7, 104, DateTimeKind.Utc).AddTicks(6616) });

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "ItemCategoryId",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000005"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 7, 58, 7, 104, DateTimeKind.Utc).AddTicks(6619), new DateTime(2025, 6, 5, 7, 58, 7, 104, DateTimeKind.Utc).AddTicks(6620) });

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "ItemCategoryId",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000006"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 7, 58, 7, 104, DateTimeKind.Utc).AddTicks(6628), new DateTime(2025, 6, 5, 7, 58, 7, 104, DateTimeKind.Utc).AddTicks(6628) });

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "ItemCategoryId",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000007"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 7, 58, 7, 104, DateTimeKind.Utc).AddTicks(6631), new DateTime(2025, 6, 5, 7, 58, 7, 104, DateTimeKind.Utc).AddTicks(6632) });

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "ItemCategoryId",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000008"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 7, 58, 7, 104, DateTimeKind.Utc).AddTicks(6635), new DateTime(2025, 6, 5, 7, 58, 7, 104, DateTimeKind.Utc).AddTicks(6635) });

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "ItemCategoryId",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000009"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 7, 58, 7, 104, DateTimeKind.Utc).AddTicks(6638), new DateTime(2025, 6, 5, 7, 58, 7, 104, DateTimeKind.Utc).AddTicks(6639) });

            migrationBuilder.UpdateData(
                table: "Levels",
                keyColumn: "LevelId",
                keyValue: new Guid("a0b1c2d3-e4f5-a6b7-c8d9-e0f1a2b3c4d5"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 7, 58, 7, 104, DateTimeKind.Utc).AddTicks(6750), new DateTime(2025, 6, 5, 7, 58, 7, 104, DateTimeKind.Utc).AddTicks(6751) });

            migrationBuilder.UpdateData(
                table: "Levels",
                keyColumn: "LevelId",
                keyValue: new Guid("b1c2d3e4-f5a6-b7c8-d9e0-f1a2b3c4d5e6"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 7, 58, 7, 104, DateTimeKind.Utc).AddTicks(6753), new DateTime(2025, 6, 5, 7, 58, 7, 104, DateTimeKind.Utc).AddTicks(6754) });

            migrationBuilder.UpdateData(
                table: "Levels",
                keyColumn: "LevelId",
                keyValue: new Guid("c2d3e4f5-a6b7-c8d9-e0f1-a2b3c4d5e6f7"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 7, 58, 7, 104, DateTimeKind.Utc).AddTicks(6757), new DateTime(2025, 6, 5, 7, 58, 7, 104, DateTimeKind.Utc).AddTicks(6757) });

            migrationBuilder.UpdateData(
                table: "Levels",
                keyColumn: "LevelId",
                keyValue: new Guid("e1f2a3b4-c5d6-e7f8-a9b0-c1d2e3f4a5b6"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 7, 58, 7, 104, DateTimeKind.Utc).AddTicks(6743), new DateTime(2025, 6, 5, 7, 58, 7, 104, DateTimeKind.Utc).AddTicks(6743) });

            migrationBuilder.UpdateData(
                table: "Levels",
                keyColumn: "LevelId",
                keyValue: new Guid("f2a3b4c5-d6e7-f8a9-b0c1-d2e3f4a5b6c7"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 7, 58, 7, 104, DateTimeKind.Utc).AddTicks(6747), new DateTime(2025, 6, 5, 7, 58, 7, 104, DateTimeKind.Utc).AddTicks(6747) });

            migrationBuilder.UpdateData(
                table: "OrganizationIndustryTypes",
                keyColumn: "IndustryTypeId",
                keyValue: new Guid("a1b2c3d4-e5f6-7890-1234-567890abcdef"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 7, 58, 7, 103, DateTimeKind.Utc).AddTicks(9744), new DateTime(2025, 6, 5, 7, 58, 7, 103, DateTimeKind.Utc).AddTicks(9749) });

            migrationBuilder.UpdateData(
                table: "OrganizationIndustryTypes",
                keyColumn: "IndustryTypeId",
                keyValue: new Guid("b2c3d4e5-f6a1-2345-6789-0abcdef12345"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 7, 58, 7, 103, DateTimeKind.Utc).AddTicks(9752), new DateTime(2025, 6, 5, 7, 58, 7, 103, DateTimeKind.Utc).AddTicks(9752) });

            migrationBuilder.UpdateData(
                table: "OrganizationIndustryTypes",
                keyColumn: "IndustryTypeId",
                keyValue: new Guid("c3d4e5f6-a1b2-3456-7890-cdef12345678"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 7, 58, 7, 103, DateTimeKind.Utc).AddTicks(9754), new DateTime(2025, 6, 5, 7, 58, 7, 103, DateTimeKind.Utc).AddTicks(9754) });

            migrationBuilder.UpdateData(
                table: "OrganizationIndustryTypes",
                keyColumn: "IndustryTypeId",
                keyValue: new Guid("d4e5f6a1-b2c3-4567-890a-bcdef1234567"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 7, 58, 7, 103, DateTimeKind.Utc).AddTicks(9756), new DateTime(2025, 6, 5, 7, 58, 7, 103, DateTimeKind.Utc).AddTicks(9756) });

            migrationBuilder.UpdateData(
                table: "QuestTypes",
                keyColumn: "QuestTypeId",
                keyValue: new Guid("a1b2c3d4-e5f6-7890-abcd-ef0123456789"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 7, 58, 7, 104, DateTimeKind.Utc).AddTicks(6704), new DateTime(2025, 6, 5, 7, 58, 7, 104, DateTimeKind.Utc).AddTicks(6704) });

            migrationBuilder.UpdateData(
                table: "QuestTypes",
                keyColumn: "QuestTypeId",
                keyValue: new Guid("b2c3d4e5-f6a1-2345-cdef-0123456789ab"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 7, 58, 7, 104, DateTimeKind.Utc).AddTicks(6708), new DateTime(2025, 6, 5, 7, 58, 7, 104, DateTimeKind.Utc).AddTicks(6708) });

            migrationBuilder.UpdateData(
                table: "QuestTypes",
                keyColumn: "QuestTypeId",
                keyValue: new Guid("c3d4e5f6-a1b2-3456-7890-abcdef012345"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 7, 58, 7, 104, DateTimeKind.Utc).AddTicks(6710), new DateTime(2025, 6, 5, 7, 58, 7, 104, DateTimeKind.Utc).AddTicks(6710) });

            migrationBuilder.UpdateData(
                table: "QuestTypes",
                keyColumn: "QuestTypeId",
                keyValue: new Guid("d4e5f6a1-b2c3-4567-890a-bcdef0123456"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 7, 58, 7, 104, DateTimeKind.Utc).AddTicks(6711), new DateTime(2025, 6, 5, 7, 58, 7, 104, DateTimeKind.Utc).AddTicks(6712) });

            migrationBuilder.UpdateData(
                table: "StockAdjustmentTypes",
                keyColumn: "AdjustmentTypeId",
                keyValue: new Guid("01a1b2c3-d4e5-6f78-9012-3456789abc01"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 7, 58, 7, 77, DateTimeKind.Utc).AddTicks(8044), new DateTime(2025, 6, 5, 7, 58, 7, 77, DateTimeKind.Utc).AddTicks(8045) });

            migrationBuilder.UpdateData(
                table: "StockAdjustmentTypes",
                keyColumn: "AdjustmentTypeId",
                keyValue: new Guid("02a1b2c3-d4e5-6f78-9012-3456789abc02"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 7, 58, 7, 77, DateTimeKind.Utc).AddTicks(8051), new DateTime(2025, 6, 5, 7, 58, 7, 77, DateTimeKind.Utc).AddTicks(8052) });

            migrationBuilder.UpdateData(
                table: "StockAdjustmentTypes",
                keyColumn: "AdjustmentTypeId",
                keyValue: new Guid("03a1b2c3-d4e5-6f78-9012-3456789abc03"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 7, 58, 7, 77, DateTimeKind.Utc).AddTicks(8056), new DateTime(2025, 6, 5, 7, 58, 7, 77, DateTimeKind.Utc).AddTicks(8057) });

            migrationBuilder.UpdateData(
                table: "StockAdjustmentTypes",
                keyColumn: "AdjustmentTypeId",
                keyValue: new Guid("04a1b2c3-d4e5-6f78-9012-3456789abc04"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 7, 58, 7, 77, DateTimeKind.Utc).AddTicks(8061), new DateTime(2025, 6, 5, 7, 58, 7, 77, DateTimeKind.Utc).AddTicks(8062) });

            migrationBuilder.UpdateData(
                table: "StockAdjustmentTypes",
                keyColumn: "AdjustmentTypeId",
                keyValue: new Guid("05a1b2c3-d4e5-6f78-9012-3456789abc05"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 7, 58, 7, 77, DateTimeKind.Utc).AddTicks(8066), new DateTime(2025, 6, 5, 7, 58, 7, 77, DateTimeKind.Utc).AddTicks(8067) });

            migrationBuilder.UpdateData(
                table: "StockAdjustmentTypes",
                keyColumn: "AdjustmentTypeId",
                keyValue: new Guid("06a1b2c3-d4e5-6f78-9012-3456789abc06"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 7, 58, 7, 77, DateTimeKind.Utc).AddTicks(8084), new DateTime(2025, 6, 5, 7, 58, 7, 77, DateTimeKind.Utc).AddTicks(8085) });

            migrationBuilder.UpdateData(
                table: "SubscriptionPlans",
                keyColumn: "PlanId",
                keyValue: new Guid("11223344-5566-7788-99aa-bbccddeeff00"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 7, 58, 7, 104, DateTimeKind.Utc).AddTicks(5037), new DateTime(2025, 6, 5, 7, 58, 7, 104, DateTimeKind.Utc).AddTicks(5039) });

            migrationBuilder.UpdateData(
                table: "SubscriptionPlans",
                keyColumn: "PlanId",
                keyValue: new Guid("aabbccdd-eeff-1122-3344-5566778899aa"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 7, 58, 7, 104, DateTimeKind.Utc).AddTicks(5060), new DateTime(2025, 6, 5, 7, 58, 7, 104, DateTimeKind.Utc).AddTicks(5060) });

            migrationBuilder.UpdateData(
                table: "SubscriptionPlans",
                keyColumn: "PlanId",
                keyValue: new Guid("ccddeeff-aabb-3344-5566-778899aabbcc"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 7, 58, 7, 104, DateTimeKind.Utc).AddTicks(5064), new DateTime(2025, 6, 5, 7, 58, 7, 104, DateTimeKind.Utc).AddTicks(5064) });

            migrationBuilder.UpdateData(
                table: "UnitGroups",
                keyColumn: "UnitGroupId",
                keyValue: new Guid("a0000000-0000-0000-0000-000000000001"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 7, 58, 7, 66, DateTimeKind.Utc).AddTicks(9542), new DateTime(2025, 6, 5, 7, 58, 7, 66, DateTimeKind.Utc).AddTicks(9542) });

            migrationBuilder.UpdateData(
                table: "UnitGroups",
                keyColumn: "UnitGroupId",
                keyValue: new Guid("a0000000-0000-0000-0000-000000000002"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 7, 58, 7, 66, DateTimeKind.Utc).AddTicks(9547), new DateTime(2025, 6, 5, 7, 58, 7, 66, DateTimeKind.Utc).AddTicks(9547) });

            migrationBuilder.UpdateData(
                table: "UnitGroups",
                keyColumn: "UnitGroupId",
                keyValue: new Guid("a0000000-0000-0000-0000-000000000003"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 7, 58, 7, 66, DateTimeKind.Utc).AddTicks(9551), new DateTime(2025, 6, 5, 7, 58, 7, 66, DateTimeKind.Utc).AddTicks(9551) });

            migrationBuilder.UpdateData(
                table: "UnitGroups",
                keyColumn: "UnitGroupId",
                keyValue: new Guid("a0000000-0000-0000-0000-000000000004"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 7, 58, 7, 66, DateTimeKind.Utc).AddTicks(9554), new DateTime(2025, 6, 5, 7, 58, 7, 66, DateTimeKind.Utc).AddTicks(9555) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasures",
                keyColumn: "UnitId",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000001"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 7, 58, 7, 68, DateTimeKind.Utc).AddTicks(5541), new DateTime(2025, 6, 5, 7, 58, 7, 68, DateTimeKind.Utc).AddTicks(5542) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasures",
                keyColumn: "UnitId",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000002"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 7, 58, 7, 68, DateTimeKind.Utc).AddTicks(5567), new DateTime(2025, 6, 5, 7, 58, 7, 68, DateTimeKind.Utc).AddTicks(5569) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasures",
                keyColumn: "UnitId",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000003"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 7, 58, 7, 68, DateTimeKind.Utc).AddTicks(5580), new DateTime(2025, 6, 5, 7, 58, 7, 68, DateTimeKind.Utc).AddTicks(5581) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasures",
                keyColumn: "UnitId",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000004"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 7, 58, 7, 68, DateTimeKind.Utc).AddTicks(5601), new DateTime(2025, 6, 5, 7, 58, 7, 68, DateTimeKind.Utc).AddTicks(5602) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasures",
                keyColumn: "UnitId",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000005"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 7, 58, 7, 68, DateTimeKind.Utc).AddTicks(5617), new DateTime(2025, 6, 5, 7, 58, 7, 68, DateTimeKind.Utc).AddTicks(5617) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasures",
                keyColumn: "UnitId",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000006"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 7, 58, 7, 68, DateTimeKind.Utc).AddTicks(5623), new DateTime(2025, 6, 5, 7, 58, 7, 68, DateTimeKind.Utc).AddTicks(5624) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasures",
                keyColumn: "UnitId",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000007"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 7, 58, 7, 68, DateTimeKind.Utc).AddTicks(5630), new DateTime(2025, 6, 5, 7, 58, 7, 68, DateTimeKind.Utc).AddTicks(5631) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasures",
                keyColumn: "UnitId",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000008"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 7, 58, 7, 68, DateTimeKind.Utc).AddTicks(5636), new DateTime(2025, 6, 5, 7, 58, 7, 68, DateTimeKind.Utc).AddTicks(5636) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasures",
                keyColumn: "UnitId",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000009"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 7, 58, 7, 68, DateTimeKind.Utc).AddTicks(5645), new DateTime(2025, 6, 5, 7, 58, 7, 68, DateTimeKind.Utc).AddTicks(5646) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasures",
                keyColumn: "UnitId",
                keyValue: new Guid("b0000000-0000-0000-0000-00000000000a"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 7, 58, 7, 68, DateTimeKind.Utc).AddTicks(5656), new DateTime(2025, 6, 5, 7, 58, 7, 68, DateTimeKind.Utc).AddTicks(5656) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasures",
                keyColumn: "UnitId",
                keyValue: new Guid("b0000000-0000-0000-0000-00000000000b"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 7, 58, 7, 68, DateTimeKind.Utc).AddTicks(5664), new DateTime(2025, 6, 5, 7, 58, 7, 68, DateTimeKind.Utc).AddTicks(5665) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasures",
                keyColumn: "UnitId",
                keyValue: new Guid("b0000000-0000-0000-0000-00000000000c"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 7, 58, 7, 68, DateTimeKind.Utc).AddTicks(5678), new DateTime(2025, 6, 5, 7, 58, 7, 68, DateTimeKind.Utc).AddTicks(5679) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasures",
                keyColumn: "UnitId",
                keyValue: new Guid("b0000000-0000-0000-0000-00000000000d"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 7, 58, 7, 68, DateTimeKind.Utc).AddTicks(5707), new DateTime(2025, 6, 5, 7, 58, 7, 68, DateTimeKind.Utc).AddTicks(5709) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasures",
                keyColumn: "UnitId",
                keyValue: new Guid("b0000000-0000-0000-0000-00000000000e"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 7, 58, 7, 68, DateTimeKind.Utc).AddTicks(5719), new DateTime(2025, 6, 5, 7, 58, 7, 68, DateTimeKind.Utc).AddTicks(5720) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasures",
                keyColumn: "UnitId",
                keyValue: new Guid("b0000000-0000-0000-0000-00000000000f"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 7, 58, 7, 68, DateTimeKind.Utc).AddTicks(5730), new DateTime(2025, 6, 5, 7, 58, 7, 68, DateTimeKind.Utc).AddTicks(5730) });
        }
    }
}
