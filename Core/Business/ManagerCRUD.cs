using Core.Entities.Abstract;
using Core.Utilities.Results;
using System.Collections.Generic;

namespace Core.Business
{
    public interface IManagerCRUD<Tentity>where Tentity:IEntity
    {
        
        public IResult Add(Tentity tentity);
        public IResult Delete(Tentity tentity);
        public IResult Update(Tentity tentity);
        public IDataResult<List<Tentity>> GetAll();
        public IDataResult<Tentity> GetById(int id);
    }
}
