using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {

        readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;

        }
        #region Get İstekleri
        [HttpGet]
        public IActionResult Getir()
        {
            var result = _departmentService.GetAll();

            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);

        }



        #endregion
        [HttpPost("add")]

        public IActionResult Add([FromBody] Department department)
        {

            var result = _departmentService.Add(department);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        #region Post İstekleri

        
        
        #endregion
    }
}
