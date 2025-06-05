// Path: CRAFTHER.Backend/Services/IProductCostingService.cs
using CRAFTHER.Backend.DTOs.BOMItems; // สำหรับ WhatIfBomItemDto
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRAFTHER.Backend.Services
{
    public interface IProductCostingService
    {
        // คำนวณต้นทุนของ Product จาก BOM และ Trigger การอัปเดตแบบ Multi-level
        Task RecalculateProductCostAsync(Guid productId, Guid organizationId);

        // คำนวณต้นทุนแบบจำลอง (What-If Analysis)
        Task<decimal?> GetWhatIfCalculatedCostAsync(Guid productId, Guid organizationId, List<WhatIfBomItemDto> whatIfItems);

        // Trigger การคำนวณต้นทุน Product ที่ได้รับผลกระทบจากการเปลี่ยนแปลงราคา Component
        Task RecalculateProductsAffectedByComponentPriceChange(Guid componentId, Guid organizationId);
    }
}