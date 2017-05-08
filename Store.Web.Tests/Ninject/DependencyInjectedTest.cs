using Ninject;

namespace Store.Web.Tests.Ninject
{
    public abstract class DependencyInjectedTest
    {
        protected DependencyInjectedTest()
        {
            Kernel = new StandardKernel(new NinjectTestingModule());
        }

        protected IKernel Kernel { get; set; }

        protected void NewScope()
        {
            ProcessingScope.Current = new ScopeObject();
        }
    }
}