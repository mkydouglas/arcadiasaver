using System.Collections.Generic;
using System.Threading.Tasks;
using backend.Dtos.Hero;
using backend.Models;

namespace backend.Services.HeroService
{
    public interface IHeroService
    {
        Task<ServiceResponse<List<GetHeroDto>>> AddHero(AddHeroDto newHero, int id);
        Task<ServiceResponse<List<GetHeroDto>>> GetAllHeros(int id);
        Task<ServiceResponse<GetHeroDto>> UpdateHero(UpdateHero updateTeam, int id);
    }
}