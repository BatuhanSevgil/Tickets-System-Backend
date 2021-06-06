using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {

        private readonly IPersonDAL _personDAL;

        public AuthManager(IPersonDAL personDAL)
        {
            _personDAL = personDAL;
        }

        public IDataResult<PersonDto> Login(LoginDto login)
        {
            var result = _personDAL.Login(login);
            if (!object.ReferenceEquals(result,null))
            {
                result.AuthTime = DateTime.Now;
                result.AuthExpireTime = result.AuthTime.AddHours(12);
                
                return new SuccessDataResult<PersonDto>(result);

            }
            return new ErrorDataResult<PersonDto>();

        }
    }
}
