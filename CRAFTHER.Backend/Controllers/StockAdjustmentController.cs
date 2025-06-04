using CRAFTHER.Backend.Data;
using CRAFTHER.Backend.Models;
using CRAFTHER.Backend.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CRAFTHER.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] // Requires authentication for all actions in this controller
    public class StockAdjustmentController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public StockAdjustmentController(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Helper method to retrieve the OrganizationId from the current user's claims.
        /// </summary>
        /// <returns>The OrganizationId of the logged-in user.</returns>
        /// <exception cref="InvalidOperationException">Thrown if Organization ID is not found in user claims.</exception>
        private Guid GetUserOrganizationId()
        {
            var orgIdClaim = HttpContext.User.FindFirst("OrganizationId");
            if (orgIdClaim == null || !Guid.TryParse(orgIdClaim.Value, out Guid orgId))
            {
                throw new InvalidOperationException("Organization ID not found in user claims. Please check JWT configuration.");
            }
            return orgId;
        }

        /// <summary>
        /// Helper method to convert a quantity from a source unit to a target unit for a specific organization.
        /// This method prioritizes component-specific conversion factors if applicable, then falls back to general unit conversions.
        /// </summary>
        /// <param name="fromUnitId">The ID of the source unit of measure.</param>
        /// <param name="toUnitId">The ID of the target unit of measure.</param>
        /// <param name="quantity">The quantity to convert.</param>
        /// <param name="organizationId">The ID of the organization.</param>
        /// <param name="component">The Component object related to the conversion (optional, for component-specific factors).</param>
        /// <returns>The converted quantity in the target unit.</returns>
        /// <exception cref="InvalidOperationException">Thrown if no valid conversion path is found or if a conversion factor is zero.</exception>
        private async Task<decimal> ConvertQuantityToInventoryUnit(Guid fromUnitId, Guid toUnitId, decimal quantity, Guid organizationId, Component? component = null)
        {
            if (fromUnitId == toUnitId)
            {
                return quantity; // No conversion needed if units are the same
            }

            // 1. Try component-specific conversion first (PurchaseUnit to InventoryUnit)
            if (component != null && fromUnitId == component.PurchaseUnitId && toUnitId == component.InventoryUnitId)
            {
                if (component.PurchaseToInventoryConversionFactor == 0)
                {
                    throw new InvalidOperationException($"Conversion factor from purchase unit '{component.PurchaseUnit?.Abbreviation}' to inventory unit '{component.InventoryUnit?.Abbreviation}' for component '{component.ComponentName}' is zero, which is invalid.");
                }
                return quantity * component.PurchaseToInventoryConversionFactor;
            }

            // 2. Fallback to general UnitConversion table
            // Try direct conversion
            var directConversion = await _context.UnitConversions
                .FirstOrDefaultAsync(uc => uc.OrganizationId == organizationId &&
                                           uc.FromUnitId == fromUnitId &&
                                           uc.ToUnitId == toUnitId);

            if (directConversion != null)
            {
                if (directConversion.ConversionFactor == 0)
                {
                    throw new InvalidOperationException($"Direct unit conversion factor from unit '{fromUnitId}' to '{toUnitId}' is zero, which is invalid.");
                }
                return quantity * directConversion.ConversionFactor;
            }

            // Try reverse conversion
            var reverseConversion = await _context.UnitConversions
                .FirstOrDefaultAsync(uc => uc.OrganizationId == organizationId &&
                                           uc.FromUnitId == toUnitId &&
                                           uc.ToUnitId == fromUnitId);

            if (reverseConversion != null)
            {
                if (reverseConversion.ConversionFactor == 0)
                {
                    throw new InvalidOperationException($"Reverse unit conversion factor from unit '{toUnitId}' to '{fromUnitId}' is zero, which is invalid.");
                }
                return quantity / reverseConversion.ConversionFactor;
            }

            // No conversion path found
            var fromUnit = await _context.UnitsOfMeasures.FindAsync(fromUnitId);
            var toUnit = await _context.UnitsOfMeasures.FindAsync(toUnitId);
            throw new InvalidOperationException($"No conversion path found from '{fromUnit?.Abbreviation ?? fromUnitId.ToString()}' to '{toUnit?.Abbreviation ?? toUnitId.ToString()}' for this organization.");
        }


        // --- API Endpoints for StockAdjustmentType ---

        /// <summary>
        /// Retrieves all available stock adjustment types.
        /// </summary>
        /// <returns>A list of StockAdjustmentType objects.</returns>
        [HttpGet("Types")]
        public async Task<ActionResult<IEnumerable<StockAdjustmentType>>> GetStockAdjustmentTypes()
        {
            return await _context.StockAdjustmentTypes.ToListAsync();
        }

        // --- API Endpoints for StockAdjustment ---

        /// <summary>
        /// Retrieves all stock adjustments for the current user's organization.
        /// </summary>
        /// <returns>A list of StockAdjustment objects.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StockAdjustment>>> GetStockAdjustments()
        {
            var userOrgId = GetUserOrganizationId();
            return await _context.StockAdjustments
                                 .Where(sa => sa.OrganizationId == userOrgId)
                                 .Include(sa => sa.Component)
                                 .Include(sa => sa.AdjustmentType)
                                 .Include(sa => sa.UnitOfMeasure)
                                 .OrderByDescending(sa => sa.AdjustmentDate)
                                 .ToListAsync();
        }

        /// <summary>
        /// Retrieves a specific stock adjustment by its ID for the current user's organization.
        /// </summary>
        /// <param name="id">The ID of the stock adjustment.</param>
        /// <returns>A StockAdjustment object if found, otherwise NotFound.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<StockAdjustment>> GetStockAdjustment(Guid id)
        {
            var userOrgId = GetUserOrganizationId();
            var stockAdjustment = await _context.StockAdjustments
                                                .Include(sa => sa.Component)
                                                .Include(sa => sa.AdjustmentType)
                                                .Include(sa => sa.UnitOfMeasure)
                                                .FirstOrDefaultAsync(sa => sa.AdjustmentId == id && sa.OrganizationId == userOrgId);

            if (stockAdjustment == null)
            {
                return NotFound();
            }

            return stockAdjustment;
        }

        /// <summary>
        /// Creates a new stock adjustment and updates the component's current stock quantity.
        /// </summary>
        /// <param name="stockAdjustment">The StockAdjustment object to create.</param>
        /// <returns>The created StockAdjustment object.</returns>
        [HttpPost]
        [Authorize(Roles = "Admin,Manager")] // Only Admin or Manager roles can create adjustments
        public async Task<ActionResult<StockAdjustment>> PostStockAdjustment(StockAdjustment stockAdjustment)
        {
            var userOrgId = GetUserOrganizationId();
            stockAdjustment.OrganizationId = userOrgId;

            // Retrieve Component including its InventoryUnit and PurchaseUnit for conversion logic
            var component = await _context.Components
                                          .Include(c => c.InventoryUnit)
                                          .Include(c => c.PurchaseUnit) // Essential for component-specific conversion
                                          .FirstOrDefaultAsync(c => c.ComponentId == stockAdjustment.ComponentId && c.OrganizationId == userOrgId);
            if (component == null)
            {
                return BadRequest("Component not found or does not belong to your organization.");
            }

            var adjustmentType = await _context.StockAdjustmentTypes.FindAsync(stockAdjustment.AdjustmentTypeId);
            if (adjustmentType == null)
            {
                return BadRequest("Invalid stock adjustment type.");
            }

            var adjustmentUnit = await _context.UnitsOfMeasures.FindAsync(stockAdjustment.UnitOfMeasureId);
            if (adjustmentUnit == null)
            {
                return BadRequest("Invalid unit of measure for stock adjustment.");
            }

            // Calculate quantity in the component's InventoryUnit
            decimal quantityInInventoryUnit;
            try
            {
                quantityInInventoryUnit = await ConvertQuantityToInventoryUnit(
                    stockAdjustment.UnitOfMeasureId,
                    component.InventoryUnitId,
                    stockAdjustment.Quantity,
                    userOrgId,
                    component // Pass the component for specific conversion factor check
                );
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest($"Failed to convert quantity: {ex.Message}");
            }

            // Update Component's CurrentStockQuantity based on adjustment type
            if (adjustmentType.Effect == "Increase")
            {
                component.CurrentStockQuantity += quantityInInventoryUnit;
            }
            else if (adjustmentType.Effect == "Decrease")
            {
                // Prevent negative stock levels
                if (component.CurrentStockQuantity < quantityInInventoryUnit)
                {
                    return BadRequest($"Insufficient stock for '{component.ComponentName}'. (Current: {component.CurrentStockQuantity} {component.InventoryUnit?.Abbreviation ?? ""})");
                }
                component.CurrentStockQuantity -= quantityInInventoryUnit;
            }

            stockAdjustment.AdjustmentDate = DateTime.UtcNow;
            stockAdjustment.CreatedAt = DateTime.UtcNow;
            stockAdjustment.UpdatedAt = DateTime.UtcNow;

            _context.StockAdjustments.Add(stockAdjustment);
            _context.Components.Update(component); // Save changes to Component's stock
            await _context.SaveChangesAsync();

            // Load navigation properties for the returned object
            await _context.Entry(stockAdjustment).Reference(sa => sa.Component).LoadAsync();
            await _context.Entry(stockAdjustment).Reference(sa => sa.AdjustmentType).LoadAsync();
            await _context.Entry(stockAdjustment).Reference(sa => sa.UnitOfMeasure).LoadAsync();
            await _context.Entry(stockAdjustment).Reference(sa => sa.Organization).LoadAsync();

            return CreatedAtAction(nameof(GetStockAdjustment), new { id = stockAdjustment.AdjustmentId }, stockAdjustment);
        }

        /// <summary>
        /// Updates an existing stock adjustment and re-calculates the component's current stock quantity.
        /// (Note: Updating old adjustments can be complex and potentially lead to inconsistencies.
        /// It's often recommended to create new adjustments for corrections instead of updating old ones.)
        /// </summary>
        /// <param name="id">The ID of the stock adjustment to update.</param>
        /// <param name="updatedStockAdjustment">The updated StockAdjustment object.</param>
        /// <returns>NoContent if successful, otherwise BadRequest, NotFound, or Forbid.</returns>
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,Manager")] // Only Admin or Manager roles can update adjustments
        public async Task<IActionResult> PutStockAdjustment(Guid id, StockAdjustment updatedStockAdjustment)
        {
            if (id != updatedStockAdjustment.AdjustmentId)
            {
                return BadRequest("Stock adjustment ID mismatch.");
            }

            var userOrgId = GetUserOrganizationId();
            if (updatedStockAdjustment.OrganizationId != userOrgId)
            {
                return Forbid("You do not have permission to modify stock adjustments for other organizations.");
            }

            // Get original adjustment to revert its effect
            var originalStockAdjustment = await _context.StockAdjustments
                                                        .AsNoTracking() // Use AsNoTracking to prevent tracking conflicts
                                                        .Include(sa => sa.Component)
                                                            .ThenInclude(c => c!.InventoryUnit) // Eager load InventoryUnit
                                                        .Include(sa => sa.Component)
                                                            .ThenInclude(c => c!.PurchaseUnit) // Eager load PurchaseUnit
                                                        .Include(sa => sa.AdjustmentType)
                                                        .FirstOrDefaultAsync(sa => sa.AdjustmentId == id && sa.OrganizationId == userOrgId);

            if (originalStockAdjustment == null)
            {
                return NotFound();
            }

            // Get the component to update its stock
            var component = await _context.Components
                                          .Include(c => c.InventoryUnit)
                                          .Include(c => c.PurchaseUnit)
                                          .FirstOrDefaultAsync(c => c.ComponentId == updatedStockAdjustment.ComponentId && c.OrganizationId == userOrgId);
            if (component == null)
            {
                return BadRequest("Component not found or does not belong to your organization.");
            }

            var newAdjustmentType = await _context.StockAdjustmentTypes.FindAsync(updatedStockAdjustment.AdjustmentTypeId);
            if (newAdjustmentType == null)
            {
                return BadRequest("Invalid stock adjustment type.");
            }

            var newAdjustmentUnit = await _context.UnitsOfMeasures.FindAsync(updatedStockAdjustment.UnitOfMeasureId);
            if (newAdjustmentUnit == null)
            {
                return BadRequest("Invalid unit of measure for stock adjustment.");
            }

            // --- 1. Revert the effect of the original stock adjustment ---
            decimal originalQuantityInInventoryUnit;
            try
            {
                originalQuantityInInventoryUnit = await ConvertQuantityToInventoryUnit(
                    originalStockAdjustment.UnitOfMeasureId,
                    component.InventoryUnitId,
                    originalStockAdjustment.Quantity,
                    userOrgId,
                    component // Pass the component for specific conversion factor check
                );
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest($"Failed to revert original adjustment quantity: {ex.Message}");
            }

            if (originalStockAdjustment.AdjustmentType?.Effect == "Increase")
            {
                component.CurrentStockQuantity -= originalQuantityInInventoryUnit;
            }
            else if (originalStockAdjustment.AdjustmentType?.Effect == "Decrease")
            {
                component.CurrentStockQuantity += originalQuantityInInventoryUnit;
            }

            // --- 2. Apply the effect of the updated stock adjustment ---
            decimal newQuantityInInventoryUnit;
            try
            {
                newQuantityInInventoryUnit = await ConvertQuantityToInventoryUnit(
                    updatedStockAdjustment.UnitOfMeasureId,
                    component.InventoryUnitId,
                    updatedStockAdjustment.Quantity,
                    userOrgId,
                    component // Pass the component for specific conversion factor check
                );
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest($"Failed to apply new adjustment quantity: {ex.Message}");
            }

            if (newAdjustmentType.Effect == "Increase")
            {
                component.CurrentStockQuantity += newQuantityInInventoryUnit;
            }
            else if (newAdjustmentType.Effect == "Decrease")
            {
                // Check for sufficient stock *after* reverting original and *before* applying new decrease
                if (component.CurrentStockQuantity < newQuantityInInventoryUnit)
                {
                    return BadRequest($"Insufficient stock for updated decrease adjustment for '{component.ComponentName}'. (Current: {component.CurrentStockQuantity} {component.InventoryUnit?.Abbreviation ?? ""})");
                }
                component.CurrentStockQuantity -= newQuantityInInventoryUnit;
            }

            updatedStockAdjustment.UpdatedAt = DateTime.UtcNow;

            _context.Entry(updatedStockAdjustment).State = EntityState.Modified; // Mark the adjustment as modified
            _context.Components.Update(component); // Save changes to Component's stock

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StockAdjustmentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw; // Re-throw other concurrency exceptions
                }
            }

            return NoContent(); // 204 No Content on successful update
        }

        /// <summary>
        /// Deletes a stock adjustment and reverts its effect on the component's current stock quantity.
        /// </summary>
        /// <param name="id">The ID of the stock adjustment to delete.</param>
        /// <returns>NoContent if successful, otherwise NotFound or BadRequest.</returns>
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin,Manager")] // Only Admin or Manager roles can delete adjustments
        public async Task<IActionResult> DeleteStockAdjustment(Guid id)
        {
            var userOrgId = GetUserOrganizationId();
            var stockAdjustment = await _context.StockAdjustments
                                        .Include(sa => sa.Component)
                                            .ThenInclude(c => c!.InventoryUnit) // Eager load InventoryUnit
                                        .Include(sa => sa.Component)
                                            .ThenInclude(c => c!.PurchaseUnit) // Eager load PurchaseUnit
                                        .Include(sa => sa.AdjustmentType)
                                        .FirstOrDefaultAsync(sa => sa.AdjustmentId == id && sa.OrganizationId == userOrgId);
            if (stockAdjustment == null)
            {
                return NotFound();
            }

            // Revert CurrentStockQuantity in Component when deleting StockAdjustment
            if (stockAdjustment.Component != null && stockAdjustment.AdjustmentType != null)
            {
                decimal quantityInInventoryUnitToRevert;
                try
                {
                    quantityInInventoryUnitToRevert = await ConvertQuantityToInventoryUnit(
                        stockAdjustment.UnitOfMeasureId,
                        stockAdjustment.Component.InventoryUnitId,
                        stockAdjustment.Quantity,
                        userOrgId,
                        stockAdjustment.Component // Pass the component for specific conversion factor check
                    );
                }
                catch (InvalidOperationException ex)
                {
                    return BadRequest($"Failed to revert stock due to conversion issue: {ex.Message}");
                }

                if (stockAdjustment.AdjustmentType.Effect == "Increase")
                {
                    stockAdjustment.Component.CurrentStockQuantity -= quantityInInventoryUnitToRevert; // Revert: If it increased, decrease
                }
                else if (stockAdjustment.AdjustmentType.Effect == "Decrease")
                {
                    stockAdjustment.Component.CurrentStockQuantity += quantityInInventoryUnitToRevert; // Revert: If it decreased, increase
                }
                _context.Components.Update(stockAdjustment.Component); // Save changes to Component's stock
            }

            _context.StockAdjustments.Remove(stockAdjustment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// Checks if a stock adjustment exists for the current organization.
        /// </summary>
        /// <param name="id">The ID of the stock adjustment.</param>
        /// <returns>True if the stock adjustment exists, otherwise False.</returns>
        private bool StockAdjustmentExists(Guid id)
        {
            var userOrgId = GetUserOrganizationId();
            return _context.StockAdjustments.Any(e => e.AdjustmentId == id && e.OrganizationId == userOrgId);
        }

        // --- API Endpoint for retrieving current stock balances ---

        /// <summary>
        /// Retrieves the current stock balances for all components in the user's organization.
        /// This data is directly pulled from the Component's CurrentStockQuantity.
        /// </summary>
        /// <returns>A list of CurrentStockBalanceDto objects.</returns>
        [HttpGet("CurrentBalances")]
        public async Task<ActionResult<IEnumerable<CurrentStockBalanceDtoxx>>> GetCurrentStockBalances()
        {
            var userOrgId = GetUserOrganizationId();

            var stockBalances = await _context.Components
                                      .Where(c => c.OrganizationId == userOrgId)
                                      .Include(c => c.InventoryUnit) // Include InventoryUnit to get its Name and Symbol
                                      .Select(c => new CurrentStockBalanceDtoxx
                                      {
                                          ComponentId = c.ComponentId,
                                          ComponentName = c.ComponentName,
                                          ComponentSKU = c.ComponentCode, // Use ComponentCode as SKU
                                          CurrentQuantity = c.CurrentStockQuantity,
                                          UnitOfMeasureId = c.InventoryUnitId,
                                          UnitOfMeasureName = c.InventoryUnit != null ? c.InventoryUnit.UnitName : "N/A",
                                          UnitOfMeasureSymbol = c.InventoryUnit != null ? c.InventoryUnit.Abbreviation : "N/A"
                                      })
                                      .OrderBy(dto => dto.ComponentName)
                                      .ToListAsync();

            return Ok(stockBalances);
        }
    }
}