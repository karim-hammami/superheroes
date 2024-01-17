using SuperHeroes.Models;

namespace SuperHeroes.Services.SuperHeroService;
public interface ISuperHeroService
{
    Task<List<SuperHeros>> GetAllHeroes();
    Task<SuperHeros?> GetSingleHero(int id);
    Task<SuperHeros?> AddHero(SuperHeros hero);
    Task<SuperHeros?> UpdateHero(int id, SuperHeros hero);
    Task<List<SuperHeros>?> DeleteHero(int id);
}
