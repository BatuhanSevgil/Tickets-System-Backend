using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
   public class TicketDto:IDTOs
    {

        public int TicketId { get; set; }

        public int OpenPersonId { get; set; }
        public int StatusId { get; set; }
        public int ImportantId { get; set; }



        public string Subject { get; set; }
        public DateTime OpenDate { get; set; }

        public string OpenPersonName { get; set; }
        public string LastAssignment { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public string Status { get; set; }
        public string Important { get; set; }
        public List<TicketDetailDto> ticketDetails { get; set; }


    }
}
