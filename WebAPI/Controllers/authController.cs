using Business.Abstract;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class authController : ControllerBase
    {

        readonly private IAuthService _authService;

        public authController(IAuthService authService)
        {
            _authService = authService;
        }





        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDto login)
        {
            var result = _authService.Login(login);
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);


        }
    }
}
