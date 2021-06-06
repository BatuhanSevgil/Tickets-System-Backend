using Core.Entities.Abstract;

namespace Entity.Concrete
{
    public class Status : IEntity
    {
        public int StatusId { get; set; }
        public string StatusDetail { get; set; }


    }
}
