namespace Domain.Entities
{
    public class SiteSetting
    {
        public long Id { get; set; }

        public string SiteTitle { get; set; }

        public string ContactEmail { get; set; }

        public string WelcomeMessage { get; set; }
        public bool IsActive { get; set; } = true;
        public bool Deleted { get; set; } = false;
    }
}
