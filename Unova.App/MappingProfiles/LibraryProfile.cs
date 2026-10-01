using AutoMapper;

using Unova.Domain.Entities;
using Unova.Shared.DTOs.Create;
using Unova.Shared.DTOs.Detail;
using Unova.Shared.DTOs.Read;
using Unova.Shared.DTOs.Update;

namespace Unova.App.MappingProfiles;

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