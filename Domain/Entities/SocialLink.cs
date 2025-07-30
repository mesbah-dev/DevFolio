namespace Domain.Entities
{
    public class SocialLink
    {
        public long Id { get; set; }

        public string PlatformName { get; set; }

        public string Url { get; set; }

        public string IconClass { get; set; }
        public bool IsActive { get; set; } = true;
        public bool Deleted { get; set; } = false;
    }
}
