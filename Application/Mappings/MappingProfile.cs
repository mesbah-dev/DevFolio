using Application.DTOs.AdminUser;
using Application.DTOs.ContactMessage;
using Application.DTOs.Education;
using Application.DTOs.Experience;
using Application.DTOs.Project;
using Application.DTOs.SiteSetting;
using Application.DTOs.Skill;
using Application.DTOs.SkillCategory;
using Application.DTOs.SocialLink;
using Application.DTOs.Technology;
using Application.DTOs.UserProfile;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AdminUser, AdminUserDto>().ReverseMap();
            CreateMap<ContactMessage, ContactMessageDto>().ReverseMap();
            CreateMap<Education, EducationDto>().ReverseMap();
            CreateMap<Experience, ExperienceDto>().ReverseMap();
            CreateMap<Project, ProjectDto>().ReverseMap();
            CreateMap<SiteSetting, SiteSettingDto>().ReverseMap();
            CreateMap<Skill, SkillDto>().ReverseMap();
            CreateMap<SkillCategory, SkillCategoryDto>().ReverseMap();
            CreateMap<SocialLink, SocialLinkDto>().ReverseMap();
            CreateMap<Technology, TechnologyDto>().ReverseMap();
            CreateMap<UserProfile, UserProfileDto>().ReverseMap();


        }
    }
}
