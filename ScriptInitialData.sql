-- CRAFTHER Test Data Insertion Script
-- Created by Tech (CRAFTHER Developer)
-- For testing a Cafe/Bakery and a Fashion/Apparel (BERRER) organization.

-- SET NOCOUNT ON prevents the message "x rows affected" from appearing for each statement,
-- which can clutter the results pane when running large scripts.
SET NOCOUNT ON;

PRINT 'Starting data insertion for CRAFTHER Test Environment...';

----------------------------------------------------
-- 1. Master Data Seeding (If not already present or for custom types)
----------------------------------------------------

-- OrganizationIndustryTypes
-- Add 'Fashion / Apparel' if it doesn't exist
DECLARE @FashionApparelIndustryTypeId UNIQUEIDENTIFIER = NEWID();
IF NOT EXISTS (SELECT 1 FROM OrganizationIndustryTypes WHERE IndustryTypeName = 'Fashion / Apparel')
BEGIN
    SET @FashionApparelIndustryTypeId = NEWID();
    INSERT INTO OrganizationIndustryTypes (IndustryTypeId, IndustryTypeName, Description, CreatedAt, UpdatedAt)
    VALUES (@FashionApparelIndustryTypeId, 'Fashion / Apparel', 'Businesses manufacturing and selling clothing and accessories.', GETUTCDATE(), GETUTCDATE());
    PRINT 'Inserted OrganizationIndustryType: Fashion / Apparel';
END
ELSE
BEGIN
    SELECT @FashionApparelIndustryTypeId = IndustryTypeId FROM OrganizationIndustryTypes WHERE IndustryTypeName = 'Fashion / Apparel';
    PRINT 'OrganizationIndustryType "Fashion / Apparel" already exists.';
END

-- Use existing seeded ItemCategories (from Migration) or create if needed
DECLARE @FoodIngredientCategoryId UNIQUEIDENTIFIER = 'C0000000-0000-0000-0000-000000000001';
DECLARE @FinishedFoodProductCategoryId UNIQUEIDENTIFIER = 'C0000000-0000-0000-0000-000000000003';
DECLARE @FabricCategoryId UNIQUEIDENTIFIER = 'C0000000-0000-0000-0000-000000000005';
DECLARE @ClothingAccessoryCategoryId UNIQUEIDENTIFIER = 'C0000000-0000-0000-0000-000000000006';
DECLARE @FinishedGarmentCategoryId UNIQUEIDENTIFIER = 'C0000000-0000-0000-0000-000000000007';

-- Use existing seeded UnitGroups (from Migration)
DECLARE @WeightUnitGroupId UNIQUEIDENTIFIER = 'A0000000-0000-0000-0000-000000000001'; -- Weight
DECLARE @VolumeUnitGroupId UNIQUEIDENTIFIER = 'A0000000-0000-0000-0000-000000000002'; -- Volume
DECLARE @CountUnitGroupId UNIQUEIDENTIFIER = 'A0000000-0000-0000-0000-000000000003'; -- Count
DECLARE @LengthUnitGroupId UNIQUEIDENTIFIER = 'A0000000-0000-0000-0000-000000000004'; -- Length

-- Use existing seeded UnitsOfMeasure (from Migration)
DECLARE @GramUnitId UNIQUEIDENTIFIER = 'B0000000-0000-0000-0000-000000000001';  -- g
DECLARE @KilogramUnitId UNIQUEIDENTIFIER = 'B0000000-0000-0000-0000-000000000002'; -- kg
DECLARE @MilliliterUnitId UNIQUEIDENTIFIER = 'B0000000-0000-0000-0000-000000000006';-- ml
DECLARE @LiterUnitId UNIQUEIDENTIFIER = 'B0000000-0000-0000-0000-000000000007';  -- l
DECLARE @PieceUnitId UNIQUEIDENTIFIER = 'B0000000-0000-0000-0000-00000000000B';  -- pcs
DECLARE @MeterUnitId UNIQUEIDENTIFIER = 'B0000000-0000-0000-0000-00000000000E';  -- m
DECLARE @CentiMeterUnitId UNIQUEIDENTIFIER = 'B0000000-0000-0000-0000-00000000000F';-- cm
DECLARE @TeaspoonUnitId UNIQUEIDENTIFIER = 'B0000000-0000-0000-0000-000000000008'; -- tsp
DECLARE @TablespoonUnitId UNIQUEIDENTIFIER = 'B0000000-0000-0000-0000-000000000009'; -- tbsp
DECLARE @CupUnitId UNIQUEIDENTIFIER = 'B0000000-0000-0000-0000-00000000000A';  -- cup

