using Core.Entities.Abstract;

namespace Entity.Concrete
{
    public class Department:IEntity
    {
        public int DepartmentId { get; set; }
        public string DepartmentDetail { get; set; }

    }
}
