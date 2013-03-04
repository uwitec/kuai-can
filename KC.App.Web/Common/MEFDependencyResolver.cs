
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition;

namespace KC.App.Web
{
    public class MEFDependencyResolver : IDependencyResolver
    {
        private readonly CompositionContainer _container;

        public MEFDependencyResolver(CompositionContainer container)
        {
            if (container == null) throw new ArgumentNullException("container");

            _container = container;
        }

        public object GetService(Type serviceType)
        {
            var name = AttributedModelServices.GetContractName(serviceType);
            return _container.GetExportedValueOrDefault<object>(name);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _container.GetExportedValues<object>(serviceType.FullName);
        }
    }
}