-- Use existing seeded SubscriptionPlans (from Migration)
DECLARE @FreePlanId UNIQUEIDENTIFIER = '11223344-5566-7788-99AA-BBCCDDEEFF00';
DECLARE @BasicPlanId UNIQUEIDENTIFIER = 'AABBCCDD-EEFF-1122-3344-5566778899AA';
DECLARE @ProPlanId UNIQUEIDENTIFIER = 'CCDDEEFF-AABB-3344-5566-778899AABBCC';

-- Use existing seeded StockAdjustmentTypes (from Migration)
DECLARE @ReceiveAdjTypeId UNIQUEIDENTIFIER = '01A1B2C3-D4E5-6F78-9012-3456789ABC01'; -- Receive
DECLARE @IssueAdjTypeId UNIQUEIDENTIFIER = '02A1B2C3-D4E5-6F78-9012-3456789ABC02';  -- Issue
DECLARE @ProductionInAdjTypeId UNIQUEIDENTIFIER = '05A1B2C3-D4E5-6F78-9012-3456789ABC05'; -- Production In
DECLARE @ConsumptionAdjTypeId UNIQUEIDENTIFIER = '06A1B2C3-D4E5-6F78-9012-3456789ABC06'; -- Consumption


PRINT 'Master data preparation complete.';

----------------------------------------------------
-- 2. Organizations
----------------------------------------------------
DECLARE @CafeOrgId UNIQUEIDENTIFIER = NEWID();
DECLARE @BerrerOrgId UNIQUEIDENTIFIER = NEWID();

INSERT INTO Organizations (OrganizationId, OrganizationName, Description, Address, PhoneNumber, Email, Website, IndustryTypeId, PlanId, CreatedAt, UpdatedAt)
VALUES
    (@CafeOrgId, 'Brew & Bite Cafe', 'Cozy cafe specializing in coffee and homemade cakes.', '123 Coffee St, Bangkok', '0812345678', 'contact@brewbite.com', 'www.brewbite.com', (SELECT IndustryTypeId FROM OrganizationIndustryTypes WHERE IndustryTypeName = 'Cafe / Coffee Shop'), @BasicPlanId, GETUTCDATE(), GETUTCDATE()),
    (@BerrerOrgId, 'BERRER Menswear', 'Fashion brand for stylish big & tall men.', '456 Fashion Ave, Bangkok', '0987654321', 'info@berrer.com', 'www.berrer.com', @FashionApparelIndustryTypeId, @BasicPlanId, GETUTCDATE(), GETUTCDATE());

PRINT 'Organizations inserted.';

----------------------------------------------------
-- 3. Components (Raw Materials)
----------------------------------------------------
-- Cafe Components
DECLARE @CoffeeBeanId UNIQUEIDENTIFIER = NEWID();
DECLARE @MilkId UNIQUEIDENTIFIER = NEWID();
DECLARE @SugarId UNIQUEIDENTIFIER = NEWID();
DECLARE @FlourId UNIQUEIDENTIFIER = NEWID();
DECLARE @ChocolateId UNIQUEIDENTIFIER = NEWID();

