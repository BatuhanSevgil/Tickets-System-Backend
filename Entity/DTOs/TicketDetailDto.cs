using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
   public class TicketDetailDto:IDTOs
    {

        public int Id { get; set; }
        public int TicketId { get; set; }
        public int sendPersonId { get; set; }
        public int toStatusId { get; set; }
        public int toImportantId { get; set; }
        public int toPersonId { get; set; }
        public int toDepartmentId { get; set; }
        public string Description { get; set; }
        public string sendPersonName { get; set; }
        public string toPersonName { get; set; }
        public string toDepartmentName { get; set; }
        public string toStatusName { get; set; }
        public string toImportantName { get; set; }

        public DateTime UpdateDate { get; set; }

        List<TicketDetailDto> ticketDetails { get; set; }

    }
}
