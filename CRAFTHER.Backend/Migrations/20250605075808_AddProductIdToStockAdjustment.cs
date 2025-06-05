using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRAFTHER.Backend.Migrations
{
    /// <inheritdoc />
    public partial class AddProductIdToStockAdjustment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_StockAdjustments_ComponentId",
                table: "StockAdjustments");

            migrationBuilder.AlterColumn<Guid>(
                name: "ComponentId",
                table: "StockAdjustments",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "ProductId",
                table: "StockAdjustments",
                type: "uniqueidentifier",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_StockAdjustments_ComponentId_ProductId_NotNull",
                table: "StockAdjustments",
                columns: new[] { "ComponentId", "ProductId" },
                unique: true,
                filter: "[ComponentId] IS NOT NULL AND [ProductId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_StockAdjustments_ProductId",
                table: "StockAdjustments",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_StockAdjustments_Products_ProductId",
                table: "StockAdjustments",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StockAdjustments_Products_ProductId",
                table: "StockAdjustments");

            migrationBuilder.DropIndex(
                name: "IX_StockAdjustments_ComponentId_ProductId_NotNull",
                table: "StockAdjustments");

            migrationBuilder.DropIndex(
                name: "IX_StockAdjustments_ProductId",
                table: "StockAdjustments");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "StockAdjustments");

            migrationBuilder.AlterColumn<Guid>(
                name: "ComponentId",
                table: "StockAdjustments",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

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
                name: "IX_StockAdjustments_ComponentId",
                table: "StockAdjustments",
                column: "ComponentId");
        }
    }
}
