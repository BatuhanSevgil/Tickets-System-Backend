using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Constants
{
  public static class RawSqlCommands
    {
        public static string LastAssigment = @"select * from dbo.TicketDetails 
                            WHERE UpdateDate IN (Select Max(UpdateDate) from dbo.TicketDetails group by TicketId)";
    }
}
