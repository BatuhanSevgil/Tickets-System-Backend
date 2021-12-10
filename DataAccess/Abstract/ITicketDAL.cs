using Core.DataAccess;
using Core.Entities.Abstract;
using Entities.DTOs;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ITicketDAL:EfEntityRepositoryBase<Ticket>
    {
        public TicketDto TicketHeaderWithDetailGetById(int ticketId);
        public List<TicketDto> TicketHeaderFilterGetAll(TicketFilterDto Header);
        public List<TicketDto> TicketDetailFilterGetAll(Expression<Func<TicketDetail, bool>> detailFilter = null);
        public List<TicketDto> TicketHeaderWithDetailGetByOpenPersonId(int openPersonId);
        public List<TicketDto> TicketHeaderWithDetailGetLastAssignPersonId(int lastPersonId);
        public List<TicketDto> TicketToMyDepartment(List<int> Departments);
        public List<TicketDto> TicketToMyDepartmentAndMyPersonId(List<int> Departments, int personId);

    }
}
