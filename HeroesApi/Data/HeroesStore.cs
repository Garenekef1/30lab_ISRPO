using HeroesApi.Models;

namespace HeroesApi.Data;

public static class HeroesStore
{
    public static List<Hero> Heroes { get; } =
    [
        new Hero
        {
            Id = 1,
            Name = "Человек-паук",
            RealName = "Питер Паркер",
            Universe = Universe.Marvel,
            PowerLevel = 85,
            Powers = ["паучье чутьё", "ловкость", "паутина"],
            Weapon = new Weapon
            {
                Name = "Веб-шутеры",
                IsRanged = true
            },
            InternalNotes = "Молодой герой Нью-Йорка"
        },
        new Hero
        {
            Id = 2,
            Name = "Железный человек",
            RealName = "Тони Старк",
            Universe = Universe.Marvel,
            PowerLevel = 90,
            Powers = ["броня", "интеллект", "полёт"],
            Weapon = new Weapon
            {
                Name = "Костюм Mark",
                IsRanged = true
            },
            InternalNotes = "Использует технологии Stark Industries"
        },
        new Hero
        {
            Id = 3,
            Name = "Бэтмен",
            RealName = "Брюс Уэйн",
            Universe = Universe.DC,
            PowerLevel = 78,
            Powers = ["детективные навыки", "боевые искусства", "тактика"],
            Weapon = new Weapon
            {
                Name = "Бэтаранг",
                IsRanged = true
            },
            InternalNotes = "Не имеет сверхспособностей"
        },
        new Hero
        {
            Id = 4,
            Name = "Супермен",
            RealName = "Кларк Кент",
            Universe = Universe.DC,
            PowerLevel = 100,
            Powers = ["сила", "полёт", "лазерное зрение"],
            Weapon = new Weapon
            {
                Name = "Нет",
                IsRanged = false
            },
            InternalNotes = "Криптонец"
        }
    ];
}
