namespace Application.DTOs.SocialLink
{
    public class SocialLinkVDto
    {
        public long Id { get; set; }
        public string PlatformName { get; set; }
        public string Url { get; set; }
        public string IconClass { get; set; }
        public bool IsActive { get; set; } 
        public bool Deleted { get; set; }
    }
}
