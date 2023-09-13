using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using Business.Abstract;
using Business.Concrete;
using Core.Utilities.Security.Jwt;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;

namespace Business.DependencyResolvers.AutoFac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            //IProductService türünde bir şey istenirse biz ona ProductManager veriyor olucaz
            builder.RegisterType<DoorService>().As<IDoorService>();
            builder.RegisterType<EfDoorDal>().As<IDoorDal>();

            builder.RegisterType<UserService>().As<IUserService>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();

            builder.RegisterType<AuthService>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();

        }
    }
}
