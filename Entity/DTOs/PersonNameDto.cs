using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
   public class PersonNameDto:IDTOs
    {

        public int PersonId { get; set; }
        public string RealName { get; set; }

    }
}
