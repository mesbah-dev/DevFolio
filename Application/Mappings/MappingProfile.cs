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
            CreateMap<AdminUser, AdminUserVDto>();

            //ContactMessage
            CreateMap<ContactMessage, ContactMessageDto>().ReverseMap();
            CreateMap<ContactMessage, ContactMessageVDto>();

            //Education
            CreateMap<Education, EducationDto>();
            CreateMap<EducationDto, Education>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
            CreateMap<Education, EducationVDto>();

            //Experience
            CreateMap<Experience, ExperienceDto>();
            CreateMap<ExperienceDto, Experience>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
            CreateMap<Experience, ExperienceVDto>();

            //Project
            CreateMap<Project, ProjectDto>();
            CreateMap<ProjectDto, Project>()
                .ForMember(dest => dest.Technologies, opt => opt.Ignore());
            CreateMap<Project, ProjectVDto>();

            //SiteSetting
            CreateMap<SiteSetting, SiteSettingDto>();
            CreateMap<SiteSettingDto, SiteSetting>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
            CreateMap<SiteSetting, SiteSettingVDto>();

            //Skill
            CreateMap<Skill, SkillDto>();
            CreateMap<SkillDto, Skill>()
                .ForMember(dest => dest.SkillCategory, opt => opt.Ignore())
                .ForMember(dest => dest.Id, opt => opt.Ignore());
            CreateMap<Skill, SkillVDto>();

            //SkillCategory
            CreateMap<SkillCategory, SkillCategoryDto>();
            CreateMap<SkillCategoryDto, SkillCategory>()
                .ForMember(dest => dest.Skills, opt => opt.Ignore())
                .ForMember(dest => dest.Id, opt => opt.Ignore());
            CreateMap<SkillCategory, SkillCategoryVDto>();

            //SocialLink
            CreateMap<SocialLink, SocialLinkDto>();
            CreateMap<SocialLinkDto, SocialLink>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
            CreateMap<SocialLink, SocialLinkVDto>();

            //Technology
            CreateMap<Technology, TechnologyDto>();
            CreateMap<TechnologyDto, Technology>()
                .ForMember(dest => dest.Projects, opt => opt.Ignore())
                .ForMember(dest => dest.Id, opt => opt.Ignore());
            CreateMap<Technology, TechnologyVDto>();

            //UserProfile
            CreateMap<UserProfile, UserProfileDto>();
            CreateMap<UserProfileDto, UserProfile>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
            CreateMap<UserProfile, UserProfileVDto>();


        }
    }
}
