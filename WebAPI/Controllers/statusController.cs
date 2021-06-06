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
    public class statusController : ControllerBase
    {

        private readonly IStatusService _status;

        public statusController(IStatusService status)
        {
            _status = status;
        }


        #region GET İstekleri


        [HttpGet]
        public IActionResult GetAll()
        {

            var result = _status.GetAll();
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);

        }
        #endregion
    }
}
