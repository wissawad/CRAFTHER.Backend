using CRAFTHER.Backend.Data;
using CRAFTHER.Backend.DTOs;
using CRAFTHER.Backend.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration; // สำหรับ IConfiguration
using Microsoft.IdentityModel.Tokens; // สำหรับ SymmetricSecurityKey
using System.IdentityModel.Tokens.Jwt; // สำหรับ JwtSecurityToken
using System.Security.Claims; // สำหรับ Claims
using System.Text; // สำหรับ Encoding
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace CRAFTHER.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IConfiguration _configuration; // สำหรับอ่านค่า JWT จาก appsettings.json
        private readonly ApplicationDbContext _context; // สำหรับการตรวจสอบ OrganizationId
        private readonly RoleManager<ApplicationRole> _roleManager;

        public AccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IConfiguration configuration,
            ApplicationDbContext context,
            RoleManager<ApplicationRole> roleManager) // เพิ่ม ApplicationDbContext
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
            _context = context;
            _roleManager = roleManager;
        }

        // --- Register (สร้างผู้ใช้งานใหม่) ---
        // POST: api/Account/Register
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto model)
        {
            // ตรวจสอบ OrganizationId ถ้ามีการระบุมา
            if (model.OrganizationId.HasValue && model.OrganizationId.Value != Guid.Empty)
            {
                var organizationExists = await _context.Organizations.AnyAsync(o => o.OrganizationId == model.OrganizationId.Value);
                if (!organizationExists)
                {
                    return BadRequest("Invalid Organization ID provided.");
                }
            }
            else // ถ้าไม่ระบุ OrganizationId มา จะถือว่าเป็นผู้ดูแลระบบ (Admin) หรือไม่มีองค์กรในตอนแรก
            {
                // สามารถเพิ่ม logic อื่นๆ ได้ เช่น บังคับให้ต้องมี OrganizationId หรือมี default
            }

            var user = new ApplicationUser
            {
                UserName = model.Email,
                Email = model.Email,
                OrganizationId = model.OrganizationId ?? Guid.Empty, // กำหนดค่า OrganizationId (ถ้าไม่มี ให้เป็น Guid.Empty หรือค่าเริ่มต้นอื่นๆ)
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                // กำหนด Role ให้กับผู้ใช้งานที่ลงทะเบียน
                // ตัวอย่าง: ถ้า OrganizationId ไม่ได้ระบุมา ถือว่าเป็น Admin (สำหรับเริ่มต้น)
                // หรืออาจจะสร้าง Role "User" เป็นค่าเริ่มต้น
                if (!model.OrganizationId.HasValue || model.OrganizationId.Value == Guid.Empty)
                {
                    await _userManager.AddToRoleAsync(user, "Admin"); // เพิ่ม Role "Admin" (ถ้ามี)
                }
                else
                {
                    await _userManager.AddToRoleAsync(user, "User"); // เพิ่ม Role "User" (ถ้ามี)
                }

                return Ok(new { Message = "User registered successfully." });
            }

            // ถ้ามี Error ในการลงทะเบียน
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
            return BadRequest(ModelState);
        }

        // --- Login (เข้าสู่ระบบและรับ JWT) ---
        // POST: api/Account/Login
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDto model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                return Unauthorized(new { Message = "Invalid login credentials." });
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);

            if (result.Succeeded)
            {
                var token = await GenerateJwtToken(user);
                return Ok(new { Token = token });
            }

            return Unauthorized(new { Message = "Invalid login credentials." });
        }

    // --- กำหนดบทบาทให้กับผู้ใช้งาน (Assign Role to User) ---
    // POST: api/Account/AssignRole
    [HttpPost("AssignRole")]
    [Authorize(Roles = "Admin")] // กำหนดให้เฉพาะผู้ดูแลระบบ (Admin) เท่านั้นที่สามารถกำหนดบทบาทได้
    public async Task<IActionResult> AssignRole([FromBody] AssignRoleDto model)
    {
        var user = await _userManager.FindByIdAsync(model.UserId.ToString());
        if (user == null)
        {
            return NotFound("ไม่พบผู้ใช้งาน.");
        }

        var role = await _roleManager.FindByIdAsync(model.RoleId.ToString());
        if (role == null)
        {
            return NotFound("ไม่พบบทบาท.");
        }

        // ตรวจสอบว่าผู้ใช้มีบทบาทนี้อยู่แล้วหรือไม่
        if (await _userManager.IsInRoleAsync(user, role.Name))
        {
            return BadRequest($"ผู้ใช้งาน '{user.Email}' มีบทบาท '{role.Name}' อยู่แล้ว.");
        }

        var result = await _userManager.AddToRoleAsync(user, role.Name); // ใช้ชื่อบทบาทในการเพิ่ม

        if (result.Succeeded)
        {
            return Ok(new { Message = $"กำหนดบทบาท '{role.Name}' ให้ผู้ใช้งาน '{user.Email}' สำเร็จแล้ว." });
        }

        foreach (var error in result.Errors)
        {
            ModelState.AddModelError(string.Empty, error.Description);
        }
        return BadRequest(ModelState);
    }

    // --- ลบบทบาทจากผู้ใช้งาน (Remove Role from User) ---
    // POST: api/Account/RemoveRole
    [HttpPost("RemoveRole")]
    [Authorize(Roles = "Admin")] // กำหนดให้เฉพาะผู้ดูแลระบบ (Admin) เท่านั้นที่สามารถลบบทบาทได้
    public async Task<IActionResult> RemoveRole([FromBody] AssignRoleDto model)
    {
        var user = await _userManager.FindByIdAsync(model.UserId.ToString());
        if (user == null)
        {
            return NotFound("ไม่พบผู้ใช้งาน.");
        }

        var role = await _roleManager.FindByIdAsync(model.RoleId.ToString());
        if (role == null)
        {
            return NotFound("ไม่พบบทบาท.");
        }

        // ตรวจสอบว่าผู้ใช้มีบทบาทนี้อยู่หรือไม่ก่อนลบ
        if (!await _userManager.IsInRoleAsync(user, role.Name))
        {
            return BadRequest($"ผู้ใช้งาน '{user.Email}' ไม่มีบทบาท '{role.Name}' นี้.");
        }

        var result = await _userManager.RemoveFromRoleAsync(user, role.Name); // ใช้ชื่อบทบาทในการลบ

        if (result.Succeeded)
        {
            return Ok(new { Message = $"ลบบทบาท '{role.Name}' ออกจากผู้ใช้งาน '{user.Email}' สำเร็จแล้ว." });
        }

        foreach (var error in result.Errors)
        {
            ModelState.AddModelError(string.Empty, error.Description);
        }
        return BadRequest(ModelState);
    }

    // --- Private method สำหรับ Generate JWT Token ---
    private async Task<string> GenerateJwtToken(ApplicationUser user)
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Secret"]!)); // ! คือ null-forgiving operator
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email!),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("OrganizationId", user.OrganizationId.ToString()) // เพิ่ม OrganizationId ใน Claim
            };

            // ดึง Roles ของผู้ใช้และเพิ่มเป็น Claim
            var roles = await _userManager.GetRolesAsync(user);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var token = new JwtSecurityToken(
                issuer: jwtSettings["Issuer"],
                audience: jwtSettings["Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(double.Parse(jwtSettings["TokenExpirationMinutes"]!)),
                signingCredentials: new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}