using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRAFTHER.Backend.Migrations
{
    /// <inheritdoc />
    public partial class AddUnitConversion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.UpdateData(
                table: "Levels",
                keyColumn: "LevelId",
                keyValue: new Guid("a0b1c2d3-e4f5-a6b7-c8d9-e0f1a2b3c4d5"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 3, 12, 22, 51, 628, DateTimeKind.Utc).AddTicks(5069), new DateTime(2025, 6, 3, 12, 22, 51, 628, DateTimeKind.Utc).AddTicks(5069) });

            migrationBuilder.UpdateData(
                table: "Levels",
                keyColumn: "LevelId",
                keyValue: new Guid("b1c2d3e4-f5a6-b7c8-d9e0-f1a2b3c4d5e6"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 3, 12, 22, 51, 628, DateTimeKind.Utc).AddTicks(5074), new DateTime(2025, 6, 3, 12, 22, 51, 628, DateTimeKind.Utc).AddTicks(5074) });

            migrationBuilder.UpdateData(
                table: "Levels",
                keyColumn: "LevelId",
                keyValue: new Guid("c2d3e4f5-a6b7-c8d9-e0f1-a2b3c4d5e6f7"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 3, 12, 22, 51, 628, DateTimeKind.Utc).AddTicks(5076), new DateTime(2025, 6, 3, 12, 22, 51, 628, DateTimeKind.Utc).AddTicks(5077) });

            migrationBuilder.UpdateData(
                table: "Levels",
                keyColumn: "LevelId",
                keyValue: new Guid("e1f2a3b4-c5d6-e7f8-a9b0-c1d2e3f4a5b6"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 3, 12, 22, 51, 628, DateTimeKind.Utc).AddTicks(5057), new DateTime(2025, 6, 3, 12, 22, 51, 628, DateTimeKind.Utc).AddTicks(5057) });

            migrationBuilder.UpdateData(
                table: "Levels",
                keyColumn: "LevelId",
                keyValue: new Guid("f2a3b4c5-d6e7-f8a9-b0c1-d2e3f4a5b6c7"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 3, 12, 22, 51, 628, DateTimeKind.Utc).AddTicks(5066), new DateTime(2025, 6, 3, 12, 22, 51, 628, DateTimeKind.Utc).AddTicks(5066) });

            migrationBuilder.UpdateData(
                table: "OrganizationIndustryTypes",
                keyColumn: "IndustryTypeId",
                keyValue: new Guid("a1b2c3d4-e5f6-7890-1234-567890abcdef"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 3, 12, 22, 51, 628, DateTimeKind.Utc).AddTicks(4388), new DateTime(2025, 6, 3, 12, 22, 51, 628, DateTimeKind.Utc).AddTicks(4391) });

            migrationBuilder.UpdateData(
                table: "OrganizationIndustryTypes",
                keyColumn: "IndustryTypeId",
                keyValue: new Guid("b2c3d4e5-f6a1-2345-6789-0abcdef12345"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 3, 12, 22, 51, 628, DateTimeKind.Utc).AddTicks(4395), new DateTime(2025, 6, 3, 12, 22, 51, 628, DateTimeKind.Utc).AddTicks(4395) });

            migrationBuilder.UpdateData(
                table: "OrganizationIndustryTypes",
                keyColumn: "IndustryTypeId",
                keyValue: new Guid("c3d4e5f6-a1b2-3456-7890-cdef12345678"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 3, 12, 22, 51, 628, DateTimeKind.Utc).AddTicks(4406), new DateTime(2025, 6, 3, 12, 22, 51, 628, DateTimeKind.Utc).AddTicks(4406) });

            migrationBuilder.UpdateData(
                table: "OrganizationIndustryTypes",
                keyColumn: "IndustryTypeId",
                keyValue: new Guid("d4e5f6a1-b2c3-4567-890a-bcdef1234567"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 3, 12, 22, 51, 628, DateTimeKind.Utc).AddTicks(4408), new DateTime(2025, 6, 3, 12, 22, 51, 628, DateTimeKind.Utc).AddTicks(4409) });

            migrationBuilder.UpdateData(
                table: "QuestTypes",
                keyColumn: "QuestTypeId",
                keyValue: new Guid("a1b2c3d4-e5f6-7890-abcd-ef0123456789"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 3, 12, 22, 51, 628, DateTimeKind.Utc).AddTicks(5002), new DateTime(2025, 6, 3, 12, 22, 51, 628, DateTimeKind.Utc).AddTicks(5003) });

            migrationBuilder.UpdateData(
                table: "QuestTypes",
                keyColumn: "QuestTypeId",
                keyValue: new Guid("b2c3d4e5-f6a1-2345-cdef-0123456789ab"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 3, 12, 22, 51, 628, DateTimeKind.Utc).AddTicks(5009), new DateTime(2025, 6, 3, 12, 22, 51, 628, DateTimeKind.Utc).AddTicks(5010) });

            migrationBuilder.UpdateData(
                table: "QuestTypes",
                keyColumn: "QuestTypeId",
                keyValue: new Guid("c3d4e5f6-a1b2-3456-7890-abcdef012345"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 3, 12, 22, 51, 628, DateTimeKind.Utc).AddTicks(5012), new DateTime(2025, 6, 3, 12, 22, 51, 628, DateTimeKind.Utc).AddTicks(5012) });

            migrationBuilder.UpdateData(
                table: "QuestTypes",
                keyColumn: "QuestTypeId",
                keyValue: new Guid("d4e5f6a1-b2c3-4567-890a-bcdef0123456"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 3, 12, 22, 51, 628, DateTimeKind.Utc).AddTicks(5014), new DateTime(2025, 6, 3, 12, 22, 51, 628, DateTimeKind.Utc).AddTicks(5014) });

            migrationBuilder.UpdateData(
                table: "SubscriptionPlans",
                keyColumn: "PlanId",
                keyValue: new Guid("11223344-5566-7788-99aa-bbccddeeff00"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 3, 12, 22, 51, 628, DateTimeKind.Utc).AddTicks(4784), new DateTime(2025, 6, 3, 12, 22, 51, 628, DateTimeKind.Utc).AddTicks(4785) });

            migrationBuilder.UpdateData(
                table: "SubscriptionPlans",
                keyColumn: "PlanId",
                keyValue: new Guid("aabbccdd-eeff-1122-3344-5566778899aa"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 3, 12, 22, 51, 628, DateTimeKind.Utc).AddTicks(4796), new DateTime(2025, 6, 3, 12, 22, 51, 628, DateTimeKind.Utc).AddTicks(4796) });

            migrationBuilder.UpdateData(
                table: "SubscriptionPlans",
                keyColumn: "PlanId",
                keyValue: new Guid("ccddeeff-aabb-3344-5566-778899aabbcc"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 3, 12, 22, 51, 628, DateTimeKind.Utc).AddTicks(4799), new DateTime(2025, 6, 3, 12, 22, 51, 628, DateTimeKind.Utc).AddTicks(4800) });

            migrationBuilder.UpdateData(
                table: "UnitGroups",
                keyColumn: "UnitGroupId",
                keyValue: new Guid("a1b2c3d4-e5f6-7890-1234-567890fedcba"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 3, 12, 22, 51, 628, DateTimeKind.Utc).AddTicks(4842), new DateTime(2025, 6, 3, 12, 22, 51, 628, DateTimeKind.Utc).AddTicks(4842) });

            migrationBuilder.UpdateData(
                table: "UnitGroups",
                keyColumn: "UnitGroupId",
                keyValue: new Guid("e1f2a3b4-c5d6-e7f8-a9b0-c1d2e3f4a5b6"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 3, 12, 22, 51, 628, DateTimeKind.Utc).AddTicks(4836), new DateTime(2025, 6, 3, 12, 22, 51, 628, DateTimeKind.Utc).AddTicks(4837) });

            migrationBuilder.UpdateData(
                table: "UnitGroups",
                keyColumn: "UnitGroupId",
                keyValue: new Guid("f2a3b4c5-d6e7-f8a9-b0c1-d2e3f4a5b6c7"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 3, 12, 22, 51, 628, DateTimeKind.Utc).AddTicks(4840), new DateTime(2025, 6, 3, 12, 22, 51, 628, DateTimeKind.Utc).AddTicks(4840) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasures",
                keyColumn: "UnitId",
                keyValue: new Guid("1a2b3c4d-5e6f-7a8b-9c0d-1e2f3a4b5c6d"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 3, 12, 22, 51, 628, DateTimeKind.Utc).AddTicks(4940), new DateTime(2025, 6, 3, 12, 22, 51, 628, DateTimeKind.Utc).AddTicks(4941) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasures",
                keyColumn: "UnitId",
                keyValue: new Guid("2b3c4d5e-6f7a-8b9c-0d1e-2f3a4b5c6d7e"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 3, 12, 22, 51, 628, DateTimeKind.Utc).AddTicks(4946), new DateTime(2025, 6, 3, 12, 22, 51, 628, DateTimeKind.Utc).AddTicks(4946) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasures",
                keyColumn: "UnitId",
                keyValue: new Guid("3c4d5e6f-7a8b-9c0d-1e2f-3a4b5c6d7e8f"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 3, 12, 22, 51, 628, DateTimeKind.Utc).AddTicks(4948), new DateTime(2025, 6, 3, 12, 22, 51, 628, DateTimeKind.Utc).AddTicks(4948) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasures",
                keyColumn: "UnitId",
                keyValue: new Guid("4d5e6f7a-8b9c-0d1e-2f3a-4b5c6d7e8f9a"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 3, 12, 22, 51, 628, DateTimeKind.Utc).AddTicks(4950), new DateTime(2025, 6, 3, 12, 22, 51, 628, DateTimeKind.Utc).AddTicks(4951) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasures",
                keyColumn: "UnitId",
                keyValue: new Guid("5e6f7a8b-9c0d-1e2f-3a4b-5c6d7e8f9a0b"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 3, 12, 22, 51, 628, DateTimeKind.Utc).AddTicks(4953), new DateTime(2025, 6, 3, 12, 22, 51, 628, DateTimeKind.Utc).AddTicks(4953) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasures",
                keyColumn: "UnitId",
                keyValue: new Guid("6f7a8b9c-0d1e-2f3a-4b5c-6d7e8f9a0b1c"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 3, 12, 22, 51, 628, DateTimeKind.Utc).AddTicks(4956), new DateTime(2025, 6, 3, 12, 22, 51, 628, DateTimeKind.Utc).AddTicks(4956) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasures",
                keyColumn: "UnitId",
                keyValue: new Guid("7a8b9c0d-1e2f-3a4b-5c6d-7e8f9a0b1c2d"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 3, 12, 22, 51, 628, DateTimeKind.Utc).AddTicks(4958), new DateTime(2025, 6, 3, 12, 22, 51, 628, DateTimeKind.Utc).AddTicks(4959) });

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UnitConversions");

            migrationBuilder.UpdateData(
                table: "Levels",
                keyColumn: "LevelId",
                keyValue: new Guid("a0b1c2d3-e4f5-a6b7-c8d9-e0f1a2b3c4d5"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 3, 7, 58, 31, 811, DateTimeKind.Utc).AddTicks(750), new DateTime(2025, 6, 3, 7, 58, 31, 811, DateTimeKind.Utc).AddTicks(750) });

            migrationBuilder.UpdateData(
                table: "Levels",
                keyColumn: "LevelId",
                keyValue: new Guid("b1c2d3e4-f5a6-b7c8-d9e0-f1a2b3c4d5e6"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 3, 7, 58, 31, 811, DateTimeKind.Utc).AddTicks(753), new DateTime(2025, 6, 3, 7, 58, 31, 811, DateTimeKind.Utc).AddTicks(753) });

            migrationBuilder.UpdateData(
                table: "Levels",
                keyColumn: "LevelId",
                keyValue: new Guid("c2d3e4f5-a6b7-c8d9-e0f1-a2b3c4d5e6f7"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 3, 7, 58, 31, 811, DateTimeKind.Utc).AddTicks(755), new DateTime(2025, 6, 3, 7, 58, 31, 811, DateTimeKind.Utc).AddTicks(755) });

            migrationBuilder.UpdateData(
                table: "Levels",
                keyColumn: "LevelId",
                keyValue: new Guid("e1f2a3b4-c5d6-e7f8-a9b0-c1d2e3f4a5b6"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 3, 7, 58, 31, 811, DateTimeKind.Utc).AddTicks(742), new DateTime(2025, 6, 3, 7, 58, 31, 811, DateTimeKind.Utc).AddTicks(742) });

            migrationBuilder.UpdateData(
                table: "Levels",
                keyColumn: "LevelId",
                keyValue: new Guid("f2a3b4c5-d6e7-f8a9-b0c1-d2e3f4a5b6c7"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 3, 7, 58, 31, 811, DateTimeKind.Utc).AddTicks(747), new DateTime(2025, 6, 3, 7, 58, 31, 811, DateTimeKind.Utc).AddTicks(747) });

            migrationBuilder.UpdateData(
                table: "OrganizationIndustryTypes",
                keyColumn: "IndustryTypeId",
                keyValue: new Guid("a1b2c3d4-e5f6-7890-1234-567890abcdef"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 3, 7, 58, 31, 811, DateTimeKind.Utc).AddTicks(61), new DateTime(2025, 6, 3, 7, 58, 31, 811, DateTimeKind.Utc).AddTicks(63) });

            migrationBuilder.UpdateData(
                table: "OrganizationIndustryTypes",
                keyColumn: "IndustryTypeId",
                keyValue: new Guid("b2c3d4e5-f6a1-2345-6789-0abcdef12345"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 3, 7, 58, 31, 811, DateTimeKind.Utc).AddTicks(67), new DateTime(2025, 6, 3, 7, 58, 31, 811, DateTimeKind.Utc).AddTicks(67) });

            migrationBuilder.UpdateData(
                table: "OrganizationIndustryTypes",
                keyColumn: "IndustryTypeId",
                keyValue: new Guid("c3d4e5f6-a1b2-3456-7890-cdef12345678"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 3, 7, 58, 31, 811, DateTimeKind.Utc).AddTicks(75), new DateTime(2025, 6, 3, 7, 58, 31, 811, DateTimeKind.Utc).AddTicks(75) });

            migrationBuilder.UpdateData(
                table: "OrganizationIndustryTypes",
                keyColumn: "IndustryTypeId",
                keyValue: new Guid("d4e5f6a1-b2c3-4567-890a-bcdef1234567"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 3, 7, 58, 31, 811, DateTimeKind.Utc).AddTicks(77), new DateTime(2025, 6, 3, 7, 58, 31, 811, DateTimeKind.Utc).AddTicks(77) });

            migrationBuilder.UpdateData(
                table: "QuestTypes",
                keyColumn: "QuestTypeId",
                keyValue: new Guid("a1b2c3d4-e5f6-7890-abcd-ef0123456789"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 3, 7, 58, 31, 811, DateTimeKind.Utc).AddTicks(704), new DateTime(2025, 6, 3, 7, 58, 31, 811, DateTimeKind.Utc).AddTicks(704) });

            migrationBuilder.UpdateData(
                table: "QuestTypes",
                keyColumn: "QuestTypeId",
                keyValue: new Guid("b2c3d4e5-f6a1-2345-cdef-0123456789ab"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 3, 7, 58, 31, 811, DateTimeKind.Utc).AddTicks(708), new DateTime(2025, 6, 3, 7, 58, 31, 811, DateTimeKind.Utc).AddTicks(708) });

            migrationBuilder.UpdateData(
                table: "QuestTypes",
                keyColumn: "QuestTypeId",
                keyValue: new Guid("c3d4e5f6-a1b2-3456-7890-abcdef012345"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 3, 7, 58, 31, 811, DateTimeKind.Utc).AddTicks(710), new DateTime(2025, 6, 3, 7, 58, 31, 811, DateTimeKind.Utc).AddTicks(711) });

            migrationBuilder.UpdateData(
                table: "QuestTypes",
                keyColumn: "QuestTypeId",
                keyValue: new Guid("d4e5f6a1-b2c3-4567-890a-bcdef0123456"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 3, 7, 58, 31, 811, DateTimeKind.Utc).AddTicks(712), new DateTime(2025, 6, 3, 7, 58, 31, 811, DateTimeKind.Utc).AddTicks(712) });

            migrationBuilder.UpdateData(
                table: "SubscriptionPlans",
                keyColumn: "PlanId",
                keyValue: new Guid("11223344-5566-7788-99aa-bbccddeeff00"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 3, 7, 58, 31, 811, DateTimeKind.Utc).AddTicks(453), new DateTime(2025, 6, 3, 7, 58, 31, 811, DateTimeKind.Utc).AddTicks(454) });

            migrationBuilder.UpdateData(
                table: "SubscriptionPlans",
                keyColumn: "PlanId",
                keyValue: new Guid("aabbccdd-eeff-1122-3344-5566778899aa"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 3, 7, 58, 31, 811, DateTimeKind.Utc).AddTicks(462), new DateTime(2025, 6, 3, 7, 58, 31, 811, DateTimeKind.Utc).AddTicks(463) });

            migrationBuilder.UpdateData(
                table: "SubscriptionPlans",
                keyColumn: "PlanId",
                keyValue: new Guid("ccddeeff-aabb-3344-5566-778899aabbcc"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 3, 7, 58, 31, 811, DateTimeKind.Utc).AddTicks(466), new DateTime(2025, 6, 3, 7, 58, 31, 811, DateTimeKind.Utc).AddTicks(466) });

            migrationBuilder.UpdateData(
                table: "UnitGroups",
                keyColumn: "UnitGroupId",
                keyValue: new Guid("a1b2c3d4-e5f6-7890-1234-567890fedcba"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 3, 7, 58, 31, 811, DateTimeKind.Utc).AddTicks(502), new DateTime(2025, 6, 3, 7, 58, 31, 811, DateTimeKind.Utc).AddTicks(502) });

            migrationBuilder.UpdateData(
                table: "UnitGroups",
                keyColumn: "UnitGroupId",
                keyValue: new Guid("e1f2a3b4-c5d6-e7f8-a9b0-c1d2e3f4a5b6"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 3, 7, 58, 31, 811, DateTimeKind.Utc).AddTicks(497), new DateTime(2025, 6, 3, 7, 58, 31, 811, DateTimeKind.Utc).AddTicks(497) });

            migrationBuilder.UpdateData(
                table: "UnitGroups",
                keyColumn: "UnitGroupId",
                keyValue: new Guid("f2a3b4c5-d6e7-f8a9-b0c1-d2e3f4a5b6c7"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 3, 7, 58, 31, 811, DateTimeKind.Utc).AddTicks(500), new DateTime(2025, 6, 3, 7, 58, 31, 811, DateTimeKind.Utc).AddTicks(500) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasures",
                keyColumn: "UnitId",
                keyValue: new Guid("1a2b3c4d-5e6f-7a8b-9c0d-1e2f3a4b5c6d"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 3, 7, 58, 31, 811, DateTimeKind.Utc).AddTicks(643), new DateTime(2025, 6, 3, 7, 58, 31, 811, DateTimeKind.Utc).AddTicks(644) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasures",
                keyColumn: "UnitId",
                keyValue: new Guid("2b3c4d5e-6f7a-8b9c-0d1e-2f3a4b5c6d7e"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 3, 7, 58, 31, 811, DateTimeKind.Utc).AddTicks(648), new DateTime(2025, 6, 3, 7, 58, 31, 811, DateTimeKind.Utc).AddTicks(648) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasures",
                keyColumn: "UnitId",
                keyValue: new Guid("3c4d5e6f-7a8b-9c0d-1e2f-3a4b5c6d7e8f"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 3, 7, 58, 31, 811, DateTimeKind.Utc).AddTicks(651), new DateTime(2025, 6, 3, 7, 58, 31, 811, DateTimeKind.Utc).AddTicks(651) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasures",
                keyColumn: "UnitId",
                keyValue: new Guid("4d5e6f7a-8b9c-0d1e-2f3a-4b5c6d7e8f9a"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 3, 7, 58, 31, 811, DateTimeKind.Utc).AddTicks(654), new DateTime(2025, 6, 3, 7, 58, 31, 811, DateTimeKind.Utc).AddTicks(654) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasures",
                keyColumn: "UnitId",
                keyValue: new Guid("5e6f7a8b-9c0d-1e2f-3a4b-5c6d7e8f9a0b"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 3, 7, 58, 31, 811, DateTimeKind.Utc).AddTicks(657), new DateTime(2025, 6, 3, 7, 58, 31, 811, DateTimeKind.Utc).AddTicks(657) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasures",
                keyColumn: "UnitId",
                keyValue: new Guid("6f7a8b9c-0d1e-2f3a-4b5c-6d7e8f9a0b1c"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 3, 7, 58, 31, 811, DateTimeKind.Utc).AddTicks(662), new DateTime(2025, 6, 3, 7, 58, 31, 811, DateTimeKind.Utc).AddTicks(662) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasures",
                keyColumn: "UnitId",
                keyValue: new Guid("7a8b9c0d-1e2f-3a4b-5c6d-7e8f9a0b1c2d"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 3, 7, 58, 31, 811, DateTimeKind.Utc).AddTicks(664), new DateTime(2025, 6, 3, 7, 58, 31, 811, DateTimeKind.Utc).AddTicks(665) });
        }
    }
}
