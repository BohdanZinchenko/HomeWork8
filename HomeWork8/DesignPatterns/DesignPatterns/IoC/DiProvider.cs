using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace DesignPatterns.IoC
{
    public class DiProvider : IServiceProvider
    {
        private readonly List<ServiceDescriptor> _serviceDescriptors;
        public DiProvider(List<ServiceDescriptor> serviceDescriptors)
        {
            _serviceDescriptors = serviceDescriptors;
        }

        public object GetService(Type serviceType)
        {
            var descriptor = _serviceDescriptors.SingleOrDefault(x => x.ServiceType == serviceType);

            if (descriptor == null)
            {
                throw new Exception("");
            }

            if (descriptor.Implementation != null)
            {
                return descriptor.Implementation;
            }


            var actualType = descriptor.ServiceType;

            var constructorInfo = actualType.GetConstructors().First();
            var parameters = constructorInfo.GetParameters()
                .Select(x => GetService(x.ParameterType)).ToArray();

            var implementation = Activator.CreateInstance(actualType,parameters);

            if (descriptor.LifeTime == LifeTime.Singleton)
            {
                descriptor.Implementation = implementation;
            }
            return implementation;

        }

        public T GetService<T>()
        {
            return (T) GetService(typeof(T));

        }
    }
}