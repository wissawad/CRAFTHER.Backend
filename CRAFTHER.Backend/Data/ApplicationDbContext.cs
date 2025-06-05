using Microsoft.EntityFrameworkCore;
using CRAFTHER.Backend.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace CRAFTHER.Backend.Data
{
    // Changed from DbContext to IdentityDbContext and specified ApplicationUser, ApplicationRole, Guid
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // DbSets for custom models
        public DbSet<Organization> Organizations { get; set; } = default!;
        public DbSet<OrganizationIndustryType> OrganizationIndustryTypes { get; set; } = default!;
        public DbSet<SubscriptionPlan> SubscriptionPlans { get; set; } = default!;
        public DbSet<UnitGroup> UnitGroups { get; set; } = default!;
        public DbSet<UnitOfMeasure> UnitsOfMeasures { get; set; } = default!;
        public DbSet<ItemCategory> ItemCategories { get; set; } = default!; 
        public DbSet<Component> Components { get; set; } = default!;
        public DbSet<Product> Products { get; set; } = default!;
        public DbSet<BOMItem> BOMItems { get; set; } = default!;
        public DbSet<UnitConversion> UnitConversions { get; set; } = default!;
        public DbSet<StockAdjustmentType> StockAdjustmentTypes { get; set; } = default!;
        public DbSet<StockAdjustment> StockAdjustments { get; set; } = default!;
        public DbSet<ProductionOrder> ProductionOrders { get; set; } = default!;
        public DbSet<ProductionOrderItem> ProductionOrderItems { get; set; } = default!;
        public DbSet<ComponentPriceHistory> ComponentPriceHistories { get; set; } = default!;

        // DbSets for Quest Models
        public DbSet<Quest> Quests { get; set; } = default!;
        public DbSet<UserQuest> UserQuests { get; set; } = default!;
        public DbSet<UserScore> UserScores { get; set; } = default!;
        public DbSet<Level> Levels { get; set; } = default!;
        public DbSet<QuestType> QuestTypes { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // *** Identity Models Configuration ***
            // Customizing the table names (optional, but good practice for clarity)
            modelBuilder.Entity<ApplicationUser>().ToTable("Users");
            modelBuilder.Entity<ApplicationRole>().ToTable("Roles");
            modelBuilder.Entity<IdentityUserRole<Guid>>().ToTable("UserRoles");
            modelBuilder.Entity<IdentityUserClaim<Guid>>().ToTable("UserClaims");
            modelBuilder.Entity<IdentityUserLogin<Guid>>().ToTable("UserLogins");
            modelBuilder.Entity<IdentityRoleClaim<Guid>>().ToTable("RoleClaims");
            modelBuilder.Entity<IdentityUserToken<Guid>>().ToTable("UserTokens");

            // Relationship for ApplicationUser to Organization
            modelBuilder.Entity<ApplicationUser>()
                .HasOne(u => u.Organization)
                .WithMany(o => o.Users)
                .HasForeignKey(u => u.OrganizationId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent deleting Organization if Users still exist


            // *** Core Models Configuration ***

            // OrganizationIndustryType
            // No specific configurations needed unless unique constraints or data seeding are required

            // SubscriptionPlan
            // No specific configurations needed unless unique constraints or data seeding are required

            // UnitGroup - Expanded and English
            modelBuilder.Entity<UnitGroup>().HasIndex(ug => ug.UnitGroupName).IsUnique();
            modelBuilder.Entity<UnitGroup>().HasData(
                new UnitGroup { UnitGroupId = Guid.Parse("A0000000-0000-0000-0000-000000000001"), UnitGroupName = "Weight", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new UnitGroup { UnitGroupId = Guid.Parse("A0000000-0000-0000-0000-000000000002"), UnitGroupName = "Volume", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new UnitGroup { UnitGroupId = Guid.Parse("A0000000-0000-0000-0000-000000000003"), UnitGroupName = "Count", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new UnitGroup { UnitGroupId = Guid.Parse("A0000000-0000-0000-0000-000000000004"), UnitGroupName = "Length", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow } // Added more groups
            );

            // UnitOfMeasure - Expanded and English, with correct conversion factors
            modelBuilder.Entity<UnitOfMeasure>().HasIndex(u => new { u.UnitGroupId, u.UnitName }).IsUnique();
            modelBuilder.Entity<UnitOfMeasure>().HasIndex(u => new { u.UnitGroupId, u.Abbreviation }).IsUnique();
            modelBuilder.Entity<UnitOfMeasure>()
                .HasOne(u => u.UnitGroup)
                .WithMany(ug => ug.UnitsOfMeasure)
                .HasForeignKey(u => u.UnitGroupId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent deleting UnitGroup if UnitOfMeasure exists

            // --- ADDED: Ensure only one base unit per UnitGroup using a filtered index (SQL Server specific) ---
            modelBuilder.Entity<UnitOfMeasure>()
                .HasIndex(u => new { u.UnitGroupId, u.IsBaseUnit })
                .HasFilter("[IsBaseUnit] = 1") // Filters to only apply unique constraint where IsBaseUnit is true
                .IsUnique();
            // --- END ADDED ---

            // Seed Data for UnitOfMeasure (Expanded and English)
            modelBuilder.Entity<UnitOfMeasure>().HasData(
                // Weight (Base: Gram)
                new UnitOfMeasure { UnitId = Guid.Parse("B0000000-0000-0000-0000-000000000001"), UnitGroupId = Guid.Parse("A0000000-0000-0000-0000-000000000001"), UnitName = "Gram", Abbreviation = "g", IsBaseUnit = true, ConversionFactorToBaseUnit = 1.0m, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new UnitOfMeasure { UnitId = Guid.Parse("B0000000-0000-0000-0000-000000000002"), UnitGroupId = Guid.Parse("A0000000-0000-0000-0000-000000000001"), UnitName = "Kilogram", Abbreviation = "kg", IsBaseUnit = false, ConversionFactorToBaseUnit = 1000.0m, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new UnitOfMeasure { UnitId = Guid.Parse("B0000000-0000-0000-0000-000000000003"), UnitGroupId = Guid.Parse("A0000000-0000-0000-0000-000000000001"), UnitName = "Milligram", Abbreviation = "mg", IsBaseUnit = false, ConversionFactorToBaseUnit = 0.001m, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new UnitOfMeasure { UnitId = Guid.Parse("B0000000-0000-0000-0000-000000000004"), UnitGroupId = Guid.Parse("A0000000-0000-0000-0000-000000000001"), UnitName = "Pound", Abbreviation = "lb", IsBaseUnit = false, ConversionFactorToBaseUnit = 453.59237m, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow }, // Approx. 1 lb = 453.592 g
                new UnitOfMeasure { UnitId = Guid.Parse("B0000000-0000-0000-0000-000000000005"), UnitGroupId = Guid.Parse("A0000000-0000-0000-0000-000000000001"), UnitName = "Ounce", Abbreviation = "oz", IsBaseUnit = false, ConversionFactorToBaseUnit = 28.349523125m, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow }, // Approx. 1 oz = 28.3495 g

                // Volume (Base: Milliliter)
                new UnitOfMeasure { UnitId = Guid.Parse("B0000000-0000-0000-0000-000000000006"), UnitGroupId = Guid.Parse("A0000000-0000-0000-0000-000000000002"), UnitName = "Milliliter", Abbreviation = "ml", IsBaseUnit = true, ConversionFactorToBaseUnit = 1.0m, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new UnitOfMeasure { UnitId = Guid.Parse("B0000000-0000-0000-0000-000000000007"), UnitGroupId = Guid.Parse("A0000000-0000-0000-0000-000000000002"), UnitName = "Liter", Abbreviation = "l", IsBaseUnit = false, ConversionFactorToBaseUnit = 1000.0m, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new UnitOfMeasure { UnitId = Guid.Parse("B0000000-0000-0000-0000-000000000008"), UnitGroupId = Guid.Parse("A0000000-0000-0000-0000-000000000002"), UnitName = "Teaspoon", Abbreviation = "tsp", IsBaseUnit = false, ConversionFactorToBaseUnit = 4.92892m, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow }, // Approx. 1 tsp = 4.92892 ml
                new UnitOfMeasure { UnitId = Guid.Parse("B0000000-0000-0000-0000-000000000009"), UnitGroupId = Guid.Parse("A0000000-0000-0000-0000-000000000002"), UnitName = "Tablespoon", Abbreviation = "tbsp", IsBaseUnit = false, ConversionFactorToBaseUnit = 14.7868m, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow }, // Approx. 1 tbsp = 14.7868 ml
                new UnitOfMeasure { UnitId = Guid.Parse("B0000000-0000-0000-0000-00000000000A"), UnitGroupId = Guid.Parse("A0000000-0000-0000-0000-000000000002"), UnitName = "Cup", Abbreviation = "cup", IsBaseUnit = false, ConversionFactorToBaseUnit = 236.588m, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow }, // Approx. 1 cup = 236.588 ml

                // Count (Base: Piece)
                new UnitOfMeasure { UnitId = Guid.Parse("B0000000-0000-0000-0000-00000000000B"), UnitGroupId = Guid.Parse("A0000000-0000-0000-0000-000000000003"), UnitName = "Piece", Abbreviation = "pcs", IsBaseUnit = true, ConversionFactorToBaseUnit = 1.0m, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new UnitOfMeasure { UnitId = Guid.Parse("B0000000-0000-0000-0000-00000000000C"), UnitGroupId = Guid.Parse("A0000000-0000-0000-0000-000000000003"), UnitName = "Dozen", Abbreviation = "dz", IsBaseUnit = false, ConversionFactorToBaseUnit = 12.0m, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new UnitOfMeasure { UnitId = Guid.Parse("B0000000-0000-0000-0000-00000000000D"), UnitGroupId = Guid.Parse("A0000000-0000-0000-0000-000000000003"), UnitName = "Pair", Abbreviation = "pr", IsBaseUnit = false, ConversionFactorToBaseUnit = 2.0m, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },

                // Length (Base: Meter)
                new UnitOfMeasure { UnitId = Guid.Parse("B0000000-0000-0000-0000-00000000000E"), UnitGroupId = Guid.Parse("A0000000-0000-0000-0000-000000000004"), UnitName = "Meter", Abbreviation = "m", IsBaseUnit = true, ConversionFactorToBaseUnit = 1.0m, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new UnitOfMeasure { UnitId = Guid.Parse("B0000000-0000-0000-0000-00000000000F"), UnitGroupId = Guid.Parse("A0000000-0000-0000-0000-000000000004"), UnitName = "Centimeter", Abbreviation = "cm", IsBaseUnit = false, ConversionFactorToBaseUnit = 0.01m, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow }
            );


            // Component
            modelBuilder.Entity<Component>().HasIndex(c => new { c.OrganizationId, c.ComponentCode }).IsUnique();
            modelBuilder.Entity<Component>()
                .HasOne(c => c.PurchaseUnit)
                .WithMany()
                .HasForeignKey(c => c.PurchaseUnitId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent deleting UnitOfMeasure if used as PurchaseUnit
            modelBuilder.Entity<Component>()
                .HasOne(c => c.InventoryUnit)
                .WithMany()
                .HasForeignKey(c => c.InventoryUnitId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent deleting UnitOfMeasure if used as InventoryUnit
            modelBuilder.Entity<Component>()
                .HasOne(c => c.Organization)
                .WithMany(o => o.Components) // Assuming Organization has a Components collection
                .HasForeignKey(c => c.OrganizationId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent deleting Organization if Components exist

            // Product
            modelBuilder.Entity<Product>().HasIndex(p => new { p.OrganizationId, p.ProductCode }).IsUnique();
            modelBuilder.Entity<Product>()
                .HasOne(p => p.ProductUnit)
                .WithMany()
                .HasForeignKey(p => p.ProductUnitId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent deleting UnitOfMeasure if used as ProductUnit

            // --- ADDED: Relationship for Product.SaleUnit ---
            modelBuilder.Entity<Product>()
                .HasOne(p => p.SaleUnit)
                .WithMany() // UnitOfMeasure does not need a collection of Products using it as SaleUnit
                .HasForeignKey(p => p.SaleUnitId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent deleting UnitOfMeasure if used as SaleUnit
            // --- END ADDED ---

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Organization)
                .WithMany(o => o.Products) // Assuming Organization has a Products collection
                .HasForeignKey(p => p.OrganizationId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent deleting Organization if Products exist

            // UnitConversion
            modelBuilder.Entity<UnitConversion>().HasIndex(uc => new { uc.OrganizationId, uc.FromUnitId, uc.ToUnitId }).IsUnique();
            modelBuilder.Entity<UnitConversion>()
                .HasOne(uc => uc.FromUnit)
                .WithMany()
                .HasForeignKey(uc => uc.FromUnitId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent deleting UnitOfMeasure if used in UnitConversion
            modelBuilder.Entity<UnitConversion>()
                .HasOne(uc => uc.ToUnit)
                .WithMany()
                .HasForeignKey(uc => uc.ToUnitId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent deleting UnitOfMeasure if used in UnitConversion
            modelBuilder.Entity<UnitConversion>()
                .HasOne(uc => uc.Organization)
                .WithMany() // Assuming Organization doesn't need a collection of UnitConversions
                .HasForeignKey(uc => uc.OrganizationId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent deleting Organization if UnitConversions exist

            // StockAdjustmentType - English
            modelBuilder.Entity<StockAdjustmentType>().HasIndex(sat => sat.Name).IsUnique();
            modelBuilder.Entity<StockAdjustmentType>().HasData(
                new StockAdjustmentType { AdjustmentTypeId = Guid.Parse("01A1B2C3-D4E5-6F78-9012-3456789ABC01"), Name = "Receive", Effect = "Increase", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new StockAdjustmentType { AdjustmentTypeId = Guid.Parse("02A1B2C3-D4E5-6F78-9012-3456789ABC02"), Name = "Issue", Effect = "Decrease", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new StockAdjustmentType { AdjustmentTypeId = Guid.Parse("03A1B2C3-D4E5-6F78-9012-3456789ABC03"), Name = "Positive Adjustment", Effect = "Increase", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new StockAdjustmentType { AdjustmentTypeId = Guid.Parse("04A1B2C3-D4E5-6F78-9012-3456789ABC04"), Name = "Negative Adjustment", Effect = "Decrease", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new StockAdjustmentType { AdjustmentTypeId = Guid.Parse("05A1B2C3-D4E5-6F78-9012-3456789ABC05"), Name = "Production In", Effect = "Increase", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow }, // For finished goods production
                new StockAdjustmentType { AdjustmentTypeId = Guid.Parse("06A1B2C3-D4E5-6F78-9012-3456789ABC06"), Name = "Consumption", Effect = "Decrease", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow } // For raw material consumption in production
            );

            // StockAdjustment
            modelBuilder.Entity<StockAdjustment>()
                .HasOne(sa => sa.Organization)
                .WithMany() // Assuming Organization doesn't need a collection of StockAdjustments
                .HasForeignKey(sa => sa.OrganizationId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent deleting Organization if StockAdjustments exist
            modelBuilder.Entity<StockAdjustment>()
                .HasOne(sa => sa.Component)
                .WithMany() // Assuming Component doesn't need a collection of StockAdjustments
                .HasForeignKey(sa => sa.ComponentId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent deleting Component if StockAdjustments exist
            modelBuilder.Entity<StockAdjustment>()
                .HasOne(sa => sa.Product) // Navigation property ไปยัง Product
                .WithMany() // Assuming Product doesn't need a collection of StockAdjustments
                .HasForeignKey(sa => sa.ProductId) // ProductId ที่เพิ่มเข้ามา
                .OnDelete(DeleteBehavior.Restrict); // Prevent deleting Product if StockAdjustments exist
            modelBuilder.Entity<StockAdjustment>()
                .HasOne(sa => sa.AdjustmentType)
                .WithMany() // Assuming StockAdjustmentType doesn't need a collection of StockAdjustments
                .HasForeignKey(sa => sa.AdjustmentTypeId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent deleting StockAdjustmentType if StockAdjustments exist
            modelBuilder.Entity<StockAdjustment>()
                .HasOne(sa => sa.UnitOfMeasure)
                .WithMany() // Assuming UnitOfMeasure doesn't need a collection of StockAdjustments
                .HasForeignKey(sa => sa.UnitOfMeasureId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent deleting UnitOfMeasure if StockAdjustments exist
            // *** เพิ่ม Unique Index เพื่อบังคับว่า Adjustment ต้องมีแค่ Component หรือ Product เท่านั้น ***
            // Unique index: ห้ามมี ComponentId และ ProductId มีค่าพร้อมกันใน StockAdjustment เดียวกัน (partial unique index)
            // สำหรับ SQL Server, Filtered Index ใช้ HasFilter:
            modelBuilder.Entity<StockAdjustment>()
                .HasIndex(sa => new { sa.ComponentId, sa.ProductId })
                .IsUnique()
                // เพิ่ม HasFilter เพื่อบังคับว่าต้องไม่เป็น NULL ทั้งคู่
                .HasFilter("[ComponentId] IS NOT NULL AND [ProductId] IS NOT NULL")
                .HasDatabaseName("IX_StockAdjustments_ComponentId_ProductId_NotNull"); // ตั้งชื่อ Index ให้ชัดเจน
            // *** สิ้นสุดการเพิ่ม Unique Index ***


            // BOMItem
            modelBuilder.Entity<BOMItem>()
                .HasOne(bi => bi.ParentProduct)
                .WithMany(p => p.BOMItems) // Parent Product has a collection of its BOMItems
                .HasForeignKey(bi => bi.ParentProductId)
                .OnDelete(DeleteBehavior.Cascade); // If Parent Product is deleted, cascade delete related BOMItems

            // --- ADDED: Relationships for BOMItem's Component and SubProduct ---
            modelBuilder.Entity<BOMItem>()
                .HasOne(bi => bi.Component)
                .WithMany() // Assuming Component doesn't need a direct collection of BOMItems
                .HasForeignKey(bi => bi.ComponentId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent deleting Component if used in BOM

            modelBuilder.Entity<BOMItem>()
                .HasOne(bi => bi.SubProduct) // Matches the SubProduct navigation property name in BOMItem
                .WithMany(p => p.SubProductBOMItems) // Matches the collection name in Product Model
                .HasForeignKey(bi => bi.ProductId) // Matches the FK property name in BOMItem
                .OnDelete(DeleteBehavior.Restrict); // Prevent deleting Product if used as SubProduct in another BOM
            // --- END ADDED ---

            modelBuilder.Entity<BOMItem>()
                .HasOne(bi => bi.UsageUnit)
                .WithMany() // Assuming UnitOfMeasure doesn't need a collection of BOMItems using it as UsageUnit
                .HasForeignKey(bi => bi.UsageUnitId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent deleting UnitOfMeasure if used in BOMItem

            // Unique index for BOMItem to prevent duplicate components/sub-products for a parent
            // This ensures a ParentProduct can only have one of a specific Component or one of a specific Product (as SubProduct)
            modelBuilder.Entity<BOMItem>().HasIndex(bi => new { bi.ParentProductId, bi.ComponentId, bi.ProductId }).IsUnique();

            // --- เพิ่ม ProductionOrder Configuration ---
            modelBuilder.Entity<ProductionOrder>().HasIndex(po => new { po.OrganizationId, po.ProductionOrderCode }).IsUnique();
            modelBuilder.Entity<ProductionOrder>()
                .HasOne(po => po.Organization)
                .WithMany() // ถ้าไม่ต้องการ Navigation Property ใน Organization
                .HasForeignKey(po => po.OrganizationId)
                .OnDelete(DeleteBehavior.Restrict); // ป้องกันลบ Organization ถ้ามี ProductionOrder ผูกอยู่

            modelBuilder.Entity<ProductionOrder>()
                .HasOne(po => po.Product)
                .WithMany() // Product ไม่มี Collection ของ ProductionOrders โดยตรง
                .HasForeignKey(po => po.ProductId)
                .OnDelete(DeleteBehavior.Restrict); // ป้องกันลบ Product ถ้ามี ProductionOrder ผูกอยู่

            modelBuilder.Entity<ProductionOrder>()
                .HasOne(po => po.UnitOfMeasure)
                .WithMany()
                .HasForeignKey(po => po.UnitOfMeasureId)
                .OnDelete(DeleteBehavior.Restrict); // ป้องกันลบ UnitOfMeasure ถ้ามี ProductionOrder ผูกอยู่
            // ------------------------------------------

            // --- เพิ่ม ProductionOrderItem Configuration ---
            modelBuilder.Entity<ProductionOrderItem>()
                .HasOne(poi => poi.ProductionOrder)
                .WithMany(po => po.ProductionOrderItems) // ProductionOrder มี Collection ของ ProductionOrderItems
                .HasForeignKey(poi => poi.ProductionOrderId)
                .OnDelete(DeleteBehavior.Cascade); // ถ้าลบ ProductionOrder ให้ลบ ProductionOrderItem ที่เกี่ยวข้องด้วย

            modelBuilder.Entity<ProductionOrderItem>()
                .HasOne(poi => poi.Component)
                .WithMany()
                .HasForeignKey(poi => poi.ComponentId)
                .OnDelete(DeleteBehavior.Restrict); // ป้องกันลบ Component ถ้าถูกใช้ใน ProductionOrderItem

            modelBuilder.Entity<ProductionOrderItem>()
                .HasOne(poi => poi.SubProduct) // ใช้ SubProduct ตามชื่อใน Model
                .WithMany() // Product ไม่มี Collection ของ ProductionOrderItems (เป็น SubProduct) โดยตรง
                .HasForeignKey(poi => poi.ProductId) // ใช้ ProductId เป็น Foreign Key
                .OnDelete(DeleteBehavior.Restrict); // ป้องกันลบ Product ถ้าถูกใช้ใน ProductionOrderItem

            modelBuilder.Entity<ProductionOrderItem>()
                .HasOne(poi => poi.UsageUnit)
                .WithMany()
                .HasForeignKey(poi => poi.UsageUnitId)
                .OnDelete(DeleteBehavior.Restrict); // ป้องกันลบ UnitOfMeasure ถ้าถูกใช้ใน ProductionOrderItem

            // Unique index: ห้ามมี Component/Product ซ้ำกันใน ProductionOrder เดียวกัน
            modelBuilder.Entity<ProductionOrderItem>()
                .HasIndex(poi => new { poi.ProductionOrderId, poi.ComponentId, poi.ProductId })
                .IsUnique();
            // ----------------------------------------------

            // *** เพิ่ม ComponentPriceHistory Configuration ***
            modelBuilder.Entity<ComponentPriceHistory>()
                .HasOne(cph => cph.Component)
                .WithMany() // Component อาจจะไม่มี Collection ของ Price Histories โดยตรง
                .HasForeignKey(cph => cph.ComponentId)
                .OnDelete(DeleteBehavior.Cascade); // ถ้าลบ Component ให้ลบประวัติราคาด้วย

            modelBuilder.Entity<ComponentPriceHistory>()
                .HasOne(cph => cph.Organization)
                .WithMany() // Organization อาจจะไม่มี Collection ของ Price Histories โดยตรง
                .HasForeignKey(cph => cph.OrganizationId)
                .OnDelete(DeleteBehavior.Restrict); // ป้องกันลบ Organization ถ้ามีประวัติราคาผูกอยู่

            // Optional: ถ้ามี ChangedByUserId
            modelBuilder.Entity<ComponentPriceHistory>()
                .HasOne(cph => cph.ChangedByUser)
                .WithMany()
                .HasForeignKey(cph => cph.ChangedByUserId)
                .OnDelete(DeleteBehavior.SetNull); // ถ้า User ถูกลบ ให้ ChangedByUserId เป็น null (หรือ Restrict)

            // Optional: Unique Index เพื่อป้องกันการบันทึกซ้ำซ้อนในวันเดียวกัน หรือตามความต้องการ
            // เช่น อาจจะอยากมีแค่ 1 record ต่อวันต่อ Component
            // modelBuilder.Entity<ComponentPriceHistory>()
            //    .HasIndex(cph => new { cph.ComponentId, cph.ChangeDate.Date }) // Index by Component and Date only
            //    .IsUnique();
            // ************************************************


            // *** Quest Models Configuration (You must define relationships here if they exist) ***
            // Example:
            // modelBuilder.Entity<UserQuest>()
            //     .HasOne(uq => uq.ApplicationUser)
            //     .WithMany(u => u.UserQuests)
            //     .HasForeignKey(uq => uq.UserId)
            //     .OnDelete(DeleteBehavior.Cascade); // Or Restrict depending on your logic

            // modelBuilder.Entity<UserQuest>()
            //     .HasOne(uq => uq.Quest)
            //     .WithMany(q => q.UserQuests)
            //     .HasForeignKey(uq => uq.QuestId)
            //     .OnDelete(DeleteBehavior.Restrict);

            // ... and similar configurations for other Quest related models (UserScore, Level, QuestType)
            // Make sure to define foreign keys and delete behaviors according to your design.

            // --- Seeding Data ---

            // Seeding OrganizationIndustryTypes
            var cafeIndustryId = Guid.Parse("A1B2C3D4-E5F6-7890-1234-567890ABCDEF");
            var bakeryIndustryId = Guid.Parse("B2C3D4E5-F6A1-2345-6789-0ABCDEF12345");
            var restaurantIndustryId = Guid.Parse("C3D4E5F6-A1B2-3456-7890-CDEF12345678");
            var craftIndustryId = Guid.Parse("D4E5F6A1-B2C3-4567-890A-BCDEF1234567");

            modelBuilder.Entity<OrganizationIndustryType>().HasData(
                new OrganizationIndustryType { IndustryTypeId = cafeIndustryId, IndustryTypeName = "Cafe / Coffee Shop", Description = "Businesses primarily focused on coffee, tea, and light snacks." },
                new OrganizationIndustryType { IndustryTypeId = bakeryIndustryId, IndustryTypeName = "Bakery / Confectionery", Description = "Businesses specializing in baked goods, pastries, and sweets." },
                new OrganizationIndustryType { IndustryTypeId = restaurantIndustryId, IndustryTypeName = "Restaurant / Eatery", Description = "Businesses serving prepared meals and beverages." },
                new OrganizationIndustryType { IndustryTypeId = craftIndustryId, IndustryTypeName = "Crafts / Handmade Goods", Description = "Businesses producing and selling handmade products." }
            );

            // Seeding SubscriptionPlans
            var freePlanId = Guid.Parse("11223344-5566-7788-99AA-BBCCDDEEFF00");
            var basicPlanId = Guid.Parse("AABBCCDD-EEFF-1122-3344-5566778899AA");
            var proPlanId = Guid.Parse("CCDDEEFF-AABB-3344-5566-778899AABBCC");

            modelBuilder.Entity<SubscriptionPlan>().HasData(
                new SubscriptionPlan
                {
                    PlanId = freePlanId,
                    PlanName = "Free",
                    Price = 0.00m,
                    Description = "Basic features for small businesses to get started.",
                    MaxProducts = 5,
                    MaxComponents = 20,
                    MaxUsers = 1,
                    StorageSpaceMB = 50,
                    CanAccessAdvancedReports = false,
                    CanIntegratePOS = false
                },
                new SubscriptionPlan
                {
                    PlanId = basicPlanId,
                    PlanName = "Basic",
                    Price = 199.00m,
                    Description = "Essential tools for growing businesses.",
                    MaxProducts = 50,
                    MaxComponents = 200,
                    MaxUsers = 3,
                    StorageSpaceMB = 500,
                    CanAccessAdvancedReports = true,
                    CanIntegratePOS = false
                },
                new SubscriptionPlan
                {
                    PlanId = proPlanId,
                    PlanName = "Pro",
                    Price = 499.00m,
                    Description = "Advanced features for established businesses.",
                    MaxProducts = 0, // 0 means unlimited
                    MaxComponents = 0, // 0 means unlimited
                    MaxUsers = 0, // 0 means unlimited
                    StorageSpaceMB = 5000,
                    CanAccessAdvancedReports = true,
                    CanIntegratePOS = true
                }
            );

            // ItemCategory Configuration and Seeding
            modelBuilder.Entity<ItemCategory>().HasIndex(ic => ic.CategoryName).IsUnique();
            modelBuilder.Entity<ItemCategory>().HasData(
                new ItemCategory { ItemCategoryId = Guid.Parse("C0000000-0000-0000-0000-000000000001"), CategoryName = "Food Ingredient", Description = "Raw materials used in food and beverage production.", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new ItemCategory { ItemCategoryId = Guid.Parse("C0000000-0000-0000-0000-000000000002"), CategoryName = "Beverage Ingredient", Description = "Raw materials used in beverage production.", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new ItemCategory { ItemCategoryId = Guid.Parse("C0000000-0000-0000-0000-000000000003"), CategoryName = "Finished Food Product", Description = "Ready-to-sell food items.", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new ItemCategory { ItemCategoryId = Guid.Parse("C0000000-0000-0000-0000-000000000004"), CategoryName = "Finished Beverage Product", Description = "Ready-to-sell beverage items.", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new ItemCategory { ItemCategoryId = Guid.Parse("C0000000-0000-0000-0000-000000000005"), CategoryName = "Fabric", Description = "Textile materials for garment production.", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow }, // New for clothing
                new ItemCategory { ItemCategoryId = Guid.Parse("C0000000-0000-0000-0000-000000000006"), CategoryName = "Accessory (Clothing)", Description = "Buttons, zippers, threads, etc. for clothing.", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow }, // New for clothing
                new ItemCategory { ItemCategoryId = Guid.Parse("C0000000-0000-0000-0000-000000000007"), CategoryName = "Finished Garment", Description = "Ready-to-sell clothing items.", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow }, // New for clothing
                new ItemCategory { ItemCategoryId = Guid.Parse("C0000000-0000-0000-0000-000000000008"), CategoryName = "Packaging Material", Description = "Materials used for product packaging.", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new ItemCategory { ItemCategoryId = Guid.Parse("C0000000-0000-0000-0000-000000000009"), CategoryName = "Other", Description = "Miscellaneous items not fitting other categories.", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow }
            );

            // Seeding QuestTypes
            var dailyQuestTypeId = Guid.Parse("A1B2C3D4-E5F6-7890-ABCD-EF0123456789");
            var weeklyQuestTypeId = Guid.Parse("B2C3D4E5-F6A1-2345-CDEF-0123456789AB");
            var mainStoryQuestTypeId = Guid.Parse("C3D4E5F6-A1B2-3456-7890-ABCDEF012345");
            var challengeQuestTypeId = Guid.Parse("D4E5F6A1-B2C3-4567-890A-BCDEF0123456");

            modelBuilder.Entity<QuestType>().HasData(
                new QuestType { QuestTypeId = dailyQuestTypeId, QuestTypeName = "DAILY", Description = "Quests that refresh daily." },
                new QuestType { QuestTypeId = weeklyQuestTypeId, QuestTypeName = "WEEKLY", Description = "Quests that refresh weekly." },
                new QuestType { QuestTypeId = mainStoryQuestTypeId, QuestTypeName = "MAIN_STORY", Description = "Core progression quests." },
                new QuestType { QuestTypeId = challengeQuestTypeId, QuestTypeName = "CHALLENGE", Description = "Difficult, one-time challenges." }
            );

            // Seeding Levels
            modelBuilder.Entity<Level>().HasData(
                new Level { LevelId = Guid.Parse("E1F2A3B4-C5D6-E7F8-A9B0-C1D2E3F4A5B6"), LevelNumber = 1, LevelName = "BOM Novice", RequiredPoints = 0, Description = "Just starting your BOM journey." },
                new Level { LevelId = Guid.Parse("F2A3B4C5-D6E7-F8A9-B0C1-D2E3F4A5B6C7"), LevelNumber = 2, LevelName = "Recipe Apprentice", RequiredPoints = 100, Description = "Learning the ropes of recipe management." },
                new Level { LevelId = Guid.Parse("A0B1C2D3-E4F5-A6B7-C8D9-E0F1A2B3C4D5"), LevelNumber = 3, LevelName = "Ingredient Explorer", RequiredPoints = 300, Description = "Mastering your ingredient knowledge." },
                new Level { LevelId = Guid.Parse("B1C2D3E4-F5A6-B7C8-D9E0-F1A2B3C4D5E6"), LevelNumber = 4, LevelName = "Costing Pro", RequiredPoints = 600, Description = "Becoming an expert in cost analysis." },
                new Level { LevelId = Guid.Parse("C2D3E4F5-A6B7-C8D9-E0F1-A2B3C4D5E6F7"), LevelNumber = 5, LevelName = "CRAFTHER Master", RequiredPoints = 1000, Description = "The ultimate CRAFTHER champion!" }
            );

            // Seeding Roles
            var adminRoleId = Guid.Parse("C1A2B3D4-E5F6-7890-1234-567890ABCDEF");
            var userRoleId = Guid.Parse("D5E6F7A8-B9C0-1234-5678-90ABCDEF1234");

            modelBuilder.Entity<ApplicationRole>().HasData(
                new ApplicationRole { Id = adminRoleId, Name = "Admin", NormalizedName = "ADMIN" },
                new ApplicationRole { Id = userRoleId, Name = "User", NormalizedName = "USER" }
            );
        }
    }
}