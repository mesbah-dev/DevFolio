using System;

namespace Application.DTOs.ContactMessage
{
    public class ContactMessageVDto
    {
        public long Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
