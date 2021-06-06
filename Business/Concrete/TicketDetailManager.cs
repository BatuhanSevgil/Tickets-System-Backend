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
    public class TicketDetailManager : ITicketDetailService
    {

        ITicketDetailDal _detailDal;

        public TicketDetailManager(ITicketDetailDal detailDal)
        {
            _detailDal = detailDal;
        }
        public IResult Add(TicketDetail ticketDetail)
        {
            ticketDetail.UpdateDate = DateTime.Now;

            _detailDal.Add(ticketDetail);
            return new SuccessResult();

        }

        public IResult Delete(TicketDetail ticketDetail)
        {

            _detailDal.Delete(ticketDetail);
            return new SuccessResult();
        }

        public IDataResult<List<TicketDetail>> GetAll()
        {
            return new SuccessDataResult<List<TicketDetail>>(_detailDal.GetAll());
        }

        public IDataResult<TicketDetail> GetById(int id)
        {
            return new SuccessDataResult<TicketDetail>(_detailDal.Get(detail => detail.Id == id));
        }


        public IDataResult<List<TicketDetail>> GetByTicketId(int ticketId)
        {
            var result = _detailDal.GetAll(detail => detail.TicketId == ticketId);

            if (result.Count<=0)
            {
                return new ErrorDataResult<List<TicketDetail>>(result);

            }
            return new SuccessDataResult<List<TicketDetail>> (result);
        }

        public IDataResult<List<TicketDetailDto>> TicketDetailsGetById(int id)
        {
            return new SuccessDataResult<List<TicketDetailDto>>(_detailDal.TicketDetailsGetById(id));
        }

        public IResult Update(TicketDetail ticketDetail)
        {
            _detailDal.Update(ticketDetail);
            return new SuccessResult();
        }
    }
}
