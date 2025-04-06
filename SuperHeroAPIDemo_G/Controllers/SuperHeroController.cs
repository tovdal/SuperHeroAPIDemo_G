using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperHeroAPIDemo_G.Models;

namespace SuperHeroAPIDemo_G.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private static List<SuperHero> heroes = new List<SuperHero>
        {
            new SuperHero
            {
                Id = 1, Name = "Spiderman", FirstName = "Peter",
                SurName="Parker", City="New York"},
            new SuperHero
            {
                Id = 2,
                Name = "Ironman", FirstName = "Tony", SurName="Stark",
                City="New York"},
        };

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetAll()
        {
            return Ok(heroes);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<SuperHero>> GetOne(int id)
        {
            var hero = heroes.Find(s => s.Id == id);

            if (hero == null)
            {
                return BadRequest("SuperHero not found");
            }
            return Ok(hero);
        }
        [HttpPost]
        public async Task<ActionResult<SuperHero>>PostHero(SuperHero hero)
        {
            heroes.Add(hero);
            return Ok(heroes);
        }
        [HttpPut]
        public async Task<ActionResult<SuperHero>> UpdateHero(SuperHero hero)
        {
            var heroToUpdate = heroes.Find(s => s.Id == hero.Id);

            if (heroToUpdate == null)
            {
                return BadRequest("Superhero not found");
            }

            heroToUpdate.Name = hero.Name;
            heroToUpdate.FirstName = hero.FirstName;
            heroToUpdate.SurName = hero.SurName;
            heroToUpdate.City = hero.City;

            return Ok(heroes);
        }
    }
}
