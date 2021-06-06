using Core.Business;
using Core.Utilities.Results;
using Entities.DTOs;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface ITicketDetailService:IManagerCRUD<TicketDetail>
    {
        public IDataResult<List<TicketDetail>> GetByTicketId(int ticketId);
        public IDataResult<List<TicketDetailDto>> TicketDetailsGetById(int id);
    }
}
