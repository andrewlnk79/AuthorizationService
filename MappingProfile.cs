using AutoMapper;

namespace AuthorizationService;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, UserViewModel>()
            .ConstructUsing(v => new UserViewModel(v));
    }
}