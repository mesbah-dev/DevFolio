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
            //AdminUser
            CreateMap<AdminUser, AdminUserDto>().ReverseMap();
            //ContactMessage
            CreateMap<ContactMessage, ContactMessageDto>().ReverseMap();
            CreateMap<ContactMessage, ContactMessageVDto>();
            //Education
            CreateMap<Education, EducationDto>().ReverseMap();
            CreateMap<Education, EducationVDto>();
            //Experience
            CreateMap<Experience, ExperienceDto>().ReverseMap();
            CreateMap<Experience, ExperienceVDto>();
            //Project
            CreateMap<Project, ProjectDto>();
            CreateMap<ProjectDto, Project>()
                .ForMember(dest => dest.Technologies, opt => opt.Ignore());
            CreateMap<Project, ProjectVDto>();
            //SiteSetting
            CreateMap<SiteSetting, SiteSettingDto>().ReverseMap();
            CreateMap<SiteSetting, SiteSettingVDto>();
            //Skill
            CreateMap<Skill, SkillDto>().ReverseMap();
            CreateMap<Skill, SkillVDto>();
            //SkillCategory
            CreateMap<SkillCategory, SkillCategoryDto>();
            CreateMap<SkillCategoryDto, SkillCategory>()
                .ForMember(dest => dest.Skills, opt => opt.Ignore());
            CreateMap<SkillCategory, SkillCategoryVDto>();
            //SocialLink
            CreateMap<SocialLink, SocialLinkDto>().ReverseMap();
            CreateMap<SocialLink, SocialLinkVDto>();
            //Technology
            CreateMap<Technology, TechnologyDto>().ReverseMap();
            CreateMap<Technology, TechnologyVDto>();
            //UserProfile
            CreateMap<UserProfile, UserProfileDto>().ReverseMap();
            CreateMap<UserProfile, UserProfileVDto>();


        }
    }
}
