using MS.ServerRoleAuthorization.Contracts;
using System.Diagnostics.Contracts;
using Unity;
using Unity.Injection;

namespace MS.ServerRoleAuthorization
{
    /// <summary>
    /// Register rules to validate auth.
    /// </summary>
    public static class RegisterRules
    {
        /// <summary>
        /// Setup SetupConfiguration
        /// </summary>
        /// <param name="configurationOptions"></param>
        public static void SetupConfiguration(ConfigurationOptions configurationOptions)
        {
            Contract.Requires(configurationOptions != null, $"Parameter {nameof(configurationOptions)} must be not null {configurationOptions}.");
            Contract.Requires(configurationOptions.ConfigData != null, $"Parameter {nameof(configurationOptions.ConfigData)} must be not null {configurationOptions.ConfigData}.");
            Contract.Requires(configurationOptions.Container != null, $"Parameter {nameof(configurationOptions.Container)} must be not null {configurationOptions.Container}.");

            configurationOptions.Container.RegisterSingleton<ISetupConfigurations, DefaultSetupConfigurations>(new InjectionConstructor(configurationOptions));
            configurationOptions.Container.RegisterSingleton<IRuleHandler, RuleHandler>();
            configurationOptions.Container.RegisterSingleton<IRuleEngine, RuleEngine>();
            configurationOptions.Container.RegisterSingleton<IValidator, RoleValidator>();
        }
    }
}