INSERT INTO Components (ComponentId, OrganizationId, ComponentCode, ComponentName, Description, ImageUrl, UnitPrice, PurchaseUnitId, PurchaseToInventoryConversionFactor, InventoryUnitId, CurrentStockQuantity, MinimumStockLevel, ItemCategoryId, CreatedAt, UpdatedAt)
VALUES
    (@CoffeeBeanId, @CafeOrgId, 'CB001', 'Arabica Coffee Beans', 'Premium roasted coffee beans.', NULL, 350.00, @KilogramUnitId, 1000.0, @GramUnitId, 0.00, 10000.00, @FoodIngredientCategoryId, GETUTCDATE(), GETUTCDATE()),
    (@MilkId, @CafeOrgId, 'MLK001', 'Fresh Milk', 'Pasteurized cow milk.', NULL, 42.00, @LiterUnitId, 1000.0, @MilliliterUnitId, 0.00, 5000.00, @FoodIngredientCategoryId, GETUTCDATE(), GETUTCDATE()),
    (@SugarId, @CafeOrgId, 'SGR001', 'Granulated Sugar', 'Fine white sugar.', NULL, 25.00, @KilogramUnitId, 1000.0, @GramUnitId, 0.00, 2000.00, @FoodIngredientCategoryId, GETUTCDATE(), GETUTCDATE()),
    (@FlourId, @CafeOrgId, 'FLR001', 'All-Purpose Flour', 'Wheat flour for baking.', NULL, 30.00, @KilogramUnitId, 1000.0, @GramUnitId, 0.00, 5000.00, @FoodIngredientCategoryId, GETUTCDATE(), GETUTCDATE()),
    (@ChocolateId, @CafeOrgId, 'CHC001', 'Dark Chocolate Bar', 'Baking chocolate.', NULL, 120.00, @PieceUnitId, 200.0, @GramUnitId, 0.00, 1000.00, @FoodIngredientCategoryId, GETUTCDATE(), GETUTCDATE());

-- BERRER Components
DECLARE @CottonFabricId UNIQUEIDENTIFIER = NEWID();
DECLARE @ButtonId UNIQUEIDENTIFIER = NEWID();
DECLARE @ThreadId UNIQUEIDENTIFIER = NEWID();
DECLARE @ZipperId UNIQUEIDENTIFIER = NEWID();
DECLARE @LabelId UNIQUEIDENTIFIER = NEWID();

INSERT INTO Components (ComponentId, OrganizationId, ComponentCode, ComponentName, Description, ImageUrl, UnitPrice, PurchaseUnitId, PurchaseToInventoryConversionFactor, InventoryUnitId, CurrentStockQuantity, MinimumStockLevel, ItemCategoryId, CreatedAt, UpdatedAt)
VALUES
    (@CottonFabricId, @BerrerOrgId, 'FAB001', 'Organic Cotton Fabric (Blue)', 'High-quality organic cotton fabric.', NULL, 150.00, @MeterUnitId, 1.0, @MeterUnitId, 0.00, 50.00, @FabricCategoryId, GETUTCDATE(), GETUTCDATE()),
    (@ButtonId, @BerrerOrgId, 'BTN001', 'Large Brown Button', 'Wooden buttons, 2cm diameter.', NULL, 5.00, @PieceUnitId, 1.0, @PieceUnitId, 0.00, 200.00, @ClothingAccessoryCategoryId, GETUTCDATE(), GETUTCDATE()),
    (@ThreadId, @BerrerOrgId, 'THD001', 'Polyester Thread (Navy)', 'Strong polyester sewing thread.', NULL, 20.00, @PieceUnitId, 1.0, @PieceUnitId, 0.00, 50.00, @ClothingAccessoryCategoryId, GETUTCDATE(), GETUTCDATE()),
    (@ZipperId, @BerrerOrgId, 'ZIP001', 'Metal Zipper (Black)', 'Heavy duty metal zipper, 20cm.', NULL, 12.00, @PieceUnitId, 1.0, @PieceUnitId, 0.00, 100.00, @ClothingAccessoryCategoryId, GETUTCDATE(), GETUTCDATE()),
    (@LabelId, @BerrerOrgId, 'LBL001', 'BERRER Brand Label', 'Woven brand labels.', NULL, 3.00, @PieceUnitId, 1.0, @PieceUnitId, 0.00, 500.00, @ClothingAccessoryCategoryId, GETUTCDATE(), GETUTCDATE());

