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
    public class ImportantController : ControllerBase
    {
        private readonly IImportantService _important;

        public ImportantController(IImportantService important)
        {
            _important = important;
        }



        #region Http Get

        [HttpGet]

        public IActionResult GetAllImpotant()
        {

            var result = _important.GetAll();

            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);

        }

        #endregion
    }
}
