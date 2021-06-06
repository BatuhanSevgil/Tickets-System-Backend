using Core.Business;
using Core.Utilities.Results;
using Entities.DTOs;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IPersonService:IManagerCRUD<Person>
    {

        public IDataResult<List<PersonDto>> GetDetailWithDepartment();
        public IDataResult<List<PersonNameDto>>GetAllPersonRealName();
        public IDataResult<PersonDto> GetPersonDtoById(int id);


    }
}