PRINT 'Components inserted.';

----------------------------------------------------
-- 4. Products (Finished Goods / Sub-Products)
----------------------------------------------------
-- Cafe Products
DECLARE @LatteId UNIQUEIDENTIFIER = NEWID();
DECLARE @MochaId UNIQUEIDENTIFIER = NEWID();
DECLARE @ChocolateCakeId UNIQUEIDENTIFIER = NEWID();
DECLARE @OrangeCakeId UNIQUEIDENTIFIER = NEWID(); -- Example SubProduct

INSERT INTO Products (ProductId, OrganizationId, ProductCode, ProductName, Description, ImageUrl, ProductUnitId, SaleUnitId, ProductUnitToSaleUnitConversionFactor, CurrentStockQuantity, SellingPrice, CalculatedCost, IsSubProduct, ItemCategoryId, CreatedAt, UpdatedAt)
VALUES
    (@LatteId, @CafeOrgId, 'DRK001', 'Cafe Latte', 'Classic espresso with steamed milk.', NULL, @PieceUnitId, @PieceUnitId, 1.0, 0.00, 80.00, 0.00, 0, @FinishedFoodProductCategoryId, GETUTCDATE(), GETUTCDATE()),
    (@MochaId, @CafeOrgId, 'DRK002', 'Cafe Mocha', 'Espresso with chocolate and steamed milk.', NULL, @PieceUnitId, @PieceUnitId, 1.0, 0.00, 95.00, 0.00, 0, @FinishedFoodProductCategoryId, GETUTCDATE(), GETUTCDATE()),
    (@ChocolateCakeId, @CafeOrgId, 'CAK001', 'Rich Chocolate Cake', 'Decadent chocolate cake slice.', NULL, @PieceUnitId, @PieceUnitId, 1.0, 0.00, 120.00, 0.00, 0, @FinishedFoodProductCategoryId, GETUTCDATE(), GETUTCDATE()),
    (@OrangeCakeId, @CafeOrgId, 'CAK002', 'Orange Cake (Base)', 'Moist orange cake base for other desserts.', NULL, @PieceUnitId, @PieceUnitId, 1.0, 0.00, 0.00, 0.00, 1, @FinishedFoodProductCategoryId, GETUTCDATE(), GETUTCDATE());

-- BERRER Products
DECLARE @MensShirtId UNIQUEIDENTIFIER = NEWID();
DECLARE @CargoShortsId UNIQUEIDENTIFIER = NEWID();
DECLARE @GraphicTeeId UNIQUEIDENTIFIER = NEWID();

INSERT INTO Products (ProductId, OrganizationId, ProductCode, ProductName, Description, ImageUrl, ProductUnitId, SaleUnitId, ProductUnitToSaleUnitConversionFactor, CurrentStockQuantity, SellingPrice, CalculatedCost, IsSubProduct, ItemCategoryId, CreatedAt, UpdatedAt)
VALUES
    (@MensShirtId, @BerrerOrgId, 'TOP001', 'Classic Oxford Shirt (L)', 'Blue Oxford button-down shirt, size L.', NULL, @PieceUnitId, @PieceUnitId, 1.0, 0.00, 899.00, 0.00, 0, @FinishedGarmentCategoryId, GETUTCDATE(), GETUTCDATE()),
    (@CargoShortsId, @BerrerOrgId, 'BOT001', 'Rugged Cargo Shorts (XL)', 'Khaki cargo shorts, size XL.', NULL, @PieceUnitId, @PieceUnitId, 1.0, 0.00, 650.00, 0.00, 0, @FinishedGarmentCategoryId, GETUTCDATE(), GETUTCDATE()),
    (@GraphicTeeId, @BerrerOrgId, 'TEE001', 'BERRER Logo Tee (XXL)', 'Black t-shirt with brand logo, size XXL.', NULL, @PieceUnitId, @PieceUnitId, 1.0, 0.00, 450.00, 0.00, 0, @FinishedGarmentCategoryId, GETUTCDATE(), GETUTCDATE());

