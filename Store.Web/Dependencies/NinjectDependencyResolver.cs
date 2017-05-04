using Ninject;
using Store.BL.UnityOfWork;
using System;
using System.Collections.Generic;

namespace Store.Web.Dependencies
{
    public class NinjectDependencyResolver
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
        }
    }
}