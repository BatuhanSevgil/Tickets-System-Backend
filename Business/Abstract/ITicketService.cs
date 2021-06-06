using Core.Business;
using Core.Utilities.Results;
using Entities.DTOs;
using Entity.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public  interface ITicketService:IManagerCRUD<Ticket>
    {
        public IDataResult<List<TicketDto>> TicketHeadersWithDetailGetAll();
        public IResult AddWithTicketDetail(Ticket ticket, TicketDetail detail);
        public IDataResult<List<TicketDto>> TicketHeadersWithOpenId(int openpersonId);
        public IDataResult<TicketDto> TicketHeaderWithDetailGetById(int ticketId);
        public IDataResult<List<TicketDto>> TicketHeadersWithLastAssignPersonId(int lastAssignPersonId);
        public IDataResult<List<TicketDto>> TicketToMyDepartment(List<int> Departments);
        public IDataResult<List<TicketDto>> TicketFilter(TicketFilterDto ticketFilter);

        public IDataResult<List<TicketDto>> TicketDetailFilter(TicketDetailFilterDTO detailFilter);
        public IDataResult<List<TicketDto>> TicketToMyDepartmentAndMyPersonId(List<int> Departments, int personId);

    }
}
