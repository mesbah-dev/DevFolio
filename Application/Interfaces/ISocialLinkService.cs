using Application.DTOs.Common;
using Application.DTOs.SocialLink;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ISocialLinkService
    {
        Task<ApiResponse> CreateSocialLinkAsync(SocialLinkDto dto);
        Task<ApiResponse> UpdateSocialLinkAsync(SocialLinkDto dto);
        Task<ApiResponse> DeleteSocialLinkAsync(long id);
        Task<ApiResponse<SocialLinkVDto>> GetByIdAsync(long id);
        Task<ApiResponse<List<SocialLinkVDto>>> GetAllAsync(BaseInput input);
    }
}
