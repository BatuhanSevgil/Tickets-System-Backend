using Core.Entities.Abstract;
using Entities.Concrete;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
  public  class PersonDto:IDTOs
    {

        public int PersonId { get; set; }
        public string RealName { get; set; }
        public DateTime AuthTime { get; set; }
        public DateTime AuthExpireTime { get; set; }
        public List<int> Departments { get; set; }
    }
}
