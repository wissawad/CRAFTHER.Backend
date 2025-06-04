using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRAFTHER.Backend.Migrations
{
    /// <inheritdoc />
    public partial class AddRemarksToUnitConversion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Remarks",
                table: "UnitConversions",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Remarks",
                table: "UnitConversions");

            migrationBuilder.UpdateData(
                table: "Levels",
                keyColumn: "LevelId",
                keyValue: new Guid("a0b1c2d3-e4f5-a6b7-c8d9-e0f1a2b3c4d5"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 4, 7, 31, 15, 303, DateTimeKind.Utc).AddTicks(4031), new DateTime(2025, 6, 4, 7, 31, 15, 303, DateTimeKind.Utc).AddTicks(4031) });

            migrationBuilder.UpdateData(
                table: "Levels",
                keyColumn: "LevelId",
                keyValue: new Guid("b1c2d3e4-f5a6-b7c8-d9e0-f1a2b3c4d5e6"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 4, 7, 31, 15, 303, DateTimeKind.Utc).AddTicks(4033), new DateTime(2025, 6, 4, 7, 31, 15, 303, DateTimeKind.Utc).AddTicks(4034) });

            migrationBuilder.UpdateData(
                table: "Levels",
                keyColumn: "LevelId",
                keyValue: new Guid("c2d3e4f5-a6b7-c8d9-e0f1-a2b3c4d5e6f7"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 4, 7, 31, 15, 303, DateTimeKind.Utc).AddTicks(4036), new DateTime(2025, 6, 4, 7, 31, 15, 303, DateTimeKind.Utc).AddTicks(4036) });

            migrationBuilder.UpdateData(
                table: "Levels",
                keyColumn: "LevelId",
                keyValue: new Guid("e1f2a3b4-c5d6-e7f8-a9b0-c1d2e3f4a5b6"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 4, 7, 31, 15, 303, DateTimeKind.Utc).AddTicks(4022), new DateTime(2025, 6, 4, 7, 31, 15, 303, DateTimeKind.Utc).AddTicks(4023) });

            migrationBuilder.UpdateData(
                table: "Levels",
                keyColumn: "LevelId",
                keyValue: new Guid("f2a3b4c5-d6e7-f8a9-b0c1-d2e3f4a5b6c7"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 4, 7, 31, 15, 303, DateTimeKind.Utc).AddTicks(4028), new DateTime(2025, 6, 4, 7, 31, 15, 303, DateTimeKind.Utc).AddTicks(4028) });

            migrationBuilder.UpdateData(
                table: "OrganizationIndustryTypes",
                keyColumn: "IndustryTypeId",
                keyValue: new Guid("a1b2c3d4-e5f6-7890-1234-567890abcdef"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 4, 7, 31, 15, 303, DateTimeKind.Utc).AddTicks(3858), new DateTime(2025, 6, 4, 7, 31, 15, 303, DateTimeKind.Utc).AddTicks(3861) });

            migrationBuilder.UpdateData(
                table: "OrganizationIndustryTypes",
                keyColumn: "IndustryTypeId",
                keyValue: new Guid("b2c3d4e5-f6a1-2345-6789-0abcdef12345"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 4, 7, 31, 15, 303, DateTimeKind.Utc).AddTicks(3864), new DateTime(2025, 6, 4, 7, 31, 15, 303, DateTimeKind.Utc).AddTicks(3864) });

            migrationBuilder.UpdateData(
                table: "OrganizationIndustryTypes",
                keyColumn: "IndustryTypeId",
                keyValue: new Guid("c3d4e5f6-a1b2-3456-7890-cdef12345678"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 4, 7, 31, 15, 303, DateTimeKind.Utc).AddTicks(3866), new DateTime(2025, 6, 4, 7, 31, 15, 303, DateTimeKind.Utc).AddTicks(3866) });

            migrationBuilder.UpdateData(
                table: "OrganizationIndustryTypes",
                keyColumn: "IndustryTypeId",
                keyValue: new Guid("d4e5f6a1-b2c3-4567-890a-bcdef1234567"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 4, 7, 31, 15, 303, DateTimeKind.Utc).AddTicks(3875), new DateTime(2025, 6, 4, 7, 31, 15, 303, DateTimeKind.Utc).AddTicks(3875) });

            migrationBuilder.UpdateData(
                table: "QuestTypes",
                keyColumn: "QuestTypeId",
                keyValue: new Guid("a1b2c3d4-e5f6-7890-abcd-ef0123456789"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 4, 7, 31, 15, 303, DateTimeKind.Utc).AddTicks(3985), new DateTime(2025, 6, 4, 7, 31, 15, 303, DateTimeKind.Utc).AddTicks(3985) });

            migrationBuilder.UpdateData(
                table: "QuestTypes",
                keyColumn: "QuestTypeId",
                keyValue: new Guid("b2c3d4e5-f6a1-2345-cdef-0123456789ab"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 4, 7, 31, 15, 303, DateTimeKind.Utc).AddTicks(3988), new DateTime(2025, 6, 4, 7, 31, 15, 303, DateTimeKind.Utc).AddTicks(3988) });

            migrationBuilder.UpdateData(
                table: "QuestTypes",
                keyColumn: "QuestTypeId",
                keyValue: new Guid("c3d4e5f6-a1b2-3456-7890-abcdef012345"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 4, 7, 31, 15, 303, DateTimeKind.Utc).AddTicks(3990), new DateTime(2025, 6, 4, 7, 31, 15, 303, DateTimeKind.Utc).AddTicks(3990) });

            migrationBuilder.UpdateData(
                table: "QuestTypes",
                keyColumn: "QuestTypeId",
                keyValue: new Guid("d4e5f6a1-b2c3-4567-890a-bcdef0123456"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 4, 7, 31, 15, 303, DateTimeKind.Utc).AddTicks(3992), new DateTime(2025, 6, 4, 7, 31, 15, 303, DateTimeKind.Utc).AddTicks(3992) });

            migrationBuilder.UpdateData(
                table: "StockAdjustmentTypes",
                keyColumn: "AdjustmentTypeId",
                keyValue: new Guid("01a1b2c3-d4e5-6f78-9012-3456789abc01"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 4, 7, 31, 15, 291, DateTimeKind.Utc).AddTicks(7356), new DateTime(2025, 6, 4, 7, 31, 15, 291, DateTimeKind.Utc).AddTicks(7356) });

            migrationBuilder.UpdateData(
                table: "StockAdjustmentTypes",
                keyColumn: "AdjustmentTypeId",
                keyValue: new Guid("02a1b2c3-d4e5-6f78-9012-3456789abc02"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 4, 7, 31, 15, 291, DateTimeKind.Utc).AddTicks(7377), new DateTime(2025, 6, 4, 7, 31, 15, 291, DateTimeKind.Utc).AddTicks(7378) });

            migrationBuilder.UpdateData(
                table: "StockAdjustmentTypes",
                keyColumn: "AdjustmentTypeId",
                keyValue: new Guid("03a1b2c3-d4e5-6f78-9012-3456789abc03"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 4, 7, 31, 15, 291, DateTimeKind.Utc).AddTicks(7382), new DateTime(2025, 6, 4, 7, 31, 15, 291, DateTimeKind.Utc).AddTicks(7382) });

            migrationBuilder.UpdateData(
                table: "StockAdjustmentTypes",
                keyColumn: "AdjustmentTypeId",
                keyValue: new Guid("04a1b2c3-d4e5-6f78-9012-3456789abc04"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 4, 7, 31, 15, 291, DateTimeKind.Utc).AddTicks(7387), new DateTime(2025, 6, 4, 7, 31, 15, 291, DateTimeKind.Utc).AddTicks(7388) });

            migrationBuilder.UpdateData(
                table: "StockAdjustmentTypes",
                keyColumn: "AdjustmentTypeId",
                keyValue: new Guid("05a1b2c3-d4e5-6f78-9012-3456789abc05"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 4, 7, 31, 15, 291, DateTimeKind.Utc).AddTicks(7392), new DateTime(2025, 6, 4, 7, 31, 15, 291, DateTimeKind.Utc).AddTicks(7393) });

            migrationBuilder.UpdateData(
                table: "StockAdjustmentTypes",
                keyColumn: "AdjustmentTypeId",
                keyValue: new Guid("06a1b2c3-d4e5-6f78-9012-3456789abc06"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 4, 7, 31, 15, 291, DateTimeKind.Utc).AddTicks(7397), new DateTime(2025, 6, 4, 7, 31, 15, 291, DateTimeKind.Utc).AddTicks(7398) });

            migrationBuilder.UpdateData(
                table: "SubscriptionPlans",
                keyColumn: "PlanId",
                keyValue: new Guid("11223344-5566-7788-99aa-bbccddeeff00"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 4, 7, 31, 15, 303, DateTimeKind.Utc).AddTicks(3938), new DateTime(2025, 6, 4, 7, 31, 15, 303, DateTimeKind.Utc).AddTicks(3939) });

            migrationBuilder.UpdateData(
                table: "SubscriptionPlans",
                keyColumn: "PlanId",
                keyValue: new Guid("aabbccdd-eeff-1122-3344-5566778899aa"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 4, 7, 31, 15, 303, DateTimeKind.Utc).AddTicks(3947), new DateTime(2025, 6, 4, 7, 31, 15, 303, DateTimeKind.Utc).AddTicks(3948) });

            migrationBuilder.UpdateData(
                table: "SubscriptionPlans",
                keyColumn: "PlanId",
                keyValue: new Guid("ccddeeff-aabb-3344-5566-778899aabbcc"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 4, 7, 31, 15, 303, DateTimeKind.Utc).AddTicks(3951), new DateTime(2025, 6, 4, 7, 31, 15, 303, DateTimeKind.Utc).AddTicks(3951) });

            migrationBuilder.UpdateData(
                table: "UnitGroups",
                keyColumn: "UnitGroupId",
                keyValue: new Guid("a0000000-0000-0000-0000-000000000001"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 4, 7, 31, 15, 286, DateTimeKind.Utc).AddTicks(5166), new DateTime(2025, 6, 4, 7, 31, 15, 286, DateTimeKind.Utc).AddTicks(5167) });

            migrationBuilder.UpdateData(
                table: "UnitGroups",
                keyColumn: "UnitGroupId",
                keyValue: new Guid("a0000000-0000-0000-0000-000000000002"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 4, 7, 31, 15, 286, DateTimeKind.Utc).AddTicks(5176), new DateTime(2025, 6, 4, 7, 31, 15, 286, DateTimeKind.Utc).AddTicks(5178) });

            migrationBuilder.UpdateData(
                table: "UnitGroups",
                keyColumn: "UnitGroupId",
                keyValue: new Guid("a0000000-0000-0000-0000-000000000003"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 4, 7, 31, 15, 286, DateTimeKind.Utc).AddTicks(5183), new DateTime(2025, 6, 4, 7, 31, 15, 286, DateTimeKind.Utc).AddTicks(5184) });

            migrationBuilder.UpdateData(
                table: "UnitGroups",
                keyColumn: "UnitGroupId",
                keyValue: new Guid("a0000000-0000-0000-0000-000000000004"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 4, 7, 31, 15, 286, DateTimeKind.Utc).AddTicks(5195), new DateTime(2025, 6, 4, 7, 31, 15, 286, DateTimeKind.Utc).AddTicks(5196) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasures",
                keyColumn: "UnitId",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000001"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 4, 7, 31, 15, 287, DateTimeKind.Utc).AddTicks(7356), new DateTime(2025, 6, 4, 7, 31, 15, 287, DateTimeKind.Utc).AddTicks(7358) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasures",
                keyColumn: "UnitId",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000002"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 4, 7, 31, 15, 287, DateTimeKind.Utc).AddTicks(7371), new DateTime(2025, 6, 4, 7, 31, 15, 287, DateTimeKind.Utc).AddTicks(7372) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasures",
                keyColumn: "UnitId",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000003"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 4, 7, 31, 15, 287, DateTimeKind.Utc).AddTicks(7384), new DateTime(2025, 6, 4, 7, 31, 15, 287, DateTimeKind.Utc).AddTicks(7384) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasures",
                keyColumn: "UnitId",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000004"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 4, 7, 31, 15, 287, DateTimeKind.Utc).AddTicks(7393), new DateTime(2025, 6, 4, 7, 31, 15, 287, DateTimeKind.Utc).AddTicks(7394) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasures",
                keyColumn: "UnitId",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000005"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 4, 7, 31, 15, 287, DateTimeKind.Utc).AddTicks(7400), new DateTime(2025, 6, 4, 7, 31, 15, 287, DateTimeKind.Utc).AddTicks(7402) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasures",
                keyColumn: "UnitId",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000006"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 4, 7, 31, 15, 287, DateTimeKind.Utc).AddTicks(7412), new DateTime(2025, 6, 4, 7, 31, 15, 287, DateTimeKind.Utc).AddTicks(7413) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasures",
                keyColumn: "UnitId",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000007"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 4, 7, 31, 15, 287, DateTimeKind.Utc).AddTicks(7424), new DateTime(2025, 6, 4, 7, 31, 15, 287, DateTimeKind.Utc).AddTicks(7425) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasures",
                keyColumn: "UnitId",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000008"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 4, 7, 31, 15, 287, DateTimeKind.Utc).AddTicks(7433), new DateTime(2025, 6, 4, 7, 31, 15, 287, DateTimeKind.Utc).AddTicks(7435) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasures",
                keyColumn: "UnitId",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000009"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 4, 7, 31, 15, 287, DateTimeKind.Utc).AddTicks(7450), new DateTime(2025, 6, 4, 7, 31, 15, 287, DateTimeKind.Utc).AddTicks(7451) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasures",
                keyColumn: "UnitId",
                keyValue: new Guid("b0000000-0000-0000-0000-00000000000a"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 4, 7, 31, 15, 287, DateTimeKind.Utc).AddTicks(7459), new DateTime(2025, 6, 4, 7, 31, 15, 287, DateTimeKind.Utc).AddTicks(7461) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasures",
                keyColumn: "UnitId",
                keyValue: new Guid("b0000000-0000-0000-0000-00000000000b"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 4, 7, 31, 15, 287, DateTimeKind.Utc).AddTicks(7470), new DateTime(2025, 6, 4, 7, 31, 15, 287, DateTimeKind.Utc).AddTicks(7470) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasures",
                keyColumn: "UnitId",
                keyValue: new Guid("b0000000-0000-0000-0000-00000000000c"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 4, 7, 31, 15, 287, DateTimeKind.Utc).AddTicks(7479), new DateTime(2025, 6, 4, 7, 31, 15, 287, DateTimeKind.Utc).AddTicks(7480) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasures",
                keyColumn: "UnitId",
                keyValue: new Guid("b0000000-0000-0000-0000-00000000000d"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 4, 7, 31, 15, 287, DateTimeKind.Utc).AddTicks(7490), new DateTime(2025, 6, 4, 7, 31, 15, 287, DateTimeKind.Utc).AddTicks(7490) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasures",
                keyColumn: "UnitId",
                keyValue: new Guid("b0000000-0000-0000-0000-00000000000e"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 4, 7, 31, 15, 287, DateTimeKind.Utc).AddTicks(7502), new DateTime(2025, 6, 4, 7, 31, 15, 287, DateTimeKind.Utc).AddTicks(7502) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasures",
                keyColumn: "UnitId",
                keyValue: new Guid("b0000000-0000-0000-0000-00000000000f"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 4, 7, 31, 15, 287, DateTimeKind.Utc).AddTicks(7514), new DateTime(2025, 6, 4, 7, 31, 15, 287, DateTimeKind.Utc).AddTicks(7514) });
        }
    }
}
