using AutoMapper;
using Ninject.Modules;
using Store.BL.UnityOfWork;
using Store.Web.Controllers;
using Store.Web.Mappers;

namespace Store.Web.Tests.Ninject
{
    public class NinjectTestingModule : NinjectModule
    {
        public override void Load()
        {
            // UOW binding
            Bind<IUnityOfWork>().To<UnityOfWork>();

            // mappers binding
            Bind<UserMapper>().ToSelf().InSingletonScope();
            Bind<ProductMapper>().ToSelf().InSingletonScope();

            // AutoMapperConfiguration binding
            Bind<IMapper>().ToMethod(AutoMapperConfig.GetMapper).InSingletonScope();

            // controllers
            Bind<ProductsController>().ToSelf().InSingletonScope();
        }
    }
}