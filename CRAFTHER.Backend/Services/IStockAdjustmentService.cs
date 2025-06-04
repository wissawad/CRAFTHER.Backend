// Path: CRAFTHER.Backend/Services/IStockAdjustmentService.cs
using CRAFTHER.Backend.DTOs;
using CRAFTHER.Backend.DTOs.StockAdjustments;
using CRAFTHER.Backend.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRAFTHER.Backend.Services
{
    public interface IStockAdjustmentService
    {
        Task<IEnumerable<StockAdjustmentResponseDto>> GetAllStockAdjustmentsAsync(Guid organizationId); 
        Task<IEnumerable<StockAdjustmentType>> GetAllStockAdjustmentTypesAsync();
        Task<IEnumerable<CurrentStockBalanceDto>> GetCurrentStockBalancesAsync(Guid organizationId);
        Task<StockAdjustmentResponseDto?> GetStockAdjustmentByIdAsync(Guid adjustmentId, Guid organizationId);
        Task<StockAdjustmentResponseDto> CreateStockAdjustmentAsync(CreateStockAdjustmentDto createDto, Guid organizationId);
        Task<StockAdjustmentResponseDto?> UpdateStockAdjustmentAsync(UpdateStockAdjustmentDto updateDto, Guid organizationId);
        Task<bool> DeleteStockAdjustmentAsync(Guid adjustmentId, Guid organizationId);
    }
}