using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
  public  class TicketFilterDto:IDTOs
    {
        public string? Subject { get; set; }
        public int? StatusId { get; set; }
        public int? ImportantId { get; set; }
    }
}
