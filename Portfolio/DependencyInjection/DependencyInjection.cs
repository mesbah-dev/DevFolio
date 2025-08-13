using Application.Interfaces;
using Application.Services;
using Domain.Interfaces;
using Infrastructure.Repositories;

namespace Web.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {

            //Repositories
            services.AddScoped<IAdminUserRepository, AdminUserRepository>();
            services.AddScoped<IContactMessageRepository, ContactMessageRepository>();
            services.AddScoped<IEducationRepository, EducationRepository>();
            services.AddScoped<IExperienceRepository, ExperienceRepository>();
            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<ISiteSettingRepository, SiteSettingRepository>();
            services.AddScoped<ISkillCategoryRepository, SkillCategoryRepository>();
            services.AddScoped<ISkillRepository, SkillRepository>();
            services.AddScoped<ISocialLinkRepository, SocialLinkRepository>();
            services.AddScoped<ITechnologyRepository, TechnologyRepository>();
            services.AddScoped<IUserProfileRepository, UserProfileRepository>();
            //Services
            services.AddScoped<IAdminUserService, AdminUserService>();
            services.AddScoped<IContactMessageService, ContactMessageService>();
            services.AddScoped<IEducationService, EducationService>();
            services.AddScoped<IExperienceService, ExperienceService>();
            services.AddScoped<IProjectService, ProjectService>();
            services.AddScoped<ISiteSettingService, SiteSettingService>();
            services.AddScoped<ISkillCategoryService, SkillCategoryService>();
            services.AddScoped<ISkillService, SkillService>();
            services.AddScoped<ISocialLinkService, SocialLinkService>();
            services.AddScoped<ITechnologyService, TechnologyService>();
            services.AddScoped<IUserProfileService, UserProfileService>();

            return services;
        }
    }
}
