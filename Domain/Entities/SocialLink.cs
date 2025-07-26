namespace Domain.Entities
{
    public class SocialLink
    {
        public long Id { get; set; }

        public string PlatformName { get; set; }

        public string Url { get; set; }

        public string IconClass { get; set; }
    }
}
