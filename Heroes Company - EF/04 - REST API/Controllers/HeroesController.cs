using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Matrix.Controllers
{
    [Authorize]
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class HeroesController : ControllerBase
    {
        private HeroesLogic heroesLogic;
        public HeroesController(HeroesLogic heroesLogic)
        {
            this.heroesLogic = heroesLogic;
        }

        [HttpGet]
        [Route("{trainerId}")]
        public IActionResult GetAllHeroesByTrainerId(string trainerId)
        {
            try
            {
                List<HeroModel> allHeroesByTrainerId = heroesLogic.GetAllHeroesByTrainerId(trainerId);
                return Ok(allHeroesByTrainerId);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        public IActionResult AddHero(HeroModel heroModel)
        {
            try
            {
                HeroModel addedHero = heroesLogic.AddHero(heroModel);
                return Created("api/heroes/" + addedHero.HeroId, addedHero);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete]
        [Route("{heroId}")]
        public IActionResult DeleteHero(string heroId)
        {
            try
            {
                heroesLogic.DeleteHero(heroId);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
