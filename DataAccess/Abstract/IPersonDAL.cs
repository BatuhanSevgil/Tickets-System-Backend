using Core.DataAccess;
using Entities.DTOs;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IPersonDAL : EfEntityRepositoryBase<Person>
    {
        public List<PersonDto> GetAllPersonWithDepartment();
        public PersonDto Login(LoginDto login);
        public List<PersonNameDto> GetAllPersonRealName();
        public PersonDto GetPersonDtoById(int id);
    }
}
