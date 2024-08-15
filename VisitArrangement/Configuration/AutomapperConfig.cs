using AutoMapper;
using VisitArrangement.API.Model.DTO;
using VisitArrangement.Domain.Entities;

namespace VisitArrangement.API.Configuration
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<UserForRegistrationDto, User>()
                .ForMember(u => u.UserName, opt => opt.MapFrom(x => x.Email));
        }
    }
}
