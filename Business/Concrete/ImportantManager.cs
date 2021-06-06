using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ImportantManager : IImportantService
    {

        IImportantDAL _importantDal;

        public ImportantManager(IImportantDAL importantDAL)
        {
            _importantDal = importantDAL;

        }
        public IResult Add(Important important)
        {
            _importantDal.Add(important);
            return new SuccessResult();

        }

        public IResult Delete(Important important)
        {
            _importantDal.Delete(important);
            return new SuccessResult();

        }

        public IDataResult<List<Important>> GetAll()
        {
            return new SuccessDataResult<List<Important>>(_importantDal.GetAll());
        }

        public IDataResult<Important> GetById(int id)
        {

            return new SuccessDataResult<Important>(_importantDal.Get(important => important.ImportantId == id));
        }


        public IResult Update(Important important)
        {
            _importantDal.Update(important);
            return new SuccessResult();
        }
    }
}
