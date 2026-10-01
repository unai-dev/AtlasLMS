using AutoMapper;

using Unova.Domain.Entities;
using Unova.Shared.DTOs.Create;
using Unova.Shared.DTOs.Read;

namespace Unova.App.MappingProfiles;

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
