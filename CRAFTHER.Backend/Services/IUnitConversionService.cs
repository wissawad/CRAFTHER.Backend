using CRAFTHER.Backend.DTOs.UnitConversions;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace CRAFTHER.Backend.Services
{
    public interface IUnitConversionService
    {
        Task<IEnumerable<UnitConversionResponseDto>> GetAllUnitConversionsAsync(Guid organizationId);
        Task<UnitConversionResponseDto?> GetUnitConversionByIdAsync(Guid unitConversionId, Guid organizationId);
        Task<UnitConversionResponseDto> CreateUnitConversionAsync(CreateUnitConversionDto createUnitConversionDto, Guid organizationId);
        Task<UnitConversionResponseDto?> UpdateUnitConversionAsync(UpdateUnitConversionDto updateUnitConversionDto, Guid organizationId);
        Task<bool> DeleteUnitConversionAsync(Guid unitConversionId, Guid organizationId);

        // เมธอดสำหรับหา Conversion Factor โดยเฉพาะ
        Task<decimal?> GetConversionFactorAsync(Guid fromUnitId, Guid toUnitId, Guid organizationId);
    }
}