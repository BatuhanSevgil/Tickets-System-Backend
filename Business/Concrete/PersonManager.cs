using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.DTOs;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete

{
    public class PersonManager : IPersonService
    {

        IPersonDAL _personDAL;

        public PersonManager(IPersonDAL personDAL)
        {
            _personDAL = personDAL;

        }
        public IResult Add(Person person)
        {
            _personDAL.Add(person);
            return new SuccessResult();
        }

        public IResult Delete(Person person)
        {
            _personDAL.Delete(person);
            return new SuccessResult();
        }

        public IDataResult<List<Person>> GetAll()
        {
            return new SuccessDataResult<List<Person>>(_personDAL.GetAll());
        }

        public IDataResult<List<PersonNameDto>> GetAllPersonRealName()
        {
            return new SuccessDataResult<List<PersonNameDto>>(_personDAL.GetAllPersonRealName());
        }

        public IDataResult<Person> GetById(int id)
        {
            return new SuccessDataResult<Person>(_personDAL.Get(person => person.PersonId == id));
        }

        public IDataResult<List<PersonDto>> GetDetailWithDepartment()
        {
            return new SuccessDataResult<List<PersonDto>>(_personDAL.GetAllPersonWithDepartment());
        }

        public IDataResult<PersonDto> GetPersonDtoById(int id)
        {
            return new SuccessDataResult<PersonDto>(_personDAL.GetPersonDtoById(id));
        }

        public IResult Update(Person person)
        {
            _personDAL.Update(person);
            return new SuccessResult();

        }
    }
}
