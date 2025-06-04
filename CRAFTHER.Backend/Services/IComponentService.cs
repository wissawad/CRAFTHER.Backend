using CRAFTHER.Backend.DTOs.Components;
using CRAFTHER.Backend.DTOs; // สำหรับ CurrentStockBalanceDto

namespace CRAFTHER.Backend.Services
{
    public interface IComponentService
    {
        Task<IEnumerable<ComponentResponseDto>> GetAllComponentsAsync(Guid organizationId);
        Task<ComponentResponseDto?> GetComponentByIdAsync(Guid componentId, Guid organizationId);
        Task<ComponentResponseDto> CreateComponentAsync(CreateComponentDto createComponentDto);
        Task<ComponentResponseDto?> UpdateComponentAsync(UpdateComponentDto updateComponentDto);
        Task<bool> DeleteComponentAsync(Guid componentId, Guid organizationId);
        Task<CurrentStockBalanceDto?> GetComponentStockBalanceAsync(Guid componentId, Guid organizationId);
    }
}