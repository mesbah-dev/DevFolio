using System;

namespace Application.DTOs.ContactMessage
{
    public class ContactMessageDto
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
