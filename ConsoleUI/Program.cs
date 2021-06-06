using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entity.Concrete;
using Newtonsoft;
using System.Text.Json;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System;
using Entities.DTOs;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {

            LoginDto loginDto = new LoginDto() { password = "b1", username = "b1" };
            EfTicketDal dal = new EfTicketDal();
            AuthManager authManager = new AuthManager(new EfPersonDal());

            var person = authManager.Login(loginDto);

            var d=dal.TicketToMyDepartment(person.Data.Departments);

          //  var a = dal.TicketHeaderWithDetailGetLastAssignPersonId(6);
            foreach (var item in d)
            {
                Console.WriteLine();
                //Console.WriteLine(JsonSerializer.Serialize(item));

                
                Console.WriteLine(item.ticketDetails.Count +" "+ item.Subject +" "+item.LastAssignment + " " +item.LastUpdateDate);
                Console.WriteLine();
            }
          

            
        }
    }
}
    

