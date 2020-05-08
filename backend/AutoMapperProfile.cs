using AutoMapper;
using backend.Dtos.Team;
using backend.Models;

namespace backend
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Team, GetTeamDto>();
            CreateMap<AddTeamDto, Team>();
        }
    }
}