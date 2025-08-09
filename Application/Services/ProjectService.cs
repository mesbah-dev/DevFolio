using Application.DTOs.Common;
using Application.DTOs.Project;
using Application.Extensions;
using Application.Helpers;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _repository;
        private readonly ITechnologyRepository _technologyRepository;
        private readonly IMapper _mapper;
        public ProjectService(IProjectRepository repository, ITechnologyRepository technologyRepository, IMapper mapper)
        {
            _repository = repository;
            _technologyRepository = technologyRepository;
            _mapper = mapper;
        }
        public async Task<ApiResponse> CreateProjectAsync(CreateProjectDto dto)
        {
            if (dto.TechnologyIds.Count == 0)
                return new ApiResponse(isSuccess: false, message: "Please Select Project's Technologies.");
            var technologies = await _technologyRepository.GetByIdsAsync(dto.TechnologyIds);
            if (technologies.Count != dto.TechnologyIds.Count)
                return new ApiResponse(false, "Some selected technologies were not found.");
            var project = new Project
            {
                Title = dto.Title,
                Description = dto.Description,
                ImageUrl = dto.ImageUrl,
                GitHubUrl = dto.GitHubUrl,
                DemoUrl = dto.DemoUrl,
                Technologies = technologies
            };
            await _repository.AddAsync(project);
            return new ApiResponse(isSuccess: true, message: "Success.");

        }

        public async Task<ApiResponse> DeleteProjectAsync(long id)
        {
            var project = await _repository.GetByIdAsync(id);
            if (project == null)
                return new ApiResponse(isSuccess: false, message: "Project Not Found.");
            await _repository.DeleteAsync(project);
            return new ApiResponse(isSuccess: true, message: "Success.");
        }

        public ApiResponse<PagedResult<ProjectVDto>> GetAll(PagingInput input)
        {
            var result = ValidationHelper.IsValidINput(input);
            if (!result.IsValid)
                return new ApiResponse<PagedResult<ProjectVDto>>(data: null, isSuccess: false, message: result.Message);

            var query = _repository.GetAll();
            query = query.ApplySortingById(input.SortBy);

            var pagedResult = new PagedResult<Project, ProjectVDto>(input, query, _mapper);
            return new ApiResponse<PagedResult<ProjectVDto>>(data: pagedResult, isSuccess: true, message: "Success.");
        }

        public async Task<ApiResponse<ProjectVDto>> GetByIdWithTechnologiesAsync(long id)
        {
            var result = await _repository.GetByIdWithTechnologiesAsync(id);
            if (result == null)
                return new ApiResponse<ProjectVDto>(data: null, isSuccess: false, message: "Not found");

            var viewModel = _mapper.Map<ProjectVDto>(result);

            return new ApiResponse<ProjectVDto>(data: viewModel, isSuccess: true, message: "Success.");
        }

        public ApiResponse<PagedResult<ProjectVDto>> Search(SearchInput input)
        {
            var result = ValidationHelper.IsValidINput(input);
            if (!result.IsValid)
                return new ApiResponse<PagedResult<ProjectVDto>>(data: null, isSuccess: false, message: result.Message);

            var query = _repository.GetAll();

            // Use 'Q' for filtering by title.
            if (!string.IsNullOrEmpty(input.Q))
                query = query.Where(s => s.Title.Contains(input.Q));
            //Use 'TechnologyId' for filtering by used technology
            if (input.TechnologyId != null)
                query = query.Where(s => s.Technologies.Any(t => t.Id == input.TechnologyId));
            //Use 'ProjectId' for filternig by project
            if (input.ProjectId != null)
                query = query.Where(s => s.Id == input.ProjectId);
            query = query.ApplySortingById(input.SortBy);
            var pagedResult = new PagedResult<Project, ProjectVDto>(input, query, _mapper);
            return new ApiResponse<PagedResult<ProjectVDto>>(data: pagedResult, isSuccess: true, message: "Success.");
        }

        public async Task<ApiResponse> UpdateProjectAsync(ProjectDto dto)
        {
            var project = await _repository.GetByIdAsync(dto.Id);
            if (project == null)
                return new ApiResponse(isSuccess: false, message: "Project not found");

            _mapper.Map(dto, project);
            await _repository.SaveChangesAsync();
            return new ApiResponse(true, "Success");

        }
        public async Task<ApiResponse> UpdateProjectTechnologiesAsync(long projectId, List<long> technologyIds)
        {
            var project = await _repository.GetByIdWithTechnologiesAsync(projectId);
            if (project == null)
                return new ApiResponse(isSuccess: false, message: "Project not found");

            var fetchedTechnologies = await _technologyRepository.GetByIdsAsync(technologyIds);

            var missingIds = technologyIds.Except(fetchedTechnologies.Select(t => t.Id)).ToList();
            if (missingIds.Any())
            {
                return new ApiResponse(isSuccess: false, message: $"Technologies not found: {string.Join(", ", missingIds)}");
            }

            var toRemove = project.Technologies.Where(t => !technologyIds.Contains(t.Id)).ToList();
            foreach (var r in toRemove)
                project.Technologies.Remove(r);

            var currentTechnologyIds = project.Technologies.Select(t => t.Id).ToHashSet();
            var toAdd = fetchedTechnologies.Where(t => !currentTechnologyIds.Contains(t.Id));
            foreach (var tech in toAdd)
            {
                project.Technologies.Add(tech);
            }

            await _repository.SaveChangesAsync();

            return new ApiResponse(isSuccess: true, message: "Success");
        }
    }
}
