using System.Text.Json;
using System.Text.Json.Serialization;
using HeroesApi.Data;
using HeroesApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace HeroesApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HeroesController : ControllerBase
{
    [HttpGet]
    public ActionResult<List<Hero>> GetAll()
    {
        return Ok(HeroesStore.Heroes);
    }

    [HttpGet("demo")]
    public IActionResult GetDemo()
    {
        var hero = HeroesStore.Heroes.First();

        var defaultOptions = new JsonSerializerOptions
        {
            WriteIndented = true
        };

        var ourOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true,
            Converters = { new JsonStringEnumConverter() }
        };

        var defaultJson = JsonSerializer.Serialize(hero, defaultOptions);
        var ourJson = JsonSerializer.Serialize(hero, ourOptions);

        return Ok(new
        {
            withDefaultSettings = JsonSerializer.Deserialize<object>(defaultJson, defaultOptions),
            withOurSettings = JsonSerializer.Deserialize<object>(ourJson, ourOptions)
        });
    }

    [HttpGet("{id:int}")]
    public ActionResult<Hero> GetById(int id)
    {
        var hero = HeroesStore.Heroes.FirstOrDefault(hero => hero.Id == id);

        if (hero is null)
        {
            return NotFound(new { message = $"Герой с id = {id} не найден" });
        }

        return Ok(hero);
    }
}
