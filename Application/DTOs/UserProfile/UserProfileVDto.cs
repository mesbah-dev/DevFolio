namespace Application.DTOs.UserProfile
{
    public class UserProfileVDto
    {
        public long Id { get; set; }
        public string FullName { get; set; }
        public string JobTitle { get; set; }
        public string ShortDescription { get; set; }
        public string Bio { get; set; }
        public string ProfileImageUrl { get; set; }
        public string ResumeUrl { get; set; }
    }
}
