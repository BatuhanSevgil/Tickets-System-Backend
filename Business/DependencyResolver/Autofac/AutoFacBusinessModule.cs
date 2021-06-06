using Autofac;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.DependencyResolver.Autofac
{
    public class AutoFacBusinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {


            // Manager to Service IoC
            builder.RegisterType<DepertmanManager>().As<IDepartmentService>().SingleInstance();
            builder.RegisterType<ImportantManager>().As<IImportantService>().SingleInstance();
            builder.RegisterType<PersonManager>().As<IPersonService>().SingleInstance();
            builder.RegisterType<StatusManager>().As<IStatusService>().SingleInstance();
            builder.RegisterType<TicketDetailManager>().As<ITicketDetailService>().SingleInstance();
            builder.RegisterType<TicketManager>().As<ITicketService>().SingleInstance();
            builder.RegisterType<AuthManager>().As<IAuthService>().SingleInstance();


            //DALservice ->DALdb 

            builder.RegisterType<EfDepartmantDAL>().As<IDepartmentDAL>().SingleInstance();
            builder.RegisterType<EfImportatDal>().As<IImportantDAL>().SingleInstance();
            builder.RegisterType<EfPersonDal>().As<IPersonDAL>().SingleInstance();
            builder.RegisterType<EfStatusDal>().As<IStatusDAL>().SingleInstance();
            builder.RegisterType<EfTicketDetailDal>().As<ITicketDetailDal>().SingleInstance();
            builder.RegisterType<EfTicketDal>().As<ITicketDAL>().SingleInstance();
            

        }
    }
}
