using Business.Abstract;
using Core.Utilities.BusinessRules;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.DTOs;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;
using System.Text;

namespace Business.Concrete
{
    public class TicketManager : ITicketService
    {
        ITicketDAL _ticketDAL;
        ITicketDetailService _detailService;

        public TicketManager(ITicketDAL ticketDAL,ITicketDetailService detailService)
        {
            _ticketDAL = ticketDAL;
            _detailService = detailService;

        }

        #region Create Operation

        public IResult Add(Ticket ticket)
        {
            ticket.OpenDate = DateTime.Now;
            ticket.LastUpdateDate = DateTime.Now;

            _ticketDAL.Add(ticket);
            return new SuccessResult();
        }

        public IResult AddWithTicketDetail(Ticket ticket, TicketDetail detail)
        {
            
            ticket.LastUpdateDate = DateTime.Now;
            ticket.OpenDate = DateTime.Now;
            detail.UpdateDate = DateTime.Now;
            detail.sendPersonId = ticket.OpenPersonId;

            detail.TicketId =_ticketDAL.AddAndOutEntity(ticket).TicketId;
            _detailService.Add(detail);
            return new SuccessResult();

        }

        #endregion

        public IResult Delete(Ticket ticket)
        {
            _ticketDAL.Delete(ticket);
            return new SuccessResult();

        }

        #region Read Operation
        public IDataResult<List<Ticket>> GetAll()
        {
            return new SuccessDataResult<List<Ticket>>(_ticketDAL.GetAll());
        }

        public IDataResult<Ticket> GetById(int id)
        {
            return new SuccessDataResult<Ticket>(_ticketDAL.Get(ticket => ticket.TicketId == id));
        }

        public IDataResult<List<TicketDto>> TicketHeadersWithDetailGetAll()
        {
            return new SuccessDataResult<List<TicketDto>>(_ticketDAL.TicketHeaderFilterGetAll());

        }


        //Open Person ID
        public IDataResult<List<TicketDto>> TicketHeadersWithOpenId(int openpersonId)
        {
            return new SuccessDataResult<List<TicketDto>>(_ticketDAL.TicketHeaderWithDetailGetByOpenPersonId(openpersonId));


        }

        // Last Assign PersonId
        public IDataResult<List<TicketDto>> TicketHeadersWithLastAssignPersonId(int lastAssignPersonId)
        {
            return new SuccessDataResult<List<TicketDto>>(_ticketDAL.TicketHeaderWithDetailGetLastAssignPersonId(lastAssignPersonId));


        }



        public IDataResult<TicketDto> TicketHeaderWithDetailGetById(int ticketId)
        {
            return new SuccessDataResult<TicketDto>(_ticketDAL.TicketHeaderWithDetailGetById(ticketId));

        }

        #endregion
        public IResult Update(Ticket ticket)
        {
            _ticketDAL.Update(ticket);
            return new SuccessResult();
        }


        public IDataResult<List<TicketDto>> TicketToMyDepartment(List<int> Departments)
        {
            return new SuccessDataResult<List<TicketDto>>(_ticketDAL.TicketToMyDepartment(Departments));
        }

        public IDataResult<List<TicketDto>> TicketToMyDepartmentAndMyPersonId(List<int> Departments, int personId)
        {
            return new SuccessDataResult<List<TicketDto>>(_ticketDAL.TicketToMyDepartmentAndMyPersonId(Departments,personId));

        }

        public IDataResult<List<TicketDto>> TicketFilter(TicketFilterDto ticketFilter)
        {


            TicketFilterDto filter = new TicketFilterDto();

            filter.Subject = string.IsNullOrWhiteSpace(ticketFilter.Subject) == true ? null : ticketFilter.Subject;
            filter.StatusId = ticketFilter.StatusId != 0 ? ticketFilter.StatusId : null;



            return new SuccessDataResult<List<TicketDto>>(_ticketDAL.TicketHeaderFilterGetAll(Get => Get.Subject == filter.Subject || Get.StatusId == filter.StatusId || Get.ImportantId == filter.ImportantId));
        }

        public IDataResult<List<TicketDto>> TicketDetailFilter(TicketDetailFilterDTO detailFilter)
        {

            TicketDetailFilterDTO filter = new TicketDetailFilterDTO();
            return new SuccessDataResult<List<TicketDto>>(_ticketDAL.TicketDetailFilterGetAll(Get => Get.toDepartmentId==detailFilter.toDepartmentId));

        }
    }
}
