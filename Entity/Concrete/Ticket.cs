using Core.Entities.Abstract;
using System;

namespace Entity.Concrete
{
    public class Ticket:IEntity
    {

        public int TicketId { get; set; }
        public string Subject { get; set; }
        public DateTime OpenDate { get; set; }
        public int OpenPersonId { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public int StatusId { get; set; }
        public int ImportantId { get; set; }



    }
}
