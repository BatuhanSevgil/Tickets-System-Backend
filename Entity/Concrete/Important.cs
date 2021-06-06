
using Core.Entities.Abstract;

namespace Entity.Concrete
{
    public class Important:IEntity
    {
        public int ImportantId { get; set; }
        public string ImportantDetail { get; set; }

    }
}
