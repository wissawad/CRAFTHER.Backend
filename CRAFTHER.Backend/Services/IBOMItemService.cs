using CRAFTHER.Backend.DTOs.BOMItems;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRAFTHER.Backend.Services
{
    public interface IBOMItemService
    {
        // Get all BOM items for a specific Parent Product
        Task<IEnumerable<BOMItemResponseDto>> GetAllBOMItemsByParentProductIdAsync(Guid parentProductId, Guid organizationId);

        // Get a specific BOM item by its ID
        Task<BOMItemResponseDto?> GetBOMItemByIdAsync(Guid bomItemId, Guid parentProductId, Guid organizationId);

        // Create a new BOM item
        Task<BOMItemResponseDto> CreateBOMItemAsync(CreateBOMItemDto createBOMItemDto);

        // Update an existing BOM item
        Task<BOMItemResponseDto?> UpdateBOMItemAsync(UpdateBOMItemDto updateBOMItemDto);

        // Delete a BOM item
        Task<bool> DeleteBOMItemAsync(Guid bomItemId, Guid parentProductId, Guid organizationId);
    }
}