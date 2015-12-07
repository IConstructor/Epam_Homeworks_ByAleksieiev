using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Dependencies;

namespace Epam_MVCTask1_ByAleksieiev_WEB
{
    public class NinjectHttpDependencyResolver : IDependencyResolver, IDependencyScope
    {
        private readonly IKernel _kernel;

        public NinjectHttpDependencyResolver(IKernel kernel)
        {
            _kernel = kernel;
        }

        public IDependencyScope BeginScope()
        {
            return this;
        }

        public void Dispose()
        {
        }

        public object GetService(Type serviceType)
        {
            return _kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _kernel.GetAll(serviceType);
        }

    }
}
