using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class DepertmanManager : IDepartmentService
    {

        IDepartmentDAL _departmentDAL;

        public DepertmanManager(IDepartmentDAL departmentDAL)
        {
            _departmentDAL = departmentDAL;

        }
        public IResult Add(Department department)
        {

            _departmentDAL.Add(department);
            return new SuccessResult();
        }

        public IResult Delete(Department department)
        {
            _departmentDAL.Delete(department);
            return new SuccessResult();
        }

    
        public IDataResult<List<Department>> GetAll()
        {
            return new SuccessDataResult<List<Department>>(_departmentDAL.GetAll());
        }

        public IDataResult<Department> GetById(int id)
        {
            return new SuccessDataResult<Department>(_departmentDAL.Get(department => department.DepartmentId == id));
        }

        public IResult Update(Department department)
        {
            _departmentDAL.Update(department);
            return new SuccessResult();
        }
    }
}
