using System;

namespace Application.DTOs.AdminUser
{
    public class AdminUserDto
    {
        public long Id { get; set; }
        public string Username { get; set; }
        public string NewPassword { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsActive { get; set; }
    }
}
