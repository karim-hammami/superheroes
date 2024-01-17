using Microsoft.EntityFrameworkCore;
using SuperHeroes.Data;
using SuperHeroes.Models;

namespace SuperHeroes.Services.SuperHeroService;
public class SuperHeroService : ISuperHeroService
{

    private readonly DataContext _context;

    public SuperHeroService(DataContext context)
    {
        _context = context;
    }
    

    public async Task<List<SuperHeros>> GetAllHeroes() {
        var heroes = await _context.SuperHeroes.ToListAsync();
        return heroes;
    }

    public async Task<SuperHeros?> GetSingleHero(int id) {
        var hero = await _context.SuperHeroes.FindAsync(id);
        if (hero is null) {
            return null;
        }
        return hero;
    }

    public async Task<SuperHeros?> AddHero(SuperHeros hero) {
        _context.SuperHeroes.Add(hero);
        await _context.SaveChangesAsync();
        var heroReturned = await _context.SuperHeroes.FindAsync(hero.Id);
        if (heroReturned is null) 
            return null;
        
        return heroReturned;
    }

    public async Task<SuperHeros?> UpdateHero(int id, SuperHeros hero) {
        var heroToBeUpdated = await _context.SuperHeroes.FindAsync(id);
        if (heroToBeUpdated is null)
            return null;
        heroToBeUpdated.Name = hero.Name;
        heroToBeUpdated.FirstName = hero.FirstName;
        heroToBeUpdated.LastName = hero.LastName;
        heroToBeUpdated.Place = hero.Place;

        await _context.SaveChangesAsync();
        return heroToBeUpdated;
    }

    public async Task<List<SuperHeros>?> DeleteHero(int id) {
        var hero = await _context.SuperHeroes.FindAsync(id);
            if (hero is null)
                return null;

            _context.SuperHeroes.Remove(hero);
            await _context.SaveChangesAsync();

            return await _context.SuperHeroes.ToListAsync();

    }

}
