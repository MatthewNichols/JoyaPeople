using System.Configuration;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using JoyaPeople.Domain.Interfaces;
using JoyaPeople.Persistence.Repositories;

namespace JoyaPeople.Persistence
{
    public class RepositoryInstaller: IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["joyaPeopleMongo"].ConnectionString;
            container.Register(
                Component.For<IMemberRepository>()
                    .ImplementedBy<MemberRepository>()
                    .DependsOn(Dependency.OnConfigValue("connectionString", connectionString))
                );
        }
    }
}
