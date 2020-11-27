using Unity;

namespace MS.ServerRoleAuthorization.Contracts
{
    /// <summary>
    /// Defines set of configurations to setup role based authorization.
    /// </summary>
    public class ConfigurationOptions
    {
        /// <summary>
        /// Setup up role based authorization.
        /// </summary>
        /// <param name="container">The unity container to register dependencies.</param>
        /// <param name="configData">The serialized configuration data.</param>
        public ConfigurationOptions(IUnityContainer container, string configData)
        {
            this.ConfigData = configData;
            this.Container = container;
        }

        /// <summary>
        /// Setup up role based authorization with ignore case mode.
        /// </summary>
        /// <remarks>
        /// role1 == Role1 = ROLE1 if set with 'true'.
        /// </remarks>
        /// <param name="enableIgnoreCaseMode">Set to true for ignore case.</param>
        /// <returns></returns>
        public ConfigurationOptions WithIgnoreCaseMode(bool enableIgnoreCaseMode)
        {
            var option = Clone(this);
            option.EnableIgnoreCaseMode = enableIgnoreCaseMode;

            return option;
        }

        /// <summary>
        /// Container to register the dependencies.
        /// </summary>
        public IUnityContainer Container { get; private set; }

        /// <summary>
        /// Role based configurations.
        /// </summary>
        public string ConfigData { get; private set; }

        /// <summary>
        /// True, if perform ignore case.
        /// </summary>
        public bool EnableIgnoreCaseMode { get; private set; } = true;

        private ConfigurationOptions Clone(ConfigurationOptions source)
        {
            return new ConfigurationOptions(source.Container, source.ConfigData)
            {
                EnableIgnoreCaseMode = source.EnableIgnoreCaseMode
            };
        }
    }
}