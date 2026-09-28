using AtlasLMS.Domain.Entities;
using AtlasLMS.Shared.DTOs.Create;
using AtlasLMS.Shared.DTOs.Read;

using AutoMapper;

namespace AtlasLMS.Application.MappingProfiles;

public class CategoryProfile : Profile
{
    public CategoryProfile()
    {
        // Category -> ReadDto
        CreateMap<Category, CategoryReadDto>().ReverseMap();

        // CreateDto -> Category
        CreateMap<CategoryCreateDto, Category>().ReverseMap();
    }
}
