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
        ApiResponse<PagedResult<SiteSettingVDto>> GetAll(PagingInput input);
        ApiResponse<PagedResult<SiteSettingVDto>> Search(BaseInput input);
    }
}
