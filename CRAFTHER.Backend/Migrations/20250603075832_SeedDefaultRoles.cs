using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CRAFTHER.Backend.Migrations
{
    /// <inheritdoc />
    public partial class SeedDefaultRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("c1a2b3d4-e5f6-7890-1234-567890abcdef"), null, "Admin", "ADMIN" },
                    { new Guid("d5e6f7a8-b9c0-1234-5678-90abcdef1234"), null, "User", "USER" }
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c1a2b3d4-e5f6-7890-1234-567890abcdef"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("d5e6f7a8-b9c0-1234-5678-90abcdef1234"));

            migrationBuilder.UpdateData(
                table: "Levels",
                keyColumn: "LevelId",
                keyValue: new Guid("a0b1c2d3-e4f5-a6b7-c8d9-e0f1a2b3c4d5"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 3, 6, 9, 57, 789, DateTimeKind.Utc).AddTicks(252), new DateTime(2025, 6, 3, 6, 9, 57, 789, DateTimeKind.Utc).AddTicks(252) });

            migrationBuilder.UpdateData(
                table: "Levels",
                keyColumn: "LevelId",
                keyValue: new Guid("b1c2d3e4-f5a6-b7c8-d9e0-f1a2b3c4d5e6"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 3, 6, 9, 57, 789, DateTimeKind.Utc).AddTicks(255), new DateTime(2025, 6, 3, 6, 9, 57, 789, DateTimeKind.Utc).AddTicks(256) });

            migrationBuilder.UpdateData(
                table: "Levels",
                keyColumn: "LevelId",
                keyValue: new Guid("c2d3e4f5-a6b7-c8d9-e0f1-a2b3c4d5e6f7"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 3, 6, 9, 57, 789, DateTimeKind.Utc).AddTicks(258), new DateTime(2025, 6, 3, 6, 9, 57, 789, DateTimeKind.Utc).AddTicks(258) });

            migrationBuilder.UpdateData(
                table: "Levels",
                keyColumn: "LevelId",
                keyValue: new Guid("e1f2a3b4-c5d6-e7f8-a9b0-c1d2e3f4a5b6"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 3, 6, 9, 57, 789, DateTimeKind.Utc).AddTicks(239), new DateTime(2025, 6, 3, 6, 9, 57, 789, DateTimeKind.Utc).AddTicks(239) });

            migrationBuilder.UpdateData(
                table: "Levels",
                keyColumn: "LevelId",
                keyValue: new Guid("f2a3b4c5-d6e7-f8a9-b0c1-d2e3f4a5b6c7"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 3, 6, 9, 57, 789, DateTimeKind.Utc).AddTicks(247), new DateTime(2025, 6, 3, 6, 9, 57, 789, DateTimeKind.Utc).AddTicks(247) });

            migrationBuilder.UpdateData(
                table: "OrganizationIndustryTypes",
                keyColumn: "IndustryTypeId",
                keyValue: new Guid("a1b2c3d4-e5f6-7890-1234-567890abcdef"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 3, 6, 9, 57, 788, DateTimeKind.Utc).AddTicks(9727), new DateTime(2025, 6, 3, 6, 9, 57, 788, DateTimeKind.Utc).AddTicks(9730) });

            migrationBuilder.UpdateData(
                table: "OrganizationIndustryTypes",
                keyColumn: "IndustryTypeId",
                keyValue: new Guid("b2c3d4e5-f6a1-2345-6789-0abcdef12345"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 3, 6, 9, 57, 788, DateTimeKind.Utc).AddTicks(9734), new DateTime(2025, 6, 3, 6, 9, 57, 788, DateTimeKind.Utc).AddTicks(9734) });

            migrationBuilder.UpdateData(
                table: "OrganizationIndustryTypes",
                keyColumn: "IndustryTypeId",
                keyValue: new Guid("c3d4e5f6-a1b2-3456-7890-cdef12345678"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 3, 6, 9, 57, 788, DateTimeKind.Utc).AddTicks(9736), new DateTime(2025, 6, 3, 6, 9, 57, 788, DateTimeKind.Utc).AddTicks(9736) });

            migrationBuilder.UpdateData(
                table: "OrganizationIndustryTypes",
                keyColumn: "IndustryTypeId",
                keyValue: new Guid("d4e5f6a1-b2c3-4567-890a-bcdef1234567"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 3, 6, 9, 57, 788, DateTimeKind.Utc).AddTicks(9737), new DateTime(2025, 6, 3, 6, 9, 57, 788, DateTimeKind.Utc).AddTicks(9738) });

            migrationBuilder.UpdateData(
                table: "QuestTypes",
                keyColumn: "QuestTypeId",
                keyValue: new Guid("a1b2c3d4-e5f6-7890-abcd-ef0123456789"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 3, 6, 9, 57, 789, DateTimeKind.Utc).AddTicks(204), new DateTime(2025, 6, 3, 6, 9, 57, 789, DateTimeKind.Utc).AddTicks(204) });

            migrationBuilder.UpdateData(
                table: "QuestTypes",
                keyColumn: "QuestTypeId",
                keyValue: new Guid("b2c3d4e5-f6a1-2345-cdef-0123456789ab"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 3, 6, 9, 57, 789, DateTimeKind.Utc).AddTicks(206), new DateTime(2025, 6, 3, 6, 9, 57, 789, DateTimeKind.Utc).AddTicks(207) });

            migrationBuilder.UpdateData(
                table: "QuestTypes",
                keyColumn: "QuestTypeId",
                keyValue: new Guid("c3d4e5f6-a1b2-3456-7890-abcdef012345"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 3, 6, 9, 57, 789, DateTimeKind.Utc).AddTicks(208), new DateTime(2025, 6, 3, 6, 9, 57, 789, DateTimeKind.Utc).AddTicks(208) });

            migrationBuilder.UpdateData(
                table: "QuestTypes",
                keyColumn: "QuestTypeId",
                keyValue: new Guid("d4e5f6a1-b2c3-4567-890a-bcdef0123456"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 3, 6, 9, 57, 789, DateTimeKind.Utc).AddTicks(210), new DateTime(2025, 6, 3, 6, 9, 57, 789, DateTimeKind.Utc).AddTicks(210) });

            migrationBuilder.UpdateData(
                table: "SubscriptionPlans",
                keyColumn: "PlanId",
                keyValue: new Guid("11223344-5566-7788-99aa-bbccddeeff00"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 3, 6, 9, 57, 789, DateTimeKind.Utc).AddTicks(7), new DateTime(2025, 6, 3, 6, 9, 57, 789, DateTimeKind.Utc).AddTicks(7) });

            migrationBuilder.UpdateData(
                table: "SubscriptionPlans",
                keyColumn: "PlanId",
                keyValue: new Guid("aabbccdd-eeff-1122-3344-5566778899aa"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 3, 6, 9, 57, 789, DateTimeKind.Utc).AddTicks(16), new DateTime(2025, 6, 3, 6, 9, 57, 789, DateTimeKind.Utc).AddTicks(17) });

            migrationBuilder.UpdateData(
                table: "SubscriptionPlans",
                keyColumn: "PlanId",
                keyValue: new Guid("ccddeeff-aabb-3344-5566-778899aabbcc"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 3, 6, 9, 57, 789, DateTimeKind.Utc).AddTicks(20), new DateTime(2025, 6, 3, 6, 9, 57, 789, DateTimeKind.Utc).AddTicks(20) });

            migrationBuilder.UpdateData(
                table: "UnitGroups",
                keyColumn: "UnitGroupId",
                keyValue: new Guid("a1b2c3d4-e5f6-7890-1234-567890fedcba"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 3, 6, 9, 57, 789, DateTimeKind.Utc).AddTicks(67), new DateTime(2025, 6, 3, 6, 9, 57, 789, DateTimeKind.Utc).AddTicks(68) });

            migrationBuilder.UpdateData(
                table: "UnitGroups",
                keyColumn: "UnitGroupId",
                keyValue: new Guid("e1f2a3b4-c5d6-e7f8-a9b0-c1d2e3f4a5b6"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 3, 6, 9, 57, 789, DateTimeKind.Utc).AddTicks(62), new DateTime(2025, 6, 3, 6, 9, 57, 789, DateTimeKind.Utc).AddTicks(62) });

            migrationBuilder.UpdateData(
                table: "UnitGroups",
                keyColumn: "UnitGroupId",
                keyValue: new Guid("f2a3b4c5-d6e7-f8a9-b0c1-d2e3f4a5b6c7"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 3, 6, 9, 57, 789, DateTimeKind.Utc).AddTicks(65), new DateTime(2025, 6, 3, 6, 9, 57, 789, DateTimeKind.Utc).AddTicks(66) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasures",
                keyColumn: "UnitId",
                keyValue: new Guid("1a2b3c4d-5e6f-7a8b-9c0d-1e2f3a4b5c6d"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 3, 6, 9, 57, 789, DateTimeKind.Utc).AddTicks(98), new DateTime(2025, 6, 3, 6, 9, 57, 789, DateTimeKind.Utc).AddTicks(99) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasures",
                keyColumn: "UnitId",
                keyValue: new Guid("2b3c4d5e-6f7a-8b9c-0d1e-2f3a4b5c6d7e"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 3, 6, 9, 57, 789, DateTimeKind.Utc).AddTicks(105), new DateTime(2025, 6, 3, 6, 9, 57, 789, DateTimeKind.Utc).AddTicks(105) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasures",
                keyColumn: "UnitId",
                keyValue: new Guid("3c4d5e6f-7a8b-9c0d-1e2f-3a4b5c6d7e8f"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 3, 6, 9, 57, 789, DateTimeKind.Utc).AddTicks(107), new DateTime(2025, 6, 3, 6, 9, 57, 789, DateTimeKind.Utc).AddTicks(108) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasures",
                keyColumn: "UnitId",
                keyValue: new Guid("4d5e6f7a-8b9c-0d1e-2f3a-4b5c6d7e8f9a"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 3, 6, 9, 57, 789, DateTimeKind.Utc).AddTicks(110), new DateTime(2025, 6, 3, 6, 9, 57, 789, DateTimeKind.Utc).AddTicks(110) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasures",
                keyColumn: "UnitId",
                keyValue: new Guid("5e6f7a8b-9c0d-1e2f-3a4b-5c6d7e8f9a0b"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 3, 6, 9, 57, 789, DateTimeKind.Utc).AddTicks(159), new DateTime(2025, 6, 3, 6, 9, 57, 789, DateTimeKind.Utc).AddTicks(160) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasures",
                keyColumn: "UnitId",
                keyValue: new Guid("6f7a8b9c-0d1e-2f3a-4b5c-6d7e8f9a0b1c"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 3, 6, 9, 57, 789, DateTimeKind.Utc).AddTicks(165), new DateTime(2025, 6, 3, 6, 9, 57, 789, DateTimeKind.Utc).AddTicks(166) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasures",
                keyColumn: "UnitId",
                keyValue: new Guid("7a8b9c0d-1e2f-3a4b-5c6d-7e8f9a0b1c2d"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 3, 6, 9, 57, 789, DateTimeKind.Utc).AddTicks(168), new DateTime(2025, 6, 3, 6, 9, 57, 789, DateTimeKind.Utc).AddTicks(168) });
        }
    }
}
