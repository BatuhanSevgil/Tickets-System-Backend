using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class StatusManager : IStatusService
    {

        IStatusDAL _statusDAL;

        public StatusManager(IStatusDAL statusDAL)
        {
            _statusDAL = statusDAL;
        }
        public IResult Add(Status status)
        {
            _statusDAL.Add(status);
            return new SuccessResult();
        }

        public IResult Delete(Status status)
        {
            _statusDAL.Delete(status);
            return new SuccessResult();

        }

        public IDataResult<List<Status>> GetAll()
        {
            return new SuccessDataResult<List<Status>>(_statusDAL.GetAll());

        }

        public IDataResult<Status> GetById(int id)
        {
            return new SuccessDataResult<Status>(_statusDAL.Get(status => status.StatusId == id));
        }

        public IResult Update(Status status)
        {
            _statusDAL.Update(status);
            return new SuccessResult();
        }
    }
}
