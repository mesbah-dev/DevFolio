using Application.DTOs.Common;
using Application.DTOs.SiteSetting;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ISiteSettingService
    {
        Task<ApiResponse> CreateSiteSettingAsync(SiteSettingDto dto);
        Task<ApiResponse> UpdateSiteSettingAsync(SiteSettingDto dto);
        Task<ApiResponse> DeleteSiteSettingAsync(long id);
        Task<ApiResponse<SiteSettingVDto>> GetByIdAsync(long id);
        Task<ApiResponse<List<SiteSettingVDto>>> GetAllAsync(PagingInput input);
        Task<ApiResponse<List<SiteSettingVDto>>> SearchAsync(BaseInput input);
    }
}
