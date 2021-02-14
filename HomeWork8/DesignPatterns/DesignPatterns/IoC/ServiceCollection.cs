using System;
using System.Collections.Generic;
using System.Net.Http.Headers;

namespace DesignPatterns.IoC
{
    public class ServiceCollection : IServiceCollection
    {
        private readonly List<ServiceDescriptor> _serviceDescriptors = new List<ServiceDescriptor>();


        public ServiceCollection()
        {
            
        }
        ServiceCollection(List<ServiceDescriptor> serviceDescriptors)
        {
            _serviceDescriptors = serviceDescriptors;
        }
        public IServiceCollection AddTransient<T>()
        {
            _serviceDescriptors.Add(new ServiceDescriptor(typeof(T), LifeTime.Transient));
            return new ServiceCollection(_serviceDescriptors);
        }

        public IServiceCollection AddTransient<T>(Func<T> factory)
        {
            _serviceDescriptors.Add(new ServiceDescriptor(factory.Invoke().GetType(), LifeTime.Transient));
            return new ServiceCollection(_serviceDescriptors);

        }

        public IServiceCollection AddTransient<T>(Func<IServiceProvider, T> factory)
        {
            _serviceDescriptors.Add(new ServiceDescriptor(factory.Invoke(new DiProvider(_serviceDescriptors)).GetType(), LifeTime.Transient));
            return new ServiceCollection(_serviceDescriptors);
        }

        public IServiceCollection AddSingleton<T>()
        {
            
            _serviceDescriptors.Add(new ServiceDescriptor(typeof(T), LifeTime.Singleton));
            return new ServiceCollection(_serviceDescriptors);
        }

        public IServiceCollection AddSingleton<T>(T service)
        {
            _serviceDescriptors.Add(new ServiceDescriptor(service, LifeTime.Singleton));
            return new ServiceCollection(_serviceDescriptors);
        }

        public IServiceCollection AddSingleton<T>(Func<T> factory)
        {
            _serviceDescriptors.Add(new ServiceDescriptor(factory.Invoke(), LifeTime.Singleton));
            return new ServiceCollection(_serviceDescriptors);
        }

        public IServiceCollection AddSingleton<T>(Func<IServiceProvider, T> factory)
        {
            _serviceDescriptors.Add(new ServiceDescriptor(factory.Invoke(new DiProvider(_serviceDescriptors)), LifeTime.Singleton));
            return new ServiceCollection(_serviceDescriptors);
        }

        public IServiceProvider BuildServiceProvider()
        {
            return new DiProvider(_serviceDescriptors);
        }
    }
}