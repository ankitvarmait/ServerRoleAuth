using MS.ServerRoleAuthorization.Contracts;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;

namespace MS.ServerRoleAuthorization
{
    public class DefaultSetupConfigurations : ISetupConfigurations
    {
        private static List<RoleConfigurations> roleConfigurations { get; set; }
        private readonly ConfigurationOptions options;

        public DefaultSetupConfigurations(ConfigurationOptions options)
        {
            Contract.Requires(options != null, $"Parameter {nameof(options)} must be not null {options}.");

            this.LoadConfigurations(options.ConfigData);
            this.options = options;
        }

        private void LoadConfigurations(string configData)
        {
            roleConfigurations = JsonConvert.DeserializeObject<List<RoleConfigurations>>(configData);
        }

        public IEnumerable<RoleConfigurations> RoleConfigurationsByRole(string role)
        {
            return roleConfigurations.Where(config =>
                config.Roles.FirstOrDefault(roleConfigured =>
                    roleConfigured.Equals(role, options.EnableIgnoreCaseMode ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal) || roleConfigured.Equals(Constants.Asterisk, StringComparison.CurrentCulture)) != null);
        }

        public ConfigurationOptions ConfigurationOptions()
        {
            return this.options;
        }
    }
}