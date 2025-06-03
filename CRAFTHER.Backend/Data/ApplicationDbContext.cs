using Microsoft.EntityFrameworkCore;
using CRAFTHER.Backend.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace CRAFTHER.Backend.Data
{
    // เปลี่ยนจาก DbContext เป็น IdentityDbContext และระบุ ApplicationUser, ApplicationRole, Guid
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // DbSets สำหรับ Model ที่เราสร้างขึ้นเอง
        public DbSet<Organization> Organizations { get; set; } = default!;
        public DbSet<OrganizationIndustryType> OrganizationIndustryTypes { get; set; } = default!;
        public DbSet<SubscriptionPlan> SubscriptionPlans { get; set; } = default!;
        public DbSet<UnitGroup> UnitGroups { get; set; } = default!;
        public DbSet<UnitOfMeasure> UnitsOfMeasures { get; set; } = default!;
        public DbSet<Component> Components { get; set; } = default!;
        public DbSet<Product> Products { get; set; } = default!;
        public DbSet<BOMItem> BOMItems { get; set; } = default!;
        public DbSet<Quest> Quests { get; set; } = default!;
        public DbSet<UserQuest> UserQuests { get; set; } = default!;
        public DbSet<UserScore> UserScores { get; set; } = default!;
        public DbSet<Level> Levels { get; set; } = default!;
        public DbSet<QuestType> QuestTypes { get; set; } = default!;
        public DbSet<UnitConversion> UnitConversions { get; set; } = default!;
        public DbSet<StockAdjustmentType> StockAdjustmentTypes { get; set; } = default!;
        public DbSet<StockAdjustment> StockAdjustments { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // ต้องเรียก base.OnModelCreating สำหรับ IdentityDbContext

            // --- กำหนด Unique Index สำหรับ Code ใน Component และ Product (สำคัญ!) ---
            // รหัสต้องไม่ซ้ำกันภายใน Organization เดียวกัน
            modelBuilder.Entity<Component>()
                .HasIndex(c => new { c.OrganizationId, c.ComponentCode })
                .IsUnique();

            modelBuilder.Entity<Product>()
                .HasIndex(p => new { p.OrganizationId, p.ProductCode })
                .IsUnique();
            // ----------------------------------------------------------------------

            // --- กำหนดความสัมพันธ์ระหว่าง ApplicationUser กับ Organization (One-to-Many) ---
            modelBuilder.Entity<ApplicationUser>()
                .HasOne(u => u.Organization)
                .WithMany() // ถ้าไม่ต้องการ Navigation Property ใน Organization ไปหา Users
                .HasForeignKey(u => u.OrganizationId)
                .OnDelete(DeleteBehavior.Restrict); // ป้องกันการลบ Organization ถ้ายังมี User อยู่

            // หากต้องการ Navigation Property ใน Organization เพื่อดู Users:
            // ไปที่ Organization.cs แล้วเพิ่ม: public ICollection<ApplicationUser>? Users { get; set; }
            // แล้วใน OnModelCreating:
            // modelBuilder.Entity<Organization>()
            //    .HasMany(o => o.Users)
            //    .WithOne(u => u.Organization)
            //    .HasForeignKey(u => u.OrganizationId)
            //    .OnDelete(DeleteBehavior.Restrict);
            // ----------------------------------------------------------------------

            // Unique Index สำหรับ UserScore เพื่อให้ 1 User มี UserScore ได้แค่ 1 Record
            modelBuilder.Entity<UserScore>()
                .HasIndex(us => us.UserId)
                .IsUnique();
            // ----------------------------------------------------------------------

            // --- แก้ไข: กำหนดพฤติกรรมการลบสำหรับ Component และ UnitOfMeasure ---
            modelBuilder.Entity<Component>()
                .HasOne(c => c.PurchaseUnit)
                .WithMany() // ไม่จำเป็นต้องมี navigation property ใน UnitOfMeasure กลับมาหา Component
                .HasForeignKey(c => c.PurchaseUnitId)
                .OnDelete(DeleteBehavior.Restrict); // สำคัญ: กำหนดเป็น Restrict หรือ NoAction

            modelBuilder.Entity<Component>()
                .HasOne(c => c.InventoryUnit)
                .WithMany() // ไม่จำเป็นต้องมี navigation property ใน UnitOfMeasure กลับมาหา Component
                .HasForeignKey(c => c.InventoryUnitId)
                .OnDelete(DeleteBehavior.Restrict); // สำคัญ: กำหนดเป็น Restrict หรือ NoAction
            // ---------------------------------------------------------------

            // --- Optional: กำหนด DeleteBehavior สำหรับ BOMItem และ UnitOfMeasure (คล้ายกัน) ---
            // BOMItem ก็มี UsageUnitId ชี้ไปที่ UnitOfMeasure
            modelBuilder.Entity<BOMItem>()
                .HasOne(b => b.UsageUnit)
                .WithMany()
                .HasForeignKey(b => b.UsageUnitId)
                .OnDelete(DeleteBehavior.Restrict);
            // ---------------------------------------------------------------------------------

            // --- Optional: กำหนด DeleteBehavior สำหรับ Product และ Organization (หาก Organization ถูกลบ, ควรทำอย่างไรกับ Product?) ---
            // Default ของ EF Core มักจะเป็น Cascade หากไม่ระบุ
            // หากต้องการป้องกัน Product ถูกลบเมื่อ Organization ถูกลบ:
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Organization)
                .WithMany()
                .HasForeignKey(p => p.OrganizationId)
                .OnDelete(DeleteBehavior.Restrict); // หรือ DeleteBehavior.Cascade ถ้าต้องการ

            // --- Optional: กำหนด DeleteBehavior สำหรับ Component และ Organization (หาก Organization ถูกลบ, ควรทำอย่างไรกับ Component?) ---
            modelBuilder.Entity<Component>()
                .HasOne(c => c.Organization)
                .WithMany()
                .HasForeignKey(c => c.OrganizationId)
                .OnDelete(DeleteBehavior.Restrict); // หรือ DeleteBehavior.Cascade ถ้าต้องการ

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

            // Seeding UnitGroups
            var liquidUnitGroupId = Guid.Parse("E1F2A3B4-C5D6-E7F8-A9B0-C1D2E3F4A5B6");
            var solidUnitGroupId = Guid.Parse("F2A3B4C5-D6E7-F8A9-B0C1-D2E3F4A5B6C7");
            var countUnitGroupId = Guid.Parse("A1B2C3D4-E5F6-7890-1234-567890FEDCBA"); // แก้ไขตรงนี้ให้เป็น Hexadecimal 100%

            modelBuilder.Entity<UnitGroup>().HasData(
                new UnitGroup { UnitGroupId = liquidUnitGroupId, UnitGroupName = "Liquid Volume", Description = "Units for measuring liquid volume." },
                new UnitGroup { UnitGroupId = solidUnitGroupId, UnitGroupName = "Weight / Mass", Description = "Units for measuring weight or mass." },
                new UnitGroup { UnitGroupId = countUnitGroupId, UnitGroupName = "Count / Quantity", Description = "Units for measuring discrete items or counts." }
            );

            // Seeding UnitOfMeasures
            // Liquid Volume Units
            var mlUnitId = Guid.Parse("1A2B3C4D-5E6F-7A8B-9C0D-1E2F3A4B5C6D");
            var literUnitId = Guid.Parse("2B3C4D5E-6F7A-8B9C-0D1E-2F3A4B5C6D7E");
            var tbspUnitId = Guid.Parse("3C4D5E6F-7A8B-9C0D-1E2F-3A4B5C6D7E8F");
            var tspUnitId = Guid.Parse("4D5E6F7A-8B9C-0D1E-2F3A-4B5C6D7E8F9A");

            // Weight/Mass Units
            var gUnitId = Guid.Parse("5E6F7A8B-9C0D-1E2F-3A4B-5C6D7E8F9A0B");
            var kgUnitId = Guid.Parse("6F7A8B9C-0D1E-2F3A-4B5C-6D7E8F9A0B1C");

            // Count Units
            var pieceUnitId = Guid.Parse("7A8B9C0D-1E2F-3A4B-5C6D-7E8F9A0B1C2D");

            modelBuilder.Entity<UnitOfMeasure>().HasData(
                // Liquid
                new UnitOfMeasure { UnitId = mlUnitId, UnitGroupId = liquidUnitGroupId, UnitName = "Milliliter", Abbreviation = "ml", IsBaseUnit = true, ConversionFactorToBaseUnit = 1.0m },
                new UnitOfMeasure { UnitId = literUnitId, UnitGroupId = liquidUnitGroupId, UnitName = "Liter", Abbreviation = "L", IsBaseUnit = false, ConversionFactorToBaseUnit = 1000.0m },
                new UnitOfMeasure { UnitId = tbspUnitId, UnitGroupId = liquidUnitGroupId, UnitName = "Tablespoon", Abbreviation = "tbsp", IsBaseUnit = false, ConversionFactorToBaseUnit = 15.0m }, // 1 tbsp = 15 ml
                new UnitOfMeasure { UnitId = tspUnitId, UnitGroupId = liquidUnitGroupId, UnitName = "Teaspoon", Abbreviation = "tsp", IsBaseUnit = false, ConversionFactorToBaseUnit = 5.0m }, // 1 tsp = 5 ml

                // Weight/Mass
                new UnitOfMeasure { UnitId = gUnitId, UnitGroupId = solidUnitGroupId, UnitName = "Gram", Abbreviation = "g", IsBaseUnit = true, ConversionFactorToBaseUnit = 1.0m },
                new UnitOfMeasure { UnitId = kgUnitId, UnitGroupId = solidUnitGroupId, UnitName = "Kilogram", Abbreviation = "kg", IsBaseUnit = false, ConversionFactorToBaseUnit = 1000.0m },

                // Count
                new UnitOfMeasure { UnitId = pieceUnitId, UnitGroupId = countUnitGroupId, UnitName = "Piece", Abbreviation = "pc", IsBaseUnit = true, ConversionFactorToBaseUnit = 1.0m }
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

            // ตั้งค่าสำหรับ UnitConversion
            modelBuilder.Entity<UnitConversion>()
                .HasOne(uc => uc.FromUnit)
                .WithMany()
                .HasForeignKey(uc => uc.FromUnitId)
                .OnDelete(DeleteBehavior.Restrict); // ไม่ให้ลบหน่วยถ้ามีการใช้งานอยู่ในการแปลง

            modelBuilder.Entity<UnitConversion>()
                .HasOne(uc => uc.ToUnit)
                .WithMany()
                .HasForeignKey(uc => uc.ToUnitId)
                .OnDelete(DeleteBehavior.Restrict); // ไม่ให้ลบหน่วยถ้ามีการใช้งานอยู่ในการแปลง

            // Ensure unique conversion for a given pair of units within an organization
            modelBuilder.Entity<UnitConversion>()
                .HasIndex(uc => new { uc.OrganizationId, uc.FromUnitId, uc.ToUnitId })
                .IsUnique();

            // ตั้งค่าสำหรับ StockAdjustment
            modelBuilder.Entity<StockAdjustment>()
                .HasOne(sa => sa.Organization)
                .WithMany()
                .HasForeignKey(sa => sa.OrganizationId)
                .OnDelete(DeleteBehavior.Restrict); // ไม่ให้ลบ Organization ถ้ามีการปรับปรุงสต็อกอยู่

            modelBuilder.Entity<StockAdjustment>()
                .HasOne(sa => sa.Component)
                .WithMany()
                .HasForeignKey(sa => sa.ComponentId)
                .OnDelete(DeleteBehavior.Restrict); // ไม่ให้ลบ Component ถ้ามีการปรับปรุงสต็อกอยู่

            modelBuilder.Entity<StockAdjustment>()
                .HasOne(sa => sa.AdjustmentType)
                .WithMany()
                .HasForeignKey(sa => sa.AdjustmentTypeId)
                .OnDelete(DeleteBehavior.Restrict); // ไม่ให้ลบ AdjustmentType ถ้ามีการปรับปรุงสต็อกอยู่

            modelBuilder.Entity<StockAdjustment>()
                .HasOne(sa => sa.UnitOfMeasure)
                .WithMany()
                .HasForeignKey(sa => sa.UnitOfMeasureId)
                .OnDelete(DeleteBehavior.Restrict); // ไม่ให้ลบ UnitOfMeasure ถ้ามีการปรับปรุงสต็อกอยู่

            // *** Optional: Seed ข้อมูลเริ่มต้นสำหรับ StockAdjustmentType ***
            modelBuilder.Entity<StockAdjustmentType>().HasData(
                new StockAdjustmentType { AdjustmentTypeId = Guid.Parse("01A1B2C3-D4E5-6F78-9012-3456789ABC01"), Name = "รับเข้า", Effect = "Increase", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new StockAdjustmentType { AdjustmentTypeId = Guid.Parse("02A1B2C3-D4E5-6F78-9012-3456789ABC02"), Name = "เบิกออก", Effect = "Decrease", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new StockAdjustmentType { AdjustmentTypeId = Guid.Parse("03A1B2C3-D4E5-6F78-9012-3456789ABC03"), Name = "ปรับเพิ่ม", Effect = "Increase", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new StockAdjustmentType { AdjustmentTypeId = Guid.Parse("04A1B2C3-D4E5-6F78-9012-3456789ABC04"), Name = "ปรับลด", Effect = "Decrease", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new StockAdjustmentType { AdjustmentTypeId = Guid.Parse("05A1B2C3-D4E5-6F78-9012-3456789ABC05"), Name = "ผลผลิต (Product Output)", Effect = "Decrease", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow } // สำหรับลดวัตถุดิบจากการผลิต
            );
        }
    }
}