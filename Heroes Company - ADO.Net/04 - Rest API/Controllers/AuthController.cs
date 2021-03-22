using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatrixHeroes
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public AuthController(TrainersLogic trainersStorage)
        {
            _trainersStorage = trainersStorage;
        }
        private readonly TrainersLogic _trainersStorage;


        [HttpPost]
        [Route("register")]
        public IActionResult Register(Trainer trainer)
        {
            try
            {
                _trainersStorage.Create(trainer);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login(Credentials credentials)
        {
            try
            {
                _trainersStorage.Login(credentials);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
