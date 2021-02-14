using System;

namespace DesignPatterns.IoC
{
    public class ServiceDescriptor
    {
        public Type ServiceType { get; }
        public object Implementation { get; internal set; }
        public LifeTime LifeTime {get;}

        public ServiceDescriptor(object implementation, LifeTime lifeTime)
        {
            ServiceType = implementation.GetType();
            Implementation = implementation;
            LifeTime = lifeTime;
        }
        public ServiceDescriptor(Type serviceType, LifeTime lifeTime)
        {
            ServiceType = serviceType;
            LifeTime = lifeTime;
        }
        
       

    }
}