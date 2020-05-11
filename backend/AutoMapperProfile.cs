using System.Linq;
using AutoMapper;
using backend.Dtos.Campaign;
using backend.Dtos.Goal;
using backend.Dtos.Hero;
using backend.Dtos.Phase;
using backend.Dtos.Player;
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
            CreateMap<Goal, GetGoalDto>();
            CreateMap<AddGoalDto, Goal>();
            CreateMap<Team, GetTeamDto>()
                .ForMember(dto => dto.Goals, t => t.MapFrom(t => t.TeamGoals.Select(tg => tg.Goal)));
            CreateMap<AddHeroDto, Hero>();
            CreateMap<Hero, GetHeroDto>();
            CreateMap<Campaign, GetCampaignDto>();
            CreateMap<AddCampaignDto, Campaign>();
            CreateMap<Player, GetPlayerDto>();
            CreateMap<Campaign, GetCampaignDto>()
                .ForMember(dto => dto.Players, c => c.MapFrom(c => c.PlayerCampaigns.Select(pc => pc.Player)));
            CreateMap<AddPhaseDto, Phase>();
            CreateMap<Phase, GetPhaseDto>();
        }
    }
}