using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class LoginDto:IDTOs
    {

        public string username { get; set; }
        public string password { get; set; }

    }
}
