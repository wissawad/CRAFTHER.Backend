using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRAFTHER.Backend.Migrations
{
    /// <inheritdoc />
    public partial class AddComponentPriceHistory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ComponentPriceHistories",
                columns: table => new
                {
                    ComponentPriceHistoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ComponentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OldUnitPrice = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    NewUnitPrice = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    ChangeDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ChangedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    OrganizationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComponentPriceHistories", x => x.ComponentPriceHistoryId);
                    table.ForeignKey(
                        name: "FK_ComponentPriceHistories_Components_ComponentId",
                        column: x => x.ComponentId,
                        principalTable: "Components",
                        principalColumn: "ComponentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComponentPriceHistories_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "OrganizationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ComponentPriceHistories_Users_ChangedByUserId",
                        column: x => x.ChangedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "ItemCategoryId",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000001"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 10, 9, 4, 3, DateTimeKind.Utc).AddTicks(6468), new DateTime(2025, 6, 5, 10, 9, 4, 3, DateTimeKind.Utc).AddTicks(6469) });

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "ItemCategoryId",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000002"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 10, 9, 4, 3, DateTimeKind.Utc).AddTicks(6479), new DateTime(2025, 6, 5, 10, 9, 4, 3, DateTimeKind.Utc).AddTicks(6480) });

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "ItemCategoryId",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000003"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 10, 9, 4, 3, DateTimeKind.Utc).AddTicks(6484), new DateTime(2025, 6, 5, 10, 9, 4, 3, DateTimeKind.Utc).AddTicks(6484) });

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "ItemCategoryId",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000004"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 10, 9, 4, 3, DateTimeKind.Utc).AddTicks(6493), new DateTime(2025, 6, 5, 10, 9, 4, 3, DateTimeKind.Utc).AddTicks(6493) });

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "ItemCategoryId",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000005"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 10, 9, 4, 3, DateTimeKind.Utc).AddTicks(6496), new DateTime(2025, 6, 5, 10, 9, 4, 3, DateTimeKind.Utc).AddTicks(6497) });

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "ItemCategoryId",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000006"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 10, 9, 4, 3, DateTimeKind.Utc).AddTicks(6499), new DateTime(2025, 6, 5, 10, 9, 4, 3, DateTimeKind.Utc).AddTicks(6500) });

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "ItemCategoryId",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000007"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 10, 9, 4, 3, DateTimeKind.Utc).AddTicks(6503), new DateTime(2025, 6, 5, 10, 9, 4, 3, DateTimeKind.Utc).AddTicks(6504) });

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "ItemCategoryId",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000008"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 10, 9, 4, 3, DateTimeKind.Utc).AddTicks(6506), new DateTime(2025, 6, 5, 10, 9, 4, 3, DateTimeKind.Utc).AddTicks(6507) });

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "ItemCategoryId",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000009"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 10, 9, 4, 3, DateTimeKind.Utc).AddTicks(6510), new DateTime(2025, 6, 5, 10, 9, 4, 3, DateTimeKind.Utc).AddTicks(6510) });

            migrationBuilder.UpdateData(
                table: "Levels",
                keyColumn: "LevelId",
                keyValue: new Guid("a0b1c2d3-e4f5-a6b7-c8d9-e0f1a2b3c4d5"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 10, 9, 4, 3, DateTimeKind.Utc).AddTicks(6647), new DateTime(2025, 6, 5, 10, 9, 4, 3, DateTimeKind.Utc).AddTicks(6647) });

            migrationBuilder.UpdateData(
                table: "Levels",
                keyColumn: "LevelId",
                keyValue: new Guid("b1c2d3e4-f5a6-b7c8-d9e0-f1a2b3c4d5e6"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 10, 9, 4, 3, DateTimeKind.Utc).AddTicks(6650), new DateTime(2025, 6, 5, 10, 9, 4, 3, DateTimeKind.Utc).AddTicks(6650) });

            migrationBuilder.UpdateData(
                table: "Levels",
                keyColumn: "LevelId",
                keyValue: new Guid("c2d3e4f5-a6b7-c8d9-e0f1-a2b3c4d5e6f7"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 10, 9, 4, 3, DateTimeKind.Utc).AddTicks(6653), new DateTime(2025, 6, 5, 10, 9, 4, 3, DateTimeKind.Utc).AddTicks(6653) });

            migrationBuilder.UpdateData(
                table: "Levels",
                keyColumn: "LevelId",
                keyValue: new Guid("e1f2a3b4-c5d6-e7f8-a9b0-c1d2e3f4a5b6"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 10, 9, 4, 3, DateTimeKind.Utc).AddTicks(6638), new DateTime(2025, 6, 5, 10, 9, 4, 3, DateTimeKind.Utc).AddTicks(6639) });

            migrationBuilder.UpdateData(
                table: "Levels",
                keyColumn: "LevelId",
                keyValue: new Guid("f2a3b4c5-d6e7-f8a9-b0c1-d2e3f4a5b6c7"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 10, 9, 4, 3, DateTimeKind.Utc).AddTicks(6644), new DateTime(2025, 6, 5, 10, 9, 4, 3, DateTimeKind.Utc).AddTicks(6644) });

            migrationBuilder.UpdateData(
                table: "OrganizationIndustryTypes",
                keyColumn: "IndustryTypeId",
                keyValue: new Guid("a1b2c3d4-e5f6-7890-1234-567890abcdef"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 10, 9, 4, 3, DateTimeKind.Utc).AddTicks(5270), new DateTime(2025, 6, 5, 10, 9, 4, 3, DateTimeKind.Utc).AddTicks(5273) });

            migrationBuilder.UpdateData(
                table: "OrganizationIndustryTypes",
                keyColumn: "IndustryTypeId",
                keyValue: new Guid("b2c3d4e5-f6a1-2345-6789-0abcdef12345"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 10, 9, 4, 3, DateTimeKind.Utc).AddTicks(5276), new DateTime(2025, 6, 5, 10, 9, 4, 3, DateTimeKind.Utc).AddTicks(5276) });

            migrationBuilder.UpdateData(
                table: "OrganizationIndustryTypes",
                keyColumn: "IndustryTypeId",
                keyValue: new Guid("c3d4e5f6-a1b2-3456-7890-cdef12345678"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 10, 9, 4, 3, DateTimeKind.Utc).AddTicks(5287), new DateTime(2025, 6, 5, 10, 9, 4, 3, DateTimeKind.Utc).AddTicks(5287) });

            migrationBuilder.UpdateData(
                table: "OrganizationIndustryTypes",
                keyColumn: "IndustryTypeId",
                keyValue: new Guid("d4e5f6a1-b2c3-4567-890a-bcdef1234567"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 10, 9, 4, 3, DateTimeKind.Utc).AddTicks(5289), new DateTime(2025, 6, 5, 10, 9, 4, 3, DateTimeKind.Utc).AddTicks(5290) });

            migrationBuilder.UpdateData(
                table: "QuestTypes",
                keyColumn: "QuestTypeId",
                keyValue: new Guid("a1b2c3d4-e5f6-7890-abcd-ef0123456789"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 10, 9, 4, 3, DateTimeKind.Utc).AddTicks(6587), new DateTime(2025, 6, 5, 10, 9, 4, 3, DateTimeKind.Utc).AddTicks(6587) });

            migrationBuilder.UpdateData(
                table: "QuestTypes",
                keyColumn: "QuestTypeId",
                keyValue: new Guid("b2c3d4e5-f6a1-2345-cdef-0123456789ab"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 10, 9, 4, 3, DateTimeKind.Utc).AddTicks(6591), new DateTime(2025, 6, 5, 10, 9, 4, 3, DateTimeKind.Utc).AddTicks(6591) });

            migrationBuilder.UpdateData(
                table: "QuestTypes",
                keyColumn: "QuestTypeId",
                keyValue: new Guid("c3d4e5f6-a1b2-3456-7890-abcdef012345"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 10, 9, 4, 3, DateTimeKind.Utc).AddTicks(6595), new DateTime(2025, 6, 5, 10, 9, 4, 3, DateTimeKind.Utc).AddTicks(6596) });

            migrationBuilder.UpdateData(
                table: "QuestTypes",
                keyColumn: "QuestTypeId",
                keyValue: new Guid("d4e5f6a1-b2c3-4567-890a-bcdef0123456"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 10, 9, 4, 3, DateTimeKind.Utc).AddTicks(6597), new DateTime(2025, 6, 5, 10, 9, 4, 3, DateTimeKind.Utc).AddTicks(6598) });

            migrationBuilder.UpdateData(
                table: "StockAdjustmentTypes",
                keyColumn: "AdjustmentTypeId",
                keyValue: new Guid("01a1b2c3-d4e5-6f78-9012-3456789abc01"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 10, 9, 3, 985, DateTimeKind.Utc).AddTicks(6130), new DateTime(2025, 6, 5, 10, 9, 3, 985, DateTimeKind.Utc).AddTicks(6131) });

            migrationBuilder.UpdateData(
                table: "StockAdjustmentTypes",
                keyColumn: "AdjustmentTypeId",
                keyValue: new Guid("02a1b2c3-d4e5-6f78-9012-3456789abc02"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 10, 9, 3, 985, DateTimeKind.Utc).AddTicks(6138), new DateTime(2025, 6, 5, 10, 9, 3, 985, DateTimeKind.Utc).AddTicks(6138) });

            migrationBuilder.UpdateData(
                table: "StockAdjustmentTypes",
                keyColumn: "AdjustmentTypeId",
                keyValue: new Guid("03a1b2c3-d4e5-6f78-9012-3456789abc03"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 10, 9, 3, 985, DateTimeKind.Utc).AddTicks(6145), new DateTime(2025, 6, 5, 10, 9, 3, 985, DateTimeKind.Utc).AddTicks(6146) });

            migrationBuilder.UpdateData(
                table: "StockAdjustmentTypes",
                keyColumn: "AdjustmentTypeId",
                keyValue: new Guid("04a1b2c3-d4e5-6f78-9012-3456789abc04"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 10, 9, 3, 985, DateTimeKind.Utc).AddTicks(6171), new DateTime(2025, 6, 5, 10, 9, 3, 985, DateTimeKind.Utc).AddTicks(6172) });

            migrationBuilder.UpdateData(
                table: "StockAdjustmentTypes",
                keyColumn: "AdjustmentTypeId",
                keyValue: new Guid("05a1b2c3-d4e5-6f78-9012-3456789abc05"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 10, 9, 3, 985, DateTimeKind.Utc).AddTicks(6177), new DateTime(2025, 6, 5, 10, 9, 3, 985, DateTimeKind.Utc).AddTicks(6178) });

            migrationBuilder.UpdateData(
                table: "StockAdjustmentTypes",
                keyColumn: "AdjustmentTypeId",
                keyValue: new Guid("06a1b2c3-d4e5-6f78-9012-3456789abc06"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 10, 9, 3, 985, DateTimeKind.Utc).AddTicks(6186), new DateTime(2025, 6, 5, 10, 9, 3, 985, DateTimeKind.Utc).AddTicks(6187) });

            migrationBuilder.UpdateData(
                table: "SubscriptionPlans",
                keyColumn: "PlanId",
                keyValue: new Guid("11223344-5566-7788-99aa-bbccddeeff00"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 10, 9, 4, 3, DateTimeKind.Utc).AddTicks(5365), new DateTime(2025, 6, 5, 10, 9, 4, 3, DateTimeKind.Utc).AddTicks(5365) });

            migrationBuilder.UpdateData(
                table: "SubscriptionPlans",
                keyColumn: "PlanId",
                keyValue: new Guid("aabbccdd-eeff-1122-3344-5566778899aa"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 10, 9, 4, 3, DateTimeKind.Utc).AddTicks(5376), new DateTime(2025, 6, 5, 10, 9, 4, 3, DateTimeKind.Utc).AddTicks(5376) });

            migrationBuilder.UpdateData(
                table: "SubscriptionPlans",
                keyColumn: "PlanId",
                keyValue: new Guid("ccddeeff-aabb-3344-5566-778899aabbcc"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 10, 9, 4, 3, DateTimeKind.Utc).AddTicks(5380), new DateTime(2025, 6, 5, 10, 9, 4, 3, DateTimeKind.Utc).AddTicks(5380) });

            migrationBuilder.UpdateData(
                table: "UnitGroups",
                keyColumn: "UnitGroupId",
                keyValue: new Guid("a0000000-0000-0000-0000-000000000001"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 10, 9, 3, 977, DateTimeKind.Utc).AddTicks(6399), new DateTime(2025, 6, 5, 10, 9, 3, 977, DateTimeKind.Utc).AddTicks(6400) });

            migrationBuilder.UpdateData(
                table: "UnitGroups",
                keyColumn: "UnitGroupId",
                keyValue: new Guid("a0000000-0000-0000-0000-000000000002"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 10, 9, 3, 977, DateTimeKind.Utc).AddTicks(6409), new DateTime(2025, 6, 5, 10, 9, 3, 977, DateTimeKind.Utc).AddTicks(6410) });

            migrationBuilder.UpdateData(
                table: "UnitGroups",
                keyColumn: "UnitGroupId",
                keyValue: new Guid("a0000000-0000-0000-0000-000000000003"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 10, 9, 3, 977, DateTimeKind.Utc).AddTicks(6414), new DateTime(2025, 6, 5, 10, 9, 3, 977, DateTimeKind.Utc).AddTicks(6414) });

            migrationBuilder.UpdateData(
                table: "UnitGroups",
                keyColumn: "UnitGroupId",
                keyValue: new Guid("a0000000-0000-0000-0000-000000000004"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 10, 9, 3, 977, DateTimeKind.Utc).AddTicks(6419), new DateTime(2025, 6, 5, 10, 9, 3, 977, DateTimeKind.Utc).AddTicks(6419) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasures",
                keyColumn: "UnitId",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000001"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 10, 9, 3, 979, DateTimeKind.Utc).AddTicks(6000), new DateTime(2025, 6, 5, 10, 9, 3, 979, DateTimeKind.Utc).AddTicks(6001) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasures",
                keyColumn: "UnitId",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000002"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 10, 9, 3, 979, DateTimeKind.Utc).AddTicks(6030), new DateTime(2025, 6, 5, 10, 9, 3, 979, DateTimeKind.Utc).AddTicks(6031) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasures",
                keyColumn: "UnitId",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000003"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 10, 9, 3, 979, DateTimeKind.Utc).AddTicks(6042), new DateTime(2025, 6, 5, 10, 9, 3, 979, DateTimeKind.Utc).AddTicks(6043) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasures",
                keyColumn: "UnitId",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000004"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 10, 9, 3, 979, DateTimeKind.Utc).AddTicks(6065), new DateTime(2025, 6, 5, 10, 9, 3, 979, DateTimeKind.Utc).AddTicks(6066) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasures",
                keyColumn: "UnitId",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000005"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 10, 9, 3, 979, DateTimeKind.Utc).AddTicks(6078), new DateTime(2025, 6, 5, 10, 9, 3, 979, DateTimeKind.Utc).AddTicks(6079) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasures",
                keyColumn: "UnitId",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000006"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 10, 9, 3, 979, DateTimeKind.Utc).AddTicks(6091), new DateTime(2025, 6, 5, 10, 9, 3, 979, DateTimeKind.Utc).AddTicks(6092) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasures",
                keyColumn: "UnitId",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000007"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 10, 9, 3, 979, DateTimeKind.Utc).AddTicks(6104), new DateTime(2025, 6, 5, 10, 9, 3, 979, DateTimeKind.Utc).AddTicks(6105) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasures",
                keyColumn: "UnitId",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000008"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 10, 9, 3, 979, DateTimeKind.Utc).AddTicks(6114), new DateTime(2025, 6, 5, 10, 9, 3, 979, DateTimeKind.Utc).AddTicks(6115) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasures",
                keyColumn: "UnitId",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000009"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 10, 9, 3, 979, DateTimeKind.Utc).AddTicks(6122), new DateTime(2025, 6, 5, 10, 9, 3, 979, DateTimeKind.Utc).AddTicks(6124) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasures",
                keyColumn: "UnitId",
                keyValue: new Guid("b0000000-0000-0000-0000-00000000000a"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 10, 9, 3, 979, DateTimeKind.Utc).AddTicks(6137), new DateTime(2025, 6, 5, 10, 9, 3, 979, DateTimeKind.Utc).AddTicks(6138) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasures",
                keyColumn: "UnitId",
                keyValue: new Guid("b0000000-0000-0000-0000-00000000000b"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 10, 9, 3, 979, DateTimeKind.Utc).AddTicks(6148), new DateTime(2025, 6, 5, 10, 9, 3, 979, DateTimeKind.Utc).AddTicks(6149) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasures",
                keyColumn: "UnitId",
                keyValue: new Guid("b0000000-0000-0000-0000-00000000000c"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 10, 9, 3, 979, DateTimeKind.Utc).AddTicks(6163), new DateTime(2025, 6, 5, 10, 9, 3, 979, DateTimeKind.Utc).AddTicks(6163) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasures",
                keyColumn: "UnitId",
                keyValue: new Guid("b0000000-0000-0000-0000-00000000000d"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 10, 9, 3, 979, DateTimeKind.Utc).AddTicks(6195), new DateTime(2025, 6, 5, 10, 9, 3, 979, DateTimeKind.Utc).AddTicks(6196) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasures",
                keyColumn: "UnitId",
                keyValue: new Guid("b0000000-0000-0000-0000-00000000000e"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 10, 9, 3, 979, DateTimeKind.Utc).AddTicks(6206), new DateTime(2025, 6, 5, 10, 9, 3, 979, DateTimeKind.Utc).AddTicks(6207) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasures",
                keyColumn: "UnitId",
                keyValue: new Guid("b0000000-0000-0000-0000-00000000000f"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 10, 9, 3, 979, DateTimeKind.Utc).AddTicks(6224), new DateTime(2025, 6, 5, 10, 9, 3, 979, DateTimeKind.Utc).AddTicks(6226) });

            migrationBuilder.CreateIndex(
                name: "IX_ComponentPriceHistories_ChangedByUserId",
                table: "ComponentPriceHistories",
                column: "ChangedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ComponentPriceHistories_ComponentId",
                table: "ComponentPriceHistories",
                column: "ComponentId");

            migrationBuilder.CreateIndex(
                name: "IX_ComponentPriceHistories_OrganizationId",
                table: "ComponentPriceHistories",
                column: "OrganizationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComponentPriceHistories");

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
    }
}
