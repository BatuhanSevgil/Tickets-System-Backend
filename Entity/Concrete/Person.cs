using Core.Entities.Abstract;

namespace Entity.Concrete
{
    public class Person : IEntity
    {

        public int PersonId { get; set; }
        public string RealName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }


    }
}
