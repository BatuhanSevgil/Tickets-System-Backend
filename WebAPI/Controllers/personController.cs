using Business.Abstract;
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
    public class personController : ControllerBase
    {

        readonly IPersonService _personService;

        public personController(IPersonService personService)
        {
            _personService = personService;

        }



        [HttpGet]
        public IActionResult GetAllPerson()
        {
            var result = _personService.GetAllPersonRealName();

            if (result.Success)
            {
                return Ok(result);

            }

            return BadRequest(result);
        }


    }
}
