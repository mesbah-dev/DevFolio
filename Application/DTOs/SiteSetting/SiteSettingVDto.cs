namespace Application.DTOs.SiteSetting
{
    public class SiteSettingVDto
    {
        public long Id { get; set; }
        public string SiteTitle { get; set; }
        public string ContactEmail { get; set; }
        public string WelcomeMessage { get; set; }
        public bool IsActive { get; set; }
        public bool Deleted { get; set; }
    }
}
