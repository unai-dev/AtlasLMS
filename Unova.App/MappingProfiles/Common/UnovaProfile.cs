using AutoMapper;

namespace Unova.App.MappingProfiles.Common;

public abstract class UnovaProfile<TBase, TRead, TDetail, TCreate> : Profile
    where TBase : class
    where TRead : class
    where TDetail : class
    where TCreate : class
{
    public UnovaProfile()
    {
        CreateMap<TBase, TRead>().ReverseMap();

        CreateMap<TBase, TDetail>().ReverseMap();

        CreateMap<TCreate, TBase>();
    }
}
