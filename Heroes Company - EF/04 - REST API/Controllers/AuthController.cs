using log4net.Core;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Matrix
{
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ILogger logger;
        private readonly JwtHelper jwtHelper;
        private AuthLogic authLogic;
        
        public AuthController(AuthLogic authLogic, JwtHelper jwtHelper, ILogger logger)
        {
            this.authLogic = authLogic;
            this.jwtHelper = jwtHelper;
            this.logger = logger;
        }

        [HttpPost]
        [Route("register")]
        public IActionResult Register(TrainerModel trainer)
        {
            try
            {
                if (authLogic.isTrainerNameExists(trainer.Username))
                {
                    return BadRequest("Username already exists! Choose another username.");
                }
                trainer = authLogic.Register(trainer);
                trainer.JwtToken = jwtHelper.GetJwtToken(trainer.Username);
                trainer.Password = null;
                return Created("api/trainers" + trainer.TrainerId, trainer);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login(CredentialsModel credentials)
        {
            try
            {
                TrainerModel trainer = authLogic.GetTrainerByCredentials(credentials);

                if (trainer == null)
                    return Unauthorized("incorrect trainername or password");

                trainer.JwtToken = jwtHelper.GetJwtToken(trainer.Username);

                trainer.Password = null;

                return Ok(trainer);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
