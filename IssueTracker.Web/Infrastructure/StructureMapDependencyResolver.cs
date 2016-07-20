using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IssueTracker.Web.Infrastructure
{
    public class StructureMapDependencyResolver : IDependencyResolver
    {
        private readonly Func<IContainer> _factory;

        public StructureMapDependencyResolver()
        {

        }
        public StructureMapDependencyResolver(Func<IContainer> factory)
        {
            _factory = factory;
        }

        public object GetService(Type serviceType)
        {
            if(serviceType == null)
            {
                return null;
            }
            var factory = _factory();
            return serviceType.IsAbstract || serviceType.IsAbstract ? factory.TryGetInstance(serviceType) : factory.GetInstance(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _factory().GetAllInstances(serviceType).Cast<object>();
        }
    }
}