using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.DTOs;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace DataAccess.Concrete.EntityFramework
{
   public class EfTicketDetailDal:EfEntityRepositoryBase<TicketDetail,ngAkisContext>,ITicketDetailDal
    {
        public List<TicketDetailDto> TicketDetailsGetById(int id)
        {

            using (ngAkisContext context=new ngAkisContext())
            {
                var detail = from _detail in context.TicketDetails where _detail.TicketId == id
                             select new TicketDetailDto
                             {
                                 sendPersonId = _detail.sendPersonId,
                                 toDepartmentId = _detail.toDepartmentId,
                                 toPersonId = _detail.toPersonId,

                                 Id = _detail.Id,
                                 Description = _detail.Description,
                                 sendPersonName = context.Persons.FirstOrDefault(person => person.PersonId == _detail.sendPersonId).RealName,
                                 toDepartmentName = _detail.toDepartmentId > 0 ? context.Departments.FirstOrDefault(department => department.DepartmentId == _detail.toDepartmentId).DepartmentDetail : "Departmana atanmayan iş",
                                 toPersonName = _detail.toPersonId > 0 ? context.Persons.FirstOrDefault(person => person.PersonId == _detail.toPersonId).RealName : "Personele atanmaya iş",
                                 UpdateDate = _detail.UpdateDate,
                                 TicketId = _detail.TicketId,
                                 toStatusId = _detail.toStatusId,
                                 toStatusName = context.Statuses.FirstOrDefault(first => first.StatusId == _detail.toStatusId).StatusDetail,
                                 toImportantId=_detail.toImportantId,
                                 toImportantName=context.Importants.FirstOrDefault(first=>first.ImportantId==_detail.toImportantId).ImportantDetail,
                                

                             };
                return detail.ToList();
                             
                             


            }
        }
    }
}
