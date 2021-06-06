using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.DTOs;
using Entity.Concrete;
using System.Linq;

using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfPersonDal : EfEntityRepositoryBase<Person, ngAkisContext>, IPersonDAL
    {


      
        public List<PersonNameDto> GetAllPersonRealName()
        {
            using (var context=new ngAkisContext())
            {

                var result = from _person in context.Persons
                             select new PersonNameDto
                             {
                                 PersonId = _person.PersonId,
                                 RealName = _person.RealName,
                             };
                return result.ToList();

            }



        }
        public List<PersonDto> GetAllPersonWithDepartment()
        {


            using (var context = new ngAkisContext())
            {

                var detail = from _person in context.Persons

                             select new PersonDto
                             {
                                 PersonId = _person.PersonId,
                                 RealName = _person.RealName,
                                 Departments = context.PersonDepartments.Where(wh => wh.PersonId == _person.PersonId).Select(s => s.DepartmentId).ToList()
                             };

                return detail.ToList();
            }

        }


        public PersonDto GetPersonDtoById(int id)
        {


            using (var context=new ngAkisContext())
            {

                var detail = from _person in context.Persons.Where(wh=>wh.PersonId==id)

                             select new PersonDto
                             {
                                 PersonId = _person.PersonId,
                                 RealName = _person.RealName,
                                 Departments = context.PersonDepartments.Where(wh => wh.PersonId == _person.PersonId).Select(s => s.DepartmentId).ToList()
                             };

                return detail.SingleOrDefault();


            }
        }

        public PersonDto Login(LoginDto login)
        {

            using (var context=new ngAkisContext())
            {

                var detail = context.Set<Person>().FirstOrDefault(wh => wh.Username == login.username && wh.Password == login.password);

                if (!object.ReferenceEquals(detail,null))
                {
                    var person = GetPersonDtoById(detail.PersonId);
                    return person;
                }
                return null;
            }
        }
    }
}
