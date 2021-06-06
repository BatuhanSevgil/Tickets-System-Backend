using Core.DataAccess;
using Entities.DTOs;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
   public interface ITicketDetailDal:EfEntityRepositoryBase<TicketDetail>
    {
        public List<TicketDetailDto> TicketDetailsGetById(int id);
    }
}
