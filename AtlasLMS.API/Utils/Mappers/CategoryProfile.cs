using AtlasLMS.Application.DTOs.Create;
using AtlasLMS.Application.DTOs.Read;
using AtlasLMS.Application.DTOs.Update;
using AtlasLMS.Domain.Entities;
using AutoMapper;

namespace AtlasLMS.API.Utils.Mappers;

public class CategoryProfile : Profile
{
    public CategoryProfile()
    {
        // Category -> ReadDto
        CreateMap<Category, CategoryReadDto>()
            .ReverseMap();

        // CreateDto -> Category
        CreateMap<CategoryCreateDto, Category>()
            .ForMember(dest => dest.ID, opt => opt.Ignore())
            .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
            .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore())
            .ForMember(dest => dest.Books, opt => opt.Ignore());

        // UpdateDto -> Category
        CreateMap<CategoryUpdateDto, Category>()
            .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
            .ForMember(dest => dest.Books, opt => opt.Ignore());
    }
}
