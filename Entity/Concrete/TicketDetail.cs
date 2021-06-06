using Core.Entities.Abstract;
using System;

namespace Entity.Concrete
{
    public class TicketDetail : IEntity
    {
        public int Id { get; set; }
        public int TicketId { get; set; }
        public string Description { get; set; }
        public int sendPersonId { get; set; }
        public int toPersonId { get; set; }
        public int toDepartmentId { get; set; }
        public DateTime UpdateDate { get; set; }
        public int toStatusId { get; set; }
        public int toImportantId { get; set; }


    }
}
