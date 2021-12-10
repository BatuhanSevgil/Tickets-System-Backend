using Core.DataAccess;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.DTOs;
using Entity.Concrete;
using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using DataAccess.Constants;
using Core.Entities.Abstract;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfTicketDal : EfEntityRepositoryBase<Ticket, ngAkisContext>, ITicketDAL
    {
        ITicketDetailDal dal = new EfTicketDetailDal();



        //

        public TicketDto TicketHeaderWithDetailGetById(int ticketId)
        {

            using (ngAkisContext context = new ngAkisContext())
            {


                var detail = from _ticket in context.Tickets
                             where _ticket.TicketId == ticketId

                                                       
                            join _detail in context.TicketDetails.FromSqlRaw(RawSqlCommands.LastAssigment)
                             on _ticket.TicketId equals _detail.TicketId



                             select new TicketDto
                             {
                                 LastAssignment =
                                 _detail.toPersonId > 0 ?
                                 context.Persons.Single(person => person.PersonId == _detail.toPersonId).RealName :
                                 context.Departments.Single(department => department.DepartmentId == _detail.toDepartmentId).DepartmentDetail,
                                 LastUpdateDate = _detail.UpdateDate,
                                

                                 ImportantId = _detail.toImportantId,
                                 OpenPersonId = _ticket.OpenPersonId,
                                 StatusId = _detail.toStatusId,

                                 OpenPersonName = context.Persons.FirstOrDefault(person => person.PersonId == _ticket.OpenPersonId).RealName,
                                 Important = context.Importants.FirstOrDefault(first=>first.ImportantId==_detail.toImportantId).ImportantDetail,
                                 OpenDate = _ticket.OpenDate,
                                 Status = context.Statuses.FirstOrDefault(first=>first.StatusId==_detail.toStatusId).StatusDetail,
                                 Subject = _ticket.Subject,
                                 TicketId = _ticket.TicketId,
                                 ticketDetails = dal.TicketDetailsGetById(_detail.TicketId)
                             };

                return detail.FirstOrDefault();
            }
        }

        public List<TicketDto> TicketToMyDepartmentAndMyPersonId(List<int> Departments, int personId)
        {

            using (ngAkisContext context = new ngAkisContext())
            {


                var detail = from _ticket in context.Tickets.Where(wh=>wh.StatusId!=6)
                             join _status in context.Statuses on
                             _ticket.StatusId equals _status.StatusId
                             join _important in context.Importants on
                             _ticket.ImportantId equals _important.ImportantId

                             join _detail in context.TicketDetails.FromSqlRaw(RawSqlCommands.LastAssigment).Where(wh => Departments.Contains(wh.toDepartmentId) || wh.toPersonId == personId)
                             on _ticket.TicketId equals _detail.TicketId

                             select new TicketDto
                             {
                                 LastAssignment =
                                 _detail.toPersonId > 0 ?
                                 context.Persons.Single(person => person.PersonId == _detail.toPersonId).RealName :
                                 context.Departments.Single(department => department.DepartmentId == _detail.toDepartmentId).DepartmentDetail,


                                 ImportantId = _ticket.ImportantId,
                                 OpenPersonId = _ticket.OpenPersonId,
                                 StatusId = _ticket.StatusId,
                                 LastUpdateDate = _detail.UpdateDate,

                                 OpenPersonName = context.Persons.FirstOrDefault(person => person.PersonId == _ticket.OpenPersonId).RealName,
                                 Important = _important.ImportantDetail,
                                 OpenDate = _ticket.OpenDate,
                                 Status = _status.StatusDetail,
                                 Subject = _ticket.Subject,
                                 TicketId = _ticket.TicketId,
                                 ticketDetails = dal.TicketDetailsGetById(_detail.TicketId)
                             };

                return detail.ToList();
            }
        }

        public List<TicketDto> TicketToMyDepartment(List<int> Departments)
        {

              using (ngAkisContext context = new ngAkisContext())
            {


                var detail = from _ticket in context.Tickets.Where(t => t.StatusId!=6)
                             join _status in context.Statuses on
                             _ticket.StatusId equals _status.StatusId
                             join _important in context.Importants on
                             _ticket.ImportantId equals _important.ImportantId

                             join _detail in context.TicketDetails.FromSqlRaw(RawSqlCommands.LastAssigment).Where(wh=>Departments.Contains(wh.toDepartmentId))
                             on _ticket.TicketId equals _detail.TicketId

                             select new TicketDto
                             {
                                 LastAssignment =
                                 _detail.toPersonId > 0 ?
                                 context.Persons.Single(person => person.PersonId == _detail.toPersonId).RealName :
                                 context.Departments.Single(department => department.DepartmentId == _detail.toDepartmentId).DepartmentDetail,


                                 ImportantId = _ticket.ImportantId,
                                 OpenPersonId = _ticket.OpenPersonId,
                                 StatusId = _ticket.StatusId,
                                 LastUpdateDate = _detail.UpdateDate,

                                 OpenPersonName = context.Persons.FirstOrDefault(person => person.PersonId == _ticket.OpenPersonId).RealName,
                                 Important = _important.ImportantDetail,
                                 OpenDate = _ticket.OpenDate,
                                 Status = _status.StatusDetail,
                                 Subject = _ticket.Subject,
                                 TicketId = _ticket.TicketId,
                                 ticketDetails = dal.TicketDetailsGetById(_detail.TicketId)
                             };

                return detail.ToList();
            }


        }

        public List<TicketDto> TicketHeaderWithDetailGetLastAssignPersonId(int lastPersonId)
        {
            // lastpersonId
            using (ngAkisContext context = new ngAkisContext())
            {


                var detail = from _ticket in context.Tickets.Where(wh=>wh.StatusId!=6)
                             join _status in context.Statuses on
                             _ticket.StatusId equals _status.StatusId
                             join _important in context.Importants on
                             _ticket.ImportantId equals _important.ImportantId

                             join _detail in context.TicketDetails.FromSqlRaw(RawSqlCommands.LastAssigment).Where(wh=>wh.toPersonId==lastPersonId)
                             on _ticket.TicketId equals _detail.TicketId

                             select new TicketDto
                             {
                                 LastAssignment =
                                 _detail.toPersonId > 0 ?
                                 context.Persons.Single(person => person.PersonId == _detail.toPersonId).RealName :
                                 context.Departments.Single(department => department.DepartmentId == _detail.toDepartmentId).DepartmentDetail,

                                 
                                 ImportantId = _ticket.ImportantId,
                                 OpenPersonId = _ticket.OpenPersonId,
                                 StatusId = _ticket.StatusId,
                                 LastUpdateDate = _detail.UpdateDate,

                                 OpenPersonName = context.Persons.FirstOrDefault(person => person.PersonId == _ticket.OpenPersonId).RealName,
                                 Important = _important.ImportantDetail,
                                 OpenDate = _ticket.OpenDate,
                                 Status = _status.StatusDetail,
                                 Subject = _ticket.Subject,
                                 TicketId = _ticket.TicketId,
                                 ticketDetails = dal.TicketDetailsGetById(_detail.TicketId)
                             };

                return detail.ToList();
            }
        }

        public List<TicketDto> TicketHeaderWithDetailGetByOpenPersonId(int openPersonId)
        {
            // OpenPersonId
            using (ngAkisContext context = new ngAkisContext())
            {


                var detail = from _ticket in context.Tickets.Where(wh => wh.StatusId != 6)
                             where _ticket.OpenPersonId == openPersonId
                            
              
                             

                             join _detail in context.TicketDetails.FromSqlRaw(RawSqlCommands.LastAssigment)
                             on _ticket.TicketId equals _detail.TicketId

                             select new TicketDto
                             {
                                 LastAssignment =
                                 _detail.toPersonId > 0 ?
                                 context.Persons.Single(person => person.PersonId == _detail.toPersonId).RealName :
                                 context.Departments.Single(department => department.DepartmentId == _detail.toDepartmentId).DepartmentDetail,

                                 

                                 ImportantId = _detail.toImportantId,
                                 OpenPersonId = _ticket.OpenPersonId,
                                 StatusId = _detail.toStatusId,
                                 LastUpdateDate=_detail.UpdateDate,

                                 OpenPersonName = context.Persons.FirstOrDefault(person => person.PersonId == _ticket.OpenPersonId).RealName,
                                 Important = context.Importants.FirstOrDefault(first=>first.ImportantId==_detail.toImportantId).ImportantDetail,
                                 OpenDate = _ticket.OpenDate,
                                 Status = context.Statuses.FirstOrDefault(first=>first.StatusId==_detail.toStatusId).StatusDetail,
                                 Subject = _ticket.Subject,
                                 TicketId = _ticket.TicketId,
                                 ticketDetails = dal.TicketDetailsGetById(_detail.TicketId)
                             };

                return detail.ToList();
            }
        }
#nullable enable
        public List<TicketDto> TicketHeaderFilterGetAll(TicketFilterDto? Header=null) 
                {

            using (ngAkisContext context = new ngAkisContext())
            {


                var detail = from _ticket in context.Tickets.WhereIf(Header.StatusId!=null , get=>get.StatusId==Header.StatusId).WhereIf(Header.Subject!=null,get=>get.Subject==Header.Subject)



                             join _detail in context.TicketDetails.FromSqlRaw(RawSqlCommands.LastAssigment)
                           .WhereIf(Header.DepartmentId!=null,get=>get.toDepartmentId==Header.DepartmentId)
                             on _ticket.TicketId equals _detail.TicketId





                             select new TicketDto
                             {
                                 ImportantId = _detail.toImportantId,
                                 OpenPersonId = _ticket.OpenPersonId,
                                 StatusId = _detail.toStatusId,
                                 LastAssignment =
                                 _detail.toPersonId > 0 ?
                                 context.Persons.Single(person => person.PersonId == _detail.toPersonId).RealName :
                                 context.Departments.Single(department => department.DepartmentId == _detail.toDepartmentId).DepartmentDetail,
                                 LastUpdateDate = _detail.UpdateDate,



                                 ticketDetails = dal.TicketDetailsGetById(_ticket.TicketId),
                                
                                 OpenPersonName = context.Persons.FirstOrDefault(person => person.PersonId == _ticket.OpenPersonId).RealName,
                                 Important = context.Importants.FirstOrDefault(first=>first.ImportantId==_detail.toImportantId).ImportantDetail,
                                 OpenDate = _ticket.OpenDate,
                                 Status = context.Statuses.FirstOrDefault(wh => wh.StatusId == _detail.toStatusId).StatusDetail,
                                 Subject = _ticket.Subject,
                                 TicketId = _ticket.TicketId,
                                

                             };



                return detail.ToList();

            }
        }

        public List<TicketDto> TicketDetailFilterGetAll(Expression<Func<TicketDetail, bool>> filter = null)
        {

            using (ngAkisContext context = new ngAkisContext())
            {


                var detail = from _ticket in context.Tickets


                             join _detail in context.TicketDetails.FromSqlRaw(RawSqlCommands.LastAssigment).Where(filter)
                             on _ticket.TicketId equals _detail.TicketId




                             select new TicketDto
                             {
                                 ImportantId = _detail.toImportantId,
                                 OpenPersonId = _ticket.OpenPersonId,
                                 StatusId = _detail.toStatusId,
                                 LastAssignment =
                                 _detail.toPersonId > 0 ?
                                 context.Persons.Single(person => person.PersonId == _detail.toPersonId).RealName :
                                 context.Departments.Single(department => department.DepartmentId == _detail.toDepartmentId).DepartmentDetail,
                                 LastUpdateDate = _detail.UpdateDate,



                                 ticketDetails = dal.TicketDetailsGetById(_ticket.TicketId),
                                 OpenPersonName = context.Persons.FirstOrDefault(person => person.PersonId == _ticket.OpenPersonId).RealName,
                                 Important = context.Importants.FirstOrDefault(first => first.ImportantId == _detail.toImportantId).ImportantDetail,
                                 OpenDate = _ticket.OpenDate,
                                 Status = context.Statuses.FirstOrDefault(wh => wh.StatusId == _detail.toStatusId).StatusDetail,
                                 Subject = _ticket.Subject,
                                 TicketId = _ticket.TicketId,


                             };



                return detail.ToList();

            }
        }

    }
}
