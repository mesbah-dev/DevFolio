using Application.DTOs.Common;
using Application.DTOs.ContactMessage;
using Application.Helpers;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ContactMessageService : IContactMessageService
    {
        private readonly IContactMessageRepository _contactMessageRepository;
        private readonly IMapper _mapper;

        public ContactMessageService(IContactMessageRepository contactMessageRepository , IMapper mapper)
        {
            _contactMessageRepository = contactMessageRepository;
            _mapper = mapper;
        }
        public async Task<ApiResponse> CreateMessageAsync(ContactMessageDto dto)
        {
            if (!ValidationHelper.IsValidEmail(dto.Email))
                return  new ApiResponse(isSuccess: false, message: "Email Is Not Valid");
            var sanitizedMessage = InputSanitizer.SanitizeBasic(dto.Message);

            var entity = _mapper.Map<ContactMessage>(dto);
            entity.Message = sanitizedMessage;
            entity.CreatedAt = DateTime.Now;

            await _contactMessageRepository.AddAsync(entity);
            return new ApiResponse(isSuccess: true, message: "Success");
        }

        public Task<ApiResponse<PagedResult<ContactMessageDto>>> GetAllAsync(BaseInput input)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<ContactMessageDto>> GetByIdAsync(long id)
        {
            throw new NotImplementedException();
        }
    }
}
