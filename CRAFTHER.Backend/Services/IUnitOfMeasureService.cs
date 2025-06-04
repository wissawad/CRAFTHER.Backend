using CRAFTHER.Backend.DTOs.UnitOfMeasures;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRAFTHER.Backend.Services
{
    public interface IUnitOfMeasureService
    {
        Task<IEnumerable<UnitOfMeasureResponseDto>> GetAllUnitsOfMeasureAsync();
        Task<UnitOfMeasureResponseDto?> GetUnitOfMeasureByIdAsync(Guid unitId);
        Task<UnitOfMeasureResponseDto> CreateUnitOfMeasureAsync(CreateUnitOfMeasureDto createUnitOfMeasureDto);
        Task<UnitOfMeasureResponseDto?> UpdateUnitOfMeasureAsync(UpdateUnitOfMeasureDto updateUnitOfMeasureDto);
        Task<bool> DeleteUnitOfMeasureAsync(Guid unitId);
        Task<IEnumerable<UnitOfMeasureResponseDto>> GetUnitsOfMeasureByGroupIdAsync(Guid unitGroupId);
    }
}