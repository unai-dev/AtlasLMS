using AutoMapper;

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
