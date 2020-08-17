using MS.ServerRoleAuthorization.Contracts;
using Unity;
using Unity.Injection;

namespace MS.ServerRoleAuthorization.FunctionalTests
{
    public class TestContainer
    {
        public TestContainer(string configData)
        {
            Container = new UnityContainer();
            this.RegisterServerRoleComponents(configData);
        }

        private void RegisterServerRoleComponents(string configData)
        {
            var options = new ConfigurationOptions(configData)
                .WithIgnoreCaseMode(true);
            Container.RegisterType<ISetupConfigurations, DefaultSetupConfigurations>(new InjectionConstructor(options));
            Container.RegisterType<IRuleHandler, RuleHandler>();
            Container.RegisterType<IRuleEngine, RuleEngine>();
            Container.RegisterType<IValidator, RoleValidator>();
        }

        public UnityContainer Container { get; }
    }
}