using AtlasLMS.API.DTOs;
using AtlasLMS.API.Entities;
using AutoMapper;

namespace AtlasLMS.API.Utils.Mapping;

public class LoanProfile : Profile
{
    public LoanProfile()
    {
        // Loan -> ReadDto
        CreateMap<Loan, LoanReadDto>()
            .ReverseMap();

        // CreateDto -> Loan
        CreateMap<LoanCreateDto, Loan>()
            .ForMember(dest => dest.ID, opt => opt.Ignore())
            .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
            .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore())
            .ForMember(dest => dest.Book, opt => opt.Ignore());

        // UpdateDto -> Loan
        CreateMap<LoanUpdateDto, Loan>()
            .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
            .ForMember(dest => dest.Book, opt => opt.Ignore());
    }
}