PRINT 'Products inserted.';

----------------------------------------------------
-- 5. BOMItems (Recipes / Bill of Materials)
----------------------------------------------------
-- Latte BOM
INSERT INTO BOMItems (BOMItemId, ParentProductId, ComponentId, ProductId, ComponentType, Quantity, UsageUnitId, Remarks, SortOrder, CreatedAt, UpdatedAt)
VALUES
    (NEWID(), @LatteId, @CoffeeBeanId, NULL, 'COMPONENT', 20.0, @GramUnitId, 'For one shot espresso', 1, GETUTCDATE(), GETUTCDATE()),
    (NEWID(), @LatteId, @MilkId, NULL, 'COMPONENT', 200.0, @MilliliterUnitId, 'Steamed milk', 2, GETUTCDATE(), GETUTCDATE()),
    (NEWID(), @LatteId, @SugarId, NULL, 'COMPONENT', 5.0, @GramUnitId, 'Optional sugar', 3, GETUTCDATE(), GETUTCDATE());

-- Mocha BOM
INSERT INTO BOMItems (BOMItemId, ParentProductId, ComponentId, ProductId, ComponentType, Quantity, UsageUnitId, Remarks, SortOrder, CreatedAt, UpdatedAt)
VALUES
    (NEWID(), @MochaId, @CoffeeBeanId, NULL, 'COMPONENT', 20.0, @GramUnitId, 'For one shot espresso', 1, GETUTCDATE(), GETUTCDATE()),
    (NEWID(), @MochaId, @ChocolateId, NULL, 'COMPONENT', 30.0, @GramUnitId, 'Chocolate syrup', 2, GETUTCDATE(), GETUTCDATE()),
    (NEWID(), @MochaId, @MilkId, NULL, 'COMPONENT', 180.0, @MilliliterUnitId, 'Steamed milk', 3, GETUTCDATE(), GETUTCDATE());

-- Rich Chocolate Cake BOM (includes Orange Cake as sub-product)
INSERT INTO BOMItems (BOMItemId, ParentProductId, ComponentId, ProductId, ComponentType, Quantity, UsageUnitId, Remarks, SortOrder, CreatedAt, UpdatedAt)
VALUES
    (NEWID(), @ChocolateCakeId, NULL, @OrangeCakeId, 'PRODUCT', 0.5, @PieceUnitId, 'Half a base orange cake', 1, GETUTCDATE(), GETUTCDATE()),
    (NEWID(), @ChocolateCakeId, @ChocolateId, NULL, 'COMPONENT', 100.0, @GramUnitId, 'For frosting', 2, GETUTCDATE(), GETUTCDATE()),
    (NEWID(), @ChocolateCakeId, @SugarId, NULL, 'COMPONENT', 50.0, @GramUnitId, 'For frosting', 3, GETUTCDATE(), GETUTCDATE());

-- Orange Cake BOM (Base cake for other desserts)
INSERT INTO BOMItems (BOMItemId, ParentProductId, ComponentId, ProductId, ComponentType, Quantity, UsageUnitId, Remarks, SortOrder, CreatedAt, UpdatedAt)
VALUES
    (NEWID(), @OrangeCakeId, @FlourId, NULL, 'COMPONENT', 200.0, @GramUnitId, 'Cake base flour', 1, GETUTCDATE(), GETUTCDATE()),
    (NEWID(), @OrangeCakeId, @SugarId, NULL, 'COMPONENT', 150.0, @GramUnitId, 'Cake base sugar', 2, GETUTCDATE(), GETUTCDATE()),
    (NEWID(), @OrangeCakeId, @MilkId, NULL, 'COMPONENT', 100.0, @MilliliterUnitId, 'Cake base milk', 3, GETUTCDATE(), GETUTCDATE());

