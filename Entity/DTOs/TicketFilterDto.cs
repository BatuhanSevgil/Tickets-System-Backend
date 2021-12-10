using Core.Entities.Abstract;


namespace Entities.DTOs
{
  public  class TicketFilterDto:IDTOs
    {
     

#nullable enable     
       public string? Subject { get; set; }
      #nullable enable 
        public int? StatusId { get; set; }
        #nullable enable 
        public int? ImportantId { get; set; }

        #nullable enable
        public int? DepartmentId { get; set; }

    }
}
