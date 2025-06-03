using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CRAFTHER.Backend.Migrations
{
    /// <inheritdoc />
    public partial class FinalInitialSchemaWithSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Levels",
                columns: new[] { "LevelId", "BadgeImageUrl", "CreatedAt", "Description", "LevelName", "LevelNumber", "RequiredPoints", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("a0b1c2d3-e4f5-a6b7-c8d9-e0f1a2b3c4d5"), null, new DateTime(2025, 6, 3, 5, 6, 34, 84, DateTimeKind.Utc).AddTicks(5253), "Mastering your ingredient knowledge.", "Ingredient Explorer", 3, 300, new DateTime(2025, 6, 3, 5, 6, 34, 84, DateTimeKind.Utc).AddTicks(5253) },
                    { new Guid("b1c2d3e4-f5a6-b7c8-d9e0-f1a2b3c4d5e6"), null, new DateTime(2025, 6, 3, 5, 6, 34, 84, DateTimeKind.Utc).AddTicks(5256), "Becoming an expert in cost analysis.", "Costing Pro", 4, 600, new DateTime(2025, 6, 3, 5, 6, 34, 84, DateTimeKind.Utc).AddTicks(5256) },
                    { new Guid("c2d3e4f5-a6b7-c8d9-e0f1-a2b3c4d5e6f7"), null, new DateTime(2025, 6, 3, 5, 6, 34, 84, DateTimeKind.Utc).AddTicks(5258), "The ultimate CRAFTHER champion!", "CRAFTHER Master", 5, 1000, new DateTime(2025, 6, 3, 5, 6, 34, 84, DateTimeKind.Utc).AddTicks(5258) },
                    { new Guid("e1f2a3b4-c5d6-e7f8-a9b0-c1d2e3f4a5b6"), null, new DateTime(2025, 6, 3, 5, 6, 34, 84, DateTimeKind.Utc).AddTicks(5245), "Just starting your BOM journey.", "BOM Novice", 1, 0, new DateTime(2025, 6, 3, 5, 6, 34, 84, DateTimeKind.Utc).AddTicks(5245) },
                    { new Guid("f2a3b4c5-d6e7-f8a9-b0c1-d2e3f4a5b6c7"), null, new DateTime(2025, 6, 3, 5, 6, 34, 84, DateTimeKind.Utc).AddTicks(5250), "Learning the ropes of recipe management.", "Recipe Apprentice", 2, 100, new DateTime(2025, 6, 3, 5, 6, 34, 84, DateTimeKind.Utc).AddTicks(5251) }
                });

            migrationBuilder.InsertData(
                table: "OrganizationIndustryTypes",
                columns: new[] { "IndustryTypeId", "CreatedAt", "Description", "IndustryTypeName", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("a1b2c3d4-e5f6-7890-1234-567890abcdef"), new DateTime(2025, 6, 3, 5, 6, 34, 84, DateTimeKind.Utc).AddTicks(4642), "Businesses primarily focused on coffee, tea, and light snacks.", "Cafe / Coffee Shop", new DateTime(2025, 6, 3, 5, 6, 34, 84, DateTimeKind.Utc).AddTicks(4644) },
                    { new Guid("b2c3d4e5-f6a1-2345-6789-0abcdef12345"), new DateTime(2025, 6, 3, 5, 6, 34, 84, DateTimeKind.Utc).AddTicks(4648), "Businesses specializing in baked goods, pastries, and sweets.", "Bakery / Confectionery", new DateTime(2025, 6, 3, 5, 6, 34, 84, DateTimeKind.Utc).AddTicks(4649) },
                    { new Guid("c3d4e5f6-a1b2-3456-7890-cdef12345678"), new DateTime(2025, 6, 3, 5, 6, 34, 84, DateTimeKind.Utc).AddTicks(4651), "Businesses serving prepared meals and beverages.", "Restaurant / Eatery", new DateTime(2025, 6, 3, 5, 6, 34, 84, DateTimeKind.Utc).AddTicks(4651) },
                    { new Guid("d4e5f6a1-b2c3-4567-890a-bcdef1234567"), new DateTime(2025, 6, 3, 5, 6, 34, 84, DateTimeKind.Utc).AddTicks(4652), "Businesses producing and selling handmade products.", "Crafts / Handmade Goods", new DateTime(2025, 6, 3, 5, 6, 34, 84, DateTimeKind.Utc).AddTicks(4653) }
                });

            migrationBuilder.InsertData(
                table: "QuestTypes",
                columns: new[] { "QuestTypeId", "CreatedAt", "Description", "QuestTypeName", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("a1b2c3d4-e5f6-7890-abcd-ef0123456789"), new DateTime(2025, 6, 3, 5, 6, 34, 84, DateTimeKind.Utc).AddTicks(5206), "Quests that refresh daily.", "DAILY", new DateTime(2025, 6, 3, 5, 6, 34, 84, DateTimeKind.Utc).AddTicks(5206) },
                    { new Guid("b2c3d4e5-f6a1-2345-cdef-0123456789ab"), new DateTime(2025, 6, 3, 5, 6, 34, 84, DateTimeKind.Utc).AddTicks(5209), "Quests that refresh weekly.", "WEEKLY", new DateTime(2025, 6, 3, 5, 6, 34, 84, DateTimeKind.Utc).AddTicks(5209) },
                    { new Guid("c3d4e5f6-a1b2-3456-7890-abcdef012345"), new DateTime(2025, 6, 3, 5, 6, 34, 84, DateTimeKind.Utc).AddTicks(5211), "Core progression quests.", "MAIN_STORY", new DateTime(2025, 6, 3, 5, 6, 34, 84, DateTimeKind.Utc).AddTicks(5211) },
                    { new Guid("d4e5f6a1-b2c3-4567-890a-bcdef0123456"), new DateTime(2025, 6, 3, 5, 6, 34, 84, DateTimeKind.Utc).AddTicks(5213), "Difficult, one-time challenges.", "CHALLENGE", new DateTime(2025, 6, 3, 5, 6, 34, 84, DateTimeKind.Utc).AddTicks(5213) }
                });

            migrationBuilder.InsertData(
                table: "SubscriptionPlans",
                columns: new[] { "PlanId", "CanAccessAdvancedReports", "CanIntegratePOS", "CreatedAt", "Description", "MaxComponents", "MaxProducts", "MaxUsers", "PlanName", "Price", "StorageSpaceMB", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("11223344-5566-7788-99aa-bbccddeeff00"), false, false, new DateTime(2025, 6, 3, 5, 6, 34, 84, DateTimeKind.Utc).AddTicks(5048), "Basic features for small businesses to get started.", 20, 5, 1, "Free", 0.00m, 50, new DateTime(2025, 6, 3, 5, 6, 34, 84, DateTimeKind.Utc).AddTicks(5048) },
                    { new Guid("aabbccdd-eeff-1122-3344-5566778899aa"), true, false, new DateTime(2025, 6, 3, 5, 6, 34, 84, DateTimeKind.Utc).AddTicks(5068), "Essential tools for growing businesses.", 200, 50, 3, "Basic", 199.00m, 500, new DateTime(2025, 6, 3, 5, 6, 34, 84, DateTimeKind.Utc).AddTicks(5068) },
                    { new Guid("ccddeeff-aabb-3344-5566-778899aabbcc"), true, true, new DateTime(2025, 6, 3, 5, 6, 34, 84, DateTimeKind.Utc).AddTicks(5072), "Advanced features for established businesses.", 0, 0, 0, "Pro", 499.00m, 5000, new DateTime(2025, 6, 3, 5, 6, 34, 84, DateTimeKind.Utc).AddTicks(5073) }
                });

            migrationBuilder.InsertData(
                table: "UnitGroups",
                columns: new[] { "UnitGroupId", "CreatedAt", "Description", "UnitGroupName", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("a1b2c3d4-e5f6-7890-1234-567890fedcba"), new DateTime(2025, 6, 3, 5, 6, 34, 84, DateTimeKind.Utc).AddTicks(5113), "Units for measuring discrete items or counts.", "Count / Quantity", new DateTime(2025, 6, 3, 5, 6, 34, 84, DateTimeKind.Utc).AddTicks(5113) },
                    { new Guid("e1f2a3b4-c5d6-e7f8-a9b0-c1d2e3f4a5b6"), new DateTime(2025, 6, 3, 5, 6, 34, 84, DateTimeKind.Utc).AddTicks(5107), "Units for measuring liquid volume.", "Liquid Volume", new DateTime(2025, 6, 3, 5, 6, 34, 84, DateTimeKind.Utc).AddTicks(5108) },
                    { new Guid("f2a3b4c5-d6e7-f8a9-b0c1-d2e3f4a5b6c7"), new DateTime(2025, 6, 3, 5, 6, 34, 84, DateTimeKind.Utc).AddTicks(5111), "Units for measuring weight or mass.", "Weight / Mass", new DateTime(2025, 6, 3, 5, 6, 34, 84, DateTimeKind.Utc).AddTicks(5111) }
                });

            migrationBuilder.InsertData(
                table: "UnitsOfMeasures",
                columns: new[] { "UnitId", "Abbreviation", "ConversionFactorToBaseUnit", "CreatedAt", "IsBaseUnit", "UnitGroupId", "UnitName", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("1a2b3c4d-5e6f-7a8b-9c0d-1e2f3a4b5c6d"), "ml", 1.0m, new DateTime(2025, 6, 3, 5, 6, 34, 84, DateTimeKind.Utc).AddTicks(5148), true, new Guid("e1f2a3b4-c5d6-e7f8-a9b0-c1d2e3f4a5b6"), "Milliliter", new DateTime(2025, 6, 3, 5, 6, 34, 84, DateTimeKind.Utc).AddTicks(5149) },
                    { new Guid("2b3c4d5e-6f7a-8b9c-0d1e-2f3a4b5c6d7e"), "L", 1000.0m, new DateTime(2025, 6, 3, 5, 6, 34, 84, DateTimeKind.Utc).AddTicks(5153), false, new Guid("e1f2a3b4-c5d6-e7f8-a9b0-c1d2e3f4a5b6"), "Liter", new DateTime(2025, 6, 3, 5, 6, 34, 84, DateTimeKind.Utc).AddTicks(5153) },
                    { new Guid("3c4d5e6f-7a8b-9c0d-1e2f-3a4b5c6d7e8f"), "tbsp", 15.0m, new DateTime(2025, 6, 3, 5, 6, 34, 84, DateTimeKind.Utc).AddTicks(5156), false, new Guid("e1f2a3b4-c5d6-e7f8-a9b0-c1d2e3f4a5b6"), "Tablespoon", new DateTime(2025, 6, 3, 5, 6, 34, 84, DateTimeKind.Utc).AddTicks(5156) },
                    { new Guid("4d5e6f7a-8b9c-0d1e-2f3a-4b5c6d7e8f9a"), "tsp", 5.0m, new DateTime(2025, 6, 3, 5, 6, 34, 84, DateTimeKind.Utc).AddTicks(5162), false, new Guid("e1f2a3b4-c5d6-e7f8-a9b0-c1d2e3f4a5b6"), "Teaspoon", new DateTime(2025, 6, 3, 5, 6, 34, 84, DateTimeKind.Utc).AddTicks(5162) },
                    { new Guid("5e6f7a8b-9c0d-1e2f-3a4b-5c6d7e8f9a0b"), "g", 1.0m, new DateTime(2025, 6, 3, 5, 6, 34, 84, DateTimeKind.Utc).AddTicks(5164), true, new Guid("f2a3b4c5-d6e7-f8a9-b0c1-d2e3f4a5b6c7"), "Gram", new DateTime(2025, 6, 3, 5, 6, 34, 84, DateTimeKind.Utc).AddTicks(5164) },
                    { new Guid("6f7a8b9c-0d1e-2f3a-4b5c-6d7e8f9a0b1c"), "kg", 1000.0m, new DateTime(2025, 6, 3, 5, 6, 34, 84, DateTimeKind.Utc).AddTicks(5167), false, new Guid("f2a3b4c5-d6e7-f8a9-b0c1-d2e3f4a5b6c7"), "Kilogram", new DateTime(2025, 6, 3, 5, 6, 34, 84, DateTimeKind.Utc).AddTicks(5167) },
                    { new Guid("7a8b9c0d-1e2f-3a4b-5c6d-7e8f9a0b1c2d"), "pc", 1.0m, new DateTime(2025, 6, 3, 5, 6, 34, 84, DateTimeKind.Utc).AddTicks(5169), true, new Guid("a1b2c3d4-e5f6-7890-1234-567890fedcba"), "Piece", new DateTime(2025, 6, 3, 5, 6, 34, 84, DateTimeKind.Utc).AddTicks(5169) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "LevelId",
                keyValue: new Guid("a0b1c2d3-e4f5-a6b7-c8d9-e0f1a2b3c4d5"));

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "LevelId",
                keyValue: new Guid("b1c2d3e4-f5a6-b7c8-d9e0-f1a2b3c4d5e6"));

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "LevelId",
                keyValue: new Guid("c2d3e4f5-a6b7-c8d9-e0f1-a2b3c4d5e6f7"));

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "LevelId",
                keyValue: new Guid("e1f2a3b4-c5d6-e7f8-a9b0-c1d2e3f4a5b6"));

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "LevelId",
                keyValue: new Guid("f2a3b4c5-d6e7-f8a9-b0c1-d2e3f4a5b6c7"));

            migrationBuilder.DeleteData(
                table: "OrganizationIndustryTypes",
                keyColumn: "IndustryTypeId",
                keyValue: new Guid("a1b2c3d4-e5f6-7890-1234-567890abcdef"));

            migrationBuilder.DeleteData(
                table: "OrganizationIndustryTypes",
                keyColumn: "IndustryTypeId",
                keyValue: new Guid("b2c3d4e5-f6a1-2345-6789-0abcdef12345"));

            migrationBuilder.DeleteData(
                table: "OrganizationIndustryTypes",
                keyColumn: "IndustryTypeId",
                keyValue: new Guid("c3d4e5f6-a1b2-3456-7890-cdef12345678"));

            migrationBuilder.DeleteData(
                table: "OrganizationIndustryTypes",
                keyColumn: "IndustryTypeId",
                keyValue: new Guid("d4e5f6a1-b2c3-4567-890a-bcdef1234567"));

            migrationBuilder.DeleteData(
                table: "QuestTypes",
                keyColumn: "QuestTypeId",
                keyValue: new Guid("a1b2c3d4-e5f6-7890-abcd-ef0123456789"));

            migrationBuilder.DeleteData(
                table: "QuestTypes",
                keyColumn: "QuestTypeId",
                keyValue: new Guid("b2c3d4e5-f6a1-2345-cdef-0123456789ab"));

            migrationBuilder.DeleteData(
                table: "QuestTypes",
                keyColumn: "QuestTypeId",
                keyValue: new Guid("c3d4e5f6-a1b2-3456-7890-abcdef012345"));

            migrationBuilder.DeleteData(
                table: "QuestTypes",
                keyColumn: "QuestTypeId",
                keyValue: new Guid("d4e5f6a1-b2c3-4567-890a-bcdef0123456"));

            migrationBuilder.DeleteData(
                table: "SubscriptionPlans",
                keyColumn: "PlanId",
                keyValue: new Guid("11223344-5566-7788-99aa-bbccddeeff00"));

            migrationBuilder.DeleteData(
                table: "SubscriptionPlans",
                keyColumn: "PlanId",
                keyValue: new Guid("aabbccdd-eeff-1122-3344-5566778899aa"));

            migrationBuilder.DeleteData(
                table: "SubscriptionPlans",
                keyColumn: "PlanId",
                keyValue: new Guid("ccddeeff-aabb-3344-5566-778899aabbcc"));

            migrationBuilder.DeleteData(
                table: "UnitsOfMeasures",
                keyColumn: "UnitId",
                keyValue: new Guid("1a2b3c4d-5e6f-7a8b-9c0d-1e2f3a4b5c6d"));

            migrationBuilder.DeleteData(
                table: "UnitsOfMeasures",
                keyColumn: "UnitId",
                keyValue: new Guid("2b3c4d5e-6f7a-8b9c-0d1e-2f3a4b5c6d7e"));

            migrationBuilder.DeleteData(
                table: "UnitsOfMeasures",
                keyColumn: "UnitId",
                keyValue: new Guid("3c4d5e6f-7a8b-9c0d-1e2f-3a4b5c6d7e8f"));

            migrationBuilder.DeleteData(
                table: "UnitsOfMeasures",
                keyColumn: "UnitId",
                keyValue: new Guid("4d5e6f7a-8b9c-0d1e-2f3a-4b5c6d7e8f9a"));

            migrationBuilder.DeleteData(
                table: "UnitsOfMeasures",
                keyColumn: "UnitId",
                keyValue: new Guid("5e6f7a8b-9c0d-1e2f-3a4b-5c6d7e8f9a0b"));

            migrationBuilder.DeleteData(
                table: "UnitsOfMeasures",
                keyColumn: "UnitId",
                keyValue: new Guid("6f7a8b9c-0d1e-2f3a-4b5c-6d7e8f9a0b1c"));

            migrationBuilder.DeleteData(
                table: "UnitsOfMeasures",
                keyColumn: "UnitId",
                keyValue: new Guid("7a8b9c0d-1e2f-3a4b-5c6d-7e8f9a0b1c2d"));

            migrationBuilder.DeleteData(
                table: "UnitGroups",
                keyColumn: "UnitGroupId",
                keyValue: new Guid("a1b2c3d4-e5f6-7890-1234-567890fedcba"));

            migrationBuilder.DeleteData(
                table: "UnitGroups",
                keyColumn: "UnitGroupId",
                keyValue: new Guid("e1f2a3b4-c5d6-e7f8-a9b0-c1d2e3f4a5b6"));

            migrationBuilder.DeleteData(
                table: "UnitGroups",
                keyColumn: "UnitGroupId",
                keyValue: new Guid("f2a3b4c5-d6e7-f8a9-b0c1-d2e3f4a5b6c7"));
        }
    }
}
