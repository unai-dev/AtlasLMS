using AtlasLMS.Domain.Entities;
using AtlasLMS.Shared.DTOs.Create;
using AtlasLMS.Shared.DTOs.Detail;
using AtlasLMS.Shared.DTOs.Read;

using AutoMapper;

namespace AtlasLMS.Application.MappingProfiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        // User -> ReadDTO
        CreateMap<User, UserReadDto>().ReverseMap();

        // User -> DetailDto
        CreateMap<User, UserDetailDto>().ReverseMap();

        // CreateDto -> User
        CreateMap<UserCreateDto, User>().ReverseMap();
    }
}
