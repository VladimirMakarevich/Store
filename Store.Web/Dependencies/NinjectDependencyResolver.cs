using AutoMapper;
using Ninject;
using Store.BL.UnityOfWork;
using Store.Web.Mappers;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Store.Web.Dependencies
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel _kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            _kernel = kernelParam;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return _kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            _kernel.Bind<IUnityOfWork>().To<UnityOfWork>();

            _kernel.Bind<IMapper>().ToMethod(AutoMapperConfig.GetMapper).InSingletonScope();

            _kernel.Bind<UserMapper>().ToSelf().InSingletonScope();
        }
    }
}