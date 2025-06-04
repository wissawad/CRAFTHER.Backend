using CRAFTHER.Backend.DTOs.UnitGroups;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRAFTHER.Backend.Services
{
    public interface IUnitGroupService
    {
        // ลบ organizationId ออกจาก parameter
        Task<IEnumerable<UnitGroupResponseDto>> GetAllUnitGroupsAsync();
        Task<UnitGroupResponseDto?> GetUnitGroupByIdAsync(Guid unitGroupId);
        Task<UnitGroupResponseDto> CreateUnitGroupAsync(CreateUnitGroupDto createUnitGroupDto);
        Task<UnitGroupResponseDto?> UpdateUnitGroupAsync(UpdateUnitGroupDto updateUnitGroupDto);
        Task<bool> DeleteUnitGroupAsync(Guid unitGroupId);
    }
}