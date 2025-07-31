using Application.DTOs.Common;
using Application.DTOs.SocialLink;
using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public class SocialLinkService : ISocialLinkService
    {
        public Task<ApiResponse> CreateSocialLinkAsync(SocialLinkDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse> DeleteSocialLinkAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<List<SocialLinkVDto>>> GetAllAsync(BaseInput input)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<SocialLinkVDto>> GetByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse> UpdateSocialLinkAsync(SocialLinkDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
