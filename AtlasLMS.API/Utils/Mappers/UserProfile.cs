using AtlasLMS.Domain.Entities;
using AtlasLMS.Shared.DTOs.Create;
using AtlasLMS.Shared.DTOs.Read;

using AutoMapper;

namespace AtlasLMS.API.Utils.Mappers;

public class UserProfile : Profile
{
    public UserProfile()
    {
        // User -> ReadDTO
        CreateMap<User, UserReadDto>()
            .ReverseMap();

        // CreateDto -> User
        CreateMap<UserCreateDto, User>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
            .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore())
            .ForMember(dest => dest.Bookings, opt => opt.Ignore())
            .ForMember(dest => dest.Loans, opt => opt.Ignore());
    }
}
