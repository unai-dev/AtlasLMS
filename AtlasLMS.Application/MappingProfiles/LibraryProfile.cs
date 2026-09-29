using AtlasLMS.Domain.Entities;
using AtlasLMS.Shared.DTOs.Create;
using AtlasLMS.Shared.DTOs.Detail;
using AtlasLMS.Shared.DTOs.Read;
using AtlasLMS.Shared.DTOs.Update;

using AutoMapper;

namespace AtlasLMS.Application.MappingProfiles;

public class LibraryProfile : Profile
{
    public LibraryProfile()
    {
        // Library -> ReadDto
        CreateMap<Library, LibraryReadDto>().ReverseMap();

        // Library -> DetailDto
        CreateMap<Library, LibraryDetailDto>().ReverseMap();

        // CreateDto -> Library
        CreateMap<LibraryCreateDto, Library>().ReverseMap();

        // UpdateDto -> Library
        CreateMap<LibraryUpdateDto, Library>().ReverseMap();
    }
}