using Application.DTOs.Common;
using Application.DTOs.SiteSetting;
using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public class SiteSettingService : ISiteSettingService
    {
        public Task<ApiResponse> CreateSiteSettingAsync(SiteSettingDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse> DeleteSiteSettingAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<List<SiteSettingVDto>>> GetAllAsync(PagingInput input)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<SiteSettingVDto>> GetByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<List<SiteSettingVDto>>> SearchAsync(BaseInput input)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse> UpdateSiteSettingAsync(SiteSettingDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
