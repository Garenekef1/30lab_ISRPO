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

    [HttpGet("serialize")]
    public IActionResult GetSerialize()
    {
        var options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true,
            Converters = { new JsonStringEnumConverter() }
        };

        var hero = new Hero
        {
            Id = 5,
            Name = "Тор",
            RealName = "Тор Одинсон",
            Universe = Universe.Marvel,
            PowerLevel = 98,
            Powers = ["молния", "сила", "полёт"],
            Weapon = new Weapon
            {
                Name = "Мьёльнир",
                IsRanged = false
            },
            InternalNotes = "Служебное поле не должно попасть в JSON"
        };

        var serialized = JsonSerializer.Serialize(hero, options);
        var deserialized = JsonSerializer.Deserialize<Hero>(serialized, options);

        return Ok(new
        {
            serializedJson = serialized,
            deserializedObject = deserialized,
            internalNotesAfterDeserialize = deserialized?.InternalNotes
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
