using Application.DTOs.Common;
using Application.DTOs.ContactMessage;
using Application.Extensions;
using Application.Helpers;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ContactMessageService : IContactMessageService
    {
        private readonly IContactMessageRepository _repository;
        private readonly IMapper _mapper;

        public ContactMessageService(IContactMessageRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<ApiResponse> CreateMessageAsync(ContactMessageDto dto)
        {
            if (!ValidationHelper.IsValidEmail(dto.Email))
                return new ApiResponse(isSuccess: false, message: "Email Is Not Valid");
            var sanitizedMessage = InputSanitizer.SanitizeBasic(dto.Message);

            var entity = _mapper.Map<ContactMessage>(dto);
            entity.Message = sanitizedMessage;
            entity.CreatedAt = DateTime.Now;

            await _repository.AddAsync(entity);
            return new ApiResponse(isSuccess: true, message: "Success");
        }

        public ApiResponse<PagedResult<ContactMessageVDto>> GetAll(PagingInput input)
        {
            var query = _repository.GetAll();
            query = query.ApplySortingById(input.SortBy);

            var pagedResult = new PagedResult<ContactMessage, ContactMessageVDto>(input, query, _mapper);
            return new ApiResponse<PagedResult<ContactMessageVDto>>(data: pagedResult, isSuccess: true, message: "Success");

        }

        public async Task<ApiResponse<ContactMessageVDto>> GetByIdAsync(long id)
        {
            var result = await _repository.GetByIdAsync(id);
            var viewModel = _mapper.Map<ContactMessageVDto>(result);

            return new ApiResponse<ContactMessageVDto>(data: viewModel, isSuccess: true, message: "Success");
        }

        public ApiResponse<PagedResult<ContactMessageVDto>> SearchAsync(BaseInput input)
        {
            var query = _repository.GetAll();
            // Use 'Q' for filtering by Email
            if (!string.IsNullOrEmpty(input.Q))
                query = query.Where(s => s.Email.Contains(input.Q));
            
            query = query.ApplySortingById(input.SortBy);

            var pagedResult = new PagedResult<ContactMessage, ContactMessageVDto>(input, query, _mapper);
            return new ApiResponse<PagedResult<ContactMessageVDto>>(data: pagedResult, isSuccess: true, message: "Success");

        }

    }
}
