using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class TicketDetailFilterDTO:IDTOs
    {
        public string? Description { get; set; }
        public int? sendPersonId { get; set; }
        public int? toPersonId { get; set; }
        public int? toDepartmentId { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? toStatusId { get; set; }
        public int? toImportantId { get; set; }
    }
}
