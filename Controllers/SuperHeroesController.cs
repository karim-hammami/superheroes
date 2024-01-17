using Microsoft.AspNetCore.Mvc;
using SuperHeroes.Models;
using SuperHeroes.Services.SuperHeroService;

namespace SuperHeroes.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SuperHeroesController : ControllerBase
{

    private readonly ISuperHeroService _superHeroService;

    public SuperHeroesController(ISuperHeroService superHeroService)
    {
        _superHeroService = superHeroService;
    }


    [HttpGet]
    public async Task<ActionResult<List<SuperHeros>>> GetAllHeroes() {
        return Ok(await _superHeroService.GetAllHeroes());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<SuperHeros>> GetSingleHero(int id) {
        var result = await _superHeroService.GetSingleHero(id);
        return result == null ? NotFound() : Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<SuperHeros>> AddHero(SuperHeros hero) {
        var result = await _superHeroService.AddHero(hero);
        return result == null ? NotFound() : Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<SuperHeros>> UpdateHero(int id, SuperHeros hero) {
        var result = await _superHeroService.UpdateHero(id, hero);
        return result == null ? NotFound() : Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<List<SuperHeros>>> DeleteHero(int id) {
        var result = await _superHeroService.DeleteHero(id);
        return result == null ? NotFound() : Ok(result);
    }

}