-- Classic Oxford Shirt BOM
INSERT INTO BOMItems (BOMItemId, ParentProductId, ComponentId, ProductId, ComponentType, Quantity, UsageUnitId, Remarks, SortOrder, CreatedAt, UpdatedAt)
VALUES
    (NEWID(), @MensShirtId, @CottonFabricId, NULL, 'COMPONENT', 2.5, @MeterUnitId, '2.5 meters for one shirt', 1, GETUTCDATE(), GETUTCDATE()),
    (NEWID(), @MensShirtId, @ButtonId, NULL, 'COMPONENT', 8.0, @PieceUnitId, '8 buttons for front and cuffs', 2, GETUTCDATE(), GETUTCDATE()),
    (NEWID(), @MensShirtId, @ThreadId, NULL, 'COMPONENT', 1.0, @PieceUnitId, 'One spool of thread', 3, GETUTCDATE(), GETUTCDATE()),
    (NEWID(), @MensShirtId, @LabelId, NULL, 'COMPONENT', 1.0, @PieceUnitId, 'Brand label', 4, GETUTCDATE(), GETUTCDATE());

-- Rugged Cargo Shorts BOM
INSERT INTO BOMItems (BOMItemId, ParentProductId, ComponentId, ProductId, ComponentType, Quantity, UsageUnitId, Remarks, SortOrder, CreatedAt, UpdatedAt)
VALUES
    (NEWID(), @CargoShortsId, @CottonFabricId, NULL, 'COMPONENT', 1.8, @MeterUnitId, '1.8 meters for one pair', 1, GETUTCDATE(), GETUTCDATE()),
    (NEWID(), @CargoShortsId, @ZipperId, NULL, 'COMPONENT', 1.0, @PieceUnitId, 'One zipper', 2, GETUTCDATE(), GETUTCDATE()),
    (NEWID(), @CargoShortsId, @ThreadId, NULL, 'COMPONENT', 0.5, @PieceUnitId, 'Half spool of thread', 3, GETUTCDATE(), GETUTCDATE()),
    (NEWID(), @CargoShortsId, @ButtonId, NULL, 'COMPONENT', 2.0, @PieceUnitId, 'Two small buttons for pockets', 4, GETUTCDATE(), GETUTCDATE());

PRINT 'BOMItems inserted.';

----------------------------------------------------
-- 6. Stock Adjustments (Initial Stock)
----------------------------------------------------
-- Cafe Initial Stock
INSERT INTO StockAdjustments (AdjustmentId, OrganizationId, ComponentId, AdjustmentTypeId, Quantity, UnitOfMeasureId, QuantityBeforeAdjustment, QuantityAfterAdjustment, Notes, AdjustmentDate, CreatedAt, UpdatedAt)
VALUES
    (NEWID(), @CafeOrgId, @CoffeeBeanId, @ReceiveAdjTypeId, 5.0, @KilogramUnitId, 0.00, 5000.00, 'Initial stock from supplier', GETUTCDATE(), GETUTCDATE(), GETUTCDATE()),
    (NEWID(), @CafeOrgId, @MilkId, @ReceiveAdjTypeId, 10.0, @LiterUnitId, 0.00, 10000.00, 'Initial stock from supplier', GETUTCDATE(), GETUTCDATE(), GETUTCDATE()),
    (NEWID(), @CafeOrgId, @SugarId, @ReceiveAdjTypeId, 3.0, @KilogramUnitId, 0.00, 3000.00, 'Initial stock from supplier', GETUTCDATE(), GETUTCDATE(), GETUTCDATE()),
    (NEWID(), @CafeOrgId, @FlourId, @ReceiveAdjTypeId, 4.0, @KilogramUnitId, 0.00, 4000.00, 'Initial stock from supplier', GETUTCDATE(), GETUTCDATE(), GETUTCDATE()),
    (NEWID(), @CafeOrgId, @ChocolateId, @ReceiveAdjTypeId, 10.0, @PieceUnitId, 0.00, 2000.00, 'Initial stock from supplier', GETUTCDATE(), GETUTCDATE(), GETUTCDATE());

