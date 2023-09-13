using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Concrete;
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

            //builder.RegisterType<CategoryManager>().As<ICategoryService>();
            //builder.RegisterType<EfCategoryDal>().As<ICategoryDal>();

            //builder.RegisterType<UserManager>().As<IUserService>();
            //builder.RegisterType<EfUserDal>().As<IUserDal>();

            //builder.RegisterType<AuthManager>().As<IAuthService>();
            //builder.RegisterType<JwtHelper>().As<ITokenHelper>();
        }
    }
}
