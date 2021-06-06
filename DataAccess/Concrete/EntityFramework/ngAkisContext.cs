using Entities.Concrete;
using Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
   public class ngAkisContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=ngAkis;Trusted_Connection=True;");
        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Important> Importants { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Status> Statuses{ get; set; }
        public DbSet<Ticket> Tickets{ get; set; }
        public DbSet<TicketDetail>TicketDetails{ get; set; }
        public DbSet<PersonDepartment> PersonDepartments { get; set; }

    }
}
