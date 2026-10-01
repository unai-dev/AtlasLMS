using AutoMapper;

using Unova.Domain.Entities;
using Unova.Shared.DTOs.Create;
using Unova.Shared.DTOs.Detail;
using Unova.Shared.DTOs.Read;

namespace Unova.App.MappingProfiles;

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
