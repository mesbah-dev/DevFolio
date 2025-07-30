using System;

namespace Application.DTOs.ContactMessage
{
    internal class ContactMessageVDto
    {
        public string FullName { get; set; }

        public string Email { get; set; }

        public string Message { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