-- Update Component CurrentStockQuantity after initial adjustments
UPDATE C
SET C.CurrentStockQuantity = SA.QuantityAfterAdjustment
FROM Components C
JOIN StockAdjustments SA ON C.ComponentId = SA.ComponentId
WHERE SA.OrganizationId = @CafeOrgId
  AND SA.AdjustmentTypeId = @ReceiveAdjTypeId; -- Only update for initial 'Receive' adjustments

-- BERRER Initial Stock
INSERT INTO StockAdjustments (AdjustmentId, OrganizationId, ComponentId, AdjustmentTypeId, Quantity, UnitOfMeasureId, QuantityBeforeAdjustment, QuantityAfterAdjustment, Notes, AdjustmentDate, CreatedAt, UpdatedAt)
VALUES
    (NEWID(), @BerrerOrgId, @CottonFabricId, @ReceiveAdjTypeId, 100.0, @MeterUnitId, 0.00, 100.00, 'Initial fabric roll', GETUTCDATE(), GETUTCDATE(), GETUTCDATE()),
    (NEWID(), @BerrerOrgId, @ButtonId, @ReceiveAdjTypeId, 500.0, @PieceUnitId, 0.00, 500.00, 'Initial button supply', GETUTCDATE(), GETUTCDATE(), GETUTCDATE()),
    (NEWID(), @BerrerOrgId, @ThreadId, @ReceiveAdjTypeId, 100.0, @PieceUnitId, 0.00, 100.00, 'Initial thread supply', GETUTCDATE(), GETUTCDATE(), GETUTCDATE()),
    (NEWID(), @BerrerOrgId, @ZipperId, @ReceiveAdjTypeId, 200.0, @PieceUnitId, 0.00, 200.00, 'Initial zipper supply', GETUTCDATE(), GETUTCDATE(), GETUTCDATE()),
    (NEWID(), @BerrerOrgId, @LabelId, @ReceiveAdjTypeId, 1000.0, @PieceUnitId, 0.00, 1000.00, 'Initial label supply', GETUTCDATE(), GETUTCDATE(), GETUTCDATE());

-- Update Component CurrentStockQuantity after initial adjustments
UPDATE C
SET C.CurrentStockQuantity = SA.QuantityAfterAdjustment
FROM Components C
JOIN StockAdjustments SA ON C.ComponentId = SA.ComponentId
WHERE SA.OrganizationId = @BerrerOrgId
  AND SA.AdjustmentTypeId = @ReceiveAdjTypeId;

PRINT 'Stock Adjustments (Initial) inserted and Component quantities updated.';


----------------------------------------------------
-- OPTIONAL: Example of how to UPDATE an existing user's OrganizationId
-- After you create a user via the frontend registration process.
----------------------------------------------------
/*
-- Step 1: Get the UserId of the user you just registered via frontend.
-- You can find this in your 'Users' table by their Email.
DECLARE @NewFrontendUserId UNIQUEIDENTIFIER = 'YOUR_USER_ID_FROM_FRONTEND_HERE'; -- REPLACE THIS WITH ACTUAL USER ID
DECLARE @TargetOrgId UNIQUEIDENTIFIER = @CafeOrgId; -- Or @BerrerOrgId

-- Step 2: Update the OrganizationId for that user
UPDATE Users
SET OrganizationId = @TargetOrgId,
    UpdatedAt = GETUTCDATE()
WHERE Id = @NewFrontendUserId;

PRINT 'Optional: Updated a user''s OrganizationId. Remember to set the correct User ID and Target Organization ID.';
*/

PRINT 'Data insertion script complete!';