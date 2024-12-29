using AutoMapper;
using VisitArrangement.Infrastructure.Entities;
using VisitArrangement.Domain.Model.DTO;

namespace VisitArrangement.API.Configuration;

public class AutomapperConfig : Profile
{
    public AutomapperConfig()
    {
        CreateMap<UserForRegistrationDto, User>()
            .ForMember(u => u.UserName, opt => opt.MapFrom(x => x.Email));
    }
}
