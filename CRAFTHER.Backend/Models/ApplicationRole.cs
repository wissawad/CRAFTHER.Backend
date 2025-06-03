using Microsoft.AspNetCore.Identity; // ต้องเพิ่ม using นี้

namespace CRAFTHER.Backend.Models
{
    // สืบทอดมาจาก IdentityRole และกำหนดให้ใช้ Guid เป็น Primary Key ของ Role
    public class ApplicationRole : IdentityRole<Guid>
    {
        // สามารถเพิ่ม properties อื่นๆ ของ Role ได้ที่นี่ถ้าต้องการ
        // เช่น Description, PermissionLevel
    }
}