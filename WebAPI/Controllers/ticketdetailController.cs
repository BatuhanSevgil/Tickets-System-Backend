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
    public class ticketdetailController : ControllerBase
    {

        ITicketDetailService _detailservice;

        public ticketdetailController(ITicketDetailService detailservice)
        {
            _detailservice = detailservice;

        }

        #region HTTP GET İSTEKLERİ 

        [HttpGet("getbyticketid/{ticketId}")]
        public IActionResult GetByTicketId(int ticketId)
        {
            var result = _detailservice.TicketDetailsGetById(ticketId);

            if (result.Success)
            {
                return Ok(result);

            }
           return BadRequest(result);

        }


        [HttpPost("add")]
        public IActionResult AddTicketDetail([FromBody]TicketDetail detail)
        {

            var result = _detailservice.Add(detail);

            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);
        }





        #endregion

        #region HTTP POST

        //[HttpPost("add")]
        //public IActionResult AddNewTicket( TicketDetail detail)
        //{
        //    var result = _detailservice.Add(detail);

        //    if (result.Success)
        //    {
        //        return Ok(result);

        //    }
        //    return BadRequest(result);


        //}



        #endregion
    }
}
