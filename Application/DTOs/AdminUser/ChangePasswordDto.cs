namespace Application.DTOs.AdminUser
{
    public class ChangePasswordDto
    {
        public long AdminId { get; set; }
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }

    }
}
