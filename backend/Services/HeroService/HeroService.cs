using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using backend.Data;
using backend.Dtos.Hero;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Services.HeroService
{
    public class HeroService : IHeroService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        public HeroService(IMapper mapper, DataContext context)
        {
            this._context = context;
            this._mapper = mapper;

        }
        public async Task<ServiceResponse<List<GetHeroDto>>> AddHero(AddHeroDto newHero, int id)
        {
            ServiceResponse<List<GetHeroDto>> response = new ServiceResponse<List<GetHeroDto>>();
            Hero hero = _mapper.Map<Hero>(newHero);
            hero.Team = await _context.Teams.FirstOrDefaultAsync(t => t.Id == id);

            await _context.Heros.AddAsync(hero);
            await _context.SaveChangesAsync();

            response.Data = await _context.Heros
                .Include(h => h.Team).Select(h => _mapper.Map<GetHeroDto>(h)).ToListAsync();

            return response;
        }

        public async Task<ServiceResponse<List<GetHeroDto>>> GetAllHeros(int id)
        {
            ServiceResponse<List<GetHeroDto>> response = new ServiceResponse<List<GetHeroDto>>();
            response.Data = await _context.Heros
                .Where(h => h.Team.Id == id).Select(h => _mapper.Map<GetHeroDto>(h)).ToListAsync();

            return response;
        }

        public async Task<ServiceResponse<GetHeroDto>> UpdateHero(UpdateHero updateTeam, int id)
        {
            ServiceResponse<GetHeroDto> serviceResponse = new ServiceResponse<GetHeroDto>();

            try
            {
                Hero hero = await _context.Heros.Include(h => h.Team).FirstOrDefaultAsync(h => h.Id == updateTeam.Id);
                hero.Name = updateTeam.Name;
                hero.Card1 = updateTeam.Card1;
                hero.Card2 = updateTeam.Card2;
                hero.Card3 = updateTeam.Card3;
                hero.Card4 = updateTeam.Card4;
                hero.DeathToken = updateTeam.DeathToken;
                _context.Heros.Update(hero);
                await _context.SaveChangesAsync();
                serviceResponse.Data = _mapper.Map<GetHeroDto>(hero);
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }
    }
}