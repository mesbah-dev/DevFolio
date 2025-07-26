using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<AdminUser> AdminUsers { get; set; }
        public DbSet<ContactMessage> ContactMessages { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectTechnology> ProjectTechnologies { get; set; }
        public DbSet<SiteSetting> SiteSettings { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<SkillCategory> SkillCategories { get; set; }
        public DbSet<SocialLink> SocialLinks { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }


    }
}
