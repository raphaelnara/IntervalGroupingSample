using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using MyApi.Data.Repositories;
using MyApi.Data.Repositories.Interfaces;

namespace MyApi
{
    public class Bootstrapper : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IOperationRepository>()
                     .ImplementedBy<OperationRepository>()
                     .LifestyleSingleton());
        }
    }
}