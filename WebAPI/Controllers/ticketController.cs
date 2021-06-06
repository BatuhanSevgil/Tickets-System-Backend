using Business.Abstract;
using Entities.DTOs;
using Entity.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ticketController : ControllerBase
    {
      readonly private ITicketService _ticketService;
      readonly private  IPersonService _personServce;

        public ticketController(ITicketService ticketService, IPersonService personService)
        {
            _ticketService = ticketService;
            _personServce = personService;
        }




        #region HTTP GET istekleri
        [HttpGet("getallticket")]
        public IActionResult GetAllTicketHeaderWithDetail()
        {

            var result = _ticketService.TicketHeadersWithDetailGetAll();
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);
        }


        [HttpGet("openperson/{personId}")]
        public IActionResult openPersonId(int personId)
        {

            var result = _ticketService.TicketHeadersWithOpenId(personId);
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);

        }


        [HttpGet("headerwithdetail/{ticketId}")]
        public IActionResult GetTicketWithDetail(int ticketId)
        {

            var result = _ticketService.TicketHeaderWithDetailGetById(ticketId);
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);

        }



        //[HttpGet("lastperson/{personId}")]
        //public IActionResult lastPersonId(int personId)
        //{

        //    var result = _ticketService.TicketHeadersWithLastAssignPersonId(personId);
        //    if (result.Success)
        //    {
        //        return Ok(result);

        //    }
        //    return BadRequest(result);

        //}


        [HttpGet("lastperson/{personId}")]
        public IActionResult LastPersonAndDepartment(int personId)
        {
            List<int> department = _personServce.GetPersonDtoById(personId).Data.Departments;
            var result = _ticketService.TicketToMyDepartmentAndMyPersonId(department, personId);
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);

        }


        [HttpPost("filter")]
         public IActionResult Filters(TicketFilterDto filterDto)
        {

            

            var result = _ticketService.TicketFilter(filterDto);

            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);


        }

        [HttpGet("filterdepartment/{departmentId}")]
        public IActionResult FilterDepartment(int departmentId)
        {
            TicketDetailFilterDTO filterDTO = new TicketDetailFilterDTO();
            filterDTO.toDepartmentId = departmentId;

            var result = _ticketService.TicketDetailFilter(filterDTO);

            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);


        }







        #endregion


        #region HTTP POST istekleri
        [HttpPost("addwithdetail")]
        public IActionResult AddTicket([FromBody] JObject data)
        {

            Ticket ticket = data.ToObject<Ticket>();
            TicketDetail detail = data.ToObject<TicketDetail>();
            var result = _ticketService.AddWithTicketDetail(ticket, detail);

            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);
        }



        [HttpPost("add")]
        public IActionResult AddTickets([FromBody] Ticket data)
        {

            var result = _ticketService.Add(data);

            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);
        }

        #endregion



        #region HTTP PUT istekleri

        [HttpPut("update")]
        public IActionResult Update([FromBody] Ticket ticket)
        {

            var result= _ticketService.Update(ticket);
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);


        }


        #endregion
    }
}
