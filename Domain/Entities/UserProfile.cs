namespace Domain.Entities
{
    public class UserProfile
    {
        public long Id { get; set; }

        public string FullName { get; set; }

        public string JobTitle { get; set; }

        public string ShortDescription { get; set; }

        public string Bio { get; set; }

        public string ProfileImageUrl { get; set; }

        public string ResumeUrl { get; set; }
        public bool IsActive { get; set; } =true ;
        public bool Deleted { get; set; } =false ;
    }
}
