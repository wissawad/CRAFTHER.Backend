using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CRAFTHER.Backend.Migrations
{
    /// <inheritdoc />
    public partial class AddStockAdjustmentModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StockAdjustmentTypes",
                columns: table => new
                {
                    AdjustmentTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Effect = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockAdjustmentTypes", x => x.AdjustmentTypeId);
                });

            migrationBuilder.CreateTable(
                name: "StockAdjustments",
                columns: table => new
                {
                    AdjustmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrganizationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ComponentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AdjustmentTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    UnitOfMeasureId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdjustmentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockAdjustments", x => x.AdjustmentId);
                    table.ForeignKey(
                        name: "FK_StockAdjustments_Components_ComponentId",
                        column: x => x.ComponentId,
                        principalTable: "Components",
                        principalColumn: "ComponentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StockAdjustments_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "OrganizationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StockAdjustments_StockAdjustmentTypes_AdjustmentTypeId",
                        column: x => x.AdjustmentTypeId,
                        principalTable: "StockAdjustmentTypes",
                        principalColumn: "AdjustmentTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StockAdjustments_UnitsOfMeasures_UnitOfMeasureId",
                        column: x => x.UnitOfMeasureId,
                        principalTable: "UnitsOfMeasures",
                        principalColumn: "UnitId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "Levels",
                keyColumn: "LevelId",
                keyValue: new Guid("a0b1c2d3-e4f5-a6b7-c8d9-e0f1a2b3c4d5"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 3, 12, 36, 21, 94, DateTimeKind.Utc).AddTicks(4620), new DateTime(2025, 6, 3, 12, 36, 21, 94, DateTimeKind.Utc).AddTicks(4620) });

            migrationBuilder.UpdateData(
                table: "Levels",
                keyColumn: "LevelId",
                keyValue: new Guid("b1c2d3e4-f5a6-b7c8-d9e0-f1a2b3c4d5e6"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 3, 12, 36, 21, 94, DateTimeKind.Utc).AddTicks(4623), new DateTime(2025, 6, 3, 12, 36, 21, 94, DateTimeKind.Utc).AddTicks(4623) });

            migrationBuilder.UpdateData(
                table: "Levels",
                keyColumn: "LevelId",
                keyValue: new Guid("c2d3e4f5-a6b7-c8d9-e0f1-a2b3c4d5e6f7"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 3, 12, 36, 21, 94, DateTimeKind.Utc).AddTicks(4625), new DateTime(2025, 6, 3, 12, 36, 21, 94, DateTimeKind.Utc).AddTicks(4625) });

            migrationBuilder.UpdateData(
                table: "Levels",
                keyColumn: "LevelId",
                keyValue: new Guid("e1f2a3b4-c5d6-e7f8-a9b0-c1d2e3f4a5b6"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 3, 12, 36, 21, 94, DateTimeKind.Utc).AddTicks(4611), new DateTime(2025, 6, 3, 12, 36, 21, 94, DateTimeKind.Utc).AddTicks(4612) });

            migrationBuilder.UpdateData(
                table: "Levels",
                keyColumn: "LevelId",
                keyValue: new Guid("f2a3b4c5-d6e7-f8a9-b0c1-d2e3f4a5b6c7"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 3, 12, 36, 21, 94, DateTimeKind.Utc).AddTicks(4617), new DateTime(2025, 6, 3, 12, 36, 21, 94, DateTimeKind.Utc).AddTicks(4617) });

            migrationBuilder.UpdateData(
                table: "OrganizationIndustryTypes",
                keyColumn: "IndustryTypeId",
                keyValue: new Guid("a1b2c3d4-e5f6-7890-1234-567890abcdef"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 3, 12, 36, 21, 94, DateTimeKind.Utc).AddTicks(4133), new DateTime(2025, 6, 3, 12, 36, 21, 94, DateTimeKind.Utc).AddTicks(4136) });

            migrationBuilder.UpdateData(
                table: "OrganizationIndustryTypes",
                keyColumn: "IndustryTypeId",
                keyValue: new Guid("b2c3d4e5-f6a1-2345-6789-0abcdef12345"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 3, 12, 36, 21, 94, DateTimeKind.Utc).AddTicks(4143), new DateTime(2025, 6, 3, 12, 36, 21, 94, DateTimeKind.Utc).AddTicks(4143) });

            migrationBuilder.UpdateData(
                table: "OrganizationIndustryTypes",
                keyColumn: "IndustryTypeId",
                keyValue: new Guid("c3d4e5f6-a1b2-3456-7890-cdef12345678"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 3, 12, 36, 21, 94, DateTimeKind.Utc).AddTicks(4145), new DateTime(2025, 6, 3, 12, 36, 21, 94, DateTimeKind.Utc).AddTicks(4146) });

            migrationBuilder.UpdateData(
                table: "OrganizationIndustryTypes",
                keyColumn: "IndustryTypeId",
                keyValue: new Guid("d4e5f6a1-b2c3-4567-890a-bcdef1234567"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 3, 12, 36, 21, 94, DateTimeKind.Utc).AddTicks(4147), new DateTime(2025, 6, 3, 12, 36, 21, 94, DateTimeKind.Utc).AddTicks(4148) });

            migrationBuilder.UpdateData(
                table: "QuestTypes",
                keyColumn: "QuestTypeId",
                keyValue: new Guid("a1b2c3d4-e5f6-7890-abcd-ef0123456789"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 3, 12, 36, 21, 94, DateTimeKind.Utc).AddTicks(4574), new DateTime(2025, 6, 3, 12, 36, 21, 94, DateTimeKind.Utc).AddTicks(4574) });

            migrationBuilder.UpdateData(
                table: "QuestTypes",
                keyColumn: "QuestTypeId",
                keyValue: new Guid("b2c3d4e5-f6a1-2345-cdef-0123456789ab"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 3, 12, 36, 21, 94, DateTimeKind.Utc).AddTicks(4578), new DateTime(2025, 6, 3, 12, 36, 21, 94, DateTimeKind.Utc).AddTicks(4579) });

            migrationBuilder.UpdateData(
                table: "QuestTypes",
                keyColumn: "QuestTypeId",
                keyValue: new Guid("c3d4e5f6-a1b2-3456-7890-abcdef012345"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 3, 12, 36, 21, 94, DateTimeKind.Utc).AddTicks(4581), new DateTime(2025, 6, 3, 12, 36, 21, 94, DateTimeKind.Utc).AddTicks(4581) });

            migrationBuilder.UpdateData(
                table: "QuestTypes",
                keyColumn: "QuestTypeId",
                keyValue: new Guid("d4e5f6a1-b2c3-4567-890a-bcdef0123456"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 3, 12, 36, 21, 94, DateTimeKind.Utc).AddTicks(4582), new DateTime(2025, 6, 3, 12, 36, 21, 94, DateTimeKind.Utc).AddTicks(4583) });

            migrationBuilder.InsertData(
                table: "StockAdjustmentTypes",
                columns: new[] { "AdjustmentTypeId", "CreatedAt", "Effect", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("01a1b2c3-d4e5-6f78-9012-3456789abc01"), new DateTime(2025, 6, 3, 12, 36, 21, 95, DateTimeKind.Utc).AddTicks(7245), "Increase", "รับเข้า", new DateTime(2025, 6, 3, 12, 36, 21, 95, DateTimeKind.Utc).AddTicks(7245) },
                    { new Guid("02a1b2c3-d4e5-6f78-9012-3456789abc02"), new DateTime(2025, 6, 3, 12, 36, 21, 95, DateTimeKind.Utc).AddTicks(7250), "Decrease", "เบิกออก", new DateTime(2025, 6, 3, 12, 36, 21, 95, DateTimeKind.Utc).AddTicks(7251) },
                    { new Guid("03a1b2c3-d4e5-6f78-9012-3456789abc03"), new DateTime(2025, 6, 3, 12, 36, 21, 95, DateTimeKind.Utc).AddTicks(7255), "Increase", "ปรับเพิ่ม", new DateTime(2025, 6, 3, 12, 36, 21, 95, DateTimeKind.Utc).AddTicks(7255) },
                    { new Guid("04a1b2c3-d4e5-6f78-9012-3456789abc04"), new DateTime(2025, 6, 3, 12, 36, 21, 95, DateTimeKind.Utc).AddTicks(7269), "Decrease", "ปรับลด", new DateTime(2025, 6, 3, 12, 36, 21, 95, DateTimeKind.Utc).AddTicks(7270) },
                    { new Guid("05a1b2c3-d4e5-6f78-9012-3456789abc05"), new DateTime(2025, 6, 3, 12, 36, 21, 95, DateTimeKind.Utc).AddTicks(7341), "Decrease", "ผลผลิต (Product Output)", new DateTime(2025, 6, 3, 12, 36, 21, 95, DateTimeKind.Utc).AddTicks(7342) }
                });

            migrationBuilder.UpdateData(
                table: "SubscriptionPlans",
                keyColumn: "PlanId",
                keyValue: new Guid("11223344-5566-7788-99aa-bbccddeeff00"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 3, 12, 36, 21, 94, DateTimeKind.Utc).AddTicks(4427), new DateTime(2025, 6, 3, 12, 36, 21, 94, DateTimeKind.Utc).AddTicks(4428) });

            migrationBuilder.UpdateData(
                table: "SubscriptionPlans",
                keyColumn: "PlanId",
                keyValue: new Guid("aabbccdd-eeff-1122-3344-5566778899aa"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 3, 12, 36, 21, 94, DateTimeKind.Utc).AddTicks(4447), new DateTime(2025, 6, 3, 12, 36, 21, 94, DateTimeKind.Utc).AddTicks(4447) });

            migrationBuilder.UpdateData(
                table: "SubscriptionPlans",
                keyColumn: "PlanId",
                keyValue: new Guid("ccddeeff-aabb-3344-5566-778899aabbcc"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 3, 12, 36, 21, 94, DateTimeKind.Utc).AddTicks(4451), new DateTime(2025, 6, 3, 12, 36, 21, 94, DateTimeKind.Utc).AddTicks(4452) });

            migrationBuilder.UpdateData(
                table: "UnitGroups",
                keyColumn: "UnitGroupId",
                keyValue: new Guid("a1b2c3d4-e5f6-7890-1234-567890fedcba"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 3, 12, 36, 21, 94, DateTimeKind.Utc).AddTicks(4490), new DateTime(2025, 6, 3, 12, 36, 21, 94, DateTimeKind.Utc).AddTicks(4491) });

            migrationBuilder.UpdateData(
                table: "UnitGroups",
                keyColumn: "UnitGroupId",
                keyValue: new Guid("e1f2a3b4-c5d6-e7f8-a9b0-c1d2e3f4a5b6"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 3, 12, 36, 21, 94, DateTimeKind.Utc).AddTicks(4485), new DateTime(2025, 6, 3, 12, 36, 21, 94, DateTimeKind.Utc).AddTicks(4486) });

            migrationBuilder.UpdateData(
                table: "UnitGroups",
                keyColumn: "UnitGroupId",
                keyValue: new Guid("f2a3b4c5-d6e7-f8a9-b0c1-d2e3f4a5b6c7"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 3, 12, 36, 21, 94, DateTimeKind.Utc).AddTicks(4489), new DateTime(2025, 6, 3, 12, 36, 21, 94, DateTimeKind.Utc).AddTicks(4489) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasures",
                keyColumn: "UnitId",
                keyValue: new Guid("1a2b3c4d-5e6f-7a8b-9c0d-1e2f3a4b5c6d"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 3, 12, 36, 21, 94, DateTimeKind.Utc).AddTicks(4516), new DateTime(2025, 6, 3, 12, 36, 21, 94, DateTimeKind.Utc).AddTicks(4516) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasures",
                keyColumn: "UnitId",
                keyValue: new Guid("2b3c4d5e-6f7a-8b9c-0d1e-2f3a4b5c6d7e"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 3, 12, 36, 21, 94, DateTimeKind.Utc).AddTicks(4522), new DateTime(2025, 6, 3, 12, 36, 21, 94, DateTimeKind.Utc).AddTicks(4522) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasures",
                keyColumn: "UnitId",
                keyValue: new Guid("3c4d5e6f-7a8b-9c0d-1e2f-3a4b5c6d7e8f"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 3, 12, 36, 21, 94, DateTimeKind.Utc).AddTicks(4526), new DateTime(2025, 6, 3, 12, 36, 21, 94, DateTimeKind.Utc).AddTicks(4526) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasures",
                keyColumn: "UnitId",
                keyValue: new Guid("4d5e6f7a-8b9c-0d1e-2f3a-4b5c6d7e8f9a"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 3, 12, 36, 21, 94, DateTimeKind.Utc).AddTicks(4536), new DateTime(2025, 6, 3, 12, 36, 21, 94, DateTimeKind.Utc).AddTicks(4536) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasures",
                keyColumn: "UnitId",
                keyValue: new Guid("5e6f7a8b-9c0d-1e2f-3a4b-5c6d7e8f9a0b"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 3, 12, 36, 21, 94, DateTimeKind.Utc).AddTicks(4539), new DateTime(2025, 6, 3, 12, 36, 21, 94, DateTimeKind.Utc).AddTicks(4540) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasures",
                keyColumn: "UnitId",
                keyValue: new Guid("6f7a8b9c-0d1e-2f3a-4b5c-6d7e8f9a0b1c"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 3, 12, 36, 21, 94, DateTimeKind.Utc).AddTicks(4542), new DateTime(2025, 6, 3, 12, 36, 21, 94, DateTimeKind.Utc).AddTicks(4542) });

            migrationBuilder.UpdateData(
                table: "UnitsOfMeasures",
                keyColumn: "UnitId",
                keyValue: new Guid("7a8b9c0d-1e2f-3a4b-5c6d-7e8f9a0b1c2d"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 3, 12, 36, 21, 94, DateTimeKind.Utc).AddTicks(4545), new DateTime(2025, 6, 3, 12, 36, 21, 94, DateTimeKind.Utc).AddTicks(4545) });

            migrationBuilder.CreateIndex(
                name: "IX_StockAdjustments_AdjustmentTypeId",
                table: "StockAdjustments",
                column: "AdjustmentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_StockAdjustments_ComponentId",
                table: "StockAdjustments",
                column: "ComponentId");

            migrationBuilder.CreateIndex(
                name: "IX_StockAdjustments_OrganizationId",
                table: "StockAdjustments",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_StockAdjustments_UnitOfMeasureId",
                table: "StockAdjustments",
                column: "UnitOfMeasureId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StockAdjustments");

            migrationBuilder.DropTable(
                name: "StockAdjustmentTypes");

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
        }
    }
}
